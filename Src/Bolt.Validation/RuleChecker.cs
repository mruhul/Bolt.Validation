using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolt.Validation
{
    public class RuleChecker
    {
        private readonly List<Rule> _rules = new List<Rule>();

        public void Should(Func<bool> fetch, string propertyName,
            string errorMessage, string errorCode = null)
        {
            Add(new Rule
            {
                Check = fetch,
                ErrorCode = errorCode,
                ErrorMessage = errorMessage,
                PropertyName = propertyName
            });
        }

        internal List<Rule> Rules
        {
            get { return _rules; }
        } 

        internal void Add(Rule rule)
        {
            _rules.Add(rule);
        }

        public RuleCheckResult Result()
        {
            var errors = from rule in _rules
                where !rule.Check.Invoke()
                select new RuleError
                       {
                           ErrorCode = rule.ErrorCode,
                           ErrorMessage = rule.ErrorMessage,
                           PropertyName = rule.PropertyName
                       };

            return new RuleCheckResult(errors.ToArray());
        }
    }

    public class RuleChecker<TEntity> : RuleChecker where TEntity : class
    {
        internal readonly TEntity Entity;

        internal RuleChecker(TEntity entity)
        {
            Entity = entity;
        }

        public static RuleChecker<TEntity> For(TEntity entity)
        {
            return new RuleChecker<TEntity>(entity);
        }
    }
}
