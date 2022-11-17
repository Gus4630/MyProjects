using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT
{
    [Serializable]
    class User : Person, IEdit
    {
        string username;
        string password;
        bool permission = false;
        public User(string username, string password, string name, string surname, int age, string mail, string birth_date) : base(name, surname, age, mail, birth_date)
        {
            this.Username = username;
            this.Password = password;
        }
        public User() : base("","",0,"","")
        {
            this.Username = "";
            this.Password = "";
            

        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public bool Permission_Check_or_Take_Quiz(Dictionary d)
        {
            if (permission == false)
            {
                Console.WriteLine("You don't have a permission. TO have a permission you have to take a quiz.\nQuiz will contain words, you have to input translations.\n\n\nTo take a quiz press 1, otherwise, press any button");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            
                            if (Editing_Permission(new TestQuiz(d)))
                            {
                                permission = true;
                                return true;
                            }
                            break;
                        }
                    default:
                        return false;

                }
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public bool Add_Word(Dictionary d, Wordclass word)
        {
            if (!d.words_list.Contains(word) && Permission_Check_or_Take_Quiz(d) == true)
            {
                d.words_list.Add(word);
                d.dictionary_size++;
                return true;
            }
            return false;
        }

        public bool Editing_Permission(TestQuiz t)
        {
            if (t.Quiz())
            {
                permission = true;
                return permission;
            }
            else
            {
                permission = false;
                return permission;
            }
        }

        public bool Remove_Word(Dictionary d, Wordclass word)
        {
            if (d.words_list.Contains(word) && Permission_Check_or_Take_Quiz(d) == true)
            {
                d.words_list.Remove(word);
                return true;
            }
            return false;
        }

        public bool Remove_Word(Dictionary d, Wordclass word, string translation)
        {
            if (d.words_list.Contains(word) && Permission_Check_or_Take_Quiz(d) == true)
            {
                int index = d.FindAndReturnIndexOfWord(word.Word);
                
                if (index != -1)
                {
                    for (int j = 0; j < d.words_list[index].Word_translation_list.Count; j++)
                    {
                        if (d.words_list[index].Word_translation_list[j] == translation && d.words_list[index].Word_translation_list.Count > 1)
                        {
                            d.words_list[index].Word_translation_list.Remove(translation);
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

            if (index >= 0 && Permission_Check_or_Take_Quiz(d) == true)
            {
                d.words_list[index] = _new;
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
            if (index >= 0 && Permission_Check_or_Take_Quiz(d) == true)
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
