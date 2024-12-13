pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat 'docker build -t my-app .'
            }
        }
        stage('Deploy') {
            steps {
                bat 'docker run -d -p 6000:8080 my-app'
            }
        }
    }
}