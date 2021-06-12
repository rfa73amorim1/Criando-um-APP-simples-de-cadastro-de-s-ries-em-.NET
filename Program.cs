using System;
using System.Threading;



namespace MenuSeries
{
    class Program
    {
        static RepSerie repositorio = new RepSerie();
		
     
	 
        static void Main(string[] args)
        {
			
			
			Console.Clear();	
			Console.WriteLine();					
			Console.Write("Olá, digite seu nome: ");
			string nome = Console.ReadLine();
			Console.WriteLine($"Seja bem vindo ao Menu de Séries, {nome}!");
			int espera = 1000;
			Thread.Sleep(espera);
			

			

            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "S")
		
			{
				switch (opcaoUsuario )
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
							Console.WriteLine ($"Serie excluída com sucesso!");
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException("Opção inválida, inicie novamente");
						
						//Melhorias: retornar ao menu em caso de opção inválida 
					
						
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("Obrigado e até breve!!");
			Console.ReadKey();
			Console.Clear();
			
        }

        private static void ExcluirSerie()
		{
			Console.Write("\nDigite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
		

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("\nDigite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);
			
			Console.WriteLine(serie);
		

		}

        private static void AtualizarSerie()
		{
			Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());			
			//Melhorias: inserir uma condicional para verificar se o Id informado existe

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
			Console.Clear();
			
		}
        private static void ListarSeries()
		{
			Console.WriteLine("\nListar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
			
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("\nInserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("\nDigite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());
			//Melhorias: validar a entrada do "Ano"

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();
			Console.Clear();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			
			Console.WriteLine();	
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("S- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		
		}
    }

