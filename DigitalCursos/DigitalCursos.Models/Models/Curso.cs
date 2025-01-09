using System.Collections.ObjectModel;

namespace DigitalCursos.Models.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string CursoNome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime Inicio { get; set; }
        public decimal Preco { get; set; }
        public string Logo { get; set; }
        public Collection<Aluno> Alunos { get; set; }
    }
}