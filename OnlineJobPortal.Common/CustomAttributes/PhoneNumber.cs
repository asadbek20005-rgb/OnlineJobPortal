using System.ComponentModel.DataAnnotations;

namespace OnlineJobPortal.Common.CustomAttributes;

public class PhoneNumber : ValidationAttribute
{

   
    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        string? phoneNumber = Convert.ToString(value);
        if (phoneNumber is null)
            return false;

        if (string.IsNullOrEmpty(phoneNumber)) return false;

        if (!phoneNumber.StartsWith("+998")) return false;

        if(phoneNumber.Length < 13) return false;

        return true;
    }
}
