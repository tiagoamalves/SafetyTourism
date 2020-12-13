﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SafetyTourism.Data;

namespace SafetyTourism.Migrations
{
    [DbContext(typeof(SafetyTourismdb))]
    [Migration("20201213012733_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("SafetyTourism.Models.DestinoTuristico", b =>
                {
                    b.Property<int>("DestinoTuristicoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Continente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DensidadeDemografica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDestino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinoTuristicoID");

                    b.ToTable("DestinoTuristicos");
                });

            modelBuilder.Entity("SafetyTourism.Models.Doenca", b =>
                {
                    b.Property<int>("DoencaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomeDoenca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoencaID");

                    b.ToTable("Doencas");
                });

            modelBuilder.Entity("SafetyTourism.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MailFuncionario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFuncionario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FuncionarioID");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("SafetyTourism.Models.GravidadeSurto", b =>
                {
                    b.Property<int>("GravidadeSurtoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<string>("NivelGravidade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GravidadeSurtoID");

                    b.ToTable("GravidadeSurtos");
                });

            modelBuilder.Entity("SafetyTourism.Models.GrupoRisco", b =>
                {
                    b.Property<int>("GrupoRiscoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DoencaID")
                        .HasColumnType("int");

                    b.Property<string>("Etnia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaixaEtaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GrupoRiscoID");

                    b.HasIndex("DoencaID");

                    b.ToTable("GrupoRiscos");
                });

            modelBuilder.Entity("SafetyTourism.Models.Recomendacoe", b =>
                {
                    b.Property<int>("RecomendacoeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<string>("Relatorio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecomendacoeID");

                    b.ToTable("Recomendacoes");
                });

            modelBuilder.Entity("SafetyTourism.Models.Sintoma", b =>
                {
                    b.Property<int>("SintomaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeSintoma")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SintomaID");

                    b.ToTable("Sintomas");
                });

            modelBuilder.Entity("SafetyTourism.Models.SurtosEpidemiologico", b =>
                {
                    b.Property<int>("SurtosEpidemiologicoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GrauContagio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GravidadeSurtoID")
                        .HasColumnType("int");

                    b.Property<int>("GrupoRiscoID")
                        .HasColumnType("int");

                    b.Property<string>("IndiceMortalidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeSurto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecomendacoeID")
                        .HasColumnType("int");

                    b.Property<int>("SintomaID")
                        .HasColumnType("int");

                    b.HasKey("SurtosEpidemiologicoID");

                    b.HasIndex("GravidadeSurtoID");

                    b.HasIndex("GrupoRiscoID");

                    b.HasIndex("RecomendacoeID");

                    b.HasIndex("SintomaID");

                    b.ToTable("SurtosEpidemiologicos");
                });

            modelBuilder.Entity("SafetyTourism.Models.SurtosOcurrencia", b =>
                {
                    b.Property<int>("SurtosOcurrenciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinoTuristicoID")
                        .HasColumnType("int");

                    b.Property<string>("Relatorio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurtosEpidemiologicoID")
                        .HasColumnType("int");

                    b.HasKey("SurtosOcurrenciaID");

                    b.HasIndex("DestinoTuristicoID");

                    b.HasIndex("SurtosEpidemiologicoID");

                    b.ToTable("SurtosOcurrencias");
                });

            modelBuilder.Entity("SafetyTourism.Models.Utilizador", b =>
                {
                    b.Property<int>("UtilizadorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MailUtilizador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoradaUtilizador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUtilizador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UtilizadorID");

                    b.ToTable("Utilizadors");
                });

            modelBuilder.Entity("SafetyTourism.Models.GrupoRisco", b =>
                {
                    b.HasOne("SafetyTourism.Models.Doenca", "Doenca")
                        .WithMany("GrupoRiscos")
                        .HasForeignKey("DoencaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doenca");
                });

            modelBuilder.Entity("SafetyTourism.Models.SurtosEpidemiologico", b =>
                {
                    b.HasOne("SafetyTourism.Models.GravidadeSurto", "GravidadeSurto")
                        .WithMany("SurtosEpidemiologicos")
                        .HasForeignKey("GravidadeSurtoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SafetyTourism.Models.GrupoRisco", "GrupoRisco")
                        .WithMany("SurtosEpidemiologicos")
                        .HasForeignKey("GrupoRiscoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SafetyTourism.Models.Recomendacoe", "Recomendacoe")
                        .WithMany("SurtosEpidemiologicos")
                        .HasForeignKey("RecomendacoeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SafetyTourism.Models.Sintoma", "Sintoma")
                        .WithMany("SurtosEpidemiologicos")
                        .HasForeignKey("SintomaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GravidadeSurto");

                    b.Navigation("GrupoRisco");

                    b.Navigation("Recomendacoe");

                    b.Navigation("Sintoma");
                });

            modelBuilder.Entity("SafetyTourism.Models.SurtosOcurrencia", b =>
                {
                    b.HasOne("SafetyTourism.Models.DestinoTuristico", "DestinoTuristico")
                        .WithMany("SurtosOcurrencias")
                        .HasForeignKey("DestinoTuristicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SafetyTourism.Models.SurtosEpidemiologico", "SurtosEpidemiologico")
                        .WithMany("SurtosOcurrencias")
                        .HasForeignKey("SurtosEpidemiologicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinoTuristico");

                    b.Navigation("SurtosEpidemiologico");
                });

            modelBuilder.Entity("SafetyTourism.Models.DestinoTuristico", b =>
                {
                    b.Navigation("SurtosOcurrencias");
                });

            modelBuilder.Entity("SafetyTourism.Models.Doenca", b =>
                {
                    b.Navigation("GrupoRiscos");
                });

            modelBuilder.Entity("SafetyTourism.Models.GravidadeSurto", b =>
                {
                    b.Navigation("SurtosEpidemiologicos");
                });

            modelBuilder.Entity("SafetyTourism.Models.GrupoRisco", b =>
                {
                    b.Navigation("SurtosEpidemiologicos");
                });

            modelBuilder.Entity("SafetyTourism.Models.Recomendacoe", b =>
                {
                    b.Navigation("SurtosEpidemiologicos");
                });

            modelBuilder.Entity("SafetyTourism.Models.Sintoma", b =>
                {
                    b.Navigation("SurtosEpidemiologicos");
                });

            modelBuilder.Entity("SafetyTourism.Models.SurtosEpidemiologico", b =>
                {
                    b.Navigation("SurtosOcurrencias");
                });
#pragma warning restore 612, 618
        }
    }
}
