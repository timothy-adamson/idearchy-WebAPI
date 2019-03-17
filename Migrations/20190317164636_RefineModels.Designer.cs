﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IdeasAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IdeasAPI.Migrations
{
    [DbContext(typeof(IdeaContext))]
    [Migration("20190317164636_RefineModels")]
    partial class RefineModels
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

                    b.Property<int?>("IdeasIDs");

                    b.Property<bool>("IsConundrum");

                    b.Property<int?>("ParentID");

                    b.Property<int>("TreeID");

                    b.HasKey("IdeaID");

                    b.HasIndex("IdeasIDs");

                    b.HasIndex("ParentID");

                    b.HasIndex("TreeID");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("IdeasAPI.Models.Tree", b =>
                {
                    b.Property<int>("TreeID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<List<int>>("IdeasIDs");

                    b.HasKey("TreeID");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("IdeasAPI.Models.Idea", b =>
                {
                    b.HasOne("IdeasAPI.Models.Tree")
                        .WithMany("Ideas")
                        .HasForeignKey("IdeasIDs");

                    b.HasOne("IdeasAPI.Models.Idea", "ParentIdea")
                        .WithMany("ChildrenIdeas")
                        .HasForeignKey("ParentID");

                    b.HasOne("IdeasAPI.Models.Tree", "Tree")
                        .WithMany()
                        .HasForeignKey("TreeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}