using Bolt.Validation.Extensions;
using Should;
using Xunit;

namespace Bolt.Validation.UnitTests
{
    public class RuleChecker_Result_Should_Validate
    {
        [Fact]
        public void EmptyString()
        {
            var entity = new TestEntity
                         {
                             Name = null,
                             Age = 0
                         };


            var result = RuleChecker<TestEntity>
                .For(entity)
                    .Check(x => x.Name)
                        .ErrorCode("1000")
                        .NotEmpty()
                        
                    .Check(x => x.Age)
                        .Range(1,10)
                .Result();

            result.IsPassed.ShouldBeFalse();
        }
    }
}