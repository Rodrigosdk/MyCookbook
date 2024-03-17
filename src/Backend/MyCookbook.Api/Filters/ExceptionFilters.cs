using MyCookbook.Communication.Response;
using MyCookbook.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using MyCookbook.Exceptions;

namespace MyCookbook.Api.Filters
{
    public class ExceptionFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MyCookbookException)
            {
                TreatMyCookbookException(context);
            }
            else
            {
                ThrowUnknownError(context);
            }
        }

        private static void TreatMyCookbookException(ExceptionContext context)
        {

            if (context.Exception is ValidationErrorsException)
            {
                TreatErrorValidationException(context);
            }
        }

        private static void TreatErrorValidationException(ExceptionContext context) 
        {
            var errorValidationException = context.Exception as ValidationErrorsException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ErrorResponse(errorValidationException!.MessagesErrors));
        }

        private static void ThrowUnknownError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new ObjectResult(new ErrorResponse(ResourceErrorMessage.UNKNOWN_ERROR));
        }
    }
}
