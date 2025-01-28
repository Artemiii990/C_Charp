using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            MorseConverter converter = new MorseConverter();

            Console.WriteLine("Enter text to translate to Morse code:");
            string inputText = Console.ReadLine();
            string morseCode = converter.TextToMorse(inputText);
            Console.WriteLine($"Morse code: {morseCode}");

            Console.WriteLine("\nEnter Morse code to translate to text:");
            string inputMorse = Console.ReadLine();
            string plainText = converter.MorseToText(inputMorse);
            Console.WriteLine($"Text: {plainText}");
        }
    }

    public class MorseConverter
    {
        public enum MorseCharacters
        {
            a, b, c, d, e, f, g, h, i, j, k, l, m,
            n, o, p, q, r, s, t, u, v, w, x, y, z,
        }
        
        private readonly string[] _morseCodes = {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---",
            "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-",
            "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---",
            "...--", "....-", ".....", "-....", "--...", "---..", "----.", "/"
        };
  
        public string TextToMorse(string text)
        {
            StringBuilder morseBuilder = new StringBuilder();
            foreach (char c in text)
            {
                if (Enum.TryParse(c.ToString(), out MorseCharacters morseChar))
                {
                    morseBuilder.Append(_morseCodes[(int)morseChar] + " ");
                }
                else
                {
                    morseBuilder.Append("? ");
                }
            }

            return morseBuilder.ToString();
        }

        public string MorseToText(string morseCode)
        {
            StringBuilder textBuilder = new StringBuilder();
            string[] morseLetters = morseCode.Split(' ');


            foreach (string morseLetter in morseLetters)
            {
                int index = Array.IndexOf(_morseCodes, morseLetter);
                if (index != -1)
                {
                    textBuilder.Append(Enum.GetName(typeof(MorseCharacters), index));
                }
                else
                {
                    textBuilder.Append("");
                }
            }
            return textBuilder.ToString();
        }
    }
}
