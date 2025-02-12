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
                    // Copiar los archivos al directorio de destino
                    powershell '''
                    $source = "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\pipeline-release"
                    $destination = "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\pipeline-release\\frontend\\proyectos-frontend\\dist\\proyectos-frontend\\browser"

                    # Eliminar archivos existentes en destino
                    Remove-Item -Path $destination\\* -Recurse -Force -ErrorAction SilentlyContinue

                    # Copiar archivos al destino
                    Copy-Item -Path "$source\\*" -Destination $destination -Recurse -Force
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
