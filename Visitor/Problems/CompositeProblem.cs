using System;
using System.Collections.Generic;
using System.Linq;
using ResultsCombiners;
using Solvers;

namespace Problems
{
    class CompositeProblem : Problem
    {
        private readonly IEnumerable<Problem> problems;
        private readonly IResultsCombiner resultsCombiner;

        public CompositeProblem(string name, IEnumerable<Problem> problems,
            IResultsCombiner resultsCombiner) : base(name, () => 0)
        {
            this.problems = problems;
            this.resultsCombiner = resultsCombiner;
        }

        public override bool tryBeSolved(ISolver problemSolver)
        {
            List<int> results = new List<int>();

            foreach (var problem in problems)
            {
                if (problem.Solved == true)
                {
                    Console.WriteLine("There is nothing to do. Problem {0} already has been solved.", problem.Name);
                }
                else
                {
                    if(problem.tryBeSolved(problemSolver))
                    {
                        results.Add((int)problem.Result);
                    }          
                }
            }

            foreach (var problem in problems)
            {
                if (problem.Solved != true)
                    return false;
            }

            IResultsCombiner resultcombiner = new SumResultsCombiner();
            this.TryMarkAsSolved(resultsCombiner.CombineResults(results));
            return true;

        }
    }
}