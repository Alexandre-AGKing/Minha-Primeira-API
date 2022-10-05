using Microsoft.AspNetCore.Mvc;
using SG_Aluno.Models;

namespace SG_Aluno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public static List<Aluno> Alunos = new List<Aluno>();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(new AlunoServices().Listar());
        }
        [HttpPost]
        public IActionResult Adicionar(Aluno aluno)
        {
            new AlunoServices().Adicionar(aluno);
            return Ok(aluno.Sucesso);
        }
        [HttpGet("{id}")]
        public IActionResult Consultar(int id)
        {

            return Ok(new AlunoServices().Consultar(new Aluno() { ID = id }));
        }
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Aluno aluno)
        {
            aluno.ID = id;
            return Ok(new AlunoServices().Alterar(aluno));
        }
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            return Ok(new AlunoServices().Eliminar(new Aluno() { ID = id }));
        }
    }
}