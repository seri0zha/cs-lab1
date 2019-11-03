using System;
using System.Collections.Generic;
namespace lab_1
{
    class Notebook
    {
        static void Main(string[] args)
        {
            Dictionary <int, Note> notes = new Dictionary <int, Note>();
            UserInterface(ref notes);
        }
        static Note CreateNote()
        {
            Note note = new Note();

            Console.WriteLine("Фамилия: ");
            note.fields.Add("Фамилия", CreateField(true));

            Console.WriteLine("Имя: ");
            note.fields.Add("Имя", CreateField(true));

            Console.WriteLine("Отчество: ");
            note.fields.Add("Отчество", CreateField(false));

            Console.WriteLine("Номер телефона: ");
            note.fields.Add("Номер телефона", CreateField(true));

            Console.WriteLine("Страна: ");
            note.fields.Add("Страна", CreateField(true));

            Console.WriteLine("Дата рождения: ");
            note.fields.Add("Дата рождения", CreateField(false));

            Console.WriteLine("Организация: ");
            note.fields.Add("Организация", CreateField(false));

            Console.WriteLine("Должность: ");
            note.fields.Add("Должность", CreateField(false));

            Console.WriteLine("Другие заметки: ");
            note.fields.Add("Другие заметки", CreateField(false));

            Console.Clear();
            return note;
        }

        static void RemoveNote(Dictionary<int, Note> notes, int id)
        {
            notes.Remove(id);
            Console.WriteLine("Запись с ID " + id + " успешно удалена.");
        }

        static void EditNote(int id)
        {

        }
        public static string CreateField(bool isRequired)
        {
            if (isRequired)
            {
                while (true)
                {
                    string field = Console.ReadLine();
                    if (String.IsNullOrEmpty(field))
                    {
                        Console.WriteLine("Ошибка! Поле является обязательным");
                    }
                    else
                    {
                        return field;
                    }
                }
            }
            else
            {
                return Console.ReadLine();
            }
        }

        static void ShowAllNotes(Dictionary<int, Note> notes)
        {
            foreach (var note in notes)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("ID: " + note.Key);
                foreach (var field in note.Value.fields)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
                Console.WriteLine("--------------------------------------");
            }
        }

        static void UserInterface(ref Dictionary <int, Note> notes)
        {
            Console.WriteLine("Добро пожаловать в записную книжку.");
            while(true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1) Добавить новую запись");
                Console.WriteLine("2) Удалить существующую запись");
                Console.WriteLine("3) Редактировать существующую запись");
                Console.WriteLine("4) Просмотр всех существующих записей");
                Console.WriteLine("5) Выйти из программы");
                string action = Console.ReadLine();
                switch(action)
                {
                    case "1": // Добавление новой записи
                        Console.Clear();
                        Random rnd = new Random();
                        int id;
                        while (true) // Проверка на уникальность индетификатора 
                        {
                            id = rnd.Next(100000, 1000000); 
                            if (!notes.ContainsKey(id)) // Если словарь еще не содержит запись с данным ID, то используем этот ID
                            {
                                break;
                            }
                        }
                        notes.Add(id, CreateNote());
                        break;

                    case "2": // Удаление существующей записи
                        Console.Clear();
                        id = Int32.Parse(Console.ReadLine());
                        RemoveNote(notes, id);
                        break;

                    case "3": // Редактирование существующей записи
                        Console.Clear();
                        //EditNote(id);
                        break;

                    case "4": // 
                        Console.Clear();
                        ShowAllNotes(notes);
                        break;

                    case "5":
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

    }

}
/*
 * 
 * using System;
using System.Collections.Generic;

namespace Lab1
{
    class NoteBook
    {
        static void Main(string[] args)
        {
            HashSet<Note> noteBook = new HashSet<Note>();
            Console.WriteLine("Добро пожаловать в \" Записную книжку \"!!");
            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1) Создать новую запись");
                Console.WriteLine("2) Редактировать существующую запись");
                Console.WriteLine("3) Удалить существующую запись");
                Console.WriteLine("4) Выйти из программы");

                string action = Console.ReadLine();

                if (action == "1")
                {
                    Console.WriteLine("Фамилия: ");
                    string surname = AddField(true);

                    Console.WriteLine("Имя: ");
                    string name = AddField(true);

                    Console.WriteLine("Отчество: ");
                    string patronymic = AddField(false);

                    Console.WriteLine("Номер телефона: ");
                    string phone = AddField(true);

                    Console.WriteLine("Страна: ");
                    string country = AddField(true);

                    Console.WriteLine("Дата рождения: ");
                    string birthDate = AddField(false);

                    Console.WriteLine("Организация: ");
                    string organisation = AddField(false);

                    Console.WriteLine("Должность: ");
                    string position = AddField(false);

                    Console.WriteLine("Другие заметки: ");
                    string others = AddField(false);

                    Note note = new Note();


                }
                else if (action == "2")
                {

                }
                else if (action == "3")
                {

                }
                else if (action == "4")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова");
                }
            }
        }

        
        public static string AddField(bool isRequired)
        {
            if (isRequired)
            {
                while (true)
                {
                    string field = Console.ReadLine();
                    if (String.IsNullOrEmpty(field))
                    {
                        Console.WriteLine("Ошибка! Поле является обязательным");
                    }
                    else
                    {
                        return field;
                    }
                }
            }
            else
            {
                return Console.ReadLine();
            }
        }
    }

    class Note
    {
        Dictionary<string, string> fields = new Dictionary<string, string>();
        /*
        public string surname;
        public string name;
        public string patronymic;
        public string phone;
        public string country;
        public string birthDate;
        public string organisation;
        public string position;
        public string others;
        

        /*public Note(string surname, string name, string phone, string country, 
                    string patronymic = "", string birthDate = "undefined",
                    string organisation = "undefined", string position = "undefined",
                    string others = "undefined"
                    )
        
        {
            this.surname = surname;
            this.name = name;
            this.phone = phone;
            this.country = country;
            this.patronymic = patronymic;
            this.birthDate = birthDate;
            this.organisation = organisation;
            this.position = position;
            this.others = others;
        }
        

    }
}
*/