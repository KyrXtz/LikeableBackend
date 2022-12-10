namespace Application.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly IServiceProvider _provider;

        public ValidationBehavior(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validator = _provider.GetService<IValidator<TRequest>>();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return await next();
        }
    }
}
