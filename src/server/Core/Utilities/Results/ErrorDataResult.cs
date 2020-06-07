using Core.Utilities.Localizations;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data, string message, int code) : base(data, false, message, code)
        {
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
        }

        public ErrorDataResult(string message, int code) : base(default, false, message, code)
        {
        }

        public ErrorDataResult(TextCode code) : base(default, false, code.GetText(), (int)code)
        {
        }
    }
}