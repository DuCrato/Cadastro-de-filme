using System;
using jogoDigitalIo.src.Classes;
using jogoDigitalIo.src.Enum;

namespace jogoDigitalIo
{
    class Program
    {
        static FilmRepository repository = new FilmRepository();

        static void Main(string[] args)
        {
            string userOption = getUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListFilm();
                        break;
                    case "2":
                        InsertFilm();
                        break;
                    case "3":
                        UpdateFilm();
                        break;
                    case "4":
                        DeleteFilm();
                        break;
                    case "5":
                        ViewFilm();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = getUserOption();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListFilm()
        {
           Console.WriteLine("Listar Filmes\n");

           var listFilm = repository.ListOfFilm();

           if (listFilm.Count == 0)
           {
               Console.WriteLine("Nenhum Filme Encontrado.\n");

               return;
           }

           foreach (var film in listFilm)
           {
               var excluided = film.ReturnExcluded();

               Console.WriteLine("#ID {0}: - {1} {2}", film.ReturnId(), film.ReturnTitle(), (excluided ? "*Excluido" : ""));
           }
        }

        private static void InsertFilm()
        {
            Console.WriteLine("Inserir novo filme\n");

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }
            
            Console.Write("\nDigite o gênero entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do filme: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int inputReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a discrição do filme: ");
            string inputDescription = Console.ReadLine();

            Film newFilm = new Film(id          : repository.NextId(),
                                    genderFilm  : (Gender)inputGender,
                                    title       : inputTitle,
                                    releaseYear : inputReleaseYear,
                                    description : inputDescription);

            repository.Insert(newFilm);
        }

        private static void UpdateFilm()
        {
            Console.Write("\nDigite o id do filme: ");

            int indexFilm = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.WriteLine("");

            Console.Write("\nDigite o gênero entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do filme: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int inputReleaseYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a discrição do filme: ");
            string inputDescription = Console.ReadLine();

            Film updateFilm = new Film(id          : repository.NextId(),
                                       genderFilm  : (Gender)inputGender,
                                       title       : inputTitle,
                                       releaseYear : inputReleaseYear,
                                       description : inputDescription);

            repository.Update(indexFilm,updateFilm);
        }

        private static void DeleteFilm()
        {
            Console.Write("\nDigite o id do filme: ");

            int indexFilm = int.Parse(Console.ReadLine());

            repository.Delete(indexFilm);
        }

        private static void ViewFilm()
        {
            Console.Write("\nDigite o id do filme: ");

            int indexFilm = int.Parse(Console.ReadLine());

            var film = repository.ReturnById(indexFilm);

            Console.WriteLine("");
            Console.WriteLine(film);
        }

        private static string getUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor!!!\n");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("\n1 - Listar filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return userOption;
        }
    }
}