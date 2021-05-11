using System;
using System.Collections.Generic;

namespace CadastroDeSeries
{
    class Program
    {
        static string opcao;
        static RepositorioSeries repositorioSeries = new RepositorioSeries(); 
        static void Main(string[] args)
        {
            // Este bloco de código adiciona algumas séries ao catálogo para efeitos de teste do programa
            Serie serieTeste1 = new Serie(
                0, "Breaking Bad", Categoria.Drama, 2008,
                "Walter White (Bryan Cranston) é um professor de química na casa dos 50 anos que trabalha em uma escola secundária no Novo México. Para atender às necessidades de Skyler (Anna Gunn), sua esposa grávida, e Walt Junior (RJ Mitte), seu filho deficiente físico, ele tem que trabalhar duplamente. Sua vida fica ainda mais complicada quando descobre que está sofrendo de um câncer de pulmão incurável. Para aumentar rapidamente a quantidade de dinheiro que deixaria para sua família após sua morte, Walter usa seu conhecimento de química para fazer e vender metanfetamina, uma droga sintética. Ele conta com a ajuda do ex-aluno e pequeno traficante Jesse (Aaron Paul) e enfrenta vários desafios, incluindo o fato de seu concunhado ser um importante nome dentro da Agência Anti-Drogas da região.",
                5
            );
            Serie serieTeste2 = new Serie(
                1, "Anne With An E", Categoria.Drama, 2017,
                "Depois de treze anos sofrendo no sistema de assistência social, a orfã Anne é mandada para morar com uma solteirona e seu irmão. Munida de sua imaginação e de seu intelecto, a pequena Anne vai transformar a vida de sua família adotiva e da cidade que lhe abrigou, lutando pela sua aceitação e pelo seu lugar no mundo.",
                3
            );
            Serie serieTeste3 = new Serie(
                2, "Stranger Things", Categoria.Suspense, 2016,
                "Em Stranger Things, quando Will (Noah Schnapp), um menino de 12 anos, desaparece misteriosamente, o xerife Jim Hopper (David Harbour) inicia uma operação para encontrá-lo. Enquanto isso, Mike (Finn Wolfhard), Dustin (Gaten Matarazzo) e Lucas (Caleb McLaughlin), melhores amigos de Will, decidem procurá-lo por conta própria. Mas as investigações acabam levando o grupo a experimentos secretos do governo e a uma peculiar menina perdida na floresta.",
                4
            );
            Serie serieTeste4 = new Serie(
                3, "Os Simpsons", Categoria.Comédia, 1989,
                "Uma animação sobre uma típica família de classe média americana. Homer é o pai nada saudável ou inteligente, que adora beber cerveja. Marge é a esposa e mãe dedicada. Bart é o filho de 10 anos, que não leva a escola a sério e tem orgulho disso. Lisa é a garota de oito anos, um gênio não apreciado. E Maggie é o bebê que não larga a chupeta.",
                34
            );
            repositorioSeries.Adicionar(serieTeste1);
            repositorioSeries.Adicionar(serieTeste2);
            repositorioSeries.Adicionar(serieTeste3);
            repositorioSeries.Adicionar(serieTeste4);
            //////////////////////////////////////
        mainLoop:
            Console.Clear();
            menu();
            switch (opcao)
            {
                case "1":
                    listarSeries();
                    Console.ReadKey();
                    break;
                case "2":
                    adicionarItem();
                    Console.ReadKey();
                    break;
                case "3":
                    listarSeries();
                    Console.WriteLine();
                    if (repositorioSeries.RetornarLista().Count == 0)
                    {
                        Console.ReadKey();
                        break;
                    }
                    Console.Write("Escolha um ID: ");
                    excluirItem(int.Parse(Console.ReadLine()));
                    Console.Clear();
                    Console.WriteLine("Item excluído com sucesso!");
                    Console.ReadKey();
                    break;
                case "4":
                    listarSeries();
                    Console.WriteLine();
                    if (repositorioSeries.RetornarLista().Count == 0)
                    {
                        Console.ReadKey();
                        break;
                    }
                    Console.Write("Escolha um ID: ");
                    recuperarItem(int.Parse(Console.ReadLine()));
                    Console.Clear();
                    Console.WriteLine("Item recuperado com sucesso!");
                    Console.ReadKey();
                    break;
                case "5":
                    listarSeries();
                    Console.WriteLine();
                    if (repositorioSeries.RetornarLista().Count == 0)
                    {
                        Console.ReadKey();
                        break;
                    }
                    Console.Write("Escolha um ID: ");
                    visualizarItem(int.Parse(Console.ReadLine()));
                    Console.ReadKey();
                    break;
                case "X":
                    Console.WriteLine();
                    Console.WriteLine("Até breve! :)");
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }

            Console.WriteLine();

        goto mainLoop;    
        }

