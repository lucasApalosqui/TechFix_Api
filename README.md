# TechFix - APi
> Status: Versão 1.0 finalizada
## Descrição do projeto
Serviço de Api que conecta clientes e prestadores de serviços na área de manutenção de computadores, utilizando de pesquisas avançadas para que seja encontrado o melhor serviço para cada cliente
## Estrutura do projeto
O Projeto foi desenvolvido a partir de um modelo préviamente pensado e documentado, onde estão presentes as tabelas e relacionamentos que existirão em nosso banco de dados.
<a target="_blank" href="https://miro.com/welcomeonboard/TWpVZnVhaXU4Q3N3Sjdyd3lheTVKZlhGQ1VWT2pEUUhaaGxyNXFLb3J4Tmh5ekZoSlZKNGFnSXRTcEhydjhNdHwzNDU4NzY0NTM0MTkzNTY4MDczfDI=?share_link_id=426535122075">Diagrama Relacional<a>

## Rodar Aplicação
Na versão atual da aplicação "`1.0`" apenas utilizamos de um acesso local para rodar o app, criando um clone do repositório, instalando as dependencias, gerar uma `Migration` em um banco de dados local e com o auxilio de uma plataforma que genrencia APIs o App se torna totalmente funcional.

caso queira saber sobre os planos para as proximas atualizações vá para a sessão <a href="#atualizacoes">futuras implementações</a>

## Rodar Testes
Entre na pasta `TechFix.Domain.Tests` e rode o seguinte comando:

    Dotnet Test

# API Rest
Abaixo temos a documentação de cada requisição disponibilizada pela API

# Cliente
## Registrar Cliente

### Request
`POST v1/client/register`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/client/register

### Body

    {
      "name": "string",
      "lastName": "string",
      "emailAddress": "string",
      "password": "string"
    }

### Response

    {
      "success": true,
      "message": "Cliente criado com sucesso",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "FullName": Lucas Apalosqui,
                "Email": lucas.apalosqui@gmail.com
                }"
    }

## Logar Cliente

### Request
`POST v1/client/login`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/client/login

### Body

    {
      "emailAddress": "string",
      "password": "string"
    }

### Response

    {
      "success": true,
      "message": "Logado com sucesso",
      "data": "{
                "Token": eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc,
                }"
    }

## Atualizar Url da imagem

### Request
`PUT v1/client/my-profile/update-url`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/client/my-profile/update-url
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Body

    {
      "urlImage": "string",
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }

### Response

    {
      "success": true,
      "message": "Atualizado com sucesso",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "FullName": Lucas Apalosqui,
                "Email": lucas.apalosqui@gmail.com,
                "UrlImage": http://url.com
                }"
    }

## Adicionar Telefone

### Request
`PUT v1/client/my-profile/add-phone`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/client/my-profile/add-phone
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Body

    {
      "phone": "string",
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }

### Response

    {
      "success": true,
      "message": "Atualizado com sucesso",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "FullName": Lucas Apalosqui,
                "Email": lucas.apalosqui@gmail.com,
                "PhoneNumber": (11) 93951-0805
                }"
    }

## Visualizar Perfil

### Request
`GET v1/client/my-profile`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/client/my-profile
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Response

    {
      "success": true,
      "message": "Perfil Encontrado",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "FullName": Lucas Apalosqui,
                "Email": lucas.apalosqui@gmail.com,
                "UrlImage": http://image.com,
                "PhoneNumber": (11) 93951-0805,
                "Hires": []
                }"
    }
