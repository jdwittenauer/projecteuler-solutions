using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerCSharp
{
    public class EulerProblemAttribute : Attribute
    {
        public EulerProblemAttribute(int problemNumber)
        {
            ProblemNumber = problemNumber;
        }

        public int ProblemNumber
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }
    }
}