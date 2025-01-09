using DigitalCursos.Api.Context;
using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.Api.Repositories
{
    public class CursoRepository: ICursoRepository
    {
        private readonly AppDbContext _context;
        public CursoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Curso> AddCurso(Curso curso)
        {
            var result = await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Curso> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.CursoId == id);
            if(curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                return curso;
            }

            return null;
        }

        public async Task<Curso> GetAlunosCurso(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Curso> GetCurso(int id)
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(c => c.CursoId == id);
            return curso;
        }

        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return await _context.Cursos.AsNoTracking().ToListAsync();
        }

        public async Task<Curso> UpdateCurso(Curso curso)
        {
            /*var result = await _context.Cursos.FirstOrDefaultAsync(c => c.CursoId == curso.CursoId);
            if(result != null)
            {
                result.Nome = curso.Nome;
                result.Sobrenome = curso.Sobrenome;
                result.Email = curso.Email;
                result.Nascimento = curso.Nascimento;
                result.Foto = curso.Foto;
                result.Genero = curso.Genero;
                result.CursoId = curso.CursoId;

                await _context.SaveChangesAsync();
                return result;
            }*/

            return null;
        }
    }
}
