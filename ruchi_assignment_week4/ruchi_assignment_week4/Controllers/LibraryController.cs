using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using ruchi_assignment_week4.Model;
using ruchi_assignment_week4.Entities;
using Microsoft.Azure.Cosmos.Linq;

namespace ruchi_assignment_week4.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class LibraryController : Controller
    {

        public Container Container;
        public LibraryController()
        {
            Container = GetContainer();
        }

        public string URI = "https://localhost:8081";
        public string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DatabaseName = "Library";
        public string ContainerName = "Books";

        private Container GetContainer()
        {
            CosmosClient cosmosClient = new CosmosClient(URI, PrimaryKey);
            Database database = cosmosClient.GetDatabase(DatabaseName);
            Container container = database.GetContainer(ContainerName);
            return container;
        }

        [HttpPost]
        public async Task<BookModel> AddBookEntity(BookModel bookModel)
        {
            BookEntity book = new BookEntity();

            book.Title = bookModel.Title;
            book.Author = bookModel.Author;
            book.PublishedDate = bookModel.PublishedDate;
            book.ISBN = bookModel.ISBN;
            book.IsIssued = bookModel.IsIssued;

            book.Id = Guid.NewGuid().ToString();
            book.UId = book.Id;
            book.DocumentType = "Book";
            book.CreatedBy = "ruchi";
            book.CreatedOn = DateTime.Now;
            book.UpdatedBy = "ruchi";
            book.UpdatedOn = DateTime.Now;
            book.Version = 1;
            book.Active = true;
            book.Archived = false;

            BookEntity response = await Container.CreateItemAsync(book);

            BookModel responseModel = new BookModel();
            responseModel.Title = response.Title;
            responseModel.Author = response.Author;
            responseModel.PublishedDate = response.PublishedDate;
            responseModel.ISBN = response.ISBN;
            responseModel.IsIssued = response.IsIssued;
            return responseModel;
        }
      

        [HttpGet]
        public async Task<BookModel> GetBookById(string id)
        {
            var book = Container.GetItemLinqQueryable<BookModel>(true).Where(q => q.UId == id).FirstOrDefault();
            return book;
        }

        [HttpGet]
        public async Task<BookModel> GetBookByName(string title)
        {
            var book = Container.GetItemLinqQueryable<BookModel>(true).Where(q => q.Title == title).FirstOrDefault();
            return book;
        }

        [HttpGet]
        public async Task<List<BookModel>> GetIssuedBook()
        {
            var books = Container.GetItemLinqQueryable<BookModel>(true).Where(q => q.IsIssued == true).ToList();
            List<BookModel> bookModels = new List<BookModel>();
            
                foreach (var book in books)
                {
                    BookModel model = new BookModel();
                    model.UId = book.UId;
                    model.Title = book.Title;
                    model.Author = book.Author;
                    model.PublishedDate = book.PublishedDate;
                    model.ISBN = book.ISBN;
                    model.IsIssued = book.IsIssued;

                    bookModels.Add(model);
                }

          return bookModels;
        }

        [HttpGet]
        public async Task<List<BookModel>> GetUnIssuedBook()
        {
            var books = Container.GetItemLinqQueryable<BookModel>(true).Where(q => q.IsIssued == false).ToList();
            List<BookModel> bookModels = new List<BookModel>();

            foreach (var book in books)
            {
                BookModel model = new BookModel();
                model.UId = book.UId;
                model.Title = book.Title;
                model.Author = book.Author;
                model.PublishedDate = book.PublishedDate;
                model.ISBN = book.ISBN;
                model.IsIssued = book.IsIssued;

                bookModels.Add(model);
            }

            return bookModels;
        }



        [HttpGet]
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "Book").ToList();
      
            List<BookModel> bookModels = new List<BookModel>();

            foreach (var book in books)
            {
                BookModel model = new BookModel();
                model.UId = book.UId;
                model.Title = book.Title;
                model.Author = book.Author;
                model.PublishedDate = book.PublishedDate;
                model.ISBN = book.ISBN;
                model.IsIssued = book.IsIssued;

                bookModels.Add(model);
            }


            return bookModels;
        }


        [HttpPost]
        public async Task<BookModel> UpdateBook(BookModel book)
        {
            var existingBook = Container.GetItemLinqQueryable<BookEntity>(true).Where(q => q.UId == book.UId && q.Active == true && q.Archived == false).FirstOrDefault();
            existingBook.Archived = true;
            existingBook.Active = false;
            await Container.ReplaceItemAsync(existingBook, existingBook.Id);
            existingBook.Id = Guid.NewGuid().ToString();
            existingBook.UpdatedBy = "ruchi";
            existingBook.UpdatedOn = DateTime.Now;
            existingBook.Version = existingBook.Version + 1;
            existingBook.Active = true;
            existingBook.Archived = false;

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.ISBN = book.ISBN;
            existingBook.IsIssued = book.IsIssued;

            existingBook = await Container.CreateItemAsync(existingBook);

            BookModel response = new BookModel();
            response.Title = existingBook.Title;
            response.Author = existingBook.Author;
            response.PublishedDate = existingBook.PublishedDate;
            response.ISBN = existingBook.ISBN;
            response.IsIssued = existingBook.IsIssued;

            return response;
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBook(string id, string partitionKey)
        { 
            await Container.DeleteItemAsync<BookModel>(id, new PartitionKey(partitionKey));
            return Ok(Response.StatusCode);
        }

        [HttpPost]
        public async Task<MemberModel> AddMember(MemberModel memberModel)
        {
            MemberEntity member = new MemberEntity();

            member.Name = memberModel.Name;
            member.DateOfBirth = memberModel.DateOfBirth;
            member.Email = memberModel.Email;
         
            member.Id = Guid.NewGuid().ToString();
            member.UId = member.Id;
            member.DocumentType = "Member";
            member.CreatedBy = "ruchi";
            member.CreatedOn = DateTime.Now;
            member.UpdatedBy = "ruchi";
            member.UpdatedOn = DateTime.Now;
            member.Version = 1;
            member.Active = true;
            member.Archived = false;

            MemberEntity response = await Container.CreateItemAsync(member);

            MemberModel responseModel = new MemberModel();
            responseModel.Name = response.Name;
            responseModel.DateOfBirth = response.DateOfBirth;
            responseModel.Email = response.Email;

            return responseModel;
        }

        [HttpGet]
        public async Task<MemberModel> GetMemberById(string id)
        {
            var member = Container.GetItemLinqQueryable<MemberModel>(true).Where(q => q.UId == id).FirstOrDefault();
            return member;
        }

        [HttpGet]
        public async Task<List<MemberModel>> GetAllMembers()
        {
           
            var members = Container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "Member").ToList();

           
            List<MemberModel> memberModels = new List<MemberModel>();

            foreach (var member in members)
            {
                MemberModel model = new MemberModel();
                model.UId = member.UId;
                model.Name = member.Name;
                model.DateOfBirth = member.DateOfBirth;
                model.Email = member.Email;
          
                memberModels.Add(model);
            }
         
            return memberModels;
        }

        [HttpPost]
        public async Task<MemberModel> UpdateMember(MemberModel member)
        {
            var existingMember = Container.GetItemLinqQueryable<MemberEntity>(true).Where(q => q.UId == member.UId && q.Active == true && q.Archived == false).FirstOrDefault();
            existingMember.Archived = true;
            existingMember.Active = false;
            await Container.ReplaceItemAsync(existingMember, existingMember.Id);
            existingMember.Id = Guid.NewGuid().ToString();
            existingMember.UpdatedBy = "ruchi";
            existingMember.UpdatedOn = DateTime.Now;
            existingMember.Version = existingMember.Version + 1;
            existingMember.Active = true;
            existingMember.Archived = false;

            existingMember.Name = member.Name;
            existingMember.DateOfBirth = member.DateOfBirth;
            existingMember.Email = member.Email;
           

            existingMember = await Container.CreateItemAsync(existingMember);

            MemberModel response = new MemberModel();
            response.Name = existingMember.Name;
            response.DateOfBirth = existingMember.DateOfBirth;
            response.Email = existingMember.Email;
           

            return response;
        }

       
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMember(string id, string partitionKey)
        {

            await Container.DeleteItemAsync<MemberModel>(id, new PartitionKey(partitionKey));
            return Ok(Response.StatusCode);
        }
    }
}