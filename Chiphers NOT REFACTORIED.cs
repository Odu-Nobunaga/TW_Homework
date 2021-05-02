using System;

namespace lab_11
{
    interface Ciphers
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
    class Vigenere : Ciphers // Шифр Виженера
    {
        private static char[] arr = {   'a', 'b', 'c', 'd', 'e', // Массив символов
                                          'f', 'g', 'h', 'i', 'j',
                                          'k', 'l', 'm', 'n', 'o', 'p',
                                          'q', 'r', 's', 't', 'u', 'v',
                                          'w', 'x', 'y', 'z', ' ', '1',
                                          '2', '3', '4', '5', '6', '7',
                                          '8', '9', '0'
                                      };
        private int a = arr.Length;
        private string chipher_key;
        public Vigenere(string key)
        {
            this.chipher_key = key.ToLower();
        }
        public string Encrypt(string text)
        {
            text = text.ToLower(); // Меняем в нижний регистр
            string result = "";
            int keyIndex = 0; // Индекс буквы ключа
            foreach (char s in text)
            {
                int esn = (Array.IndexOf(arr, s) + Array.IndexOf(arr, chipher_key[keyIndex])) % a; // Вычисление номера символа для замещения

                result += arr[esn]; // Добавляем в результат зашифрованный символ

                keyIndex++; // Увеличиваем индекс ключа

                if ((keyIndex + 1) == chipher_key.Length)
                    keyIndex = 0; // Обнуление индекса
            }
            return result;
        }
        public string Decrypt(string text)
        {
            text = text.ToLower();
            string result = "";
            int keyInd = 0;
            foreach (char symbol in text)
            {
                int dsn = (Array.IndexOf(arr, symbol) + a - Array.IndexOf(arr, chipher_key[keyInd])) % a;
                result += arr[dsn];
                keyInd++;
                if ((keyInd + 1) == chipher_key.Length)
                    keyInd = 0;
            }
            return result;
        }
    }
    //Атбаш
    public class Atbash : Ciphers
    {
        private const string alphabet = "abcdefghijklmnopqrstuvwxyz";  //алфавит языка
        private string Reverse(string inputText)        //метод для переворачивания строки
        {
            var reversedText = string.Empty;
            foreach (var s in inputText)
            {
                //добавляем символ в начало строки
                reversedText = s + reversedText;
            }
            return reversedText;
        }
        //метод шифрования/дешифрования
        private string EncryptDecrypt(string text, string symbols, string cipher)
        {
            //переводим текст в нижний регистр
            text = text.ToLower();
            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                //поиск позиции символа в строке алфавита
                var index = symbols.IndexOf(text[i]);
                if (index >= 0)
                {
                    //замена символа на шифр
                    outputText += cipher[index].ToString();
                }
            }
            return outputText;
        }
        //шифрование текста
        public string Encrypt(string plainText)
        {
            return EncryptDecrypt(plainText, alphabet, Reverse(alphabet));
        }
        //расшифровка текста
        public string Decrypt(string encryptedText)
        {
            return EncryptDecrypt(encryptedText, Reverse(alphabet), alphabet);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("выберете шифр:");
            Console.WriteLine("1 - шифр Виженера");
            Console.WriteLine("2 - Атбаш ");
            int port = int.Parse(Console.ReadLine());
            Ciphers cipher = null;
            switch (port)
            {
                case 1:
                    Console.WriteLine("Вижинер шифрование");
                    string Vigenere_Key; 
                    Console.WriteLine("Введите ключ");
                    Vigenere_Key = Console.ReadLine();
                    cipher = new Vigenere(Vigenere_Key);
                    Console.WriteLine("Введите текст");
                    string text = Console.ReadLine();
                    string ciphertext = cipher.Encrypt(text);
                    Console.WriteLine("Шифровка");
                    Console.WriteLine(ciphertext);
                    text = cipher.Decrypt(ciphertext);
                    Console.WriteLine("Расшифровка");
                    Console.WriteLine(text);
                    break;
                case 2:
                    Console.WriteLine("Атбаш шифрование");
                    var atbash = new Atbash();
                    Console.Write("Введите текст сообщения: ");
                    var message = Console.ReadLine();
                    var encryptedMessage = atbash.Encrypt(message);
                    Console.WriteLine("Зашифрованное сообщение: {0}", encryptedMessage);
                    var decryptedMessage = atbash.Decrypt(encryptedMessage);
                    Console.WriteLine("Расшифрованное сообщение: {0}", decryptedMessage);
                    break;
            }
        }
    }
}

