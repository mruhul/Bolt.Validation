using System.Text.RegularExpressions;

namespace Bolt.Validation.Extensions
{
    public static class RuleCheckerUnitStringExtensions
    {
        public static TRuleChecker NotEmpty<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, string> source)
            where TRuleChecker : RuleChecker
        {
            return source
                .DefaultErrorMessage(Messages.NotEmpty, source.GetPropertyName())
                .That(value => !string.IsNullOrWhiteSpace(value));
        }

        public static TRuleChecker MaxLength<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, string> source, int maxLength)
            where TRuleChecker : RuleChecker
        {
            return source
                .DefaultErrorMessage(Messages.MaxLength, source.GetPropertyName(), maxLength)
                .That(value => value == null || value.Length <= maxLength);
        }

        public static TRuleChecker MinLength<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, string> source, int minLength)
            where TRuleChecker : RuleChecker
        {
            return source
                .DefaultErrorMessage(Messages.MinLength, source.GetPropertyName(), minLength)
                .That(value => value == null || value.Length >= minLength);
        }

        public static TRuleChecker Match<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, string> source, string pattern)
            where TRuleChecker : RuleChecker
        {
            return source
                .DefaultErrorMessage(Messages.NotMatched, source.GetPropertyName(), pattern)
                .That(value => value == null || Regex.IsMatch(value, pattern));
        }

        public static TRuleChecker Match<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, string> source, Regex pattern)
            where TRuleChecker : RuleChecker
        {
            return source
                .DefaultErrorMessage(Messages.NotMatched, source.GetPropertyName(), pattern)
                .That(value => value == null || pattern.IsMatch(value));
        }

        private static readonly Regex EmailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled | RegexOptions.Singleline);
        public static TRuleChecker Email<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, string> source)
            where TRuleChecker : RuleChecker
        {
            return source
                .DefaultErrorMessage(Messages.InvalidEmail, source.GetPropertyName())
                .That(value => value == null || EmailRegex.IsMatch(value));
        }

        private static readonly Regex UrlRegex = new Regex(@"^\w+://(?:[\w-]+(?:\:[\w-]+)?\@)?(?:[\w-]+\.)+[\w-]+(?:\:\d+)?[\w- ./?%&=\+]*$", RegexOptions.Compiled | RegexOptions.Singleline);
        public static TRuleChecker Url<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, string> source)
            where TRuleChecker : RuleChecker
        {
            return source
                .DefaultErrorMessage(Messages.InvalidUrl, source.GetPropertyName())
                .That(value => value == null || UrlRegex.IsMatch(value));
        }
    }
}