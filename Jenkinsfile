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

                    // Copiar SOLO los archivos del frontend evitando otros directorios
                    powershell '''
                    $source = "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\pipeline-release\\frontend\\proyectos-frontend\\dist\\proyectos-frontend\\browser"
                    $destination = "C:\\Users\\Administrator\\Documents\\Sites\\TestProyect\\Front"
					
                    # Crear el destino si no existe
                    if (!(Test-Path $destination)) {
                        New-Item -ItemType Directory -Path $destination -Force
                    }

                    # Eliminar archivos anteriores en el destino
                    Get-ChildItem -Path $destination -Recurse | Remove-Item -Force -Recurse

                    # Copiar solo los archivos del frontend
                    Copy-Item -Path "$source\\*" -Destination $destination -Recurse -Force

                    echo "Archivos copiados correctamente a $destination"
                    '''
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
