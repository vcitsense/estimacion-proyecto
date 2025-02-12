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
                    // Agrega aquí el comando para compilar tu proyecto
                    // Por ejemplo, para .NET Core:
                    sh 'dotnet build'
                }
            }
        }

        stage('Ejecutar Pruebas') {
            steps {
                script {
                    echo 'Ejecutando pruebas...'
                    // Ejecutar pruebas unitarias si las tienes
                    // sh 'dotnet test'
                }
            }
        }

        stage('Desplegar en IIS') {
            steps {
                script {
                    echo 'Desplegando en IIS...'
                    // Aquí agregas los comandos para copiar los archivos a IIS
                    // Por ejemplo, si usas PowerShell:
                    // powershell 'Copy-Item -Path "ruta/origen" -Destination "C:\inetpub\wwwroot\miapp" -Recurse -Force'
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
