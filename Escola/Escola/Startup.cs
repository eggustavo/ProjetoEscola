using System.Web.Http;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Escola
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Criando um HttpConfiguration, para que seja possível configuramos o retorno da API
            var config = new HttpConfiguration();

            //Removendo o retorno no formado XML, ficando assim, somente o retorno em JSON (Javascript Object Notation)
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Removendo o recurso do retorno dos objetos JSON serem por referência (Somente quando as classes possuírem relacionamentos)
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            //Removendo o recurso do retorno dos objetos JSON serem por loop (Somente quando as classes possuírem relacionamentos)
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //Fazendo com que o objeto JSON fique formatado, ou seja, identado.
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            //Fazendo com que as propriedades do objeto JSON, sejam retornas no padrão CamelCase, ou seja, 
            //a primeira palavra em minúsculo e as primeiras das demais em maíusculo. Exemplo: cursoId
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Habilitado as rotas no HttpConfiguraton (config)
            config.MapHttpAttributeRoutes();

            //Permitir que o acesso seja feito por qualquer endereço IP
            app.UseCors(CorsOptions.AllowAll);

            //Configurando o Swagger para documentação da API
            SwaggerConfig.Register(config);

            //Startar o WebApi, passando as configurações feitas no config
            app.UseWebApi(config);
        }
    }
}
