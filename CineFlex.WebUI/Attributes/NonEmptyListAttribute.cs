using System.ComponentModel.DataAnnotations;

namespace CineFlex.WebUI.Attributes
{
    public class NonEmptyListAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is null)
                return false;

            if (value is System.Collections.IList list)
                return list.Count > 0;

            return false;
        }
    }
}