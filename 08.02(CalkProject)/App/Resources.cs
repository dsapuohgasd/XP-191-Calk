using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._02_CalkProject_.App
{
    // Класс с ресурсами
    public static class Resources
    {
        public static String Culture { get; set; } = "uk-UA";
        public static String GetEmptyStringMessage(String? culture = null)   // Пустая строка
        {
            if (culture == null) culture = Culture;                     // Если переданный параметр null то локализакция устанавливается по умолчанию
            switch (culture)
            {
                case "uk-UA": return "Пуста строка не підтримується";   // Возврат строки сообщения
                case "en-US": return "Empty string not allowed";        // Возврат строки сообщения
            }
            throw new Exception("Unsupported culture");                 // Возврат ошибки с неподдерживаемой культурой
        }
        public static String GetInvalidCharMessage(char c, String? culture =null)  // Неподдерживаемый символ
        {
            culture ??=  Culture;                                // Если переданный параметр null то локализакция устанавливается по умолчаниюы
            return culture switch
            {
                "uk-UA"=> $"Недозволенний символ '{c}'",         // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"Invalid char '{c}'",                // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")  // Возврат ошибки с неподдерживаемой культурой
            };
        }
        public static String GetInvalidTypeMessage(int objNumber, String type, String? culture = null)  // Неподдерживаемый тип
        {
            if (culture == null) culture = Culture;                         // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA"=> $"об:{objNumber}: тип: '{type}' недозволенний",   // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"obj:{objNumber}: type: '{type}' unsupported",  // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")             // Возврат ошибки с неподдерживаемой культурой
            };
        }
        public static String GetMisplacedNMessage(String? culture = null)  // 'N=0' 
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA" => $"'N' не допустима в цьому контексті",   // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"'N' is not allowrd in this context",   // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")     // Возврат ошибки с неподдерживаемой культурой
            };
        }

    }
}
