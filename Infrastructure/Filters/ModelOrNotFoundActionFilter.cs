namespace Infrastructure.Filters
{
    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            var validationErrors = context.ModelState.Keys
                .SelectMany(x => context.ModelState[x].Errors)
                .Select(x => x.ErrorMessage);
            var errors = new
            {
                messages = validationErrors
            };

            context.Result = new BadRequestObjectResult(errors);
        }
    }
}
