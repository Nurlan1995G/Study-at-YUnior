using System;

namespace Program
{
    class ProgramBook 
    {
        static void Main(string[] args)
        {
            BookStorage bookStorage = new BookStorage();

            string commandAddBook = "1";
            string commandShowInfo = "2";
            string commandFindInfoAuthor = "3";
            string commandDelete = "4";
            string commandExit = "5";
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("\n$Хранилище книг$\n");
                Console.WriteLine("Главное меню\n");
                Console.WriteLine("1 - Добавить книгу;\n2 - Получить всю информацию по книгам;\n3 - Найти по автору;\n4 - Удалить книгу;\n5 - Выход из программы.\n");
                Console.Write("Введите команду: ");

                string userInput = Console.ReadLine();

                if(userInput == commandAddBook)
                {
                    bookStorage.AddBook();
                }
                else if(userInput == commandShowInfo)
                {
                    bookStorage.ShowInfoBook();
                }
                else if(userInput == commandFindInfoAuthor)
                {
                    bookStorage.ShowInfoAuthor();
                }      
                else if(userInput == commandDelete)
                {
                    bookStorage.DeleteBook();
                }
                else if(userInput == commandExit)
                {
                    Console.WriteLine("Вы вели выход из программы!");
                    isWorking = false;
                }

                Console.ReadKey();
                Console.Clear();
            }
        } 
    }

    class Book
    {
        public Book(string nameBook, string authorBook, int yearRelease)
        {
            Name = nameBook;
            Author = authorBook;
            YearRelease = yearRelease;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearRelease { get; private set; }
    }

    class BookStorage
    {
        private List<Book> _books = new List<Book>();

        public BookStorage()
        {
            GetBook();
        }

        public void AddBook()
        {
            Console.Write("Введите название книги: ");
            string bookName = Console.ReadLine();
            Console.Write("Введите автора: ");
            string authorName = Console.ReadLine();
            Console.Write("Введите год выпуска: ");
            int yearRelease = Convert.ToInt32(Console.ReadLine());

            _books.Add(new Book(bookName, authorName, yearRelease));
        }

        public void DeleteBook()
        {
            if(TryTakeBook(out Book book))
            {
                _books.Remove(book);
                Console.WriteLine($"Книга с автором - {book.Author} удалена!");
            }
            else
            {
                Console.WriteLine("Такого автора не существует!");
            }
        }

        public void ShowInfoAuthor()
        {
            if(TryTakeBook(out Book book))
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    if (book == _books[i])
                    {
                        Console.WriteLine($"Название книги - {_books[i].Name} | Имя автора - {_books[i].Author} | Год выпуска - {_books[i].YearRelease}");
                    }
                }
            }
        }

        public void ShowInfoBook()
        {
            if (_books.Count > 0)
            {
                for (int i = 0; i < _books.Count; i++)
                {
                    Console.WriteLine($"Название книги - {_books[i].Name} | Имя автора - {_books[i].Author} | Год выпуска - {_books[i].YearRelease}");
                }
            }
            else
            {
                Console.WriteLine("У вас пока нет ничего!");
            }
        }
        private bool TryTakeBook(out Book book)
        {
            book = null;
            bool isFound = false;

            Console.Write("Введите автора книги: ");
            string userInput = Console.ReadLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (userInput.ToLower() == _books[i].Author.ToLower())
                {
                    book = _books[i];
                    return true;
                }
            }

            Console.WriteLine("Введенное вами имя автора не существует. Попробуйте еще раз");

            return false;
        }

        private void GetBook()
        {
            _books.Add(new Book("Загадка Эндхауза", "Агата Кристи", 1932));
            _books.Add(new Book("Всадник без головы", "Майн Рид", 1865));
            _books.Add(new Book("Шантарам", "Грегори Д.Робертс", 2003));
            _books.Add(new Book("Соловей", "Кристин Ханна", 1995));
            _books.Add(new Book("Цветы для Элджернона", "Дэниел Киз", 1959));
        }
    }
}