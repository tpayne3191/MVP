using System.Collections.Generic;

namespace Capstone.Core
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}