namespace Bolt.Validation.Extensions
{
    public static class RuleCheckerUnitLongExtensions
    {
        public static TRuleChecker NonZero<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long> source)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage("{0} cannot be zero")
                    .That(value => value != 0);
        }

        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long> source, long greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(string.Format("{{0}} must be greater than {0}", greaterFrom))
                    .That(value => value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long> source, long lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source.That(value => value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long> source, long min, long max)
            where TRuleChecker : RuleChecker
        {
            return source.That(value => value >= min && value <= max);
        }


        public static TRuleChecker NonZero<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long?> source)
            where TRuleChecker : RuleChecker
        {
            return source.That(value => !value.HasValue || value.Value != 0);
        }

        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long?> source, long greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source.That(value => !value.HasValue || value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long?> source, long lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source.That(value => !value.HasValue || value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,long?> source, long min, long max)
            where TRuleChecker : RuleChecker
        {
            return source.That(value => !value.HasValue || (value >= min && value <= max));
        }
    }
}