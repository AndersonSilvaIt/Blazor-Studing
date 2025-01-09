using DigitalCursos.Api.Repositories;
using DigitalCursos.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCursos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController: ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAlunos()
        {
            try
            {
                var result = await _alunoRepository.GetAlunos();
                return Ok(result);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var result = await _alunoRepository.GetAluno(id);
                return Ok(result);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> GetAluno(Aluno aluno)
        {
            try
            {
                if(aluno == null)
                {
                    return BadRequest();
                }
                var createdAluno = await _alunoRepository.AddAluno(aluno);

                return CreatedAtAction(nameof(GetAluno), new { id = createdAluno.AlunoId }, createdAluno);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Aluno>> UpdateAluno(int id, Aluno aluno)
        {
            try
            {
                if(id != aluno.AlunoId)
                {
                    return BadRequest($"O aluno com id={id} não confere com o aluno a ser atualizado");
                }

                var alunoToUpdate = await _alunoRepository.GetAluno(id);

                if(alunoToUpdate == null)
                {
                    return NotFound($"Aluno com o id = {id} não encontrado");
                }

                return await _alunoRepository.UpdateAluno(aluno);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Aluno>> DleteAluno(int id)
        {
            try
            {
                var alunoToDelete = await _alunoRepository.GetAluno(id);
                if(alunoToDelete == null)
                {
                    return NotFound($"Aluno com o id = {id} não encontrado");
                }

                return await _alunoRepository.DeleteAluno(id);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

    }
}