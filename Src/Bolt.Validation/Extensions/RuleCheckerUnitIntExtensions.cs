namespace Bolt.Validation.Extensions
{
    public static class RuleCheckerUnitIntExtensions
    {
        public static TRuleChecker NonZero<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, int> source)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.NonZero, source.GetPropertyName())
                    .That(value => value != 0);
        }

        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, int> source, int greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.GreaterThan, source.GetPropertyName(), greaterFrom)
                    .That(value => value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,int> source, int lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.LessThan, source.GetPropertyName(), lessFrom)
                    .That(value => value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,int> source, int min, int max)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.Range, source.GetPropertyName(), min, max)
                    .That(value => value >= min && value <= max);
        }


        public static TRuleChecker NonZero<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,int?> source)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.NonZero, source.GetPropertyName())
                    .That(value => !value.HasValue || value.Value != 0);
        }

        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,int?> source, int greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.GreaterThan, source.GetPropertyName(), greaterFrom)
                    .That(value => !value.HasValue || value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,int?> source, int lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.LessThan, source.GetPropertyName(), lessFrom)
                    .That(value => !value.HasValue || value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, int?> source, int min, int max)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.Range, source.GetPropertyName(), min, max)
                    .That(value => !value.HasValue || (value >= min && value <= max));
        }
    }
}