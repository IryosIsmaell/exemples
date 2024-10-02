using Ark.CrossCutting.Validators;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Ark.CrossCutting.Attributes
{
    public sealed class DocumentBRAttribute : ValidationAttribute
    {
        public DocumentBRAttribute()
        {
            this.ErrorMessage = ErrorMessage ?? "O número do documento {0}, é inválido.";
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"O objeto não contém nenhuma propriedade com nome '{validationContext.MemberName}'");
            }

            if (value != null)
            {
                var isValid = DocumentBRValidation.IsValid((string)value);

                if (!isValid)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return null;
        }
    }
}
