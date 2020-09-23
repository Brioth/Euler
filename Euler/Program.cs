using Euler.Data;
using Euler.Models;
using System;

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
                        Exit();
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
                        SolveProblem();
                        break;
                    default:
                        Console.WriteLine("invalid commands, type 'Help' to view valid commands");
                        break;
                }
            }            
        }

        private static void Exit()
        {
            Console.WriteLine("Do you want to save?");
            var save = ProcessYN();
            if (save) _uow.Save();
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
                SolveProblem(problem);
            }
            else
            {
                return;
            }

            _uow.Save();
        }

        private static void SolveProblem()
        {
            Console.WriteLine("Which problem do you want to solve?");
            var eulerId = Convert.ToInt32(Console.ReadLine());

            Problem problem = _uow.Problems.GetByEulerId(eulerId);
            SolveProblem(problem);
        }

        private static void SolveProblem(Problem problem)
        {
            Console.WriteLine("Please insert parameters");
            var input = GetInput();
            problem.Solution = _solver.Solve(problem, input);
            Console.WriteLine(String.Format("The solution is {0}", problem.Solution));

            Console.WriteLine("Mark problem as completed?");
            problem.Solved = ProcessYN();
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
