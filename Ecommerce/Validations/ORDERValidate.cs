using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models;

public partial class ORDER : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            yield return new ValidationResult("Họ Tên không được để trống!", new[] { nameof(name) });
        }
        if (string.IsNullOrWhiteSpace(phone))
        {
            yield return new ValidationResult("Số điện thoại không được để trống!", new[] { nameof(phone) });
        }
        if (string.IsNullOrWhiteSpace(address))
        {
            yield return new ValidationResult("Địa chỉ giao hàng không được để trống!", new[] { nameof(address) });
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            yield return new ValidationResult("Email không được để trống!", new[] { nameof(email) });
        }


    }
}
