using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    [Serializable]
    class Wordclass
    {
        private string word;
        private string definition;
        private List<string> word_translation_list;
        private List<string> word_synonyms_list;

        public string Word { get => word; set => word = value; }
        public string Definition { get => definition; set => definition = value; }
        public List<string> Word_translation_list { get => word_translation_list; set => word_translation_list = value; }
        public List<string> Word_synonyms_list { get => word_synonyms_list; set => word_synonyms_list = value; }

        public Wordclass(string word, string definition, List<string> word_translation, List<string> word_synonyms)
        {
            this.Word = word;
            this.Definition = definition;
            this.Word_translation_list = word_translation;
            this.Word_synonyms_list = word_synonyms;
        }

        public Wordclass()
        {
            Word_translation_list = new List<string>();
            Word_synonyms_list = new List<string>();
        }

        public bool Translation_Print()
        {
            bool check = false;
            Console.Clear();
            Console.WriteLine("\t\tTranslations:");
            for (int i = 0; i < Word_translation_list.Count; i++)
            {
                check = true;
                Console.WriteLine("\t\t"+ (i+1) + "." + Word_translation_list[i]);
            }

            return check;
        }
    }
}
