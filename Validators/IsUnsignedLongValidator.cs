using FluentValidation.Validators;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Validators;

public class IsUnsignedLongValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override bool IsValid(FluentValidation.ValidationContext<T> context, TProperty value)
    {
        return value switch
        {
            null => false,
            ulong v => true,
            string s => ulong.TryParse(s, out _),
            _ => false
        };
    }

    public override string Name => "IsUnsignedLongValidator";
}
