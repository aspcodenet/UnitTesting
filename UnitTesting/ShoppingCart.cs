using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting
{
    public class ShoppingCart
    {
        
        public Item GetItem(int prodid)
        {
            return _items.FirstOrDefault(r => r.ProductId == prodid);
        }


        public void RemoveProduct(int prodId, int antal)
        {
            var item = _items.FirstOrDefault(r => r.ProductId == prodId);
            if (item == null) return;
            item.Remove(antal);
        }


        public int GetCountForProduct(int prodid)
        {
            var item = _items.FirstOrDefault(r => r.ProductId == prodid);
            if (item == null) return 0;
            return item.Antal;
        }
        public void AddProduct(int id, string text, int antal, decimal perPrice)
        {
            var existing = _items.FirstOrDefault(r => r.ProductId == id);
            if(existing == null)
                _items.Add(new Item(id,text,antal,perPrice));
            else
            {
                existing.Add(antal);
            }

        }
        public int GetUniqueProductsCount() => _items.Count;
        public decimal Total()
        {
            return _items.Sum(p => p.RowPrice());
        }
        private List<Item> _items = new List<Item>();
        public class Item
        {
            public int ProductId { get; protected set; }
            public string Text { get; protected set; }
            public int Antal { get; protected set; }
            public decimal PerPrice { get; protected set; }

            public decimal RowPrice()
            {
                return Convert.ToDecimal(Antal) * PerPrice;
            }

            public Item(int id, string text, int antal, decimal perPrice)
            {
                ProductId = id;
                Text = text;
                Antal = antal;
                PerPrice = perPrice;
            }

            public void Add(int antal)
            {
                Antal += antal;
            }

            public void Remove(int antal)
            {
                Antal -= antal;
            }
        }

    }
}