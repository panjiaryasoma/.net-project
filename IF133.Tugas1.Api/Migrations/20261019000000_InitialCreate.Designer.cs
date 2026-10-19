using IF133.Tugas1.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IF133.Tugas1.Api.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("20261019000000_InitialCreate")]
public partial class InitialCreate
{
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

        modelBuilder.Entity("IF133.Tugas1.Api.Entities.Product", entity =>
        {
            entity.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("INTEGER");

            entity.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnType("TEXT");

            entity.Property<string>("Description")
                .HasMaxLength(500)
                .HasColumnType("TEXT");

            entity.Property<decimal>("Price")
                .HasColumnType("TEXT");

            entity.Property<int>("Stock")
                .HasColumnType("INTEGER");

            entity.HasKey("Id");
            entity.ToTable("Products");
        });
    }
}
