using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolt.Validation
{
    public class RuleCheckerUnit<TRuleChecker,TValue> where TRuleChecker : RuleChecker
    {
        private readonly TRuleChecker _ruleChecker;
        private readonly TValue _value;
        private readonly Rule _rule = new Rule();
        private Func<string> _defaultErrorMessage = null; 

        internal RuleCheckerUnit(TRuleChecker ruleChecker, TValue value)
        {
            _ruleChecker = ruleChecker;
            _value = value;
        }

        public string GetPropertyName()
        {
            return _rule.PropertyName ?? "Value";
        }
        
        public RuleCheckerUnit<TRuleChecker,TValue> PropertyName(string propertyName)
        {
            _rule.PropertyName = propertyName;

            return this;
        }

        public RuleCheckerUnit<TRuleChecker, TValue> ErrorCode(string errorCode)
        {
            _rule.ErrorCode = errorCode;

            return this;
        }

        public RuleCheckerUnit<TRuleChecker, TValue> ErrorMessage(string errorMessage)
        {
            _rule.ErrorMessage = errorMessage;

            return this;
        }

        public RuleCheckerUnit<TRuleChecker, TValue> ErrorMessage(string errorMessage, params object[] args)
        {
            return ErrorMessage(string.Format(errorMessage, args));
        }

        public RuleCheckerUnit<TRuleChecker, TValue> DefaultErrorMessage(string errorMessage, params object[] args)
        {
            _defaultErrorMessage = () => string.Format(errorMessage, args);

            return this;
        }
        
        public TRuleChecker That(Func<TValue,bool> condition)
        {
            _rule.Check = () => condition.Invoke(_value);

            if (string.IsNullOrWhiteSpace(_rule.ErrorMessage))
            {
                _rule.ErrorMessage = _defaultErrorMessage == null ? "Value is invalid" : _defaultErrorMessage.Invoke();
            }

            _ruleChecker.Add(_rule);

            return _ruleChecker;
        }
    }
}