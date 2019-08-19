pipeline {
	agent any 
	parameters{
		string(name: 'BUILD_PATH',defaultValue: 'WebApi.sln',description:'enter solution name')
		string(name: 'IMAGE_NAME',defaultValue: 'raguapiimage',description:'enter image name')
        string(name: 'USER_NAME',defaultValue: 'Enter dockerhub user name',description:'Enter dockerhub user name')
        password(name: 'PASSWORD',defaultValue: 'enter dockerhub Password',description:'enter dockerhub Password')
        string(name: 'TAG_NAME',defaultValue: 'Enter tag  name',description:'Enter tag  name')
	}
    stages {
        stage('Build') {
            steps {
		    powershell(script: 'dotnet build ${env:BUILD_PATH}.sln')
            powershell(script: "echo Building........")
            }
        }
	stage('Test') {
            steps {
                powershell(script: 'dotnet test')
                powershell(script: "echo Testing.......")
            }
        }
	stage('Publish') {
            steps {
                powershell(script: 'dotnet publish -c Release -o ../publish')
                powershell(script: "echo Testing..........")
            }
        }
        stage('zip'){
            steps{
                archiveArtifacts artifacts: 'publish/*.*', fingerprint: true
            }
        }
        stage('Build Docker')
        {
            steps{
                powershell(script: 'docker build -t ${env:IMAGE_NAME} ./WebApi')
            }
        }
        stage('Login to Docker'){
            steps{
                powershell(script: 'docker login -u ${env:USER_NAME} -p ${env:PASSWORD}');
            }
        }
        stage('Create TagName'){
            steps{
                powershell(script: 'docker tag ${env:IMAGE_NAME}:latest imra35/ragu-api:${env:TAG_NAME}')
            }
        }
        stage('Pushing Image to Docker'){
            steps{
                powershell(script: 'docker push imra35/ragu_api:${env:TAG_NAME}')
            }
        }
	
    }
    
}
