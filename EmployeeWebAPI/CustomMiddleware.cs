
namespace EmployeeWebAPI.API;
public class CustomMiddleware : IMiddleware
{
    private readonly ILogger<CustomMiddleware> _logger;
    public CustomMiddleware(ILogger<CustomMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
        }
        finally
        {
            _logger.LogInformation("Custom middleware Executing...");
        }
    }
}
