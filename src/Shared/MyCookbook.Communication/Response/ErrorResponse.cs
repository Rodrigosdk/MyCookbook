namespace MyCookbook.Communication.Response;

public class ErrorResponse
{
    public List<string> Messages { get; set; }

    public ErrorResponse(string messages)
    {
        Messages = new List<string> { messages };
    }

    public ErrorResponse(List<string> messages)
    {
        Messages = messages;
    }
}