        static void recuperarItem(int id)
        {
            Console.Clear();
            try
            {
                Serie serie = repositorioSeries.BuscarPorId(id);
            }
            catch
            {
                Console.WriteLine("ID inválido!");
                return;
            }
            repositorioSeries.Recuperar(id);
        }

        static void excluirItem(int id)
        {
            Console.Clear();
            try
            {
                Serie serie = repositorioSeries.BuscarPorId(id);
            }
            catch
            {
                Console.WriteLine("ID inválido!");
                return;
            }
            repositorioSeries.Excluir(id);
        }

        static void visualizarItem(int id)
        {
            Console.Clear();
            Serie serie;

            try
            {
                serie = repositorioSeries.BuscarPorId(id);
            }
            catch
            {
                Console.WriteLine("ID inválido!");
                return;
            }
            Console.Write(serie.nome);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine((serie.excluido) ? " *Excluído*" : "");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(serie.descricao);
            Console.WriteLine();
            Console.WriteLine($"- Temporadas: {serie.temporadas}");
            Console.WriteLine($"- Categoria: {serie.categoria}");
            Console.WriteLine($"- Ano: {serie.ano}");
        }

        static void listarSeries()
        {
            Console.Clear();
            Console.WriteLine("Catálogo");
            Console.WriteLine("---------");
            List<Serie> lista = repositorioSeries.RetornarLista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não há títulos cadastrados.");
                return;
            }

            foreach (Serie l in lista)
            {
                Console.Write($"# {l.id} - {l.nome} [{l.ano}]");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine((l.excluido) ? " *Excluído*" : "");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static string solicitarDado(string texto, bool pularLinha = true)
        {
            Console.Write(texto);
            if (pularLinha)
            {
                Console.WriteLine();
            }
            return Console.ReadLine();
        }

        static void adicionarItem()
        {
            Console.Clear();
            string nome = solicitarDado("Digite o nome do título: ");
            Console.Clear();
            string descricao = solicitarDado("Digite uma descrição: ");
            Console.Clear();
            Console.WriteLine("Escolha uma categoria:");
            var categorias = Enum.GetValues(typeof(Categoria));
            int index = 1;
            foreach (Categoria c in categorias)
            {
                Console.WriteLine("{0} - {1}", index, c);
                index++;
            }
            Console.Write("Opção: ");
            string categoriaEscolhida = Console.ReadLine();
            Categoria categoria = (Categoria)int.Parse(categoriaEscolhida);
            Console.Clear();
            int ano = int.Parse(solicitarDado("Digite o ano do título: "));
            Console.Clear();
            int temporadas = int.Parse(solicitarDado("Digite a quantidade de temporadas: "));
            int id = repositorioSeries.NovoId();
            Serie serie = new Serie(id, nome, categoria, ano, descricao, temporadas);
            repositorioSeries.Adicionar(serie);
            Console.Clear();
            visualizarItem(serie.id);
            Console.WriteLine();
            Console.WriteLine("Item adicionado com sucesso!");
        }

        static void menu()
        {
            Console.WriteLine("Menu inicial");
            Console.WriteLine("-------------");
            Console.WriteLine("[1] - Listar catálogo");
            Console.WriteLine("[2] - Cadastrar novo item");
            Console.WriteLine("[3] - Excluir item");
            Console.WriteLine("[4] - Recuperar item");
            Console.WriteLine("[5] - Visualizar item");
            Console.WriteLine("[X] - Sair");
            Console.Write("Opção: ");
            opcao = Console.ReadLine().ToUpper();
        }
    }
}
