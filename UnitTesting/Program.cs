using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book("12223","Nils Nilsson", "Fantastiska dikter"),
                new Book("55551234","Åsa Åsasson", "Mina bästa TV-spel")
            };

            books[0].BuyNewEx(12);
            books[1].BuyNewEx(2);

            var borrower = "Stefan";
            if(books[0].IsBorrower(borrower) == false)
                books[0].Borrow(borrower);
            else
            {
                Console.WriteLine("Du har ju redan lånat den boken");
            }
            Console.WriteLine($"Antal kvar av {books[0].Title} är nu {books[0].Count} ");
                

        }
    }
}
