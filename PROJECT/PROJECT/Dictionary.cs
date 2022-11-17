using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    [Serializable]
    class Dictionary
    {
        public List<Wordclass> words_list;
        public string dictionary_type;
        public int dictionary_size;
        public Person author;
        public Dictionary(List<Wordclass> w, string type, Person author)
        {
            this.words_list = w;
            this.dictionary_type = type;
            this.dictionary_size = w.Count;
            this.author = author;
        }
        public Dictionary()
        {
            words_list = new List<Wordclass>();
            dictionary_type = "Not Defined";
            dictionary_size = 0;
        }
        public bool Translation_Search(Wordclass w)
        {
            int index = FindAndReturnIndexOfWord(w.Word);
            if (index == -1) return false;
            return words_list[index].Translation_Print();
        }
        public int FindAndReturnIndexOfWord(string word)
        {
            for (int i = 0; i < words_list.Count; i++)
            {
                if (words_list[i].Word == word)
                {
                    return i;
                }

            }
            return -1;
        }




    }



}
