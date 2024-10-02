using Ark.CrossCutting.Attributes;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace Ark.CrossCutting.Adapters
{
    internal class DocumentBRAttributeAdapter : AttributeAdapterBase<DocumentBRAttribute>
    {
        public DocumentBRAttributeAdapter(
            DocumentBRAttribute attribute,
            IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            string errorMessage = GetErrorMessage(context);

            AddAttribute(context.Attributes, "data-val", "true");
            AddAttribute(context.Attributes, "data-val-document", "Documento informado não é válido!");
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            string propertyDisplayName = validationContext.ModelMetadata.GetDisplayName();
            return GetErrorMessage(validationContext.ModelMetadata, propertyDisplayName);
        }

        private static void AddAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (!attributes.ContainsKey(key))
            {
                attributes.Add(key, value);
            }
        }
    }
}
