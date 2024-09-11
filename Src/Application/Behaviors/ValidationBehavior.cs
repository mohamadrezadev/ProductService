using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Application.Behaviors;
public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;
  
    public async Task<TResponse> Handle( TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken )
    {
        //pre
        var context=new ValidationContext<TRequest>(request);
        var  validationfailures =await Task.WhenAll(_validators.Select(validator =>validator.ValidateAsync(context)));

        var erorrs = validationfailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult=>validationResult.Errors)
            .Select(validationfailures=>$"{validationfailures.PropertyName},{validationfailures.ErrorMessage}")
            .ToList();

        if (erorrs.Any())
            throw new BusinessValidationException(erorrs);

        //nex
         var response=await next();
        
        //post
        return response;
    }
}
public class BusinessValidationException : Exception
{
    public List<string> Errors { get; set; }
    public BusinessValidationException(List<string> Errors)
    {
        this.Errors = Errors;
    }
}

