using fistEntity.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace fistEntity
{
    public class UnitTest1
    {

        public UnitTest1()
        {
            var db = new BlogContext();
            db.Post.RemoveRange(db.Post.ToList());
            db.Author.RemoveRange(db.Author.ToList());
            db.SaveChanges();
            Author author = new Author
            {
                Id = 1,
                Name = "Quan"
            };
            db.Author.Add(author);
            db.SaveChanges();
            Post post1 = new Post();
            Post post2 = new Post();
            post1.Id = 1;
            post1.Title = "Multiline String Literal in C#";
            post1.Content = @"You can use the @ symbol in front of a string to form a verbatim string literal:";
            post1.Author = author;

            post2.Id = 2;
            post2.Title = "Creating and Throwing Exceptions (C# Programming Guide";
            post2.Content = @"Exceptions are used to indicate that an error has occurred while running the program. Exception objects that describe an error are created and then thrown with the throw keyword. The runtime then searches for the most compatible exception handler.";
            post2.Author = author;


            db.Post.Add(post1);

            
            db.Post.Add(post2);

            db.SaveChanges();
            

        }

        [Fact]
        public void createNewAuthor()
        {
            var db = new BlogContext();
            Author author = new Author();
            author.Id = 2;
            author.Name = "Ngoc";
            db.Author.Add(author);
            var count = db.SaveChanges();
            Assert.Equal(1, count);
        }
        [Fact]
        public void createDuplicateAuthor()
        {
            var db = new BlogContext();
            Author author = new Author();
            author.Id = 1;
            author.Name = "Quan";
            db.Author.Add(author);
           
            Assert.Throws<DbUpdateException>(() => db.SaveChanges());
            
        }
        [Fact]
        public void findAuthor()
        {
            var db = new BlogContext();
            Author author = new Author();
           
            Assert.Equal("Quan", db.Author.Find(1).Name);
        }
        [Fact]
        public void createPostOne()
        {
            var db = new BlogContext();
            Author author = db.Author.Find(1);
            Post post = new Post();
            post.Id = 3;
            post.Title = "Introduction to Relationships";
            post.Content = @"Relational databases are data stores whose structure is based on how items of data are related to each other.
            A key benefit to taking a relational view of data is to reduce duplication.For example, you might want to record data about people in a town. If you took a non - relational approach to recording this data, you would store the person's name together with their address, place of work, school and so on as individual data items. Where multiple people live at the same address or go to the same school, you would record the address or school details in multiple places. If the school name ever changed, you would have to update it in every data item in which it appeared, which is a time-consuming and error-prone task.
            In a relational database, each entity such as the person, the school, the place of work is stored in separate tables and unique instances if the entity are identified by a Primary Key value. Relationships or associations between entities are defined in a database by the existence of Foreign Keys.";


            post.Author = author;
            db.Post.Add(post);
            var count = db.SaveChanges();
            Assert.Equal(1, count);
           
        }

        [Fact]
        public void getAllPostFormAuthor1()
        {
            var db = new BlogContext();
            Author author = db.Author.Find(1);
            
           
            Assert.Equal(2, author.Posts.Count);

        }


    }
}
