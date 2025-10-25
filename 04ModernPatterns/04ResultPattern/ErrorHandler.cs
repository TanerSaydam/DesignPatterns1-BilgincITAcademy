using Microsoft.AspNetCore.Diagnostics;

namespace _04ResultPattern;

public sealed class ErrorHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var res = Result<string>.Failed(exception.Message);

        await httpContext.Response.WriteAsJsonAsync(res);

        return true;
    }
}
