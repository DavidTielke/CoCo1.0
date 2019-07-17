using System;
using System.Runtime.Serialization;

namespace DavidTielke.PersonManagementApp.Data.DataStoring.Contract.Exceptions
{
    [Serializable]
    public class EntityAlreadyInStoreException : DataStoringException
    {
        public EntityAlreadyInStoreException()
        {
        }

        public EntityAlreadyInStoreException(string message) : base(message)
        {
        }

        public EntityAlreadyInStoreException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EntityAlreadyInStoreException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}