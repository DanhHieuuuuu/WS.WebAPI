pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'docker build -t my-app .'
            }
        }
        stage('Deploy') {
            steps {
                sh 'docker run -d -p 6000:8080 my-app'
            }
        }
    }
}