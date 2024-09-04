namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{   //versões nova coloca dps do public required, ou cria um construtor
    public List<string> ErroMessages { get; set; }

    public ResponseErrorJson(string errorMessage)
    {
        ErroMessages = [errorMessage];
    }

    public ResponseErrorJson(List<string> errorMessage)
    {
        ErroMessages = errorMessage;
    }
}
