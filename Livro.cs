namespace SistemaBiblioteca
{
    public class Livro : Entidade
    {
        public string titulo { get; set; } = "Novo Livro";
        public string autor { get; set; } = "";
        public string edicao { get; set; } = "";
        public int anoPublicacao { get; set; } = 0;
        public int corredor { get; set; } = 0;
        public int estante { get; set; } = 0;
        public int prateleira { get; set; } = 0;
        public bool disponivel { get; set; } = true;
    }
}