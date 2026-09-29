using Chatter.CQRS.Commands;
using Chatter.Testing.Core.Creators.Common;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace Chatter.CQRS.Tests.Commands.UsingCommandDispatcher
{
    public class WhenInitializing : Testing.Core.Context
    {
        private readonly Mock<IServiceProvider> _serviceProvider = new Mock<IServiceProvider>();
        private readonly LoggerCreator<CommandDispatcher> _logger;

        public WhenInitializing() 
            => _logger = New.Common().Logger<CommandDispatcher>();

        [Fact]
        public void MustThrowWhenServiceProviderIsNull()
        {
            Action ctor = () => new CommandDispatcher(null, _logger.Creation);
            ctor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void MustThrowWhenLoggerIsNull()
        {
            Action ctor = () => new CommandDispatcher(_serviceProvider.Object, null);
            ctor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void MustNotThrowWhenServiceProviderAndLoggerHaveValue()
        {
            Action ctor = () => new CommandDispatcher(_serviceProvider.Object, _logger.Creation);
            ctor.Should().NotThrow<ArgumentNullException>();
            ctor.Should().NotThrow();
        }

        [Fact]
        public void MustThrowWhenServiceProviderAndLoggerAreNull()
        {
            Action ctor = () => new CommandDispatcher(null, null);
            ctor.Should().Throw<ArgumentNullException>();
        }
    }
}
