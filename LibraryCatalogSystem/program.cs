using System;

namespace LibraryCatalogSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("My Library", "123 Main Street");

            // Add books and media items to the library
            Book book1 = new Book("Book 1", "Author 1", "1234567890", 2021);
            Book book2 = new Book("Book 2", "Author 2", "0987654321", 2019);
            MediaItem mediaItem1 = new MediaItem("DVD 1", "DVD", 120);
            MediaItem mediaItem2 = new MediaItem("CD 1", "CD", 60);

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddMediaItem(mediaItem1);
            library.AddMediaItem(mediaItem2);

            // Print the catalog
            library.PrintCatalog();
        }
    }
}