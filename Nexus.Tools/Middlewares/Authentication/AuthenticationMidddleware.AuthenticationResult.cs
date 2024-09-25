using System.Collections.Generic;

namespace Nexus.Tools.Validations.Middlewares.Authentication;

/// <summary>
/// Result for authentication validation 
/// </summary>
/// <remarks>
/// Constructor for validation 
/// </remarks>
/// <param name="isValidLogin"></param>
/// <param name="confirmedAccount"></param>
public sealed class AuthenticationResult(bool isValidLogin, bool confirmedAccount)
{
    /// <summary>
    /// Indicates whether the authentication and valid.
    /// </summary>
    public bool IsValidLogin { get; set; } = isValidLogin;

    /// <summary>
    /// Indicates whether the account for the login has been confirmed using additional means.
    /// </summary>
    public bool ConfirmedAccount { get; set; } = confirmedAccount;

    /// <summary>
    /// Min Required Client Authentication Level
    /// </summary>
    public int AuthenticationLevel { get; set; } = 1;

    /// <summary>
    /// Defines if this access is of resource owner
    /// </summary>
    public bool IsOwner { get; set; } = true;

    /// <summary>
    /// Define this Authentication Authorized Scopes
    /// </summary>
    public IEnumerable<string> Scopes { get; set; } = [];

    /// <summary>
    /// Constructor for validation result 
    /// </summary>
    /// <param name="isValidLogin">confirm if is valid login</param>
    /// <param name="confirmedAccount">Confirm if account is confirmed</param>
    /// <param name="authenticationLevel">Min Required authentication level</param>
    public AuthenticationResult(bool isValidLogin, bool confirmedAccount, int authenticationLevel) : this(isValidLogin, confirmedAccount)
    {
        AuthenticationLevel = authenticationLevel;
    }

    /// <summary>
    /// Constructor for validation result 
    /// </summary>
    /// <param name="isValidLogin">confirm if is valid login</param>
    /// <param name="confirmedAccount">Confirm if account is confirmed</param>
    /// <param name="scopes">Authentication scopes</param>
    public AuthenticationResult(bool isValidLogin, bool confirmedAccount, IEnumerable<string> scopes)
        : this(isValidLogin, confirmedAccount)
    {
        Scopes = scopes;
    }
}