using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Escola.Context;
using Escola.Domain;

namespace Escola.Controllers
{
    public class CursoController : BaseController
    {
        private readonly EscolaContext _context = new EscolaContext();

        [HttpGet]
        [Route("api/v1/curso")]
        public HttpResponseMessage ListarTodos()
        {
            return CriarResposta(HttpStatusCode.OK, _context.CursoSet.ToList());
        }

        [HttpGet]
        [Route("api/v1/curso/{cursoId}")]
        public HttpResponseMessage ListarPorId(int cursoId)
        {
            return CriarResposta(HttpStatusCode.OK, _context.CursoSet.Find(cursoId));
        }

        [HttpPost]
        [Route("api/v1/curso")]
        public HttpResponseMessage AdicionarOuAtualizar(Curso curso)
        {
            //Validando se o objeto curso recebido não é nulo
            if (curso == null)
            {
                Notificacoes.Add("Curso não Informado.");
                return CriarResposta(HttpStatusCode.BadRequest);
            }

            //Validando se o Nome do curso não é Nulo, Vazio ou se tem mais de 100 caracteres
            if (string.IsNullOrEmpty(curso.Nome))
                Notificacoes.Add("Nome Obrigatório.");
            else
            {
                if (curso.Nome.Length > 100)
                    Notificacoes.Add("Nome deve ter no máximo 100 caracteres");
            }

            //Validando se a Duração do curso não é Nula, Vazia ou se tem mais de 50 caracteres
            if (string.IsNullOrEmpty(curso.Duracao))
                Notificacoes.Add("Nome Obrigatório.");
            else
            {
                if (curso.Duracao.Length > 50)
                    Notificacoes.Add("Duração deve ter no máximo 50 caracteres");
            }

            //Validando se o Período do curso não é Nula, Vazia ou se tem mais de 5 caracteres
            if (string.IsNullOrEmpty(curso.Periodo))
                Notificacoes.Add("Período Obrigatório.");
            else
            {
                if (curso.Periodo.Length > 5)
                    Notificacoes.Add("Período deve ter no máximo 50 caracteres");
            }

            //Se tiver erros retorna os erros e não adiciona ou altera o curso
            if (Notificacoes.Count > 0)
                return CriarResposta(HttpStatusCode.BadRequest);

            //Salvando os dados
            _context.CursoSet.AddOrUpdate(curso);
            _context.SaveChanges();

            return CriarResposta(HttpStatusCode.Created, new
            {
                Mensagem = "Curso adicionado / alterado com sucesso."
            });
        }

        [HttpDelete]
        [Route("api/v1/curso/{cursoId}")]
        public HttpResponseMessage Remover(int cursoId)
        {
            //Localiza o curso pelo Id
            var curso = _context.CursoSet.Find(cursoId);

            //Se o curso não for localizado, retorna o erro
            if (curso == null)
            {
                Notificacoes.Add("Curso não Localizado.");
                return CriarResposta(HttpStatusCode.NotFound);
            }

            //Verifica se o curso possui alunos matriculados
            if (curso.AlunosMatriculadosNoCurso.Count > 0)
            {
                Notificacoes.Add("Curso não pode ser excluído, pois existem aluno(s) matriculado(s).");
                return CriarResposta(HttpStatusCode.BadRequest);
            }

            //Confirmando a Exclusão
            _context.CursoSet.Remove(curso);
            _context.SaveChanges();

            return CriarResposta(HttpStatusCode.OK, new
            {
                Mensagem = "Curso removido com sucesso."
            });
        }
    }
}
