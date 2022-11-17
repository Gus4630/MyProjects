using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PROJECT
{
    [Serializable]
    class TestQuiz
    {
        Dictionary d;

        public TestQuiz(Dictionary d)
        {
            this.d = d;
        }

        public bool Quiz()
        {
            Console.WriteLine("Please Translate the following words...\n");
            string input;

            for (int i = 0; i < d.words_list.Count && i <= 10; i++)
            {
                Console.WriteLine(d.words_list[i].Word);
                Console.Write("Please write translation: ");
                input = Console.ReadLine();
                Console.WriteLine();
                if (!d.words_list[i].Word_translation_list.Contains(input))
                {
                    Console.Clear();
                    Thread.Sleep(2000);
                    Console.WriteLine("You failed the test. You are not permitted to edit.");
                    
                    return false;
                }
                Console.WriteLine("Correct!");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.Clear();
            Thread.Sleep(2000);
            Console.WriteLine("You successfully passed the test! You are enabled to edit the words");

            return true;
        }

    }
}
