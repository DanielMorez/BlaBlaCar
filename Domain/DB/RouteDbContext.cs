using BlaBlaCar.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaCar.Domain.DB
{
    public class RouteDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public RouteDbContext(DbContextOptions<RouteDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public override DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<BookRoute> BookRoutes { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(y => y.Employee)
                .WithOne()
                .HasForeignKey<User>("EmployeeId")
                .IsRequired(true);
                x.HasIndex("EmployeeId").IsUnique(true);
            });
        
            #region Employee

            modelBuilder.Entity<Employee>(b =>
            {
                b.ToTable("Employees");
                EntityId(b);
                b.Property(x => x.FirstName)
                    .HasColumnName("FirsName")
                    .IsRequired();
                b.Property(x => x.Surname)
                    .HasColumnName("Surname")
                    .IsRequired();
                b.Property(x => x.Email)
                    .HasColumnName("Address");
                b.Ignore(x => x.FullName);
            });
            #endregion

            #region Route

            modelBuilder.Entity<Route>(b =>
            {
                b.ToTable("Routes");
                EntityId(b);
                b.Property(x => x.Car)
                    .HasColumnName("Car")
                    .IsRequired();
                b.Property(x => x.FromCity)
                    .HasColumnName("FromCity")
                    .IsRequired();
                b.Property(x => x.ToCity)
                    .HasColumnName("ToCity")
                    .IsRequired();
                b.Property(x => x.Price)
                    .HasColumnName("Price")
                    .IsRequired();
                b.Property(x => x.PassengersAmount)
                    .HasColumnName("PassengersAmount")
                    .IsRequired();
            });
            #endregion

            #region BookRoute

            modelBuilder.Entity<BookRoute>(b =>
            {
                b.ToTable("BookRoutes");
                EntityId(b);
                b.Property(x => x.Id)
                    .HasColumnName("Book")
                    .IsRequired();
            });
            #endregion


        }

        /// <summary>
        /// Описание идентификатора сущности модели
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="builder">Построитель модели данных</param>
        private static void EntityId<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(x => x.Id)
                .HasAnnotation("Npgsql:Serial", true);
        }
    }
}
