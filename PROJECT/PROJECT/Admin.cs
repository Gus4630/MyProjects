using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    [Serializable]
    class Admin : Person, IEdit
    {

        string username;
        string password;

        public Admin(string name, string surname, int age, string mail, string birth_date, string username, string password) : base(name, surname, age, mail, birth_date)
        {
            this.Password = password;
            this.Username = username;
        }
        public Admin() : base("", "", 0, "", "")
        {
            this.Username = "";
            this.Password = "";
        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public bool Add_Word(Dictionary d, Wordclass word)
        {
            if (!d.words_list.Contains(word))
            {
                d.words_list.Add(word);
                d.dictionary_size++;
                return true;
            }
            return false;
        }
        public string Add_Word(Dictionary d, List<Wordclass> word)
        {
            bool check = true;
            int counter = 0;
            for (int i = 0; i < word.Count; i++)
            {
                if (!d.words_list.Contains(word[i]))
                {
                    d.words_list.Add(word[i]);
                    counter++;
                    d.dictionary_size++;
                }
                else
                {
                    check = false;
                }

            }
            if (check)
            {
                return $"All the {word.Count} words were successfully added!";
            }
            else
            {
                return $"Not all words were added(Repeated words), however, {counter} words were successfully added!";
            }

        }
        public bool Remove_Word(Dictionary d, Wordclass word)
        {
            if (d.words_list.Contains(word))
            {
                d.words_list.Remove(word);
                d.dictionary_size--;
                return true;
            }
            return false;
        }

        public bool Remove_Word(Dictionary d, Wordclass word, string translation)
        {
            if (d.words_list.Contains(word))
            {
                int index = d.FindAndReturnIndexOfWord(word.Word);

                if (index != -1)
                {
                    for (int j = 0; j < d.words_list[index].Word_translation_list.Count; j++)
                    {
                        if (d.words_list[index].Word_translation_list[j] == translation)
                        {
                            d.words_list[index].Word_translation_list.Remove(translation);
                            d.dictionary_size--;
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        public bool Word_Edit(Dictionary d, Wordclass _old, Wordclass _new)
        {
            int index = d.FindAndReturnIndexOfWord(_old.Word);

            d.words_list[index] = _new;
            if (index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Word_Edit(Dictionary d, Wordclass word, string old_translation, string new_translation) //Отправляется объект слова
        {
            int index = d.FindAndReturnIndexOfWord(word.Word);
            if (index >= 0)
            {
                if (d.words_list[index].Word_translation_list.Contains(old_translation))
                {
                    for (int j = 0; j < d.words_list[index].Word_translation_list.Count; j++)
                    {
                        if (d.words_list[index].Word_translation_list[j] == old_translation)
                        {
                            d.words_list[index].Word_translation_list.RemoveAt(j);
                            d.words_list[index].Word_translation_list.Insert(j, new_translation);
                            return true;

                        }
                    }
                }

            }

            return false;


        }
    }

}
