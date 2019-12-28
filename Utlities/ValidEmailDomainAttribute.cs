using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployManagment.core.Utlities
{
    // To make this class work with attribute Validation we should make this class inhirit from ValidationAttribute
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string allowedeDomain;

        public ValidEmailDomainAttribute(string allowedeDomain)
        {
            this.allowedeDomain = allowedeDomain;
        }
        public override bool IsValid(object value)
        {
            var emailSplited = value.ToString().Split('@');
            return emailSplited[1].ToUpper() == allowedeDomain.ToString().ToUpper();
        }
    }
}
