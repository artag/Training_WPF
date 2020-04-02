using System;

namespace Demo.Infrastructure.Services
{
    public class ServiceResult<T> : EventArgs
    {
        public ServiceResult(T obj)
        {
            Object = obj;
        }

        public T Object { get; }
    }
}
