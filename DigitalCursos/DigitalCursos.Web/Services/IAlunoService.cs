using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<Aluno> UpdateAluno(Aluno atualizaAluno);
        Task<Aluno> CreateAluno(Aluno novoAluno);
        Task DeleteAluno(int id);
    }
}