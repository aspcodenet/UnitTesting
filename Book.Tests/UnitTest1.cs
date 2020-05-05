using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Book.Tests
{
    [TestClass]
    public class UnitTest1
    {
        UnitTesting.Book sut = new UnitTesting.Book("12345", "Nils","Testboken");

        [TestMethod]
        public void BuyNewEx_should_add_count()
        {
            sut.BuyNewEx(12);
            sut.BuyNewEx(11);
            Assert.AreEqual(23,sut.Count);
        }

        [TestMethod]
        public void BuyNewEx_should_make_available()
        {
            sut.BuyNewEx(12);
            sut.BuyNewEx(3);
            Assert.AreEqual(15, sut.Available);
        }

        [TestMethod]
        public void Borrow_should_decrease_available()
        {
            sut.BuyNewEx(12);
            sut.BuyNewEx(3);
            sut.Borrow("Stefan");
            Assert.AreEqual(14, sut.Available);
        }

    }
}
