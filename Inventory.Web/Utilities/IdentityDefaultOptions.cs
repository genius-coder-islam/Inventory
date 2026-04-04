namespace Inventory.Web.Utilities
{
    public class IdentityDefaultOptions
    {
        public bool PasswordRequiredDigit { get; set; }
        public bool PasswordRequiredLowercase { get; set; }
        public bool PasswordRequiredNonAlphanumeric { get; set; }
        public bool PasswordRequiredUppercase { get; set; }
        public int PasswordRequiredLength { get; set; }
        public int PasswordRequiredUniqueChars { get; set; }
        public bool SignInRequiredConfirmedEmail { get; set; }
        public bool UserRequireUniqueEmail { get; set; }
        public string LoginPath { get; set; }
        public string LogoutPath { get; set; }
        public string AccessDeniedPath { get; set; }
        public bool SlidingExpiration { get; set; }
        public int CookieExpiration { get; set; }
        public int LockoutMaxFailedAccessAttempts { get; set; }
        public int LockoutDefaultLockoutTimeSpanInMinutes { get; set; }
        public bool LockoutAllowedForNewUsers { get; set; }
    }
}
