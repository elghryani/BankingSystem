using BankingSystem.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Exceptions
{
    public class GlobalExceptionHandler(
        IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            ProblemDetails problem = exception switch
            {
                ValidationException ex => new ValidationProblemDetails(
                    ex.Errors.GroupBy(g => g.PropertyName)
                    .ToDictionary(g => g.Key,g=> g.Select(e => e.ErrorMessage).ToArray()))
                {
                    Title = "ValidationError",
                    Status = StatusCodes.Status400BadRequest,
                },

                NotFoundException => new ProblemDetails
                {
                    Title = "Resource not found!",
                    Detail = exception.Message,
                    Status = StatusCodes.Status404NotFound
                },

                _ => new ProblemDetails
                {
                    Title = "Server Error",
                    Detail = "An Unhandled exception",
                    Status = StatusCodes.Status500InternalServerError
                }

            };

            httpContext.Response.StatusCode = problem.Status!.Value;

            await problemDetailsService.WriteAsync(new ProblemDetailsContext 
            {
                 HttpContext = httpContext,
                 ProblemDetails = problem
            });

            return true;
           
        }
    }
}