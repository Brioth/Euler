using System;
using System.Collections.Generic;
using System.Text;

namespace Euler.Models
{
    public class Problem : IEntity
    {
        public string Title { get; set; }
        public int EulerId { get; set; }
        public string Description { get; set; }
        public int Solution { get; set; }
        public bool Solved { get; set; }

        public override string ToString()
        {
            return String.Format(
                "EulerId: {1}{0}" +
                "Title: {2}{0}" +
                "Description: {3}{0}" +
                "Solution: {4}{0}" +
                "Solved: {5}{0}", Environment.NewLine, EulerId, Title, Description, Solution, Solved);
        }
    }
}
