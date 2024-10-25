namespace SistemaBiblioteca
{
    public class Usuario : Entidade
    {
        public string nome { get; set; } = "Novo Usuário";
        public string telefone { get; set; } = "";
        public string endereco { get; set; } = "";
        public string email { get; set; } = "";
        public bool banido { get; set; } = false;

        public Usuario selecionarUsuario(List<Usuario> usuarios)
        {
            Console.Clear();
            ConsoleUtils.WriteTitle("Selecione Um Usuário");
            Console.Write("\n");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não existem usuários cadastrados no sistema!");
                Console.ReadKey();
                return null;
            }

            int indice = 0;
            Usuario usuario = usuarios[indice];

            while (true)
            {
                Console.Clear();
                ConsoleUtils.WriteTitle("Selecione Um Usuário");
                Console.Write("\n");

                Console.WriteLine($"ID: {usuario.id}");
                Console.WriteLine($"Nome: {usuario.nome}");
                Console.WriteLine($"Telefone: {usuario.telefone}");
                Console.WriteLine($"Endereço: {usuario.endereco}");
                Console.WriteLine($"E-mail: {usuario.email}");
                Console.WriteLine($"Banido: {(usuario.banido ? "Sim" : "Não")}\n");

                Console.WriteLine("Pressione as Setas <--> para selecionar outro usuário");
                Console.WriteLine("Pressione Enter para confirmar a seleção e voltar");

                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.LeftArrow) { indice--; }
                if (input.Key == ConsoleKey.RightArrow) { indice++; }
                if (input.Key == ConsoleKey.Enter) { break; }

                try { usuario = usuarios[indice]; }
                catch
                {
                    indice = 0;
                    usuario = usuarios[indice];
                }
            }

            return usuario;
        }
    }
}