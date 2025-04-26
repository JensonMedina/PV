using System;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
namespace Application.Common
{

    public class ValidationFilter : IActionFilter
    {
        private readonly ILoggerApp _logger;

        public ValidationFilter(ILoggerApp logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // Obtener info del controlador y acción
                var controllerName = context.ActionDescriptor.RouteValues["controller"];
                var actionName = context.ActionDescriptor.RouteValues["action"];

                //var errors = context.ModelState
                //    .Where(x => x.Value.Errors.Count > 0)
                //    .Select(x => new
                //    {
                //        Field = x.Key,
                //        Messages = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                //    }).ToArray();

                foreach (var kvp in context.ModelState)
                {
                    var fieldKey = kvp.Key;
                    var errors = kvp.Value.Errors;

                    foreach (var error in errors)
                    {
                        _logger.LogError("ValidationFilter",
                            $"[Controller: {controllerName}] [Action: {actionName}] Campo: {fieldKey} - Error: {error.ErrorMessage}");
                    }
                }

                context.Result = new BadRequestObjectResult(context.ModelState); // mantiene el comportamiento por defecto
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }

}
