using System;
using System.Runtime.Serialization;

namespace DavidTielke.PersonManagementApp.Logic.PersonManagement.Contract.Exceptions
{
    [Serializable]
    public class PersonManagementException : Exception
    {
        public PersonManagementException()
        {
        }

        public PersonManagementException(string message) : base(message)
        {
        }

        public PersonManagementException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PersonManagementException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
