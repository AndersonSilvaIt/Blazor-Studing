using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
    public class AlunoService: IAlunoService
    {
        private readonly HttpClient _httpClient;

        public AlunoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            var alunos = await _httpClient.GetFromJsonAsync<IEnumerable<Aluno>>("api/Alunos");
            return alunos;
        }

        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = await _httpClient.GetFromJsonAsync<Aluno>($"api/Alunos/{id}");
            return aluno;
        }

        public async Task<Aluno> CreateAluno(Aluno novoAluno)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Alunos", novoAluno);
            var content = await response.Content.ReadFromJsonAsync<Aluno>();

            return content;
        }

        public async Task<Aluno> UpdateAluno(Aluno atualizaAluno)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Alunos/{atualizaAluno.AlunoId}", atualizaAluno);
            var content = await response.Content.ReadFromJsonAsync<Aluno>();

            return content;
        }

        public async Task DeleteAluno(int id)
        {
            await _httpClient.DeleteAsync($"api/Alunos/{id}");
        }
    }
}
