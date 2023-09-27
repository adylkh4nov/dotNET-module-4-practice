using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_4_practice
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        // Добавление книги в библиотеку
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        // Удаление книги из библиотеки
        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        // Поиск книги по автору
        public List<Book> FindBooksByAuthor(string author)
        {
            return books.Where(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Поиск книги по году издания
        public List<Book> FindBooksByYear(int year)
        {
            return books.Where(book => book.Year == year).ToList();
        }

        // Сортировка книг по названию
        public void SortBooksByTitle()
        {
            books.Sort((book1, book2) => string.Compare(book1.Title, book2.Title, StringComparison.OrdinalIgnoreCase));
        }

        // Сортировка книг по автору
        public void SortBooksByAuthor()
        {
            books.Sort((book1, book2) => string.Compare(book1.Author, book2.Author, StringComparison.OrdinalIgnoreCase));
        }

        // Сортировка книг по году издания
        public void SortBooksByYear()
        {
            books.Sort((book1, book2) => book1.Year.CompareTo(book2.Year));
        }

        // Вывод списка всех книг в библиотеке
        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
