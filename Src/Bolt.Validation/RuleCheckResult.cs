namespace Bolt.Validation
{
    public class RuleCheckResult
    {
        public RuleCheckResult(RuleError[] errors)
        {
            IsPassed = errors == null || errors.Length == 0;
            Errors = errors;
        }

        public bool IsPassed { get; private set; }
        public RuleError[] Errors { get; set; }
    }
}