using Euler.Data;
using Euler.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Buffers;
using System.Linq;
using System.Linq.Expressions;

namespace Euler
{
    class Program
    {
        private static IUnitOfWork _uow;
        private static Solver _solver;

        static void Main(string[] args)
        {
            Initialize();

            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Please enter a command");
                var input = Console.ReadLine();

                switch (input)
                {
                    case nameof(Commands.Exit):
                        exit = true;
                        break;
                    case nameof(Commands.Help):
                        ShowHelp();
                        break;
                    case nameof(Commands.CreateProblem):
                        CreateProblem();
                        break;
                    case nameof(Commands.ShowProblem):
                        ShowProblem();
                        break;
                    case nameof(Commands.Solve):
                        throw new NotImplementedException();
                        break;
                    default:
                        Console.WriteLine("invalid commands, type 'Help' to view valid commands");
                        break;
                }
            }            
        }

        private static void Initialize()
        {
            //IConfiguration config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", true, true)
            //    .Build();

            _uow = new CsvUnitOfWork();
            _solver = new Solver();
        }

        private static void CreateProblem() {
            Problem problem = new Problem();

            Console.WriteLine("EulerId: ");
            problem.EulerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Title: ");
            problem.Title = Console.ReadLine();

            Console.WriteLine("Description: ");
            problem.Description = Console.ReadLine();

            ShowProblem(problem);
            Console.WriteLine("Add this problem?");
            var add = ProcessYN();
            if (add)
            {              
                _uow.Problems.Add(problem);
                _uow.Save();
                             
            } else
            {
                return;
            }

            Console.WriteLine("Solve this problem?");
            var solve = ProcessYN();
            if (solve)
            {
                Console.WriteLine("Please insert parameters");
                var input = GetInput();
                var output = _solver.Solve(problem, input);
                Console.WriteLine(output);
            } else
            {
                return;
            }

            Console.WriteLine("Mark problem as completed?");
            problem.Solved = ProcessYN();

            _uow.Save();
        }

        private static void ShowProblem()
        {
            Console.WriteLine("Provide id");
            var id = Convert.ToInt32(Console.ReadLine());
            ShowProblem(_uow.Problems.GetByEulerId(id));
        }

        private static void ShowProblem(Problem problem)
        {
            Console.WriteLine(problem);
        }

        private static void ShowHelp()
        {
            var commands = Enum.GetValues(typeof(Commands));
            Console.WriteLine("Possible commands: ");
            foreach (var command in commands)
            {
                Console.WriteLine(String.Format("- {0}", command));
            }
        }

        private static bool ProcessYN()
        {
            var input = Console.ReadLine().ToLower();

            return (input.Equals("y") || input.Equals("yes"));
        }

        private static int[] GetInput()
        {
            return Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
        }
    }
}
