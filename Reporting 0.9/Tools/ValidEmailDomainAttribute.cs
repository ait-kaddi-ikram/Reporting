using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.Tools
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        private readonly string domain;

        public ValidEmailDomainAttribute(string Domain)
        {
            this.domain = Domain;
        }
        public override bool IsValid(object value)
        {
            string[] values = value.ToString().Split('@');
            string[] domains = this.domain.Split(';');
            foreach(string dom in domains)
            {
                if (values[1].ToLower() == dom.ToLower())
                {
                    return true;
                }
            }
            return false;
           
         
        }
    }
}
