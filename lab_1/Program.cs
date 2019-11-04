using System;
using System.Collections;
using System.Collections.Generic;
namespace lab_1
{
    class Notebook
    {
        public static Dictionary<int, Note> notes = new Dictionary<int, Note>();
        static void Main(string[] args)
        {
            UserInterface(ref Notebook.notes);
        }
        static Note CreateNote()
        {
            Note note = new Note();
            
            foreach(var field in Note.fieldsList) // Добавление полей в запись
            {
                Console.WriteLine(field.Key + ": ");
                note.fields.Add(field.Key, CreateField(field.Value));
            }
            Console.Clear();
            return note;
        }

        static void RemoveNote(Dictionary<int, Note> notes, int id)
        {
            notes.Remove(id);
            Console.WriteLine("Запись с ID " + id + " успешно удалена.");
        }

        static void EditNote(Dictionary<int, Note> notes, int id)
        {
            Console.WriteLine("Введите поле которое нужно редактировать: ");
            while(true)
            {
                string field = Console.ReadLine();
                if (notes[id].fields.ContainsKey(field))
                {
                    Console.WriteLine("Введите новое значение поля: ");
                    notes[id].fields[field] = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Данного поля не существует. Попробуйте снова: ");
                }
            }
        }
        public static string CreateField(bool isRequired)
        {
            if (isRequired)
            {
                while (true)
                {
                    string field = Console.ReadLine(); 
                    if (String.IsNullOrEmpty(field)) // Проверка корректности введенной строки 
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

        static void ReadNote(Dictionary<int, Note> notes, int id = 0)
        {
            if (notes.ContainsKey(id))
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("ID: " + id);
                foreach (var field in notes[id].fields)
                {
                    Console.WriteLine($"{field.Key}: {field.Value}");
                }
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine("Запись не найдена!");
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
                    if (!String.IsNullOrEmpty(field.Value))
                    {
                        Console.WriteLine($"{field.Key}: {field.Value}");
                    }
                }
                Console.WriteLine("--------------------------------------");
            }
        }

        static int ReadId()
        {
            int id;
            while(true)
            {
                string input = Console.ReadLine();
                if (!Int32.TryParse(input, out id))
                {
                    Console.WriteLine("Ошибка! ID введен некорректно. Попробуйте снова: ");
                }
                else
                {
                    return Int32.Parse(input);
                }
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
                Console.WriteLine("4) Посмотреть существующую запись");
                Console.WriteLine("5) Просмотр всех существующих записей");
                Console.WriteLine("6) Выйти из программы");
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
                        Console.WriteLine("Введите ID записи для удаления: ");
                        id = ReadId();
                        RemoveNote(notes, id);
                        break;

                    case "3": // Редактирование существующей записи
                        Console.Clear();
                        Console.WriteLine("Введите ID записи для редактирования: ");
                        id = ReadId();
                        EditNote(notes, id);
                        break;

                    case "4": // Вывод на экран одной записи
                        Console.Clear();
                        Console.WriteLine("Введите ID записи: ");
                        id = ReadId();
                        ReadNote(notes, id);
                        break;

                    case "5": // Вывод на экран всех записей
                        Console.Clear();
                        ShowAllNotes(notes);
                        break;

                    case "6": // Выход из программы
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

/* TODO
 * Добавить защиту от дурака при вводе - переделать ввод ID
 * Проверка телефона - состоит только из цифр
 * Переделать вывод информации записи - DONE
 */