using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            if (isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode =  502;
                context.Result = context.Exception is FluentValidation.ValidationException validMessage ? 
                    new JsonResult(validMessage.Errors) :
                    new JsonResult("An error ocorred");
                context.ExceptionHandled = true;
            }
            base.OnException(context);
        }
    }
}
