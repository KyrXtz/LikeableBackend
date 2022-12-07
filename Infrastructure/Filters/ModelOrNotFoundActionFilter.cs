namespace Infrastructure.Filters
{
    public class ModelOrNotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result is ObjectResult result)
                if(result.Value == null) 
                    context.Result = new NotFoundResult(); 

            base.OnActionExecuted(context);
        }
    }
}
