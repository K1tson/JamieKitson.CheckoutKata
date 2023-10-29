using AutoFixture;

namespace CheckoutKata.Core.Tests
{
    public abstract class TestBase
    {
        protected IFixture Fixture;

        protected TestBase()
            : this(new Fixture())
        {
        }

        protected TestBase(IFixture fixture)
        {
            Fixture = fixture;
        }

    }
}
