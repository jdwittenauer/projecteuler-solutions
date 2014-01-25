using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;
using Extensions;

namespace ProjectEulerCSharp
{
    class Execute
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Project Euler problem solver.");

            var solversMetaData = EulerProblemMetadata.GetProblemSolvers().ToList();

            if (!solversMetaData.Any())
            {
                Console.WriteLine("There are no problems available to solve");
                Console.ReadLine();
                return;
            }

            do
            {
                Console.WriteLine("Which problem would you like to solve?");

                var chosenSolver = GetSolver(solversMetaData);
                SolveProblem(chosenSolver);

                Console.WriteLine("Would you like to solve another? (y/n)");
            } while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        private static void SolveProblem(EulerProblemMetadata chosenSolver)
        {
            Console.WriteLine(string.Format("Solving problem {0}: {1}", chosenSolver.Number, chosenSolver.Title));
            object instance = Activator.CreateInstance(chosenSolver.Class);

            Stopwatch timer = new Stopwatch();
            long answer = 0;

            timer.Start();
            answer = (long)chosenSolver.Method.Invoke(instance, new object[] { });
            timer.Stop();

            double time = timer.ElapsedMilliseconds / 1000;

            Console.WriteLine(string.Format("Answer is {0}; took {1} seconds", answer, time));
        }

        private static EulerProblemMetadata GetSolver(IList<EulerProblemMetadata> solversMetaData)
        {
            var chosenSolver =
                Console.In.ReadLines()
                .Validate(input => input.IsInteger(), "Please type in a number")
                .Select(input => int.Parse(input))
                .Validate(problemNumber => solversMetaData.Any(metaData => metaData.Number == problemNumber), "That problem number wasn't recognised")
                .Select(problemNumber => solversMetaData.First(metaData => metaData.Number == problemNumber))
                .First();

            return chosenSolver;
        }
    }
}
