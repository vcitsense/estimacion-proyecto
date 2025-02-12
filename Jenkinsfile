pipeline {
    agent any

    tools {
        nodejs "NodeJS 18"
    }

    stages {
        stage('Clonar Código') {
            steps {
                git branch: 'master', url: 'https://github.com/vcitsense/estimacion-proyecto.git'
            }
        }

        stage('Instalar Dependencias') {
            steps {
                script {
                    echo 'Instalando dependencias...'
                    dir('frontend/proyectos-frontend') {
                        bat 'npm install'
                    }
                }
            }
        }

        stage('Compilar Frontend') {
            steps {
                script {
                    echo 'Compilando Angular...'
                    dir('frontend/proyectos-frontend') {
                        bat 'npx ng build --configuration production'
                    }
                }
            }
        }

        stage('Desplegar en IIS') {
            steps {
                script {
                    echo 'Desplegando en IIS...'

                    // Guardamos el script de PowerShell en un archivo temporal
                    writeFile file: 'deploy.ps1', text: '''
                        $source = "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\pipeline-release\\frontend\\proyectos-frontend\\dist\\proyectos-frontend\\browser"
                        $destination = "C:\\Users\\Administrator\\Documents\\Sites\\TestProyect\\Front"

                        # Crear el destino si no existe
      
