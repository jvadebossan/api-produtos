using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace MenuOn.Dtos
{
    public class UmItemNaLista : ValidationAttribute
    {
        public UmItemNaLista()
        {
            ErrorMessage = "A lista deve conter pelo menos um item.";
        }

        public override bool IsValid(object value)
        {
            if (value is IList list)
            {
                return list.Count > 0;
            }
            return false;
        }

    }
}