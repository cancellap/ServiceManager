using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domaiin.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation()
        {
        }

        public DomainExceptionValidation(string? message) : base(message)
        {
        }

        public DomainExceptionValidation(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DomainExceptionValidation(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}
