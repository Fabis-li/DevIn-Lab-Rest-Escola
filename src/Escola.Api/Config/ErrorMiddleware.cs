using System.Net;
using Escola.Domain.DTO;
using Escola.Domain.Exceptions;

namespace Escola.Api.Config;

private readonly RequestDelegate _next;
public class ErrorMiddleware
{
    public ErrorMiddleware(RequestDelegate next)
    {
       
    }

    public async Task InvokeAsync (HttpContext context)
    {
        
           
    }

    private Task TratamentoExcessao(HttpContext context, Exception ex)
    {
        HttpStatusCode status;
        string messege;
        if(ex is DuplicadoException){
            status = HttpStatusCode.NotAcceptable;
            messege = ex.Message;
        }
        else{
            status = HttpStatusCode.InternalServerError;
            messege = "Ocorreu um erro favor contactar a TI";
        }

        var response = new ErrorDTO(message);

        context.Response.StatusCode = (int) status;
        return context.Response.WriteAsJsonAsync(response);
        

    }
}
