<h1 align="center">Hyperativa WEB API</h1>

<h2 align="center">Construção</h2>
    Principais frameworks/bibliotecas utilizados no projeto
<!--ts-->
   * [.NET 5](#https://dotnet.microsoft.com/download/dotnet/5.0)
   * [Swagger](#https://swagger.io/)
   * [Entity Framework Core](#https://docs.microsoft.com/pt-br/ef/)
   * [JWT Token](#https://jwt.io/)    
<!--te-->

<h2 align="center">Clone</h2>

```
C:\>git clone https://github.com/DouglasFam/Hyperativa-Project.git
```

<h2 align="center">Executar</h2>
Abra o projeto com o Visual Studio 19.
aponte o Gerenciador de pacotes para a aplicação Hyperativa.Data
execute o script:

```
update-database
```
Defina o <b>Hyperativa.App</b> como projeto principal e Pressione F5.


<h2 align="center">Database</h2>
A ConnectionString está setada para o localdb.


```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Hyperativadb;Trusted_Connection=True;MultipleActiveResultSets=True"
```

<h2 align="center">Insert User Token</h2>
Insira no banco um usuário para gerar o token

```
INSERT INTO [dbo].[HPRTV_Users]
           ([Id]
           ,[Username]
           ,[Password]
           ,[Access])
     VALUES
           ('291e3c9c-27aa-40dc-b57b-bbb75529b07f'
           ,'userteste'
           ,'senhateste'
           ,'teste')
```           

<h2 align="center">Consumingo a API</h2>
Após executar o projeto, irá abrir a página 

``` 
https://localhost/swagger/index.html
``` 

Acesse o Endpoint <b>/v1/account/login</b>
Adicione o usuario e senha que foi inserido no banco HPRTV_Users e execute

```  
{
  "id": 0,
  "username": "userteste",
  "password": "senhateste",
  "role": "string"
}
``` 

Irá gerar o Token Bearer. Copie o Código, vá em Authorize e adicione o token.
Após autenticação do token, a API está liberada para ser consumida.



