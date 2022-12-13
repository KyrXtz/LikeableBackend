namespace SharedKernel
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; private set; }
        public string Error { get; private set; }

        public static implicit operator Result<T>(string error)
            => new Result<T> { Succeeded = false, Error = error };

        public static implicit operator Result<T>(T data)
            => new Result<T> { Succeeded = true, Data = data };
        public static Result<T> Success(T data)
            => new Result<T> { Succeeded = true, Data = data };
        public static Result<T> Fail(string error)
            => new Result<T> { Succeeded = false, Error = error };

    }
}
