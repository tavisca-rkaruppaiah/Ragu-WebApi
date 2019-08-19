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
		stage('Test') {
            		steps {
                		powershell('dotnet test')
                		powershell("echo Testing.......")
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
                		powershell('docker tag ${env:IMAGE_NAME}:latest imra35/ragu_api:${env:TAG_NAME}')
            		}
        	}
        	stage('Pushing Image to Docker'){
            		steps{
                		powershell('docker push imra35/ragu_api:${env:TAG_NAME}')
            		}
        	}
	
    }
    
}
