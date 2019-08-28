pipeline {
    agent any 
    parameters{
        string(name: 'SOLUTION_NAME', defaultValue: '', description: 'enter solution name')
        string(name: 'DLL_NAME', defaultValue: '', description: 'Enter dll filename')
        string(name: 'IMAGE_NAME', defaultValue: '', description:'enter image name')
        string(name: 'USER_NAME', defaultValue: 'username', description:'Enter dockerhub user name')
        string(name: 'TAG_NAME', defaultValue: 'Enter tag  name', description:'Enter tag  name')
        string(name: 'PORT', defaultValue: '1234', description:'Which Port You want to run')
    }
        stages {
            stage('Build') {
                    steps {
                        powershell("echo Building........")
                        powershell('dotnet build ${env:SOLUTION_NAME}.sln')
                        powershell("echo Build Completed")
                    }
            }
            stage('Test') {
                steps {
                    powershell("echo Testing ....")
                    powershell('dotnet test')
                    powershell("echo Tested")
                }
            }
            stage('Publish') {
                steps {
                    powershell("echo Publishing ... ")
                    powershell('dotnet publish -c Release -o ../publish')
                    powershell("echo Published")
                }
            }
            stage('Build Docker'){
                steps{
                        powershell('echo building docker ...')
                        powershell('docker build -t ${env:IMAGE_NAME} --build-arg DLL_FILE=${env:DLL_NAME} .')
                        powershell('echo dll name passed')
                }
            }
            stage('Create TagName'){
                steps{
                        powershell("echo Creating TagName....")
                        powershell('docker tag ${env:IMAGE_NAME}:latest ${env:USER_NAME}/${env:IMAGE_NAME}:${env:TAG_NAME}')
                        powershell("echo TagName Created.")
                        powershell("echo Pushing to docker")
                     withCredentials([usernamePassword(credentialsId: 'docker', usernameVariable: 'username',  passwordVariable: 'password')]) {                    
                        powershell ( 'echo Docker login')
                        bat ( 'docker login -u %username% -p %password%' )
                        powershell('docker push ${env:USER_NAME}/${env:IMAGE_NAME}:${env:TAG_NAME}')
                        powershell("echo Successfully Pushed")
                    }   
                        
                }
            }
            stage('Pull') {
                steps {
                    powershell('echo project pulling')
                    powershell('docker pull ${env:USER_NAME}/${env:IMAGE_NAME}:${env:TAG_NAME}')
                    powershell("echo Successfully Pull")
                }
            }
            stage('Run') {
                steps {
                    powershell('echo Job Trying to run')
                    powershell('docker run -p ${env:PORT}:80 ${env:USER_NAME}/${env:IMAGE_NAME}:${env:TAG_NAME}')
                    powershell("echo Job Running....")
                }
            }    
    }
    
}
