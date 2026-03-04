using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.Application.Exceptions
{
    public class NotFoundException : ExternalException
    {
        public NotFoundException(string message): base(message)
        {
        }

        public NotFoundException(string entityName, object key)
            : base($"{entityName} with key '{key}' was not found.")
        {
        }
    }
}
