using System;
using System.Runtime.Serialization;

namespace FinsaWeb.Models.CoreNocciolo
{
    [Serializable]
    public class DataException : Exception
    {
        

        public DataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}