using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTesting;

namespace RealBook.Tests
{
    //class EMailFake : IEmailer
    //{
    //    public bool Called = false;
    //    public void Send(string to, string header, string body)
    //    {
    //        Called = true;
    //        return;
    //    }
    //}

    //class UserRep : IUserRepository
    //{
    //pribvate List<>
    //    public bool Exists(string email)
    //    {
    //        if (email == "stefan@stefan.se") return true;
    //        return false;
    //    }

    //    public void Add(string email, string name)
    //    {
            
    //    }
    //}


    [TestClass]
    public class RegistrationServiceTests
    {
        RegistrationService sut;
        Mock<IEmailer> eMailFakeMock;         
        Mock<IUserRepository> userRepositoryMock;

        public RegistrationServiceTests()
        {
            eMailFakeMock = new Mock<IEmailer>();
            userRepositoryMock = new Mock<IUserRepository>();

            sut = new RegistrationService(eMailFakeMock.Object, userRepositoryMock.Object);
        }
            

        [TestMethod]
        public void When_email_exists_should_return_false()
        {
            var model = new RegistrationViewModel {Email = "stefan@stefan.se", Name = "Stefan"};
            //userRepositoryMock.Setup(r => r.Exists("stefan@stefan.se")).Returns(false);
            userRepositoryMock.Setup(r => r.Exists(It.IsAny<string>())).Returns(true);
            Assert.IsFalse(sut.Register(model));
        }




        [TestMethod]
        public void When_email_not_exists_should_return_true()
        {
            var model = new RegistrationViewModel { Email = "kalle@stefan.se", Name = "Stefan" };
            userRepositoryMock.Setup(r => r.Exists(It.IsAny<string>())).Returns(false);
            Assert.IsTrue(sut.Register(model));
        }




        [TestMethod]
        public void When_registration_ok_should_send_email()
        {
            var model = new RegistrationViewModel { Email = "kalle@stefan.se", Name = "Stefan" };
            userRepositoryMock.Setup(r => r.Exists(It.IsAny<string>())).Returns(false);
            sut.Register(model);

            //eMailFakeMock.Verify(p=>p.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),Times.Once);
            eMailFakeMock.Verify(p => p.Send("kalle@stefan.se", It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }


    }
}