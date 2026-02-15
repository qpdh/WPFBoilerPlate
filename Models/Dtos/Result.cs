namespace WPFBoilerPlate.Models.Dtos
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public T Value { get; }

        private Result(bool success, T value, string error)
        {
            IsSuccess = success;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value)
            => new Result<T>(true, value, null);

        public static Result<T> Failure(string error)
            => new Result<T>(false, default, error);
    }
}