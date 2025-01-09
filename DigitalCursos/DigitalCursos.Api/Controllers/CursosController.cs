using DigitalCursos.Api.Repositories;
using DigitalCursos.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCursos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController: ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursosController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCursos()
        {
            try
            {
                var result = await _cursoRepository.GetCursos();
                return Ok(result);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            try
            {
                var result = await _cursoRepository.GetCurso(id);
                return Ok(result);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> GetCurso(Curso curso)
        {
            try
            {
                if(curso == null)
                {
                    return BadRequest();
                }
                var createdCurso = await _cursoRepository.AddCurso(curso);

                return CreatedAtAction(nameof(GetCurso), new { id = createdCurso.CursoId }, createdCurso);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Curso>> UpdateCurso(int id, Curso curso)
        {
            try
            {
                if(id != curso.CursoId)
                {
                    return BadRequest($"O curso com id={id} não confere com o curso a ser atualizado");
                }

                var cursoToUpdate = await _cursoRepository.GetCurso(id);

                if(cursoToUpdate == null)
                {
                    return NotFound($"Curso com o id = {id} não encontrado");
                }

                return await _cursoRepository.UpdateCurso(curso);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Curso>> DleteCurso(int id)
        {
            try
            {
                var cursoToDelete = await _cursoRepository.GetCurso(id);
                if(cursoToDelete == null)
                {
                    return NotFound($"Curso com o id = {id} não encontrado");
                }

                return await _cursoRepository.DeleteCurso(id);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

    }
}