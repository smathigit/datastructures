using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresAndAlgorithms.Stacks;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            IVerifyProgram program = null;
            
            // Implement 2 stacks in an array
            program = new Implement2StacksInArray();
            program.VerifyProgram();
        }
    }
}
