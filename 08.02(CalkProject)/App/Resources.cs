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
        
        // Пустая строка
        public static String GetEmptyStringMessage(String? culture = null) 
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA" => "Пуста строка не підтримується",         // Возврат строки сообщения в uk-UA кодировке
                "en-US" => "Empty string not allowed",              // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture"),    // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // Неподдерживаемый символ
        public static String GetInvalidCharMessage(char c, String? culture =null)  
        {
            culture ??=  Culture;                                // Если переданный параметр null то локализакция устанавливается по умолчаниюы
            return culture switch
            {
                "uk-UA"=> $"Недозволенний символ '{c}'",         // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"Invalid char '{c}'",                // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")  // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // Неподдерживаемый тип
        public static String GetInvalidTypeMessage(int objNumber, String type, String? culture = null)  
        {
            if (culture == null) culture = Culture;                         // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA"=> $"об:{objNumber}: тип: '{type}' недозволенний",   // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"obj:{objNumber}: type: '{type}' unsupported",  // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")             // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // 'N=0' 
        public static String GetMisplacedNMessage(String? culture = null)  
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA" => $"'N' не допустима в цьому контексті",   // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"'N' is not allowrd in this context",   // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")     // Возврат ошибки с неподдерживаемой культурой
            };
        }

        ///////////////////////////////////////////////////////////////////////////////
        //UI->
        ///////////////////////////////////////////////////////////////////////////////
        
        // Ввод числа
        public static String GetEnterNumberMessage(String? culture = null)  
        {
            if (culture == null) culture = Culture;               // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch                                 
            {                                                     
                "uk-UA" => "Введiть число: ",                     // Возврат строки сообщения в "uk-UA" кодировке
                "en-US" => "Enter number: ",                      // Возврат строки сообщения в "en-US" кодировке
                _ => throw new Exception("Unsupported culture"),  // Возврат ошибки с неподдерживаемой культурой
            };
        } 
        
        // Выбор операции
        public static String GetEnterOperationMessage(String? culture = null)  
        {
            if (culture == null) culture = Culture;               // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch                                 
            {                                                     
                "uk-UA" => "Введiть операцiю: ",                  // Возврат строки сообщения в "uk-UA" кодировке
                "en-US" => "Enter operation: ",                   // Возврат строки сообщения в "en-US" кодировке
                _ => throw new Exception("Unsupported culture"),  // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // Результат
        public static String GetResultMessage(object res, String? culture = null)  
        {
            if (culture == null) culture = Culture;               // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch                                 
            {                                                     
                "uk-UA" => $"Результат: {res}",                   // Возврат строки сообщения в "uk-UA" кодировке
                "en-US" => $"Result: {res}",                      // Возврат строки сообщения в "en-US" кодировке
                _ => throw new Exception("Unsupported culture"),  // Возврат ошибки с неподдерживаемой культурой
            };
        }
    }
}
