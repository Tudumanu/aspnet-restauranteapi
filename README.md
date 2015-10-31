# A C# ASP.NET Web API 2 for a simple restaurant management with localDB

## Configura��es

Projeto com o CORS habilitado, verifique a configura��o em *App_Start/WebApiConfig.cs*

### Dicas Package Manager Console

* Para habilitar mudan�as no BD, use `Enable-Migrations -ContextProjectName WebAPIServices`
 ** Isso ir� criar o Migrations/Configuration.cs, altere o `AutomaticMigrationsEnabled` para `true`
* Para alterar o BD, dentro do Console, digite: `Update-Database -Verbose` (-Force para for�ar altera��o que possa perder dados)

#### Fontes de pesquisa:

* **Aulas MVC e os fundamentos do ASP.NET**: http://odetocode.com/about/pluralsight
* **Acessar a API via controller**: http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client