namespace SistemaBiblioteca
{
    public class Emprestimo : Entidade
    {
        public int idLivro { get; set; }
        public int idUsuario { get; set; }
        public bool devolvido { get; set; } = false;
        public DateTime dataEmprestimo { get; set; } = DateTime.Now;
        public DateTime dataDevolucao { get; set; }
    }
}