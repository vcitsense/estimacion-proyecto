pipeline {
    agent any

    stages {
        stage('Clonar Código') {
            steps {
                git branch: 'master', url: 'https://github.com/vcitsense/estimacion-proyecto.git'
            }
        }

        stage('Compilar') {
            steps {
                script {
                    echo 'Compilando código...'
                }
            }
        }

        stage('Publicar Aplicación') {
            steps {
                script {
                    echo 'Publicando aplicación...'
                }
            }
        }

        stage('Desplegar en IIS') {
            steps {
                script {
                    echo 'Desplegando en IIS...'

                }
            }
        }
    }

    post {
        success {
            echo 'Despliegue exitoso.'
        }
        failure {
            echo 'El despliegue ha fallado.'
        }
    }
}
