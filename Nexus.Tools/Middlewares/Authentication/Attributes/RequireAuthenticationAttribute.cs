﻿using System;

namespace Nexus.Tools.Validations.Middlewares.Authentication.Attributes;

/// <summary>
/// Informs <see cref="AuthenticationMidddleware"/> that the class or method requires autenticated user.
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
public sealed class RequireAuthenticationAttribute : Attribute
{
    /// <summary>
    ///  Informs Authentication Middleware that the class or method requires a validated account.
    /// </summary>
    public bool RequireAccountValidation { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool ShowView { get; set; }

    /// <summary>
    ///  Min required AuthenticationLevel
    /// </summary>
    public int MinAuthenticationLevel { get; set; }

    /// <summary>
    /// Required Authentication Scope
    /// </summary>
    public string? Scope { get; set; }

    /// <summary>
    /// Requires resource owner
    /// </summary>
    public bool RequiresToBeOwner { get; set; }

    public RequireAuthenticationAttribute()
    {
        ShowView = false;
        RequiresToBeOwner = true;
        MinAuthenticationLevel = 0;
    }
}