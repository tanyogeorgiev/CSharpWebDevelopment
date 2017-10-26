

namespace GameStore.App.Infrastructure.Validations
{

    using SimpleMvc.Framework.Attributes.Validation;
    public class RequiredAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {

            return new System.ComponentModel.DataAnnotations.RequiredAttribute().IsValid(value);
        }
    }
}
