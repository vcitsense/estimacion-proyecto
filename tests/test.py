import pytest
import requests
import logging

# Configurar logging
logging.basicConfig(level=logging.INFO, format="%(asctime)s - %(levelname)s - %(message)s")

base_url = "http://52.205.206.106:9905/api/Proyecto/"

# Lista de las rutas de las APIs a probar
apis = [
    "ConsultarEntidades",
    "ConsultarProyectosPorEntidad?idEntidad=1",
    "ConsultarModulosPorProyecto?idProyecto=1",
    "ConsultarHistoriasUsuario?idModulo=1"
]

@pytest.mark.parametrize("api_url", apis)
def test_api(api_url):
    """ Prueba cada endpoint verificando el código de respuesta HTTP """
    url = f"{base_url}{api_url}"
    logging.info(f"Probando API: {url}")

    try:
        response = requests.get(url)
        logging.info(f"Respuesta [{response.status_code}]: {response.text[:200]}")  # Muestra solo los primeros 200 caracteres

        assert response.status_code == 200, f"Error en {url}: Código {response.status_code}"
    
    except requests.exceptions.RequestException as e:
        pytest.fail(f"Error de conexión a {url}: {str(e)}")
