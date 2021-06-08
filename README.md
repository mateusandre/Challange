# Challange
## Desafio Softplan

Dependências

* .Net Core 3.1
* Swashbuckle.AspNetCore (6.1.4)
* Docker
* Docker-Compose

## Documentação
Após clonar o projeto abra o terminal a partir da pasta raiz e execute o comando "docker-compose up" para subir os containers das API's

## As API's estarão disponíveis nos endereços:

**API de Cálculo de Juros**: http://localhost:501

**API de Taxa de Juros**: http://localhost:502

Ao abrir os endereços acima será exibido a documentação do Swagger da respectiva API.

Solução ao Desafio
Utilizado princípios de DDD, SOLID, Orientação a objetos, Injeção de dependência.

## Como executar os testes:
Execute os códigos a partir da pasta raiz do projeto

* **Unitários**: *dotnet test tests/UnitTests*

* **Integração**: *dotnet test tests/IntegrationTests*
