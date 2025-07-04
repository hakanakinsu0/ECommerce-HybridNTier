﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Dal.ContextClasses;

#nullable disable

namespace Project.Dal.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Project.Entities.Models.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "ccfcd3d3-eace-4336-add0-3616dd671369",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(3490),
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Project.Entities.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ActivationCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            ConcurrencyStamp = "3226f8bb-327d-451f-83bf-ef35b033bba0",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 231, DateTimeKind.Local).AddTicks(2116),
                            Email = "hakan@gmail.com",
                            EmailConfirmed = true,
                            IsBanned = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "HAKAN@GMAIL.COM",
                            NormalizedUserName = "HKN123",
                            PasswordHash = "AQAAAAIAAYagAAAAEFeLXoThtoYlJcDRO+lYFgu2BJObgX4WXWyAJt9rfM10eQgPWJgZYhXfWAV6Q3pLlg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bfd86824-625a-4f59-b7d6-f111eb236941",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "hkn123"
                        });
                });

            modelBuilder.Entity("Project.Entities.Models.AppUserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("AppUserProfiles");
                });

            modelBuilder.Entity("Project.Entities.Models.AppUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique();

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 231, DateTimeKind.Local).AddTicks(2495),
                            RoleId = 1,
                            Status = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Project.Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Outdoors",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8167),
                            Description = "Totam incidunt nisi bilgiyasayarı odit qui voluptatem aspernatur dolorem minima.",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Clothing",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8239),
                            Description = "Ama voluptatum ullam nostrum eve ötekinden velit uzattı dolorem aut.",
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Grocery",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8292),
                            Description = "Vitae ipsum gazete açılmadan quasi blanditiis çobanın un layıkıyla beğendim.",
                            Status = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Grocery",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8369),
                            Description = "Düşünüyor sit qui göze adresini lakin sevindi ipsa sinema commodi.",
                            Status = 1
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Jewelery",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8424),
                            Description = "Qui quia anlamsız filmini otobüs inventore kutusu quia oldular ipsa.",
                            Status = 1
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Baby",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8471),
                            Description = "Dergi quia ut ut inventore eum enim magni voluptatem gülüyorum.",
                            Status = 1
                        },
                        new
                        {
                            Id = 7,
                            CategoryName = "Games",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8515),
                            Description = "Sokaklarda domates adanaya sıla eve odio aliquam quia fugit göze.",
                            Status = 1
                        },
                        new
                        {
                            Id = 8,
                            CategoryName = "Kids",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8591),
                            Description = "Telefonu aliquid ut consectetur minima layıkıyla modi gülüyorum gördüm cesurca.",
                            Status = 1
                        },
                        new
                        {
                            Id = 9,
                            CategoryName = "Movies",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8637),
                            Description = "Fugit et kapının eius tv eos non ama teldeki illo.",
                            Status = 1
                        },
                        new
                        {
                            Id = 10,
                            CategoryName = "Tools",
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(8681),
                            Description = "Umut iusto için gitti sayfası rem nisi odit voluptate qui.",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Project.Entities.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Project.Entities.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("OrderId", "ProductId")
                        .IsUnique();

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Project.Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UnitInStock")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(9236),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Handmade Steel Soap",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 251.86m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 183, DateTimeKind.Local).AddTicks(9410),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Incredible Frozen Pizza",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 477.18m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(69),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Practical Fresh Pizza",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 23.86m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(660),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Awesome Metal Chair",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 774.54m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(867),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Unbranded Soft Pants",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 749.41m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 6,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(1145),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Handcrafted Cotton Gloves",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 623.00m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 7,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(1353),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Intelligent Cotton Gloves",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 80.82m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 8,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(1803),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Handcrafted Fresh Mouse",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 242.95m
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 9,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(2660),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Handcrafted Plastic Gloves",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 923.26m
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 10,
                            CreatedDate = new DateTime(2025, 6, 11, 22, 39, 33, 184, DateTimeKind.Local).AddTicks(3190),
                            ImagePath = "data:image/svg+xml;charset=UTF-8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20version%3D%221.1%22%20baseProfile%3D%22full%22%20width%3D%22100%22%20height%3D%22100%22%3E%3Crect%20width%3D%22100%25%22%20height%3D%22100%25%22%20fill%3D%22grey%22%2F%3E%3Ctext%20x%3D%2250%22%20y%3D%2250%22%20font-size%3D%2220%22%20alignment-baseline%3D%22middle%22%20text-anchor%3D%22middle%22%20fill%3D%22white%22%3E100x100%3C%2Ftext%3E%3C%2Fsvg%3E",
                            ProductName = "Licensed Concrete Table",
                            Status = 1,
                            UnitInStock = 100,
                            UnitPrice = 560.57m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Project.Entities.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Project.Entities.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Project.Entities.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Project.Entities.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.Entities.Models.AppUserProfile", b =>
                {
                    b.HasOne("Project.Entities.Models.AppUser", "AppUser")
                        .WithOne("Profile")
                        .HasForeignKey("Project.Entities.Models.AppUserProfile", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Project.Entities.Models.AppUserRole", b =>
                {
                    b.HasOne("Project.Entities.Models.AppRole", "Role")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Entities.Models.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.Entities.Models.Order", b =>
                {
                    b.HasOne("Project.Entities.Models.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Project.Entities.Models.OrderDetail", b =>
                {
                    b.HasOne("Project.Entities.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Entities.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Project.Entities.Models.Product", b =>
                {
                    b.HasOne("Project.Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Project.Entities.Models.AppRole", b =>
                {
                    b.Navigation("AppUserRoles");
                });

            modelBuilder.Entity("Project.Entities.Models.AppUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Profile")
                        .IsRequired();

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Project.Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Project.Entities.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Project.Entities.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
