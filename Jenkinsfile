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
		
		stage('Ejecutar Pruebas') {
			steps {
				script {
					echo 'Ejecutando pruebas con pytest...'
					dir('tests') {  // Asegúrate de que esta sea la ruta correcta de test.py
						bat 'pytest test.py --junitxml=test_results.xml'
					}
				}
			}
		}

		stage('Publicar Resultados de Pruebas') {
			steps {
				script {
					echo 'Publicando resultados de pruebas en Jenkins...'
				}
				junit 'tests/test_results.xml'  // Asegúrate de que el path sea correcto
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
