<h3>Projeto de estudo com .net core 3.0</h3>

Requisitos:

    dotnet core 3.1
    dotnet-tool dotnet ef ou visual studio
    docker

Para rodar:

    git clone <url>
    
    Docker-compose:
        -Trocar ${SQL_PASSWORD} por senha para o SqlServer
        -Trocar ${REDIS_PASSWORD} por senha para o redis

    obs: As senhas podem ser trocadas por um arquivo .env carregando as secrets
    https://medium.com/better-programming/using-variables-in-docker-compose-265a604c2006

    cd webApi
    
    DotnetSecrets:
        dotne user-secrets init
        dotnet user-secrets set "SECRETY_DATABASE" "{senha configurada no container do sqlserver}"
        dotnet user-secrets set "REDIS_SECRETY_DATABASE" "{senha do redis}"
        dotnet user-secrets set "JWT_KEY" "{chave de criptografia do token jwt}"

    Migrations:
        dotnet ef database update

	dotnet run

    testar em https://localhost:5001/swagger/index.html

Controle de roles:

    Por default todo usuario criado em /api/auth/register tem a role "USER", para incluir, 
    excluir e modificar a aplicação é preciso a role "ADMIN" que pode ser criada 
    em POST "api/v1/administration/role?role=ADMIN" e inserida no usuario no 
    PUT "api/v1/administration/role"
