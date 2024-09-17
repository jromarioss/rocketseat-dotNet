using System.Net;

namespace CashFlow.Exception.ExceptionBase;
public class ErrorOnValidationException : CashFlowException
{
    private readonly List<string> _errors;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> ErrorMessages) : base(string.Empty)
    {
        _errors = ErrorMessages;
    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}
