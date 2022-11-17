using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PROJECT
{

    [Serializable]
    internal class DictionaryProject
    {

        public static bool loop_continue(string str)
        {
            if (str == "e" || str == "E")
            {

                return false;
            }
            return true;
        }

        public static string printing_ending_of_numbers(int number)
        {
            number %= 10;
            if (number == 1) return "-st";
            else if (number == 2) return "-nd";
            else if (number == 3) return "-d";
            else return "-th";
        }

        public static bool Dictionary_Program()
        {
            IEdit person = new Admin("", "", 1, "", "", "", "");


            Dictionary d = new Dictionary();
            bool loop_break = true;
            string path = "Dictionary.dat";


            DB db = new DB();/*Deserialize(path)*/;
            int choice;
            db = Deserialize(path);
            
            while (loop_break)
            {

                string str_loop = "";
                while (loop_continue(str_loop))
                {
                    Console.Clear();
                    Console.WriteLine("1. Register Admin\n2. Register User\n3. Login\n4. Exit the program");
                    Console.Write("\n\nInput: ");
                    choice = Convert.ToInt32(Console.ReadLine());



                    switch (choice)
                    {
                        case 1: { person = Add_Admin(); db.admins.Add((Admin)person); str_loop = "e"; break; }
                        case 2: { person = Add_User(); db.users.Add((User)person); str_loop = "e"; break; }
                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine("Type your username: ");
                                string login = Console.ReadLine();
                                Console.WriteLine("Type your password: ");
                                string password = Console.ReadLine();
                                for (int i = 0; i < db.admins.Count; i++)
                                {
                                    if (db.admins[i].Username == login && db.admins[i].Password == password)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Admin \"{db.admins[i].Name} {db.admins[i].Surname}\" Successfully loged in");
                                        person = db.admins[i];
                                        str_loop = "e";
                                        Thread.Sleep(2000);
                                    }
                                }
                                for (int i = 0; i < db.users.Count; i++)
                                {
                                    if (db.users[i].Username == login && db.users[i].Password == password)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"User \"{db.users[i].Name} {db.users[i].Surname}\" Successfully loged in");
                                        person = db.users[i];
                                        str_loop = "e";
                                        Thread.Sleep(2000);

                                    }
                                }
                                if (str_loop != "e")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Wrong Username or Password. Try Again\n");
                                }
                                break;

                            }
                        case 4:
                            {
                                str_loop = "e";
                                loop_break = false;

                                Console.Clear();
                                Console.WriteLine("Saving the data...");
                                Thread.Sleep(2000);
                                Console.WriteLine();
                                SaveSerialize(path, db);

                                return true;
                            }
                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong Input\nTry again.");
                            Thread.Sleep(1000);
                            break;
                    }
                }
                
                while (true)
                {
                 
                    Console.Clear();
                    
                    Console.WriteLine("1. Create a Dictionary");
                    Console.WriteLine("2. Choose a Dictionary");
                    Console.WriteLine("3. Exit the Program");
                    choice = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    if (choice == 3) { break; }
                    switch (choice)
                    {
                        case 1:
                            {
                                if (person.GetType() == new User().GetType())
                                {
                                    d.author = (User)person;
                                }
                                else
                                {
                                    d.author = (Admin)person;
                                }
                                Console.WriteLine("Please write the type of the dictionary(ex. RUS-ENG): ");

                                string dictionary_type = Console.ReadLine();
                                d.dictionary_type = dictionary_type;

                                int counter_of_words = 1;
                                while (true)
                                {

                                    Wordclass w = new Wordclass();
                                    string word;
                                    Console.Clear();

                                    if (counter_of_words <= 1)
                                    {
                                        Console.WriteLine($"Please enter the {counter_of_words + printing_ending_of_numbers(counter_of_words)} word to add:");
                                        word = Console.ReadLine();
                                    }
                                    else
                                    {

                                        Console.WriteLine($"Please enter the {counter_of_words + printing_ending_of_numbers(counter_of_words)} word to add\nIf you want to stop or exit press e/E:");
                                        word = Console.ReadLine();
                                        if (!loop_continue(word)) break;

                                    }
                                    d.dictionary_size = counter_of_words;


                                    w.Word = word;

                                    Console.WriteLine($"Please enter the definition of the word \"{word}\": ");
                                    string definition = Console.ReadLine();
                                    w.Definition = definition;

                                    int counter_of_translations = 1;
                                    while (true)
                                    {

                                        if (counter_of_translations <= 1)
                                        {
                                            Console.WriteLine($"Please enter the {counter_of_translations + printing_ending_of_numbers(counter_of_translations)} translation of a \"{word}\" to add: ");
                                            string translation = Console.ReadLine();
                                            w.Word_translation_list.Add(translation);
                                            counter_of_translations++;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Please enter the {counter_of_translations + printing_ending_of_numbers(counter_of_translations)} translation of a \"{word}\" to add:\nIf you want to stop press E ");
                                            string translation = Console.ReadLine();

                                            if (!loop_continue(translation))
                                            {
                                                break;
                                            }
                                            w.Word_translation_list.Add(translation);
                                            counter_of_translations++;
                                        }

                                    }

                                    Console.Clear();


                                    int counter_of_synonyms = 1;
                                    while (true)
                                    {
                                        if (counter_of_synonyms <= 1)
                                        {
                                            string synonym;
                                            Console.WriteLine($"Please enter the {counter_of_synonyms + printing_ending_of_numbers(counter_of_synonyms)} synonym of a \"{word}\" to add:");
                                            synonym = Console.ReadLine();
                                            w.Word_synonyms_list.Add(synonym);
                                            counter_of_synonyms++;

                                        }
                                        else
                                        {
                                            Console.Clear();
                                            string synonym;
                                            Console.WriteLine($"Please enter the {counter_of_synonyms + printing_ending_of_numbers(counter_of_synonyms)} synonym of a \"{word}\" to add:\nIf you want to stop press E/e:");
                                            synonym = Console.ReadLine();
                                            if (!loop_continue(synonym))
                                            {
                                                break;
                                            }
                                            w.Word_synonyms_list.Add(synonym);
                                            counter_of_synonyms++;
                                        }

                                    }
                                    Console.Clear();
                                    Console.WriteLine("Operation succesfful!");
                                    Thread.Sleep(2000);
                                    d.words_list.Add(w);
                                    counter_of_words++;


                                }
                                db.dictionaries.Add(d);
                                break;
                            }
                        case 2:
                            {
                                while (true)
                                {


                                    int index_of_dictionary = 0;
                                    Console.Clear();
                                    Console.WriteLine($"Choose one of the dictionaries:");





                                    for (int i = 0; i < db.dictionaries.Count; i++)
                                    {
                                        Console.WriteLine((i + 1) + ". " + db.dictionaries[i].dictionary_type);
                                    }
                                    Console.WriteLine("Type \"-1\" to exit: ");

                                    index_of_dictionary = Convert.ToInt32(Console.ReadLine());
                                    index_of_dictionary--;
                                    if (index_of_dictionary == -2)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    bool loop_ = true;
                                    while (loop_)
                                    {


                                        if (index_of_dictionary < db.dictionaries.Count)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"1. Add a word to {db.dictionaries[index_of_dictionary].dictionary_type}");
                                            Console.WriteLine($"2. Edit a word in {db.dictionaries[index_of_dictionary].dictionary_type}");
                                            Console.WriteLine($"3. Edit a translation of a certain word in {db.dictionaries[index_of_dictionary].dictionary_type}");
                                            Console.WriteLine($"4. Delete a word in {db.dictionaries[index_of_dictionary].dictionary_type}");
                                            Console.WriteLine($"5. Delete a translation of a certain word in {db.dictionaries[index_of_dictionary].dictionary_type}");
                                            Console.WriteLine($"6. Search for a word's translation in {db.dictionaries[index_of_dictionary].dictionary_type}");
                                            Console.WriteLine($"7. Return Back");
                                            Console.WriteLine($"8. Print the info of the dictionary {db.dictionaries[index_of_dictionary].dictionary_type}");
                                            choice = Convert.ToInt32(Console.ReadLine());

                                            switch (choice)
                                            {

                                                case 1:
                                                    {

                                                        Wordclass w = new Wordclass();
                                                        string word;
                                                        Console.Clear();



                                                        Console.WriteLine($"Please type the word:");
                                                        word = Console.ReadLine();
                                                        w.Word = word;
                                                        Console.WriteLine($"Please enter the definition of the word \"{word}\": ");
                                                        string definition = Console.ReadLine();
                                                        w.Definition = definition;

                                                        int counter_of_translations = 1;
                                                        while (true)
                                                        {

                                                            if (counter_of_translations <= 1)
                                                            {
                                                                Console.WriteLine($"Please enter the {counter_of_translations + printing_ending_of_numbers(counter_of_translations)} translation of a \"{word}\" to add: ");
                                                                string translation = Console.ReadLine();
                                                                w.Word_translation_list.Add(translation);
                                                                counter_of_translations++;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine($"Please enter the {counter_of_translations + printing_ending_of_numbers(counter_of_translations)} translation of a \"{word}\" to add:\nIf you want to stop press E ");
                                                                string translation = Console.ReadLine();

                                                                if (!loop_continue(translation))
                                                                {
                                                                    break;
                                                                }
                                                                w.Word_translation_list.Add(translation);
                                                                counter_of_translations++;
                                                            }

                                                        }

                                                        Console.Clear();


                                                        int counter_of_synonyms = 1;
                                                        while (true)
                                                        {
                                                            if (counter_of_synonyms <= 1)
                                                            {
                                                                string synonym;
                                                                Console.WriteLine($"Please enter the {counter_of_synonyms + printing_ending_of_numbers(counter_of_synonyms)} synonym of a \"{word}\" to add:");
                                                                synonym = Console.ReadLine();
                                                                w.Word_synonyms_list.Add(synonym);
                                                                counter_of_synonyms++;

                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                string synonym;
                                                                Console.WriteLine($"Please enter the {counter_of_synonyms + printing_ending_of_numbers(counter_of_synonyms)} synonym of a \"{word}\" to add:\nIf you want to stop press E/e:");
                                                                synonym = Console.ReadLine();
                                                                if (!loop_continue(synonym))
                                                                {
                                                                    break;
                                                                }
                                                                w.Word_synonyms_list.Add(synonym);
                                                                counter_of_synonyms++;
                                                            }

                                                        }
                                                        Console.Clear();
                                                        Console.WriteLine("Successfully Added\n");
                                                        Thread.Sleep(2000);
                                                        person.Add_Word(db.dictionaries[index_of_dictionary], w);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Words:");
                                                        for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list.Count; i++)
                                                        {
                                                            Console.WriteLine($"{db.dictionaries[index_of_dictionary].words_list[i].Word}");

                                                        }
                                                        Console.WriteLine();

                                                        Console.WriteLine("Please enter the word you want to edit: ");
                                                        string old_word = Console.ReadLine();


                                                        int index_of_wordlist = db.dictionaries[index_of_dictionary].FindAndReturnIndexOfWord(old_word);
                                                        if (index_of_wordlist == -1)
                                                        {
                                                            Console.Clear();
                                                            Thread.Sleep(1500);
                                                            Console.WriteLine("There is no such word");
                                                            break;
                                                        }
                                                        Wordclass _old = db.dictionaries[index_of_dictionary].words_list[index_of_wordlist];

                                                        Wordclass _new = new Wordclass();

                                                        Console.Clear();

                                                        string new_word;

                                                        Console.WriteLine($"Please type the new word:");
                                                        new_word = Console.ReadLine();
                                                        _new.Word = new_word;
                                                        Console.WriteLine($"Please enter the definition of the word \"{new_word}\": ");
                                                        string definition = Console.ReadLine();
                                                        _new.Definition = definition;

                                                        int counter_of_translations = 1;
                                                        while (true)
                                                        {

                                                            if (counter_of_translations <= 1)
                                                            {
                                                                Console.WriteLine($"Please enter the {counter_of_translations + printing_ending_of_numbers(counter_of_translations)} translation of a \"{new_word}\" to add: ");
                                                                string translation = Console.ReadLine();
                                                                _new.Word_translation_list.Add(translation);
                                                                counter_of_translations++;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine($"Please enter the {counter_of_translations + printing_ending_of_numbers(counter_of_translations)} translation of a \"{new_word}\" to add:\nIf you want to stop press E ");
                                                                string translation = Console.ReadLine();

                                                                if (!loop_continue(translation))
                                                                {
                                                                    break;
                                                                }

                                                                _new.Word_translation_list.Add(translation);
                                                                counter_of_translations++;
                                                            }

                                                        }

                                                        Console.Clear();


                                                        int counter_of_synonyms = 1;
                                                        while (true)
                                                        {
                                                            if (counter_of_synonyms <= 1)
                                                            {
                                                                string synonym;
                                                                Console.WriteLine($"Please enter the {counter_of_synonyms + printing_ending_of_numbers(counter_of_synonyms)} synonym of a \"{new_word}\" to add:");
                                                                synonym = Console.ReadLine();
                                                                _new.Word_synonyms_list.Add(synonym);
                                                                counter_of_synonyms++;

                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                string synonym;
                                                                Console.WriteLine($"Please enter the {counter_of_synonyms + printing_ending_of_numbers(counter_of_synonyms)} synonym of a \"{new_word}\" to add:\nIf you want to stop press E/e:");
                                                                synonym = Console.ReadLine();
                                                                if (!loop_continue(synonym))
                                                                {
                                                                    break;
                                                                }
                                                                _new.Word_synonyms_list.Add(synonym);
                                                                counter_of_synonyms++;
                                                            }

                                                        }
                                                        Console.Clear();

                                                        person.Word_Edit(db.dictionaries[index_of_dictionary], _old, _new);
                                                        Console.WriteLine("Successfully Edited!!\n");
                                                        Thread.Sleep(2000);

                                                        break;
                                                    }
                                                case 3:
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine("Words:");
                                                        for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list.Count; i++)
                                                        {
                                                            Console.WriteLine($"{db.dictionaries[index_of_dictionary].words_list[i].Word}");

                                                        }
                                                        Console.WriteLine();
                                                        Console.WriteLine("Please enter the word: ");
                                                        string old_word = Console.ReadLine();
                                                        int index_of_wordlist = db.dictionaries[index_of_dictionary].FindAndReturnIndexOfWord(old_word);
                                                        if (index_of_wordlist == -1)
                                                        {
                                                            Console.Clear();
                                                            Thread.Sleep(1500);
                                                            Console.WriteLine("There is no such word");
                                                            break;
                                                        }
                                                        Wordclass word = db.dictionaries[index_of_dictionary].words_list[index_of_wordlist];

                                                        Console.Clear();
                                                        for (int i = 0; i < word.Word_translation_list.Count; i++)
                                                        {
                                                            Console.WriteLine(word.Word_translation_list[i]);
                                                        }
                                                        Console.WriteLine();
                                                        Console.WriteLine("Please enter the old translation: ");
                                                        string old_translation = Console.ReadLine();

                                                        Console.WriteLine("Please enter the new translation: ");
                                                        string new_translation = Console.ReadLine();

                                                        Console.Clear();
                                                        if (person.Word_Edit(db.dictionaries[index_of_dictionary], word, old_translation, new_translation))
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Successfully replaced");
                                                            Thread.Sleep(2000);
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("One of the entered parameters are incorrect. Try Again");
                                                            Thread.Sleep(2000);
                                                        }


                                                        break;
                                                    }

                                                case 4:
                                                    {
                                                        Wordclass w;

                                                        Console.Clear();
                                                        Console.WriteLine("Words:");
                                                        for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list.Count; i++)
                                                        {
                                                            Console.WriteLine($"{db.dictionaries[index_of_dictionary].words_list[i].Word}");

                                                        }
                                                        Console.WriteLine();
                                                        Console.WriteLine("Please enter the word you want to remove: ");
                                                        string str = Console.ReadLine();

                                                        int index_of_word = db.dictionaries[index_of_dictionary].FindAndReturnIndexOfWord(str);
                                                        if (index_of_word == -1)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("There is no such word");
                                                            Thread.Sleep(1500);
                                                            break;
                                                        }
                                                        w = db.dictionaries[index_of_dictionary].words_list[index_of_word];

                                                        if (person.Remove_Word(db.dictionaries[index_of_dictionary], w))
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Succesfully removed");
                                                            Thread.Sleep(2000);
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Unsuccessful operation");
                                                            Thread.Sleep(2000);
                                                        }

                                                        break;
                                                    }
                                                case 5:
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine("Words:");
                                                        for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list.Count; i++)
                                                        {
                                                            Console.WriteLine($"{db.dictionaries[index_of_dictionary].words_list[i].Word}");

                                                        }
                                                        Console.WriteLine();
                                                        Console.WriteLine("Please enter the word: ");

                                                        string word = Console.ReadLine();
                                                        int index_of_word = db.dictionaries[index_of_dictionary].FindAndReturnIndexOfWord(word);
                                                        if (index_of_word == -1)
                                                        {
                                                            Console.Clear();
                                                            Thread.Sleep(1500);
                                                            Console.WriteLine("There is no such word");
                                                            break;
                                                        }

                                                        Wordclass w = db.dictionaries[index_of_dictionary].words_list[index_of_word];

                                                        Console.WriteLine($"Translations of the word \"{w.Word}\":");
                                                        for (int i = 0; i < w.Word_translation_list.Count; i++)
                                                        {
                                                            Console.WriteLine(w.Word_translation_list[i]);
                                                        }

                                                        Console.WriteLine();
                                                        Console.WriteLine("Please enter the translation you want to remove: ");
                                                        string translation = Console.ReadLine();

                                                        if (person.Remove_Word(db.dictionaries[index_of_dictionary], w, translation))
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Successful operation");
                                                            Thread.Sleep(2000);
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Unsuccessful operation");
                                                            Thread.Sleep(2000);
                                                        }


                                                        break;
                                                    }
                                                case 6:
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Words:");
                                                        for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list.Count; i++)
                                                        {
                                                            Console.WriteLine($"{db.dictionaries[index_of_dictionary].words_list[i].Word}");

                                                        }
                                                        Console.WriteLine();

                                                        Console.WriteLine("Please enter the word: ");
                                                        string word = Console.ReadLine();
                                                        int index_of_word = db.dictionaries[index_of_dictionary].FindAndReturnIndexOfWord(word);

                                                        if (index_of_word != -1)
                                                        {

                                                            Wordclass wordclass = db.dictionaries[index_of_dictionary].words_list[index_of_word];

                                                            if (db.dictionaries[index_of_dictionary].Translation_Search(wordclass))
                                                            {
                                                                Console.WriteLine();
                                                                Console.WriteLine("Successfully finished\n\nPress any button to Continue...");
                                                                Thread.Sleep(2000);

                                                                Console.ReadKey();
                                                                Console.Clear();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("There is no such word");
                                                            Thread.Sleep(2000);
                                                        }


                                                        break;
                                                    }
                                                case 7:
                                                    {
                                                        loop_ = false;
                                                        Console.Clear();
                                                        //Thread.Sleep(2000);
                                                        break;
                                                    }
                                                case 8:
                                                    {
                                                        while (true)
                                                        {

                                                            Console.Clear();
                                                            Console.WriteLine($"Dictionary type: {db.dictionaries[index_of_dictionary].dictionary_type}");
                                                            Console.WriteLine($"Dictionary Size: {db.dictionaries[index_of_dictionary].dictionary_size} ");
                                                            Console.WriteLine($"Dictionary Creator:{db.dictionaries[index_of_dictionary].author.Name} {db.dictionaries[index_of_dictionary].author.Surname}");

                                                            Console.WriteLine("Words:");
                                                            for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list.Count; i++)
                                                            {
                                                                Console.WriteLine($"{i + 1}.{db.dictionaries[index_of_dictionary].words_list[i].Word}");

                                                            }
                                                            Console.WriteLine("Choose the word by index(Type -1 to exit): ");

                                                            int index = Convert.ToInt32(Console.ReadLine());
                                                            if (index == -1)
                                                            {
                                                                break;
                                                            }
                                                            index--;
                                                            Console.Clear();
                                                            Console.WriteLine("Definition:");
                                                            Console.WriteLine(db.dictionaries[index_of_dictionary].words_list[index].Definition + "\n");
                                                            Console.WriteLine("Translations:");
                                                            for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list[index].Word_translation_list.Count; i++)
                                                            {
                                                                Console.WriteLine($"{i + 1}.{db.dictionaries[index_of_dictionary].words_list[index].Word_translation_list[i]}");
                                                            }

                                                            Console.WriteLine("\nSynonyms:");
                                                            for (int i = 0; i < db.dictionaries[index_of_dictionary].words_list[index].Word_synonyms_list.Count; i++)
                                                            {
                                                                Console.WriteLine($"{i + 1}.{db.dictionaries[index_of_dictionary].words_list[index].Word_synonyms_list[i]}");
                                                            }

                                                            Console.WriteLine("Press any button to continue...");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    }
                                                default:
                                                    Console.Clear();
                                                    Console.WriteLine("Wrong Input");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();
                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            loop_ = false;
                                            Console.Clear();
                                            Console.WriteLine("Wrong Input. Try again");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                        }
                                    }


                                }
                                break;
                            }

                        default:
                            break;
                    }

                }
            }
            Console.Clear();
            Console.WriteLine("Saving the data...");
            Thread.Sleep(2000);
            Console.WriteLine();
            //SaveSerialize("Dictionary.dat", db);
            return true;
        }

        public static Admin Add_Admin()
        {

            Admin admin;

            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your mail: ");
            string mail = Console.ReadLine();
            Console.WriteLine("Enter your birth date: ");
            string birth = Console.ReadLine();
            Console.WriteLine("Enter your username: ");
            string login = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            admin = new Admin(name, surname, age, mail, birth, login, password);

            Console.WriteLine("Successfully Added");
            return admin;


        }

        public static User Add_User()
        {

            User user;
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your mail: ");
            string mail = Console.ReadLine();
            Console.WriteLine("Enter your birth date: ");
            string birth = Console.ReadLine();
            Console.WriteLine("Enter your username: ");
            string login = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Successfully Added");

            user = new User(login, password, name, surname, age, mail, birth);
            return user;

        }

        public static void SaveSerialize(string path, DB db)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, db);
            }
        }
        public static DB Deserialize(string path)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                DB db = (DB)binaryFormatter.Deserialize(fs);
                return db;
            }
        }

        public static void StartTheProgram()
        {

        }

        static void Main(string[] args)
        {



            Dictionary_Program();


        }
    }
}
