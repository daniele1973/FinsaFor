using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinsaWeb.Models.Exceptions
{
    [Serializable()]
    public class BusinessLogicException : Exception
    {
 
        public BusinessLogicException() : base() { }
        public BusinessLogicException(string message) : base(message) { }
        public BusinessLogicException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected BusinessLogicException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }

}
