using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_History
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepoCompany repoCompany = new RepoCompany();
            TestClass testClass=new TestClass(repoCompany);
            testClass.Run();
            Console.ReadKey();
        }
    }
}
