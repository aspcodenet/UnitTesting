using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace RealBook.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
//        private ShoppingCart sut = new ShoppingCart();


        [TestMethod]
        public void When_adding_product_not_already_in_cart_then_number_of_items_should_increase_by_one()
        {
            var sut = new ShoppingCart();
            sut.AddProduct(1010, "Äpple", 1,12.2m);
            int antal = sut.GetUniqueProductsCount();

            sut.AddProduct(1011, "Päron", 2, 13.2m);

            Assert.AreEqual(antal + 1,sut.GetUniqueProductsCount());
        }


        [TestMethod]
        public void When_adding_product_total_should_update_correctly()
        {
            var sut = new ShoppingCart();
            sut.AddProduct(1010, "Äpple", 1, 12.2m);
            var total = sut.Total();

            sut.AddProduct(1011, "Päron", 1, 13.2m);

            Assert.AreEqual(total + 13.2m, sut.Total());
        }



        [TestMethod]
        public void When_adding_product_already_in_cart_then_number_of_items_should_not_increase()
        {
            var sut = new ShoppingCart();
            sut.AddProduct(1010, "Äpple", 1, 12.2m);
            sut.AddProduct(1011, "Päron", 2, 13.2m);
            int antal = sut.GetUniqueProductsCount();
            sut.AddProduct(1011, "Päron", 3, 13.2m);

            Assert.AreEqual(antal, sut.GetUniqueProductsCount());
        }


        [TestMethod]
        public void When_adding_product_already_in_cart_then_count_for_cartitem_should_increase()
        {
            var sut = new ShoppingCart();
            sut.AddProduct(1010, "Äpple", 1, 12.2m);
            sut.AddProduct(1011, "Päron", 2, 13.2m);
            sut.AddProduct(1011, "Päron", 3, 13.2m);

            Assert.AreEqual(5, sut.GetItem(1011).Antal);
        }



        [TestMethod]
        public void When_removing_one_ex_number_will_decrease()
        {
            var sut = new ShoppingCart();
            sut.AddProduct(1010, "Äpple", 1, 12.2m);
            sut.AddProduct(1011, "Päron", 2, 13.2m);
            sut.AddProduct(1011, "Päron", 3, 13.2m);
            sut.RemoveProduct(1011,1);
            Assert.AreEqual(4, sut.GetItem(1011).Antal);
        }


        [TestMethod]
        public void When_removing_one_ex_and_product_is_not_in_cart_nothing_happens()
        {
            var sut = new ShoppingCart();
            sut.AddProduct(1010, "Äpple", 1, 12.2m);
            sut.AddProduct(1011, "Päron", 2, 13.2m);
            sut.AddProduct(1011, "Päron", 3, 13.2m);
            
            var total = sut.Total();
            sut.RemoveProduct(1012, 1);

            Assert.AreEqual(total, sut.Total());
        }



    }
}