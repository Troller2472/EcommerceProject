using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models;

public partial class PRODUCT : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(productName))
        {
            yield return new ValidationResult("Tên sản phẩm không được để trống!", new[] { nameof(productName) });
        }

        if (!price.HasValue)
        {
            yield return new ValidationResult("Vui lòng nhập giá sản phẩm", new[] { nameof(price) });
        }
        else if (price.Value < 0)
        {
            yield return new ValidationResult("Giá phải >= 0", new[] { nameof(price) });
        }

        if (!categoryId.HasValue)
        {
            yield return new ValidationResult("Bạn phải chọn danh mục", new[] { nameof(categoryId) });
        }
    }
}
