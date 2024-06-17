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

# Prestador
## Registrar Prestador

### Request
`POST v1/provider/register`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/register

### Body

    {
      "name": "string",
      "emailAddress": "string",
      "phone": "string",
      "password": "string",
      "cnpj": "string"
    }
    
### Response

    {
      "success": true,
      "message": "Prestador criado com sucesso",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "name": Luis,
                "Email": luis@gmail.com,
                "Cnpj": 12345678978451,
                "Phone": 11939510202,
                "UrlImage": null
                }"
    }

## Logar Prestador

### Request
`Post v1/provider/login`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/login


### Body

    {
      "cnpj": "string",
      "password": "string"
    }
    
### Response

    {
      "success": true,
      "message": "Prestador Logado com sucesso",
      "data": "{
                "Token": eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc,
                }"
    }

## Perfil do Prestador

### Request
`GET v1/provider/my-profile`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"
    
### Response

    {
      "success": true,
      "message": "Sucesso ao retornar prestador",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "Name": luis,
                "Email": luis@email.com,
                "Phone": 11939510202,
                "UrlImmage": https://image.com,
                "Cnpj": 12345678945124
                }"
    }

## Lista de Prestadores

### Request
`GET v1/providers/list`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/providers/list
    
### Response

    {
      "success": true,
      "message": "Sucesso ao retornar prestadores",
      "data":    
                [    
                    {
                        "Name": luis,
                        "Email": luis@email.com,
                        "Phone": 11939510202,
                    },
                    {
                        "Name": luis2,
                        "Email": luis2@email.com,
                        "Phone": 11939510205,
                    }
                    
                ]
    }

## Prestadores por nome

### Request
`GET v1/providers/list/{name}`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/providers/list/{name}
    
### Response

    {
      "success": true,
      "message": "Sucesso ao retornar prestadores",
      "data":    
                [    
                    {
                        "Name": luis,
                        "Email": luis@email.com,
                        "Phone": 11939510202,
                    },
                    {
                        "Name": luis2,
                        "Email": luis2@email.com,
                        "Phone": 11939510205,
                    }
                    
                ]
    }

## Atualizar Url

### Request
`PUT v1/provider/my-profile/update-url`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/update-url
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"


### Body

    {
      "url": "string",
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
### Response

    {
      "success": true,
      "message": "Url Atualizada com sucesso",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "Name": luis,
                "Email": luis@email.com,
                "Phone": 11939510202,
                "UrlImmage": https://image.com,
                "Cnpj": 12345678945124
                }"
    }

## Atualizar Url

### Request
`PUT v1/provider/my-profile/add-address`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/add-address
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"


### Body

    {
      "street": "string",
      "district": "string",
      "state": "string",
      "number": 0,
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
### Response

    {
      "success": true,
      "message": "Endereço adicionado com sucesso",
      "data": "{
                "Id": d7fa6f2d-f6ba-4757-a637-75d97a809184,
                "Name": luis,
                "Cnpj": 12345678945124,
                "Street": rua das alamedas,
                "District": vila matilde,
                "State": São Paulo,
                "Number": 10,
                "Complement": null
                }"
    }

## Criar Serviço

### Request
`PUT v1/provider/my-profile/services/create-service`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/services/create-service
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"


### Body

    {
      "title": "string",
      "category": 0,
      "description": "string",
      "amount": 0,
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
### Response

    {
      "success": true,
      "message": "Serviço criado com sucesso",
      "data": "{
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Manutencao,
                "Amount": 200,
                }"
    }

# Endereço
## Atualizar Endereço

### Request
`PUT v1/provider/my-profile/address`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/address
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Body

    {
      "street": "string",
      "district": "string",
      "state": "string",
      "number": 0,
      "addressId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "providerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
### Response

    {
      "success": true,
      "message": "Endereço atualizado com sucesso",
      "data": "{
                "AddressId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "Street": Rua das camelitas,
                "District": Vila madalena,
                "State": São Paulo,
                "Number": 1055,
                "Complement": null
                }"
    }

## Adicionar Complemento

### Request
`PUT v1/provider/my-profile/address/add-complement`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/address/add-complement
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Body

    {
      "complement": bloco 3,
      "addressId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "providerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
### Response

    {
      "success": true,
      "message": "Complemento atualizado com sucesso!",
      "data": "{
                "AddressId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "Street": Rua das camelitas,
                "District": Vila madalena,
                "State": São Paulo,
                "Number": 1055,
                "Complement": bloco 3
                }"
    }

## Visualizar Endereço

### Request
`GET v1/provider/my-profile/address`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/address
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Response

    {
      "success": true,
      "message": "Endereço encontrado",
      "data": "{
                "AddressId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "Street": Rua das camelitas,
                "District": Vila madalena,
                "State": São Paulo,
                "Number": 1055,
                "Complement": bloco 3
                }"
    }

