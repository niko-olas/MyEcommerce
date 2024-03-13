using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomotive.Domain.Primitives;
/// <summary>
/// Represents the result of some operation, with status information and possibly a value and an error.
/// </summary>
/// <typeparam name="TValue">The result value type.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue Content;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValueType}"/> class with the specified parameters.
    /// </summary>
    /// <param name="value">The result value.</param>
    /// <param name="isSuccess">The flag indicating if the result is successful.</param>
    /// <param name="error">The error.</param>
    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
        => Content = value;

    public static implicit operator Result<TValue>(TValue value) => Ok(value);

    /// <summary>
    /// Gets the result value if the result is successful, otherwise throws an exception.
    /// </summary>
    /// <returns>The result value if the result is successful.</returns>
    /// <exception cref="InvalidOperationException"> when <see cref="Result.IsFailure"/> is true.</exception>
    public TValue Value => IsSuccess
        ? Content
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");
}