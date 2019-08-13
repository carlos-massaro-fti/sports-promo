using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Comum.Exceptions
{
    public class AppException : Exception
    {

        public IEnumerable<ValidationResult> ValidationResults { get; }



        public AppException(string message, IEnumerable<ValidationResult> validationResults) : base(message)
        {
            ValidationResults = validationResults;
        }
    }
}
