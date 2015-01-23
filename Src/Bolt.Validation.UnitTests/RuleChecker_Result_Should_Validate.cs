using System.Diagnostics;
using Bolt.Validation.Extensions;
using Should;
using Xunit;
using Xunit.Extensions;

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

        [Theory]
        [InlineData(null, true)]
        [InlineData("Hello world", false)]
        [InlineData("mruhul@gmail.com", true)]
        public void Email(string email, bool pass)
        {
            var input = new TestEntity {Email = email};

            var result = RuleChecker<TestEntity>.For(input)
                .Check(x => x.Email)
                .Email()
                .Result();

            result.IsPassed.ShouldEqual(pass);
            if (!result.IsPassed)
            {
                result.Errors[0].ErrorMessage.ShouldEqual("Email is not a valid email address");
            }
        }
    }
}