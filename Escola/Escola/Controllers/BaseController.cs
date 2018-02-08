using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Escola.Controllers
{
    public class BaseController : ApiController
    {
        protected List<string> Notificacoes;

        public BaseController()
        {
            Notificacoes = new List<string>();
        }

        protected HttpResponseMessage CriarResposta(HttpStatusCode codigoHttp, object dados = null)
        {
            return Request.CreateResponse(codigoHttp, new
            {
                Sucesso = Notificacoes.Count == 0,
                Dados = dados,
                Notificacoes = Notificacoes.ToArray()
            });
        }
    }
}
