using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace RealBook.Tests
{
    [TestClass]
    public class BookTests
    {
        Book sut = new Book("123", "Stefan", "Fina dikter");

        [TestMethod]
        public void When_buying_new_ex_available_should_be_set()
        {
            sut.BuyNewEx(12);

            Assert.AreEqual(12, sut.Available);
        }

        [TestMethod]
        public void When_refilling_new_exes_new_ones_should_be_added_to_existing()
        {
            sut.BuyNewEx(12);
            sut.BuyNewEx(11);

            Assert.AreEqual(23, sut.Available);
        }

        [TestMethod]
        public void Borrow_should_decrease_available()
        {
            sut.BuyNewEx(15);
            sut.Borrow("Stefan");
            Assert.AreEqual(14, sut.Available);
        }

    }
}
