// 7 и 6 практика

using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Регулярные выражения\n");

        // 1. Отрывок текста (локальный, без интернета)
        Console.WriteLine("1. Исходный текст:");
        string text = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа. " +
                      "Регулярные выражения в C# - это мощный инструмент для обработки текста. " +
                      "Программисты часто используют регулярные выражения для поиска и замены. " +
                      "Регулярные выражения позволяют находить email: test@example.com и номера: 123-456-7890. " +
                      "Россия - великая страна. Регулярные выражения экономят время. " +
                      "Изучение регулярных выражений требует практики. Регулярки - это круто!";
        
        Console.WriteLine($"\"{text}\"\n");

        // 2. Посчитать количество символов, слов, словосочетаний
        Console.WriteLine("2. Статистика текста:");
        
        // Количество символов
        int charCountWithSpaces = text.Length;
        int charCountWithoutSpaces = text.Replace(" ", "").Replace("\n", "").Replace("\r", "").Length;
        Console.WriteLine($"   - Символов (с пробелами): {charCountWithSpaces}");
        Console.WriteLine($"   - Символов (без пробелов): {charCountWithoutSpaces}");
        
        // Количество слов
        Regex wordRegex = new Regex(@"\w+");
        MatchCollection words = wordRegex.Matches(text);
        Console.WriteLine($"   - Количество слов: {words.Count}");
        
        string phrase = "регулярных выражений";
        Regex phraseRegex = new Regex(phrase, RegexOptions.IgnoreCase);
        int phraseCount = phraseRegex.Matches(text).Count;
        Console.WriteLine($"   - Словосочетаний \"{phrase}\": {phraseCount}");
        
        // количество символа 'а'
        char targetChar = 'а';
        int charCountTarget = 0;
        foreach (char c in text.ToLower())
            if (c == targetChar) charCountTarget++;
        Console.WriteLine($"   - Символов '{targetChar}': {charCountTarget}\n");
        
        // вывести строки, начинающиеся с 'Р'
        Console.WriteLine("3. Строки, начинающиеся с 'Р':");
        string[] lines = text.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string trimmed = line.Trim();
            if (trimmed.Length > 0 && trimmed[0] == 'Р')
            {
                Console.WriteLine($"   {trimmed}.");
            }
        }
        
        // вывести строки, оканчивающиеся на 'ения'
        Console.WriteLine("\n4. Строки, оканчивающиеся на 'ения':");
        foreach (string line in lines)
        {
            string trimmed = line.Trim();
            if (trimmed.EndsWith("ения"))
            {
                Console.WriteLine($"   {trimmed}.");
            }
        }
        
        // изменить часть текста (замена 'регулярные' на 'РЕГУЛЯРНЫЕ')
        Console.WriteLine("\n5. Изменение текста (замена 'регулярные' на 'РЕГУЛЯРНЫЕ'):");
        string modifiedText = Regex.Replace(text, "регулярные", "РЕГУЛЯРНЫЕ", RegexOptions.IgnoreCase);
        Console.WriteLine($"   {modifiedText}\n");
        
        Console.WriteLine("\nУказатели\n");
        
        // работа с указателями
        UnsafePointerDemo();
        
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
    
    unsafe static void UnsafePointerDemo()
    {
        // базовые операции с указателями
        Console.WriteLine("1. Базовые операции * и &:");
        int* ptr1;
        int value1 = 42;
        ptr1 = &value1;
        
        Console.WriteLine($"   Значение value1: {value1}");
        Console.WriteLine($"   Значение по указателю: {*ptr1}");
        Console.WriteLine($"   Адрес value1: {(ulong)ptr1:X}");
        
        *ptr1 = 100;
        Console.WriteLine($"   После *ptr1 = 100: value1 = {value1}\n");
        
        // несколько переменных в разных ячейках памяти
        Console.WriteLine("2. Переменные в разных ячейках памяти:");
        
        int var1 = 10;
        int var2 = 20;
        int var3 = 30;
        int var4 = 40;
        int var5 = 50;
        
        int* p1 = &var1;
        int* p2 = &var2;
        int* p3 = &var3;
        int* p4 = &var4;
        int* p5 = &var5;
        
        Console.WriteLine($"   var1 = {var1}, адрес: {(ulong)p1:X}");
        Console.WriteLine($"   var2 = {var2}, адрес: {(ulong)p2:X}");
        Console.WriteLine($"   var3 = {var3}, адрес: {(ulong)p3:X}");
        Console.WriteLine($"   var4 = {var4}, адрес: {(ulong)p4:X}");
        Console.WriteLine($"   var5 = {var5}, адрес: {(ulong)p5:X}");
        
        // изменение переменных через указатели
        Console.WriteLine("\n3. Изменение переменных через указатели:");
        
        *p1 = *p1 + 5;      // var1 = 15
        *p2 = *p2 * 2;      // var2 = 40
        *p3 = *p3 - 10;     // var3 = 20
        *p4 = *p4 / 2;      // var4 = 20
        *p5 = *p5 + 100;    // var5 = 150
        
        Console.WriteLine($"   После изменений:");
        Console.WriteLine($"   var1 = {var1} (было 10)");
        Console.WriteLine($"   var2 = {var2} (было 20)");
        Console.WriteLine($"   var3 = {var3} (было 30)");
        Console.WriteLine($"   var4 = {var4} (было 40)");
        Console.WriteLine($"   var5 = {var5} (было 50)");
        
        // указатель на указатель
        Console.WriteLine("\n4. Указатель на указатель:");
        int x = 77;
        int* ptrX = &x;
        int** ptrPtrX = &ptrX;
        
        Console.WriteLine($"   x = {x}");
        Console.WriteLine($"   *ptrX = {*ptrX}");
        Console.WriteLine($"   **ptrPtrX = {**ptrPtrX}");
        Console.WriteLine($"   Адрес ptrX: {(ulong)ptrPtrX:X}");
        
        **ptrPtrX = 99;
        Console.WriteLine($"   После **ptrPtrX = 99: x = {x}\n");
        
        // арифметика указателей с массивом
        Console.WriteLine("5. Арифметика указателей (массив):");
        int[] arr = { 10, 20, 30, 40, 50 };
        
        fixed (int* arrPtr = arr)
        {
            Console.WriteLine($"   Первый элемент: {*arrPtr}");
            Console.WriteLine($"   Второй элемент: {*(arrPtr + 1)}");
            Console.WriteLine($"   Третий элемент: {*(arrPtr + 2)}");
            
            Console.Write("   Все элементы: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{*(arrPtr + i)} ");
            }
            Console.WriteLine();
        }
        
        // сравнение адресов
        Console.WriteLine("\n6. Сравнение адресов:");
        if (p1 < p2)
            Console.WriteLine($"   Адрес var1 ({((ulong)p1):X}) МЕНЬШЕ адреса var2 ({((ulong)p2):X})");
        else
            Console.WriteLine($"   Адрес var1 ({((ulong)p1):X}) БОЛЬШЕ адреса var2 ({((ulong)p2):X})");
        
        Console.WriteLine($"   Разница: {Math.Abs((long)p2 - (long)p1)} байт");
    }
}