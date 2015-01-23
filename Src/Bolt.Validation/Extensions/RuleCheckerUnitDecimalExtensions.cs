namespace Bolt.Validation.Extensions
{
    public static class RuleCheckerUnitDecimalExtensions
    {
        public static TRuleChecker NonZero<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal> source)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.NonZero, source.GetPropertyName())
                    .That(value => value != 0);
        }

        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal> source, decimal greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.GreaterThan, source.GetPropertyName(), greaterFrom)
                    .That(value => value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal> source, decimal lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.LessThan, source.GetPropertyName(), lessFrom)
                    .That(value => value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal> source, decimal min, decimal max)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.Range, source.GetPropertyName(), min, max)
                    .That(value => value >= min && value <= max);
        }


        public static TRuleChecker NonZero<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal?> source)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.NonZero, source.GetPropertyName())
                    .That(value => !value.HasValue || value.Value != 0);
        }

        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal?> source, decimal greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.GreaterThan, source.GetPropertyName(), greaterFrom)
                    .That(value => !value.HasValue || value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal?> source, decimal lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.LessThan, source.GetPropertyName(), lessFrom)
                    .That(value => !value.HasValue || value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,decimal?> source, decimal min, decimal max)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.Range, source.GetPropertyName(), min, max)
                    .That(value => !value.HasValue || (value >= min && value <= max));
        }
    }
}