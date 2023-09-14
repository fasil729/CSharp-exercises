using System;
using System.Collections.Generic;

namespace LibraryCatalogSystem
{
    class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
        public List<MediaItem> MediaItems { get; set; }

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void AddMediaItem(MediaItem item)
        {
            MediaItems.Add(item);
        }

        public void RemoveMediaItem(MediaItem item)
        {
            MediaItems.Remove(item);
        }

        public void PrintCatalog()
        {
            Console.WriteLine("Library Catalog:");
            Console.WriteLine("Books:");
            foreach (var book in Books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Publication Year: {book.PublicationYear}");
            }

            Console.WriteLine("Media Items:");
            foreach (var mediaItem in MediaItems)
            {
                Console.WriteLine($"Title: {mediaItem.Title}, Media Type: {mediaItem.MediaType}, Duration: {mediaItem.Duration} minutes");
            }
        }
    }
}