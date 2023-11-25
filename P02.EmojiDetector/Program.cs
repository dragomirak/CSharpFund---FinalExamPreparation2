using System.Text.RegularExpressions;

namespace P02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coolThreshholdPattern = @"\d";
            string emojiPattern = @"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string emojiCoolnessPattern = @"\w";

            List<string> allEmoji = new List<string>();
            List<string> validEmoji = new List<string>();

            string input = Console.ReadLine();
            long threshhold = 1;

            foreach (Match match in Regex.Matches(input, coolThreshholdPattern))
            {
                threshhold *= long.Parse(match.Value);
            }

            foreach (Match match in Regex.Matches(input, emojiPattern))
            {
                string emoji = match.Value;
                allEmoji.Add(emoji);
            }

            foreach (string emoji in allEmoji)
            {
                int emojiCoolness = 0;
                foreach (Match match in Regex.Matches(emoji, emojiCoolnessPattern))
                {
                    emojiCoolness += char.Parse(match.Value);
                }

                if (emojiCoolness >= threshhold)
                {
                    validEmoji.Add(emoji);
                }
            }

            Console.WriteLine($"Cool threshold: {threshhold}");
            Console.WriteLine($"{allEmoji.Count} emojis found in the text. The cool ones are:");
            foreach (string emoji in validEmoji)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}