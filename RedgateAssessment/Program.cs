using RedGateTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedgateAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new SimpleCharacterReader();
            var analizer = new WordFrequencyAnalizer(reader);

            var list = analizer.Analize();
            list.ForEach(wf => Console.WriteLine(wf.ToString()));

            Console.ReadKey();
        }
    }
}
