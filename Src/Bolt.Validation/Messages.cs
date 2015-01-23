namespace Bolt.Validation
{
    internal static class Messages
    {
        public const string NotNull = "{0} cannot be null";
        public const string NotEmpty = "{0} cannot be null or empty";
        public const string MaxLength = "{0} cannot have more than {1} characters";
        public const string MinLength = "{0} cannot have less than {1} characters";
        public const string NotEmptyOnly = "{0} cannot be empty";
        public const string GreaterThan = "{0} must be greater than {1}";
        public const string LessThan = "{0} must be less than {1}";
        public const string Range = "{0} must be within {1} and {2}";
        public const string NonZero = "{0} cannot be zero";
        public const string NotMatched = "{0} doestn't match with pattern {1}";
        public const string InvalidEmail = "{0} is not a valid email address";
        public const string InvalidUrl = "{0} is not a valid url";
    }
}
