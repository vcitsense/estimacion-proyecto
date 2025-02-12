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

        stage('Instalar Dependencias Frontend') {
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

        stage('Compilar Backend .NET') {
            steps {
                script {
                    echo 'Compilando Backend .NET...'
                    dir('estimacion-proyecto') {
                        bat 'dotnet publish -c Release -r win-x64 --self-contained true -o publish_output'
                    }
                }
            }
        }

        stage('Preparar Despliegue') {
            steps {
                script {
                    echo 'Deteniendo IIS y limpiando espacio...'
                    powershell '''
                    # Detener IIS antes de eliminar archivos
                    Stop-Website -Name "TestProject"
                    Stop-Service -Name W3SVC

                    # Limpiar workspace de Jenkins
                    echo "Eliminando workspace de Jenkins..."
                    Remove-Item -Path "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\*" -Recurse -Force -ErrorAction SilentlyContinue

                    # Limpiar frontend y backend en el servidor
                    $destinationFront = "C:\\Users\\Administrator\\Documents\\Sites\\TestProyect\\Front"
                    $destinationBack = "C:\\Users\\Administrator\\Documents\\Sites\\TestProyect\\Back"

                    echo "Eliminando archivos previos en el frontend..."
                    if (Test-Path $destinationFront) {
                        Get-ChildItem -Path $destinationFront -Recurse | Remove-Item -Force -Recurse -ErrorAction SilentlyContinue
                    }

                    echo "Eliminando archivos previos en el backend..."
                    if (Test-Path $destinationBack) {
                        Get-ChildItem -Path $destinationBack -Recurse | Remove-Item -Force -Recurse -ErrorAction SilentlyContinue
                    }
                    '''
                }
            }
        }

        stage('Desplegar en IIS') {
            steps {
                script {
                    echo 'Desplegando en IIS...'

                    // Desplegar Frontend
                    powershell '''
                    $sourceFront = "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\pipeline-release\\frontend\\proyectos-frontend\\dist\\proyectos-frontend\\browser"
                    $destinationFront = "C:\\Users\\Administrator\\Documents\\Sites\\TestProyect\\Front"

                    if (!(Test-Path $destinationFront)) {
                        New-Item -ItemType Directory -Path $destinationFront -Force
                    }

                    Copy-Item -Path "$sourceFront\\*" -Destination $destinationFront -Recurse -Force
                    echo "Frontend desplegado correctamente en $destinationFront"
                    '''

                    // Desplegar Backend
                    powershell '''
                    $sourceBack = "C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\pipeline-release\\estimacion-proyecto\\publish_output"
                    $destinationBack = "C:\\Users\\Administrator\\Documents\\Sites\\TestProyect\\Back"

                    if (!(Test-Path $destinationBack)) {
                        New-Item -ItemType Directory -Path $destinationBack -Force
                    }

                    Copy-Item -Path "$sourceBack\\*" -Destination $destinationBack -Recurse -Force
                    echo "Backend desplegado correctamente en $destinationBack"
                    '''
                }
            }
        }

        stage('Reiniciar IIS') {
            steps {
                script {
                    echo 'Reiniciando IIS...'
                    powershell '''
                    Start-Service -Name W3SVC
                    Start-Website -Name "TestProject"
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
