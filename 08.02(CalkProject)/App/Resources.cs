using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._02_CalkProject_.App
{
    // Класс с ресурсами
    public   class Resources
    {
        public   String Culture { get; set; } = "uk-UA";
        
        // Пустая строка
        public   String GetEmptyStringMessage(String? culture = null) 
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA" => "Пуста строка не пiдтримується",         // Возврат строки сообщения в uk-UA кодировке
                "en-US" => "Empty string not allowed",              // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture"),    // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // Неподдерживаемый символ
        public   String GetInvalidCharMessage(char c, String? culture =null)  
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
        public   String GetInvalidTypeMessage(String type, String? culture = null)  
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA"=> $"тип: '{type}' недозволенний",           // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"type: '{type}' unsupported",           // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")     // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // Неподдерживаемая операция
        public   String GetInvalidOperation(String? culture = null)  
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA"=> $"операция недозволеннa",         // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"operation unsupported",         // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")     // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // Неподдерживаемая операция
        public   String GetInvalidLength(String? culture = null)  
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA"=> $"Недозволенний розмiр строки",           // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"Length unsupported",                   // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")     // Возврат ошибки с неподдерживаемой культурой
            };
        }
        
        // 'N=0' 
        public   String GetMisplacedNMessage(String? culture = null)  
        {
            if (culture == null) culture = Culture;                 // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch
            {
                "uk-UA" => $"'N' не допустима в цьому контексті",   // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"'N' is not allowrd in this context",   // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")     // Возврат ошибки с неподдерживаемой культурой
            };
        }

        // Неподдерживаемый символ
        public String GetInvalidSymbolMessage(String? culture = null)
        {
            culture ??= Culture;                                // Если переданный параметр null то локализакция устанавливается по умолчаниюы
            return culture switch
            {
                "uk-UA" => $"Недозволенний символ",              // Возврат строки сообщения в uk-UA кодировке
                "en-Us" => $"Invalid symbol",                      // Возврат строки сообщения в en-US кодировке
                _ => throw new Exception("Unsupported culture")  // Возврат ошибки с неподдерживаемой культурой
            };
        }
        ///////////////////////////////////////////////////////////////////////////////
        //UI->
        ///////////////////////////////////////////////////////////////////////////////

        // Ввод числа
        public   String GetEnterNumberMessage(String? culture = null)  
        {
            if (culture == null) culture = Culture;               // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch                                 
            {                                                     
                "uk-UA" => "Введiть вираз (CX + CD): ",                     // Возврат строки сообщения в "uk-UA" кодировке
                "en-US" => "Enter expression (CX + CD): ",                      // Возврат строки сообщения в "en-US" кодировке
                _ => throw new Exception("Unsupported culture"),  // Возврат ошибки с неподдерживаемой культурой
            };
        } 
        // Выбор операции
        public   String GetEnterOperationMessage(String? culture = null)  
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
        public   String GetResultMessage(String userInput, RomanNumber res, String? culture = null)  
        {
            if (culture == null) culture = Culture;               // Если переданный параметр null то локализакция устанавливается по умолчанию
            return culture switch                                 
            {                                                     
                "uk-UA" => $"\nРезультат: {userInput} = {res}",                   // Возврат строки сообщения в "uk-UA" кодировке
                "en-US" => $"\nResult: {userInput} = {res}",                      // Возврат строки сообщения в "en-US" кодировке
                _ => throw new Exception("Unsupported culture"),  // Возврат ошибки с неподдерживаемой культурой
            };
        }
    }
}
