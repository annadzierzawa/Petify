﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Petify.IdentityServer.Errors
{
    public class MultiLanguageIdentityErrorDescriber : IdentityErrorDescriber
    {
        private readonly IStringLocalizer<MultiLanguageIdentityErrorDescriber> _localizer;

        public MultiLanguageIdentityErrorDescriber(IStringLocalizer<MultiLanguageIdentityErrorDescriber> localizer)
        {
            _localizer = localizer;
        }

        public override IdentityError DefaultError() =>
            new IdentityError { Code = nameof(DefaultError), Description = _localizer["An unknown failure has occurred."] };

        public override IdentityError ConcurrencyFailure() =>
            new IdentityError { Code = nameof(ConcurrencyFailure), Description = _localizer["Optimistic concurrency failure, object has been modified."] };

        public override IdentityError PasswordMismatch() =>
            new IdentityError { Code = nameof(PasswordMismatch), Description = _localizer["Incorrect password."] };

        public override IdentityError InvalidToken() =>
            new IdentityError { Code = nameof(InvalidToken), Description = _localizer["Invalid token."] };

        public override IdentityError LoginAlreadyAssociated() =>
            new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = _localizer["A user with this login already exists."] };

        public override IdentityError InvalidUserName(string userName) =>
            new IdentityError { Code = nameof(InvalidUserName), Description = string.Format(_localizer["User name {0} is invalid, can only contain letters or digits."], userName) };

        public override IdentityError InvalidEmail(string email) =>
            new IdentityError { Code = nameof(InvalidEmail), Description = string.Format(_localizer["Email {0} is invalid."], email) };

        public override IdentityError DuplicateUserName(string userName) =>
            new IdentityError { Code = nameof(DuplicateUserName), Description = string.Format(_localizer["User Name {0} is already taken."], userName) };

        public override IdentityError DuplicateEmail(string email) =>
            new IdentityError { Code = nameof(DuplicateEmail), Description = string.Format(_localizer["Email {0} is already taken."], email) };

        public override IdentityError InvalidRoleName(string role) =>
            new IdentityError { Code = nameof(InvalidRoleName), Description = string.Format(_localizer["Role name {0} is invalid."], role) };

        public override IdentityError DuplicateRoleName(string role) =>
            new IdentityError { Code = nameof(DuplicateRoleName), Description = string.Format(_localizer["Role name {0} is already taken."], role) };

        public override IdentityError UserAlreadyHasPassword() =>
            new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = _localizer["User already has a password set."] };

        public override IdentityError UserLockoutNotEnabled() =>
            new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = _localizer["Lockout is not enabled for this user."] };

        public override IdentityError UserAlreadyInRole(string role) =>
            new IdentityError { Code = nameof(UserAlreadyInRole), Description = string.Format(_localizer["User already in role {0}."], role) };

        public override IdentityError UserNotInRole(string role) =>
            new IdentityError { Code = nameof(UserNotInRole), Description = string.Format(_localizer["User is not in role {0}."], role) };

        public override IdentityError PasswordTooShort(int length) =>
            new IdentityError { Code = nameof(PasswordTooShort), Description = string.Format(_localizer["Passwords must be at least {0} characters."], length) };

        public override IdentityError PasswordRequiresNonAlphanumeric() =>
            new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = _localizer["Passwords must have at least one non alphanumeric character."] };

        public override IdentityError PasswordRequiresDigit() =>
            new IdentityError { Code = nameof(PasswordRequiresDigit), Description = _localizer["Passwords must have at least one digit ('0'-'9')."] };

        public override IdentityError PasswordRequiresLower() =>
            new IdentityError { Code = nameof(PasswordRequiresLower), Description = _localizer["Passwords must have at least one lowercase ('a'-'z')."] };

        public override IdentityError PasswordRequiresUpper() =>
            new IdentityError { Code = nameof(PasswordRequiresUpper), Description = _localizer["Passwords must have at least one uppercase ('A'-'Z')."] };
    }
}
