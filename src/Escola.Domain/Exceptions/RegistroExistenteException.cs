namespace Escola.Domain.Exceptions;

public class RegistroExistenteException : Exception
{
    public RegistroExistenteException(string message) : base (message)
    {
        
    }
}