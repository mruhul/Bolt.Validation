using System;
using System.Linq.Expressions;

namespace Bolt.Validation.Extensions
{
    public static class RuleCheckerExtensions
    {
        public static RuleCheckerUnit<RuleChecker, TValue> Check<TValue>(this RuleChecker source, TValue value)
        {
            return new RuleCheckerUnit<RuleChecker, TValue>(source, value);
        }

        public static TRuleChecker Merge<TRuleChecker>(this TRuleChecker source, RuleChecker from) where TRuleChecker : RuleChecker
        {
            source.Rules.AddRange(from.Rules);

            return source;
        }

        public static RuleCheckerUnit<RuleChecker<TEntity>, TValue> Check<TEntity, TValue>(this RuleChecker<TEntity> source, Expression<Func<TEntity, TValue>> selector)
            where TEntity : class 
        {
            var value = selector.Compile()(source.Entity);
            var name = ((MemberExpression)selector.Body).Member.Name;

            return new RuleCheckerUnit<RuleChecker<TEntity>, TValue>(source, (TValue)value).PropertyName(name);
        }
    }
}