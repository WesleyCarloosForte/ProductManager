using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Application.Common.Response
{
 public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T? Value { get; private set; }
        public string[] Errors { get; private set; } = Array.Empty<string>();

        private Result() { }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };

        public static Result<T> Failure(params string[] errors) => new Result<T> { IsSuccess = false, Errors = errors };
    }
}
