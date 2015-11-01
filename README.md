# A C# ASP.NET Web API 2 for a simple restaurant management with localDB

Projeto com o CORS habilitado, verifique a configuração em *App_Start/WebApiConfig.cs*

 Para executar esta aplicação, é necessário descompactar a pasta Bin na raiz do projeto. A pasta pode ser obtida neste link: https://drive.google.com/file/d/0B3EhAlFCLZLgVHpmUUk2WXcyRFU/view?usp=sharing

Principais arquivos criados:

* Models/ > Garcom.cs, Pedido.cs, Restaurante.cs
* Controllers/ > GarcomController.cs, PedidoController.cs, RestauranteController.cs e RelatorioController.cs

### Dicas Package Manager Console

* Para habilitar mudanças no BD, use `Enable-Migrations -ContextProjectName WebAPIServices`
  * Isso irá criar o Migrations/Configuration.cs, altere o `AutomaticMigrationsEnabled` para `true`
* Para alterar o BD, dentro do Console, digite: `Update-Database -Verbose` (-Force para forçar alteração que possa perder dados)

#### Fontes de pesquisa:

* **Aulas MVC e os fundamentos do ASP.NET**: http://odetocode.com/about/pluralsight
* **Acessar a API via controller**: http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
