namespace Bolt.Validation.Extensions
{
    public static class RuleCheckerUnitDoubleExtensions
    {
        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, double> source, double greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.GreaterThan, source.GetPropertyName(), greaterFrom)
                    .That(value => value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,double> source, double lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.LessThan, source.GetPropertyName(), lessFrom)
                    .That(value => value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,double> source, double min, double max)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.Range, source.GetPropertyName(), min, max)
                    .That(value => value >= min && value <= max);
        }
        
        public static TRuleChecker GreaterThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,double?> source, double greaterFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.GreaterThan, source.GetPropertyName(), greaterFrom)
                    .That(value => !value.HasValue || value > greaterFrom);
        }

        public static TRuleChecker LessThan<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,double?> source, double lessFrom)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.LessThan, source.GetPropertyName(), lessFrom)
                    .That(value => !value.HasValue || value < lessFrom);
        }

        public static TRuleChecker Range<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, double?> source, double min, double max)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.Range, source.GetPropertyName(), min, max)
                    .That(value => !value.HasValue || (value >= min && value <= max));
        }
    }
}