// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using TestEFCoreCipher;


using var db = new BloggingContext();

//var connStr = $"Data Source={db.DbPath}";//连接字符串
//var conn = new SqliteConnectionStringBuilder(connStr)
//{
//    Mode = SqliteOpenMode.ReadWriteCreate,
//    Password = "123"
//}.ToString();
//using (var connection = new SqliteConnection(conn))
//{
//    connection.Open();
//    var com = connection.CreateCommand();
//    com.CommandText = @"CREATE TABLE Users (
//    ID INTEGER PRIMARY KEY AUTOINCREMENT,
//    UserName TEXT(16),
//    CreateTime TEXT NOT NULL
//);";
//    com.ExecuteNonQuery();
//}

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
//db.Remove(blog);
db.SaveChanges();
