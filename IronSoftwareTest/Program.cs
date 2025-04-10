using System.Text;

namespace IronSoftwareTest
{
    /// <summary>
    /// A class to decode strings entered using an old-style mobile phone keypad.
    /// Supports multi-press characters, backspace (*), pause (space), and send (#).
    /// </summary>
    public class OldPhonePadDecoder
    {
        private static readonly Dictionary<char, string> Keypad = new Dictionary<char, string>
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "},
        };

        /// <summary>
        /// Decodes the input string entered using the old phone keypad.
        /// </summary>
        /// <param name="input">Keypad input ending with '#'</param>
        /// <returns>Decoded output string</returns>
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input) || input[^1] != '#')
                return ""; // Must end with send

            input = input[..^1]; // Remove '#'
            StringBuilder output = new StringBuilder();
            StringBuilder currentSequence = new StringBuilder();
            char? lastChar = null;

            foreach (char c in input)
            {
                if (c == ' ')
                {
                    AppendSequence(currentSequence, output);
                    currentSequence.Clear();
                    lastChar = null;
                }
                else if (c == '*')
                {
                    if (currentSequence.Length > 0)
                    {
                        AppendSequence(currentSequence, output);
                        currentSequence.Clear();
                    }
                    if (output.Length > 0)
                        output.Length--; // backspace
                    lastChar = null;
                }
                else if (char.IsDigit(c))
                {
                    if (lastChar != null && c != lastChar)
                    {
                        AppendSequence(currentSequence, output);
                        currentSequence.Clear();
                    }
                    currentSequence.Append(c);
                    lastChar = c;
                }
            }

            // Final append
            AppendSequence(currentSequence, output);
            return output.ToString();
        }

        private static void AppendSequence(StringBuilder sequence, StringBuilder output)
        {
            if (sequence.Length == 0) return;

            char digit = sequence[0];
            if (!Keypad.ContainsKey(digit)) return;

            string letters = Keypad[digit];
            if (letters.Length == 0) return;

            int index = (sequence.Length - 1) % letters.Length;
            output.Append(letters[index]);
        }
    }

    /// <summary>
    /// Sample test cases to verify functionality
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Test("33#", "E");
            Test("227*#", "B");
            Test("4433555 555666#", "HELLO");
            Test("8 88777444666*664#", "TURING");
            Test("2 22 222#", "ABC");
            Test("7777 9999 33 33#", "SZEE");
        }

        static void Test(string input, string expected)
        {
            string result = OldPhonePadDecoder.OldPhonePad(input);
            Console.WriteLine($"Input: {input} => Output: {result} {(result == expected ? "✓" : $"✗ (Expected: {expected})")}");
        }
    }
}
