using System;

namespace Bolt.Validation
{
    public class Rule
    {
        public Func<bool> Check { get; set; }
        public string PropertyName { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}