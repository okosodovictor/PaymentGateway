using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentGateway.Application.Business
{
    public abstract class Model : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new ValidationResult[] { };
        }

        public Result Validate()
        {
            var errors = new List<ValidationResult>();
            var ctx = new ValidationContext(this, null, null);
            var isValid = Validator.TryValidateObject(this, ctx, errors);
            return new Result(isValid, errors);
        }

        public class Result
        {
            public bool IsValid { get; }
            public IEnumerable<ValidationResult> Errors { get; }

            public Result(bool isValid, IEnumerable<ValidationResult> errors)
            {
                IsValid = isValid;
                Errors = errors;
            }
        }
    }


}
