namespace MyCookbook.Exceptions.ExceptionBase;

public class ValidationErrorsException : MyCookbookException 
{
    public List<string> MessagesErrors { get; set; }

    public ValidationErrorsException(List<string> messagesErrors)
    {
        MessagesErrors = messagesErrors;
    }
}
