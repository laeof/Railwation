﻿using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common;

public class Result<T>
{
    private Result(T value, bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, Error.None);
    public static Result<T> Faillure(Error error) => new Result<T>(default!, false, error);
    public T Value { get; }
    public Error Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
}