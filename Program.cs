namespace SistemaBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                
                Console.WriteLine("---------- Bem vindo à biblioteca ----------");
               
                Console.WriteLine("1.  Cadastrar Novo Livro"); //funcional
                Console.WriteLine("2.  Dar baixa como perdido");
                Console.WriteLine("3.  Dar baixa como destruido");
                Console.WriteLine("4.  Atualizar dados do livro");
                Console.WriteLine("5.  Novo Usuário"); //funcional
                Console.WriteLine("6.  Atualizar Cadastro");
                Console.WriteLine("7.  Banir Usuário");
                Console.WriteLine("8.  Emprestar Livro"); //funcional
                Console.WriteLine("9.  Devolver Livro");
                Console.WriteLine("10. Sair\n"); //funcional
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        biblioteca.cadastrarLivro();
                        break;
                    case "5":
                        Console.Clear();
                        biblioteca.cadastrarNovoUsuario();
                        break;
                    case "8":
                        Console.Clear();
                        biblioteca.emprestarLivro();
                        break;
                    case "10":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }
    }
}