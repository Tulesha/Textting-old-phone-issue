namespace Textting_old_phone_issue;

public class TextingException : Exception
{
    private readonly string _tryingParse;

    public TextingException(string tryingParse)
    {
        _tryingParse = tryingParse;
    }

    public override string Message => $"Unable to parse message with {_tryingParse} sequence";
}