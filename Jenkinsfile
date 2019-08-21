pipeline {
    agent any 
    parameters{
        string(name: 'BUILD_PATH',defaultValue: '',description:'enter solution name')
        string(name: 'IMAGE_NAME',defaultValue: '',description:'enter image name')
        string(name: 'USER_NAME',defaultValue: 'username',description:'Enter dockerhub user name')
        password(name: 'PASSWORD',defaultValue: 'password',description:'enter dockerhub Password')
        string(name: 'TAG_NAME',defaultValue: 'Enter tag  name',description:'Enter tag  name')
    }
        stages {
            stage('Build') {
                    steps {
                    powershell('dotnet build ${env:BUILD_PATH}.sln')
                        powershell("echo Building........")
                    }
            }
            stage('Sonaqube Begin'){
                steps{
                    powershell( 'dotnet C:/Users/rkaruppaiah/Downloads/sonar-scanner-msbuild-4.6.2.2108-netcoreapp2.0/SonarScanner.MSBuild.dll begin /k:"WebApi" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="72275f1554693b285a63b0619970566c500cb5ef"')
                }
            }
        stage('Test') {
                    steps {
                        powershell('dotnet test')
                        powershell("echo Testing.......")
                    }
            }
            stage('Sonaqube End'){
                steps{
                    powershell( 'dotnet C:/Users/rkaruppaiah/Downloads/sonar-scanner-msbuild-4.6.2.2108-netcoreapp2.0/SonarScanner.MSBuild.dll end /d:sonar.login="72275f1554693b285a63b0619970566c500cb5ef"')
                }
            }
        stage('Publish') {
                    steps {
                        powershell('dotnet publish -c Release -o ../publish')
                        powershell( "echo Testing..........")
                    }
            }
            stage('Zip the Project'){
                    steps{
                        archiveArtifacts artifacts: 'publish/*.*', fingerprint: true
                    }
            }
            stage('Build Docker'){
                    steps{
                        powershell('docker build -t ${env:IMAGE_NAME} .')
                    }
            }
            stage('Login to Docker'){
                    steps{
                        powershell('docker login -u ${env:USER_NAME} -p ${env:PASSWORD}');
                    }
            }
            stage('Create TagName'){
                    steps{
                        powershell('docker tag ${env:IMAGE_NAME}:latest imra35/${env:IMAGE_NAME}:${env:TAG_NAME}')
                    }
            }
            stage('Pushing Image to Docker'){
                    steps{
                        powershell('docker push imra35/${env:IMAGE_NAME}:${env:TAG_NAME}')
                    }
            }
    
    }
    
}