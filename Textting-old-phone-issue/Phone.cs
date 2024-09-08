using System.Text;

namespace Textting_old_phone_issue;

public class Phone
{
    private readonly Dictionary<string, char> _alphabet = new()
    {
        { "2", 'A' },
        { "22", 'B' },
        { "222", 'C' },

        { "3", 'D' },
        { "33", 'E' },
        { "333", 'F' },

        { "4", 'G' },
        { "44", 'H' },
        { "444", 'I' },

        { "5", 'J' },
        { "55", 'K' },
        { "555", 'L' },

        { "6", 'M' },
        { "66", 'N' },
        { "666", 'O' },

        { "7", 'P' },
        { "77", 'Q' },
        { "777", 'R' },
        { "7777", 'S' },

        { "8", 'T' },
        { "88", 'U' },
        { "888", 'V' },

        { "9", 'W' },
        { "99", 'X' },
        { "999", 'Y' },
        { "9999", 'Z' },

        { "0", ' ' }
    };

    public string SendMessage(string codeMessage)
    {
        if (!codeMessage.Contains('#'))
            return string.Empty;

        var result = new StringBuilder();
        char? lastChar = null;
        var repeater = 1;
        foreach (var currChar in codeMessage.TakeWhile(currChar => currChar != '#'))
        {
            switch (currChar)
            {
                case ' ':
                    lastChar = null;
                    repeater = 1;
                    continue;
                case '*':
                    result.Remove(result.Length - 1, 1);
                    continue;
            }

            if (lastChar == currChar)
            {
                repeater += 1;
                result.Remove(result.Length - 1, 1);
            }
            else
            {
                repeater = 1;
            }

            // Try to add normal letter
            if (_alphabet.TryGetValue(new string(currChar, repeater), out var mes))
            {
                result.Append(mes);
            }
            else
            {
                // Try to handle cycling recording of the letter
                repeater = 1;
                try
                {
                    result.Append(_alphabet[new string(currChar, repeater)]);
                }
                catch (KeyNotFoundException)
                {
                    throw new TextingException(new string(currChar, repeater));
                }
            }

            lastChar = currChar;
        }


        return result.ToString().Trim();
    }
}