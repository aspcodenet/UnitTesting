using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTesting;

namespace Book.Tests
{
    [TestClass]
    public class RegistrationServiceTests
    {
        private Mock<IEmailer> emailerMock;
        private RegistrationService sut;
        private Mock<IUserRepository> userRepositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            emailerMock = new Mock<IEmailer>();
            userRepositoryMock = new Mock<IUserRepository>();
            sut = new RegistrationService(emailerMock.Object, userRepositoryMock.Object);
        }

        [TestMethod]
        public void Register_should_return_false_when_user_already_exists()
        {
            var email = "stefan@stefan.se";
            userRepositoryMock.Setup(r => r.Exists(email)).Returns(true);
            Assert.IsFalse(sut.Register(new RegistrationViewModel
            { Name = "Stefan", Email = email }));
        }

        [TestMethod]
        public void Register_should_send_email()
        {
            var email = "stefan@stefan.se";
            userRepositoryMock.Setup(r => r.Exists(email)).Returns(false);


            sut.Register(new RegistrationViewModel
                {Name = "Stefan", Email = email});

            emailerMock.Verify(r => r.Send(email, It.IsAny<string>(),
                It.IsAny<string>()
            ), Times.Once());
        }
    }
}