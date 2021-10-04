using System;
using System.Runtime.Serialization;

namespace Trpo_task_1.Drozdov
{
    [Serializable]
    public class DrozdovException : Exception
    {
        public DrozdovException()
        {
        }

        public DrozdovException(string message) : base(message)
        {
        }

        public DrozdovException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DrozdovException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}