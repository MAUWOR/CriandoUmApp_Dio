using System;
using Dio.Series.Classes;
namespace Dio.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {  
            string opcaoUsuario = ObterOpcaoUsuario();
            
                while (opcaoUsuario.ToUpper() !="X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                        ListaSerie();
                        break;
                        case "2":
                        InserirSerie();
                        break;
                        case "3":
                        AtualizarSerie();
                        break;
                        case "4":
                        ExcluirSerie();
                        break;
                        case "5":
                        VisualizarSerie();
                        break;
                        case "C":
                        LimpaTela();
                        ObterOpcaoUsuario();
                        break;
                  
                    default:
                    Console.WriteLine("");
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos sserviços.");
            Console.ReadLine();
        }
// Metodo Listar Série
                private static void ListaSerie()
        {
            Console.WriteLine("Lista Série");
            var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine( "Nenhuma Série Cadastrada");
            return;

        } 
        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();
            Console.WriteLine( "ID {0}: - {1} {2}", serie.retornaId(),serie.retornaTitulo(),(excluido?"*Excluido*":""));
        }      
    }
// Metodo Inserir Série
          private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série");
           
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                 Console.WriteLine("ID {0}-{1}",i, Enum.GetName(typeof(Genero),i)); 
            }
                 Console.WriteLine("Digite o Genero entre as opções acima:");
                 int entradaGenero = int.Parse(Console.ReadLine());
                 Console.WriteLine("Digite o titulo da Série:");
                 string entradaTitulo = Console.ReadLine();
                 Console.WriteLine("Digite o ano de inicio da Série:");   
                 int entradaAno = int.Parse(Console.ReadLine());
                 Console.WriteLine("Digite a descrição da Série:");
                 string entradaDescricao = Console.ReadLine();

                   Serie novaSerie = new Serie( id:repositorio.ProximoId(),
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                descricao: entradaDescricao,
                                                ano: entradaAno);
            
             repositorio.Insere(novaSerie);
        }
// Metodo Atualizar Série
         private static void AtualizarSerie()
        {
        
        Console.WriteLine("Digite o ID da Série:");
        int indiceSerie = int.Parse(Console.ReadLine());
        
        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
        }
            Console.WriteLine("Digite o Genero entre as opções acima:");
                 int entradaGenero = int.Parse(Console.ReadLine());
                 Console.WriteLine("Digite o titulo da Série:");
                 string entradaTitulo = Console.ReadLine();
                 Console.WriteLine("Digite o ano de inicio da Série:");   
                 int entradaAno = int.Parse(Console.ReadLine());
                 Console.WriteLine("Digite a descrição da Série:");
                 string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie( id:repositorio.ProximoId(),
                                                 genero: (Genero)entradaGenero,
                                                 titulo: entradaTitulo,
                                                 descricao: entradaDescricao,
                                                 ano: entradaAno);
                                                 
                 repositorio.Atualizar( indiceSerie,atualizaSerie);                                
        
       }
// Metodo Excluir Série
       private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui( indiceSerie);

        }
// Metodo Visualizar Série
        private static  void VisualizarSerie(){

        Console.WriteLine("Digite o id da Série");
        int indiceSerie = int.Parse(Console.ReadLine());
        var serie = repositorio.RetornaPorId(indiceSerie);
        Console.WriteLine(serie); 

        }
// Metodo Limpar Série
        private static void LimpaTela()
        {
            Console.WriteLine("Tem certeza que quer Limpa a tela: Y/N");
            string opcaoLimpaTela = Console.ReadLine();
            if( opcaoLimpaTela.ToUpper() == "Y"){

                 Console.Clear();   

            }if(opcaoLimpaTela.ToUpper()=="N"){

                Console.WriteLine("----");
            }else{
                Console.WriteLine("A resposta e Y ou N, mais tudo bem vamos proceguir");
                Console.WriteLine();
            }
            
        }
// Metodo Listar opção do usuário
        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine("Dio Série ao seu dispor!!!" );
            Console.WriteLine("Informe a opção desejada:" );
            
            Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        } 
    }
}
