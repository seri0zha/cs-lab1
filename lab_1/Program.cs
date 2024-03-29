﻿using System;
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

        static void UserInterface(ref Dictionary<int, Note> notes) // Метод взаимодействия с пользователем
        {
            Console.WriteLine("Добро пожаловать в записную книжку.");
            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1) Добавить новую запись");
                Console.WriteLine("2) Удалить существующую запись");
                Console.WriteLine("3) Редактировать существующую запись");
                Console.WriteLine("4) Посмотреть существующую запись");
                Console.WriteLine("5) Просмотр всех существующих записей");
                Console.WriteLine("6) Выйти из программы");
                string action = Console.ReadLine();
                switch (action)
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
                        Console.Clear();
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        static Note CreateNote()
        {
            Note note = new Note();
            
            foreach(var field in Note.fieldsList) // Добавление полей в запись
            {
                Console.WriteLine(field.Key + ": ");
                while (true)
                {
                    string value = CreateField(field.Value);
                    if (field.Key.Equals("Телефон"))
                    {
                        if (!CheckNumber(value))
                        {
                            Console.WriteLine("Телефон должен содержать только цифры! Попробуйте снова: ");
                        }
                        else
                        {
                            note.fields.Add(field.Key, value);
                            break;
                        }

                    }
                    else
                    {
                        note.fields.Add(field.Key, value);
                        break;
                    }
                }
                
            }
            Console.Clear();
            return note;
        } // Создание записи

        static void RemoveNote(Dictionary<int, Note> notes, int id) // Удаление записи
        {
            if (notes.ContainsKey(id))
            {
                notes.Remove(id);
                Console.WriteLine("Запись с ID " + id + " успешно удалена.");
            }
            else
            {
                Console.WriteLine("Ошибка! Запись с ID " + id + " не найдена.");
            }
        }

        static void EditNote(Dictionary<int, Note> notes, int id) // Редактирование записи
        {
            if (notes.ContainsKey(id))
            {
                Console.WriteLine("Введите поле которое нужно редактировать: ");
                while (true)
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
            else
            {
                Console.WriteLine("Ошибка! Запись с ID " + id + " не найдена.");
            }
        }
        public static string CreateField(bool isRequired) // Создание поля записи
        {
            if (isRequired)
            {
                while (true)
                {
                    string field = Console.ReadLine(); 
                    if (String.IsNullOrEmpty(field) || field.Equals(" ")) // Проверка корректности введенной строки 
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

        static void ReadNote(Dictionary<int, Note> notes, int id = 0) // Вывод на экран одной записи
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

        static void ShowAllNotes(Dictionary<int, Note> notes) // Вывод на экран всех записей
        {
            if (notes.Count == 0)
            {
                Console.WriteLine("В записной книжке еще нет ни одной записи!");
            }
            else
            {
                foreach (var note in notes)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("ID: " + note.Key);
                    foreach (var field in note.Value.fields)
                    {
                        if (!String.IsNullOrEmpty(field.Value) && !field.Value.Equals(" "))
                        {
                            Console.WriteLine($"{field.Key}: {field.Value}");
                        }
                    }
                    Console.WriteLine("--------------------------------------");
                }
            }
        } 

        static int ReadId() // Считывание ID введенного пользователем
        {
            int id;
            while (true)
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

        static bool CheckNumber(string number) // Проверка номера
        {
            foreach (char c in number)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        } 
    }
}
