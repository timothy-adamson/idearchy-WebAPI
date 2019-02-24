﻿// <auto-generated />
using System;
using IdeasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IdeasAPI.Migrations
{
    [DbContext(typeof(IdeaContext))]
    [Migration("20190224192714_nullableParent")]
    partial class nullableParent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IdeasAPI.Models.Idea", b =>
                {
                    b.Property<int>("IdeaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Colour");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("FromCountry");

                    b.Property<string>("IdeaText")
                        .HasMaxLength(500);

                    b.Property<bool>("IsConundrum");

                    b.Property<int?>("ParentID");

                    b.HasKey("IdeaID");

                    b.HasIndex("ParentID");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("IdeasAPI.Models.Idea", b =>
                {
                    b.HasOne("IdeasAPI.Models.Idea", "ParentIdea")
                        .WithMany("ChildrenIdeas")
                        .HasForeignKey("ParentID");
                });
#pragma warning restore 612, 618
        }
    }
}
