using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBiblioteca
{
    public class Biblioteca
    {
        public List<Livro> livros = new List<Livro>();
        public List<Usuario> usuarios = new List<Usuario>();
        public List<Emprestimo> emprestimos = new List<Emprestimo>();

        public void cadastrarLivro()
        {
            Livro novoLivro = new Livro();
            if (livros.Count == 0)
                novoLivro.id = 1;
            else
                novoLivro.id = livros.Max(q => q.id) + 1;

            
            Console.WriteLine("---------- Adicionando novo Livro ----------");
            
            Console.Write("\nDigite o nome do Autor: ");
            novoLivro.autor = Console.ReadLine();
            Console.Write("Digite o Título da Obra: ");
            novoLivro.titulo = Console.ReadLine();
            Console.Write("Digite a edição do volume: ");
            novoLivro.edicao = Console.ReadLine();
            Console.Write("Digite o ano de publicação: ");
            novoLivro.anoPublicacao = int.Parse(Console.ReadLine());
            Console.Clear();

            
            Console.WriteLine(" -------- Informações de Localização --------");
            
            Console.Write("\nDigite o número do corredor: ");
            novoLivro.corredor = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da estante: ");
            novoLivro.estante = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da prateleira: ");
            novoLivro.prateleira = int.Parse(Console.ReadLine());

            livros.Add(novoLivro);
            
            Console.WriteLine("\nNovo Livro adicionado com sucesso!\n");
            
            Console.WriteLine("Pressione qualquer tecla para retornar ao Menu...");
            Console.ReadKey();
        }

        public void cadastrarNovoUsuario()
        {
            Usuario novoUsuario = new Usuario();
            if (usuarios.Count == 0)
                novoUsuario.id = 1;
            else
                novoUsuario.id = usuarios.Max(q => q.id) + 1;

            
            Console.WriteLine("---------- Cadastrando novo Usuário ----------");
            

            Console.Write("Digite o nome do usuário: ");
            novoUsuario.nome = Console.ReadLine();
            Console.Write("Digite o telefone: ");
            novoUsuario.telefone = Console.ReadLine();
            Console.Write("Digite o endereço: ");
            novoUsuario.endereco = Console.ReadLine();
            Console.Write("Digite o e-mail: ");
            novoUsuario.email = Console.ReadLine();

            novoUsuario.banido = false;

            usuarios.Add(novoUsuario);
            
            Console.WriteLine("\nNovo usuário cadastrado com sucesso!\n");
            
            Console.WriteLine("Pressione qualquer tecla para retornar ao Menu...");
            Console.ReadKey();
        }

        private Livro selecionarLivro()
        {
            Console.Clear();
            Console.WriteLine("---------- Selecionar Livro ----------");

            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                Console.WriteLine("Pressione qualquer tecla para retornar ao Menu...");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine("Livros disponíveis para empréstimo:");
            foreach (var livro in livros.Where(l => l.disponivel))
            {
                Console.WriteLine($"ID: {livro.id}, Título: {livro.titulo}, Autor: {livro.autor}");
            }

            Console.Write("\nDigite o ID do livro que deseja emprestar: ");
            if (int.TryParse(Console.ReadLine(), out int idLivro))
            {
                var livroSelecionado = livros.FirstOrDefault(l => l.id == idLivro && l.disponivel);
                if (livroSelecionado != null)
                {
                    return livroSelecionado;
                }
            }

            Console.WriteLine("Livro não encontrado ou indisponível. Pressione qualquer tecla para retornar ao Menu...");
            Console.ReadKey();
            return null;
        }

        private Usuario selecionarUsuario()
        {
            Console.Clear();
            Console.WriteLine("---------- Selecionar Usuário ----------");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                Console.WriteLine("Pressione qualquer tecla para retornar ao Menu...");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine("Usuários disponíveis:");
            foreach (var usuario in usuarios.Where(u => !u.banido))
            {
                Console.WriteLine($"ID: {usuario.id}, Nome: {usuario.nome}, E-mail: {usuario.email}");
            }

            Console.Write("\nDigite o ID do usuário que pegará o livro emprestado: ");
            if (int.TryParse(Console.ReadLine(), out int idUsuario))
            {
                var usuarioSelecionado = usuarios.FirstOrDefault(u => u.id == idUsuario && !u.banido);
                if (usuarioSelecionado != null)
                {
                    return usuarioSelecionado;
                }
            }

            Console.WriteLine("Usuário não encontrado ou banido. Pressione qualquer tecla para retornar ao Menu...");
            Console.ReadKey();
            return null;
        }

        public void emprestarLivro()
        {
            Livro livro = selecionarLivro();
            if (livro == null) return;

            Usuario usuario = selecionarUsuario();
            if (usuario == null) return;

            Emprestimo novoEmprestimo = new Emprestimo();
            if (emprestimos.Count == 0)
                novoEmprestimo.id = 1;
            else
                novoEmprestimo.id = emprestimos.Max(q => q.id) + 1;

            novoEmprestimo.idLivro = livro.id;
            novoEmprestimo.idUsuario = usuario.id;
            livro.disponivel = false;
            novoEmprestimo.devolvido = false;
            novoEmprestimo.dataDevolucao = DateTime.Now.AddDays(3);

            emprestimos.Add(novoEmprestimo);
           
            Console.WriteLine("\nLivro emprestado com sucesso!\n");
            
            Console.WriteLine("Pressione qualquer tecla para retornar ao Menu...");
            Console.ReadKey();
        }
    }
}