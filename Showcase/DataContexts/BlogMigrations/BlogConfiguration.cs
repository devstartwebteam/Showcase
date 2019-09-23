namespace Showcase.DataContexts.BlogMigrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Showcase.DataContexts.BlogDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\BlogMigrations";
        }

        protected override void Seed(Showcase.DataContexts.BlogDb context)
        {
            /*var authors = new List<Author>
            {
            new Author{FirstName="Nathan",LastName="Johnson", Location="Oregon", UserName="devstartwebteam", NickName="Nate"},
            };

            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category{CategoryName=".NET", CategoryDescription="The .NET framework is a software development framework that is made up of the FCL (Framework Class Library) and the CLR (Common Language Runtime)"},
                new Category{CategoryName="WordPress", CategoryDescription="WordPress is a popular blogging platform and website development tool that runs on the LAMP stack."},
                new Category{CategoryName="Reactive JavaScript", CategoryDescription="Reactive JavaScript refers to JavaScript frameworks that implement the Obsever pattern in order to respond to a stream of events."},
                new Category{CategoryName="C#", CategoryDescription="C# is a modern programming language developed by Microsoft. It is strongly typed, imperative, declarative and object oriented. "},
                new Category{CategoryName="Java", CategoryDescription="Java is a general-purpose computer-programming language that is concurrent, class-based, object-oriented, and highly portable due to it being compiled to bytecode."},
                new Category{CategoryName="Front End", CategoryDescription="Front end development refers to programming that occurs in the Browser which is usually aided by Browser Web APIs also called BOM APIs."},
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();*/
        }
    }
}
