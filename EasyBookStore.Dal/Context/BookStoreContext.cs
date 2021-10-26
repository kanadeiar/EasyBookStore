﻿using EasyBookStore.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EasyBookStore.Domain.Models.Identity;

namespace EasyBookStore.Dal.Context
{
    //public class BookStoreContext : IdentityDbContext<User, Role, string>
    //{
    //    public DbSet<Genre> Genres { get; set; }
    //    public DbSet<Author> Authors { get; set; }
    //    public DbSet<Product> Products { get; set; }

    //    public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

    //}
    public class BookStoreContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Product> Products { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

    }
}
