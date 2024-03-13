﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomotive.Domain.Primitives;
/// <summary>
/// Represents a concrete domain error.
/// </summary>
public sealed class Error 
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;


    /// <summary>
    /// Gets the empty error instance.
    /// </summary>
    public static Error None => new Error(string.Empty, string.Empty);

  
}