using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename = args[0];
            try
            {
                Splitter billSplit = new Splitter(filename);
                billSplit.GenerateOutputFile();
            }
            catch (Exception exp) {
                Console.Write(exp.ToString());
            }
            
        }
    }
}
