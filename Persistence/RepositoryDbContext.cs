

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactGroup>().HasData(
                new ContactGroup { Id = 1, GroupName = "Family" },
                new ContactGroup { Id = 2, GroupName = "Friends" },
                new ContactGroup { Id = 3, GroupName = "Work" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, Name = "John Doe", PhoneNumber = "123-456-7890", ContactType = "Mobile", GroupId = 1 },
                new Contact { Id = 2, Name = "Jane Doe", PhoneNumber = "987-654-3210", ContactType = "Home", GroupId = 2 },
                new Contact { Id = 3, Name = "Sam Smith", PhoneNumber = "555-666-7777", ContactType = "Work", GroupId = 3 },
                new Contact { Id = 4, Name = "Alice Johnson", PhoneNumber = "111-222-3333", ContactType = "Mobile", GroupId = 1 },
                new Contact { Id = 5, Name = "Bob Brown", PhoneNumber = "222-333-4444", ContactType = "Home", GroupId = 2 },
                new Contact { Id = 6, Name = "Charlie White", PhoneNumber = "333-444-5555", ContactType = "Work", GroupId = 3 },
                new Contact { Id = 7, Name = "David Black", PhoneNumber = "444-555-6666", ContactType = "Mobile", GroupId = 1 },
                new Contact { Id = 8, Name = "Eve Green", PhoneNumber = "555-666-7777", ContactType = "Home", GroupId = 2 },
                new Contact { Id = 9, Name = "Frank Red", PhoneNumber = "666-777-8888", ContactType = "Work", GroupId = 3 },
                new Contact { Id = 10, Name = "Grace Blue", PhoneNumber = "777-888-9999", ContactType = "Mobile", GroupId = 1 },
                new Contact { Id = 11, Name = "Henry Silver", PhoneNumber = "888-999-0000", ContactType = "Home", GroupId = 2 },
                new Contact { Id = 12, Name = "Isla Gold", PhoneNumber = "999-000-1111", ContactType = "Work", GroupId = 3 },
                new Contact { Id = 13, Name = "Jack Brown", PhoneNumber = "000-111-2222", ContactType = "Mobile", GroupId = 1 },
                new Contact { Id = 14, Name = "Karen White", PhoneNumber = "111-222-3333", ContactType = "Home", GroupId = 2 },
                new Contact { Id = 15, Name = "Leo Black", PhoneNumber = "222-333-4444", ContactType = "Work", GroupId = 3 },
                new Contact { Id = 16, Name = "Mia Red", PhoneNumber = "333-444-5555", ContactType = "Mobile", GroupId = 1 },
                new Contact { Id = 17, Name = "Nina Green", PhoneNumber = "444-555-6666", ContactType = "Home", GroupId = 2 },
                new Contact { Id = 18, Name = "Oscar Blue", PhoneNumber = "555-666-7777", ContactType = "Work", GroupId = 3 },
                new Contact { Id = 19, Name = "Peter Silver", PhoneNumber = "666-777-8888", ContactType = "Mobile", GroupId = 1 },
                new Contact { Id = 20, Name = "Quinn Gold", PhoneNumber = "777-888-9999", ContactType = "Home", GroupId = 2 }
            );
        }
    }
}
