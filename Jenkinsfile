pipeline {
  agent any 
  parameters{
    string(name: 'USER_NAME',defaultValue: 'username',description:'enter docker user name')
    password(name: 'PASSWORD',defaultValue: 'password',description:'enter dockerhub Password')
    string(name: 'REPOSITORY_NAME',defaultValue: 'repository name',description:'Enter dockerhub repository name')
    string(name: 'TAG_NAME',defaultValue: '',description:'Enter tag  name')
    string(name: 'PORT',defaultValue: 'Enter port  number',description:'Which port you want to run')
  }
  stages {
        stage('Login to Docker'){
            		steps{
                		powershell(script: 'docker login -u ${env:USER_NAME} -p ${env:PASSWORD}');
            		}
        	}
        stage('Pull from Docker') {
            steps {
                    powershell(script: 'docker pull ${env:USER_NAME}/${env:REPOSITORY_NAME}:${env:TAG_NAME}')
                    powershell(script: "echo pulling........")
              }
          } 
        stage('Run') {
            steps {
                    powershell(script: 'docker run -p ${env:PORT}:80 ${env:USER_NAME}/${env:REPOSITORY_NAME}:${env:TAG_NAME}')
                    powershell(script: "echo Running.......")
            }
        }
  
    }
    
}
