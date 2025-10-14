using Microsoft.EntityFrameworkCore;
using PortfilioMS.Models.Entities;
using System;

namespace PortfilioMS.Data.Seeds
{
    public static class BlogPostSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "Getting Started with ASP.NET Core MVC",
                    Slug = "getting-started-with-aspnet-core-mvc",
                    Summary = "Learn the fundamentals of building web applications with ASP.NET Core MVC and Entity Framework.",
                    Content = "In this comprehensive guide, we'll explore the basics of ASP.NET Core MVC...",
                    FeaturedImageUrl = "/images/blog/aspnet-core.jpg",
                    Tags = "ASP.NET Core, MVC, C#, Web Development",
                    Category = "Web Development",
                    IsPublished = true,
                    AllowComments = true,
                    ViewCount = 0,
                    PublishedDate = DateTime.UtcNow.AddDays(-10),
                    CreatedDate = DateTime.UtcNow.AddDays(-12),
                    UpdatedDate = DateTime.UtcNow.AddDays(-10),
                    MetaDescription = "Learn ASP.NET Core MVC fundamentals in this beginner-friendly guide.",
                    MetaKeywords = "ASP.NET Core, MVC, Web Development, Entity Framework"
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "Entity Framework Core Best Practices",
                    Slug = "entity-framework-core-best-practices",
                    Summary = "Discover best practices for using Entity Framework Core in your applications.",
                    Content = "Entity Framework Core is a powerful ORM that helps manage database access...",
                    FeaturedImageUrl = "/images/blog/entity-framework.jpg",
                    Tags = "Entity Framework, SQL, Performance, ORM",
                    Category = "Database",
                    IsPublished = true,
                    AllowComments = true,
                    ViewCount = 0,
                    PublishedDate = DateTime.UtcNow.AddDays(-5),
                    CreatedDate = DateTime.UtcNow.AddDays(-8),
                    UpdatedDate = DateTime.UtcNow.AddDays(-5),
                    MetaDescription = "Follow these EF Core best practices to write clean and efficient data access code.",
                    MetaKeywords = "Entity Framework, ORM, SQL, .NET"
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "Building RESTful APIs with ASP.NET Core",
                    Slug = "building-restful-apis-with-aspnet-core",
                    Summary = "Learn how to create robust and scalable REST APIs using ASP.NET Core Web API.",
                    Content = "RESTful APIs have become the standard for modern web services. In this post, you'll learn how to build APIs with ASP.NET Core...",
                    FeaturedImageUrl = "/images/blog/web-api.jpg",
                    Tags = "API, REST, ASP.NET Core, Web API",
                    Category = "API Development",
                    IsPublished = true,
                    AllowComments = true,
                    ViewCount = 0,
                    PublishedDate = DateTime.UtcNow.AddDays(-2),
                    CreatedDate = DateTime.UtcNow.AddDays(-5),
                    UpdatedDate = DateTime.UtcNow.AddDays(-2),
                    MetaDescription = "Build RESTful APIs using ASP.NET Core and follow clean API design principles.",
                    MetaKeywords = "REST, API, ASP.NET Core, Web API"
                }
            );
        }
    }
}
