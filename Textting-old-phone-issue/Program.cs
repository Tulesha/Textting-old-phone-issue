using System.Text;

var tel = new Telephone();
Console.WriteLine(tel.SendMessage("44 45*#"));
Console.WriteLine(tel.SendMessage("4433555 555666096667775553#"));
Console.WriteLine(tel.SendMessage("34447288555#"));
Console.WriteLine(tel.SendMessage("4433999#"));
Console.WriteLine(tel.SendMessage("666 6633089666084477733 33#"));
Console.WriteLine(tel.SendMessage("00 11 22#"));

Console.ReadLine();

public class Telephone
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
        var result = new StringBuilder();
        char? lastChar = null;
        var repeater = 1;
        try
        {
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

                result.Append(_alphabet[new string(currChar, repeater)]);

                lastChar = currChar;
            }
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Invalid message sequence");
        }

        return result.ToString();
    }
}