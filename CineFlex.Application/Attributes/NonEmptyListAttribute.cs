using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Attributes
{
    public class NonEmptyListAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;

            if (value is System.Collections.IList list)
                return list.Count > 0;

            return false;
        }
    }
}
