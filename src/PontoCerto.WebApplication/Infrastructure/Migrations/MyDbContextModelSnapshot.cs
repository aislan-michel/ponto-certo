﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PontoCerto.WebApplication.Infrastructure;

#nullable disable

namespace PontoCerto.WebApplication.Infrastructure.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Cargo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Cargos", (string)null);
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Colaborador", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CargoId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EmpresaId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Colaboradores", (string)null);
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Empresa", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<int>("QuantidadeFuncionarios")
                        .HasColumnType("int");

                    b.Property<string>("Segmento")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Empresas", (string)null);
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.RegistroDePonto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ColaboradorId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("RegistrosDePonto", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Colaborador", b =>
                {
                    b.HasOne("PontoCerto.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Colaboradores")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontoCerto.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Colaboradores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PontoCerto.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<string>("ColaboradorId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasColumnType("varchar(120)")
                                .HasColumnName("Nome");

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasColumnType("varchar(120)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("ColaboradorId");

                            b1.ToTable("Colaboradores");

                            b1.WithOwner()
                                .HasForeignKey("ColaboradorId");
                        });

                    b.Navigation("Cargo");

                    b.Navigation("Empresa");

                    b.Navigation("Nome")
                        .IsRequired();
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Empresa", b =>
                {
                    b.OwnsOne("PontoCerto.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<string>("EmpresaId")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Bairro")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .HasColumnType("varchar(8)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Estado")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .HasColumnType("varchar(5)")
                                .HasColumnName("Numero");

                            b1.HasKey("EmpresaId");

                            b1.ToTable("Empresas");

                            b1.WithOwner()
                                .HasForeignKey("EmpresaId");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.RegistroDePonto", b =>
                {
                    b.HasOne("PontoCerto.Domain.Entities.Colaborador", "Colaborador")
                        .WithMany("RegistrosDePonto")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Cargo", b =>
                {
                    b.Navigation("Colaboradores");
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Colaborador", b =>
                {
                    b.Navigation("RegistrosDePonto");
                });

            modelBuilder.Entity("PontoCerto.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Colaboradores");
                });
#pragma warning restore 612, 618
        }
    }
}
