using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models;

public partial class CATEGORY : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(categoryName))
        {
            yield return new ValidationResult("Tên danh mục không được để trống!", new[] { nameof(categoryName) });
        }

    }
}
