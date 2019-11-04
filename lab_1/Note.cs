using System;
using System.Collections.Generic;
using System.Text;

namespace lab_1
{
    class Note
    {
        public static Dictionary<string, bool> fieldsList = new Dictionary<string, bool>() // Словарь возможных записей, где тип bool указывает на обязательность поля
            { { "Фамилия", true }, { "Имя", true }, { "Отчество", false },
              { "Телефон", true }, { "Страна", true }, { "Дата рождения", false },
              { "Организация", false }, { "Должность", false }, { "Другое", false }
            };

        public Dictionary<string, string> fields = new Dictionary<string, string>();

    }
}
