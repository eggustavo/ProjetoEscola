using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Escola.Context;
using Escola.Domain;

namespace Escola.Controllers
{
    public class AlunoController : BaseController
    {
        private readonly EscolaContext _context = new EscolaContext();

        [HttpGet]
        [Route("api/v1/aluno")]
        public HttpResponseMessage ListarTodos()
        {
            return CriarResposta(HttpStatusCode.OK, _context.AlunoSet.ToList());
        }

        [HttpGet]
        [Route("api/v1/aluno/{alunoId}")]
        public HttpResponseMessage ListarPorId(int alunoId)
        {
            return CriarResposta(HttpStatusCode.OK, _context.AlunoSet.Find(alunoId));
        }

        [HttpPost]
        [Route("api/v1/aluno")]
        public HttpResponseMessage AdicionarOuAtualizar(Aluno aluno)
        {
            //Validando se o objeto aluno recebido não é nulo
            if (aluno == null)
            {
                Notificacoes.Add("Aluno não Informado.");
                return CriarResposta(HttpStatusCode.BadRequest);
            }

            //Validando se o Nome do aluno não é Nulo, Vazio ou se tem mais de 100 caracteres
            if (string.IsNullOrEmpty(aluno.Nome))
                Notificacoes.Add("Nome Obrigatório.");
            else
            {
                if (aluno.Nome.Length > 100)
                    Notificacoes.Add("Nome deve ter no máximo 100 caracteres");
            }

            //Validando se o sexo do aluno não é Nulo ou Vazio
            if (string.IsNullOrEmpty(aluno.Sexo))
                Notificacoes.Add("Sexo Obrigatório.");

            //Localiza o curso pelo Id
            var curso = _context.CursoSet.Find(aluno.CursoId);

            //Se o curso não for localizado, retorna o erro
            if (curso == null)
                Notificacoes.Add("Curso não localizado.");

            //Se tiver erros retorna os erros e não adiciona ou altera o aluno
            if (Notificacoes.Count > 0)
                return CriarResposta(HttpStatusCode.BadRequest);

            //Setar o curso no aluno
            aluno.Curso = curso;

            //Salvando os dados
            _context.AlunoSet.AddOrUpdate(aluno);
            _context.SaveChanges();

            return CriarResposta(HttpStatusCode.Created, new
            {
                Mensagem = "Aluno adicionado / alterado com sucesso."
            });
        }

        [HttpDelete]
        [Route("api/v1/aluno/{alunoId}")]
        public HttpResponseMessage Remover(int alunoId)
        {
            //Localiza o aluno pelo Id
            var aluno = _context.AlunoSet.Find(alunoId);

            //Se o aluno não for localizado, retorna o erro
            if (aluno == null)
            {
                Notificacoes.Add("Aluno não Localizado.");
                return CriarResposta(HttpStatusCode.NotFound);
            }

            //Confirmando a Exclusão
            _context.AlunoSet.Remove(aluno);
            _context.SaveChanges();

            return CriarResposta(HttpStatusCode.OK, new
            {
                Mensagem = "Aluno removido com sucesso."
            });
        }
    }
}