# Serviço
## Lista de serviços

### Request
`GET v1/services`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/services
    
### Response

    {
      "success": true,
      "message": "Lista de serviços",
      "data": "{
                "Id": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ProviderName": Luis,
                "Email": luis@gmail.com,
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Limpeza,
                "Amount": 200
                }"
    }

## Serviços por nome de prestador

### Request
`GET v1/services/provider-name/{name}`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/services/provider-name/{name}
    
### Response

    {
      "success": true,
      "message": "Lista de serviços",
      "data": "{
                "Id": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ProviderName": Luis,
                "Email": luis@gmail.com,
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Limpeza,
                "Amount": 200
                }"
    }

## Serviços por titulo

### Request
`GET v1/services/title/{title}`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/services/title/{title}
    
### Response

    {
      "success": true,
      "message": "Lista de serviços",
      "data": "{
                "Id": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ProviderName": Luis,
                "Email": luis@gmail.com,
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Limpeza,
                "Amount": 200
                }"
    }

## Serviços por categoria

### Request
`GET v1/services/category/{category}`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/services/category/{category}
    
### Response

    {
      "success": true,
      "message": "Lista de serviços",
      "data": "{
                "Id": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ProviderName": Luis,
                "Email": luis@gmail.com,
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Limpeza,
                "Amount": 200
                }"
    }

## Serviços por valor minimo e máximo

### Request
`GET v1/services/amount/min={minimum}&max={maximum}`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/services/category/{category}
    
### Response

    {
      "success": true,
      "message": "Lista de serviços",
      "data": "{
                "Id": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ProviderName": Luis,
                "Email": luis@gmail.com,
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Limpeza,
                "Amount": 200
                }"
    }

## Serviços de prestadores

### Request
`GET v1/provider/my-profile/services`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/services
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"
    
### Response

    {
      "success": true,
      "message": "Lista de serviços",
      "data": "{
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Limpeza,
                "Amount": 200
                }"
    }

## Serviço por Id

### Request
`GET v1/service/{serviceId}`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/service/{serviceId}
    
### Response

    {
      "success": true,
      "message": "Serviço encontrado",
      "data": "{
                "Id": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ProviderName": Luis,
                "Email": luis@gmail.com,
                "Title": Cascavel Ti,
                "Description": Apenas uma descrição válida para testes,
                "Category": Limpeza,
                "Amount": 200
                }"
    }

## Criar contrato

### Request
`PUT v1/service/create-hire`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/service/create-hire
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Body

    {
      "clientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "date": "2024-06-17T18:00:15.064Z",
      "serviceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "providerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
### Response

    {
      "success": true,
      "message": "Contrato criado com sucesso",
      "data": "{
                "ClientId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ServiceId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ServiceTitle": Cascavel Ti,
                "Date": 11:05:2001,
                "IsActive": true,
                "ServiceAmount": 200
                }"
    }

# Contrato
## Cancelar contrato

### Request
`PUT v1/client/my-profile/hires/cancel-hire`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/client/my-profile/hires/cancel-hire
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Body

    {
      "serviceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "clientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    
### Response

    {
      "success": true,
      "message": "Atualizado com sucesso",
      "data": "{
                "Id": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "Date": 11:05:2001,
                "IsActive": true,
                }"
    }

## Contratos ativos de clientes

### Request
`GET v1/client/my-profile/hires`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/client/my-profile/hires
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Response

    {
      "success": true,
      "message": "Atualizado com sucesso",
      "data": "{
                "ServiceId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ClientId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "ServiceTitle": Cascavel Ti,
                "ServiceAmount": 200,
                "Date": 11:05:2001,
                "IsActive": true,
                }"
    }

## Contratos ativos de serviços

### Request
`GET v1/provider/my-profile/service/{serviceId}/hires`

    curl -i -H 'Accept: application/json' http://localhost:7091/v1/provider/my-profile/service/{serviceId}/hires
    Authorization (Bearer Token): "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImQ3ZmE2ZjJkLWY2YmEtNDc1Ny1hNjM3LTc1ZDk3YTgwOTE4NCIsInJvbGUiOiJjbGllbnRlIiwibmJmIjoxNzE4MzE5MjcyLCJleHAiOjE3MTgzNDgwNzIsImlhdCI6MTcxODMxOTI3Mn0.dOTXfTQIqTNczrA3GOA9KlV9D1C8fjvu3blHNaESGpc"

### Response

    {
      "success": true,
      "message": "Atualizado com sucesso",
      "data": "{
                "ClientId": 3fa85f64-5717-4562-b3fc-2c963f66afa6,
                "clientEmail": lucas.apalosqui@gmail.com,
                "ClientName": Lucas Apalosqui,
                "HireDate": 11:05:2001,
                "HireIsActive": true,
                }"
    }
