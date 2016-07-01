///<summary>
///Created on 24.06.2016
/// @author Group 6
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBNF_Parser
{
    class Program
    {
     
        static void Main (string[] args)
        {
            var reader = new Reader(@"../expression.txt");
                
                ThreadPool.SetMaxThreads(3, 3);
                ThreadPool.SetMinThreads(3, 3);

                System.Threading.ThreadPool.QueueUserWorkItem(reader.parseDocument);

            Console.ReadKey();
        }

    }
}
