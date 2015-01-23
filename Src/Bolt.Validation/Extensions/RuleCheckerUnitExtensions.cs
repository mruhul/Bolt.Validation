using System;

namespace Bolt.Validation.Extensions
{
    public static class RuleCheckerUnitExtensions
    {
        public static TRuleChecker NotNull<TRuleChecker,TValue>(this RuleCheckerUnit<TRuleChecker,TValue> source) 
            where TValue : class 
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.NotNull, source.GetPropertyName())
                    .That(value => value != null);
        }

        public static TRuleChecker NotEmpty<TRuleChecker>(this RuleCheckerUnit<TRuleChecker, Guid> source)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.NotEmptyOnly, source.GetPropertyName())
                    .That(value => value != Guid.Empty);
        }

        public static TRuleChecker NotEmpty<TRuleChecker>(this RuleCheckerUnit<TRuleChecker,Guid?> source)
            where TRuleChecker : RuleChecker
        {
            return source
                    .DefaultErrorMessage(Messages.NotEmpty, source.GetPropertyName())
                    .That(guid => guid.HasValue && guid.Value != Guid.Empty);
        }
    }
}