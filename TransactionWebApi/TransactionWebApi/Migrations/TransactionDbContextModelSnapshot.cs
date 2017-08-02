using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TransactionWebApi.Models;

namespace TransactionWebApi.Migrations
{
    [DbContext(typeof(TransactionDbContext))]
    partial class TransactionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionWebApi.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CurrencyCode");

                    b.Property<string>("Description");

                    b.Property<string>("Merchant");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<decimal>("TransactionAmount");

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("TransactionId");

                    b.ToTable("Transaction");
                });
        }
    }
}
