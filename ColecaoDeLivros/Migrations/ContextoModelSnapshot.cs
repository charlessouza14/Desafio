﻿// <auto-generated />
using System;
using ColecaoDeItem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ColecaoDeItem.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ColecaoDeLivros.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemEmprestado")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemEmprestado")
                        .IsUnique()
                        .HasFilter("[ItemEmprestado] IS NOT NULL");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("ColecaoDeLivros.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Item");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("ColecaoDeLivros.Models.ItemEmprestado", b =>
                {
                    b.HasBaseType("ColecaoDeLivros.Models.Item");

                    b.HasDiscriminator().HasValue("ItemEmprestado");
                });

            modelBuilder.Entity("ColecaoDeLivros.Models.Contato", b =>
                {
                    b.HasOne("ColecaoDeLivros.Models.Item", null)
                        .WithOne("Contato")
                        .HasForeignKey("ColecaoDeLivros.Models.Contato", "ItemEmprestado");
                });

            modelBuilder.Entity("ColecaoDeLivros.Models.Item", b =>
                {
                    b.Navigation("Contato")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
