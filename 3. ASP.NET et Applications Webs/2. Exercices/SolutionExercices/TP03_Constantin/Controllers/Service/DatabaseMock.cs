#pragma warning disable
namespace Bookstore.Controllers.Service
{
    public class DatabaseMock
    {
        private List<Books> _books;
        private List<Authors> _authors;
        private List<Users> _users;
        private List<Sales> _sales;
        public Users loggedUser;

        public DatabaseMock()
        {
            _books = new List<Books>();
            _authors = new List<Authors>();
            _users = new List<Users>();
            _sales = new List<Sales>();
            SeedDB();
        }
        public List<Books> GetBooks()
        {
            return _books;
        }
        public List<Authors> GetAuthors()
        {
            return _authors;
        }
        public List<Users> GetUsers()
        {
            return _users;
        }
        public List<Sales> GetSales()
        {
            return _sales;
        }
        public void AddBook(Books book)
        {
            _books.Add(book);
        }
        public void AddAuthor(Authors author)
        {
            _authors.Add(author);
        }
        public void AddUser(Users user)
        {
            _users.Add(user);
        }
        public void AddSale(Sales sale)
        {
            _sales.Add(sale);
        }
        public void DeleteBook(Books book)
        {
            _books.Remove(book);
        }
        public void DeleteAuthor(Authors author)
        {
            _authors.Remove(author);
        }
        public void DeleteUser(Users user)
        {
            _users.Remove(user);
        }
        public void DeleteSale(Sales sale)
        {
            _sales.Remove(sale);
        }
        public Books GetByIdBook(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }
        public Authors GetByIdAuthor(int id)
        {
            return _authors.FirstOrDefault(x => x.Id == id);
        }
        public Users GetByIdUser(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
        public Sales GetByIdSale(int id)
        {
            return _sales.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateBook(BooksVM book)
        {
            Books temp = _books.FirstOrDefault(x => x.Id == book.Id);
            temp.Title = book.Title ?? temp.Title;
            temp.Description = book.Description ?? temp.Description;
            temp.Price = book.Price;
            temp.Image = book.Image ?? temp.Image;
            temp.ISBN = book.ISBN ?? temp.ISBN;
            temp.Author = GetByIdAuthor(book.AuthorId) ?? temp.Author;
            temp.DateParution = book.DateParution;
        }
        public void UpdateAuthor( AuthorsVM author)
        {
            Authors temp = _authors.FirstOrDefault(x => x.Id == author.Id);
            temp.Biography = author.Biography ?? temp.Biography;
            temp.BirthDate = author.BirthDate;
            temp.DeathDate = author.DeathDate;
            temp.FullName = author.FullName ?? temp.FullName;
        }
        public void UpdateUser(int id, UsersVM user)
        {
            Users temp = _users.FirstOrDefault(x => x.Id == id);
            temp.Name = user.Name ?? temp.Name;
            temp.Email = user.Email ?? temp.Email;
            temp.Password = user.Password ?? temp.Password;
        }
        public void UpdateSales(int id, Sales sale)
        {
            Sales temp = _sales.FirstOrDefault(x => x.Id == id);
            temp.Date = sale.Date;
            temp.ListBook = sale.ListBook ?? temp.ListBook;
            temp.Buyer = sale.Buyer ?? temp.Buyer;
        }

        public void SeedDB()
        {
            //Books
            Books book1 = new Books()
            {
                Title = "Harry Potter and the Philosopher's Stone",
                Description = "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard, in his eleventh year at Hogwarts School of Witchcraft and Wizardry. The plot follows Harry's struggle with Lord Voldemort, a dark wizard who intends to become immortal, overthrow the wizard governing body known as the Ministry of Magic, and subjugate all wizards and Muggles to his service. The story primarily concerns Harry's struggle with his older brother, who is a powerful wizard, and the effect Harry has on his older brother's mysterious death.",
                Price = 19.99,
                Image = "https://m.media-amazon.com/images/I/815v2OuIHXL._AC_SL1500_.jpg",
                ISBN = "0-7475-3269-9",
                ListCategory = new List<Books.Categories>() { Books.Categories.Fantasy, Books.Categories.Adventure, Books.Categories.Mystery },
                DateParution = new DateTime(2000, 1, 1)

            };
            Books book2 = new Books()
            {
                Title = "Harry Potter and the Chamber of Secrets",
                Description = "Harry Potter and the Chamber of Secrets is a fantasy novel written by British author J. K. Rowling and the second novel in the Harry Potter series. It follows Harry Potter, a young wizard, in his eleventh year at Hogwarts School of Witchcraft and Wizardry. The story follows Harry's second year with the help of his friends Ron and Hermione, and their quest to find and destroy the Horcruxes, a magical item that grants the power to unlock one hundred and twenty-something Horcruxes.",
                Price = 19.99,
                Image = "https://images-na.ssl-images-amazon.com/images/I/91dtESnWABL.jpg",
                ISBN = "0-7475-3269-9",
                ListCategory = new List<Books.Categories>() { Books.Categories.Fantasy, Books.Categories.Adventure, Books.Categories.Mystery },
                DateParution = new DateTime(2000, 1, 1)
            };
            Books book3 = new Books()
            {
                Title = "Harry Potter and the Prisoner of Azkaban",
                Description = "Harry Potter and the Prisoner of Azkaban is a fantasy novel written by British author J. K. Rowling and the third novel in the Harry Potter series. It follows Harry Potter, a young wizard, and his friends Hermione and Ron Weasley, who are targeted by an authoritarian wizard and his army of wizards, led by Albus Dumbledore, for their alleged involvement in the destruction of the One Tower, a symbol of wizardhood and magical authority in the wizarding world.",
                Price = 19.99,
                Image = "https://images-eu.ssl-images-amazon.com/images/I/51Dfqo6jR5L._SX342_SY445_QL70_ML2_.jpg",
                ISBN = "0-7475-3269-9",
                ListCategory = new List<Books.Categories>() { Books.Categories.Fantasy, Books.Categories.Adventure, Books.Categories.Mystery },
                DateParution = new DateTime(2000, 1, 1)
            };
            Books book4 = new Books()
            {
                Title = "A song of Ice and Fire",
                Description ="A song of Ice and Fire is a fantasy novel written by American author George R. R. Martin. It was first published on August 1, 1996 by HarperCollins Publishers. The novel is part of the Martin family's ongoing series of fantasy novels, beginning with A Game of Thrones and continuing with A Clash of Kings and A Storm of Swords. The novel was adapted into a film by British director Guy Ritchie, and the film was released on November 21, 2011.",
                Price = 19.99,
                Image = "https://images-na.ssl-images-amazon.com/images/I/81Z5yP7OqhL.jpg",
                ISBN = "0-7475-3269-9",
                ListCategory = new List<Books.Categories>() { Books.Categories.Fantasy, Books.Categories.Adventure, Books.Categories.Mystery },
                DateParution = new DateTime(2000, 1, 1)
            };
            _books.Add(book1);
            _books.Add(book2);
            _books.Add(book3);
            _books.Add(book4);

            //Authors

            Authors authors1 = new Authors()
            {
                FullName = "J.K. Rowling",
                Biography = "Joanne Rowling is the pseudonym of British author and film producer, J. K. Rowling. She is the author of the Harry Potter fantasy series, which has won multiple awards and sold more than 500 million copies worldwide. She is the author of the novel Harry Potter and the Philosopher's Stone (1997), which was adapted into the film Harry Potter and the Sorcerer's Stone (2001).",
                BirthDate = new DateTime(1965, 7, 31),
            };

            Authors authors2 = new Authors()
            {
                FullName = "George R.R. Martin",
                Biography = "George R.R. Martin is an American novelist, screenwriter, and humorist best known for his two best-selling novels, A Game of Thrones (1996) and A Dance with Dragons (2011). He is also the author of the fantasy series A Song of Ice and Fire, which has sold more than 500 million copies worldwide.",
                BirthDate = new DateTime(1958, 3, 16),

            };



            _authors.Add(authors1);
            _authors.Add(authors2);
            foreach (var book in _books)
            {
                book.Author = authors1;
            }



            //Users

            Users user1 = new Users()
            {
                Name = "John",
                Email = "John@mail.com",
                Password = "12345",
                Role = Users.RoleEnum.user
            };

            Users user2 = new Users()
            {
                Name = "Jane",
                Email = "admin@admin.com",
                Password = "12345",
                Role = Users.RoleEnum.admin
            };

            _users.Add(user1);
            _users.Add(user2);

            //Sales

            Sales sale1 = new Sales()
            {
                Date = new DateTime(2020, 1, 1),
                Buyer = user1,
                ListBook = new List<Books>() { book1, book2, book3 }
            };

            Sales sale2 = new Sales()
            {
                Date = new DateTime(2020, 1, 1),
                Buyer = user2,
                ListBook = new List<Books>() { book1, book2, book3 }
            };
            _sales.Add(sale1);
            _sales.Add(sale2);

        }
    }
}
