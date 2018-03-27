﻿// <auto-generated />
using fp_web_aula_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace fp_web_aula_1.Migrations
{
    [DbContext(typeof(CopaContext))]
    partial class CopaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("fp_web_aula_1.Models.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Camisa");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("Posicao");

                    b.HasKey("Id");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("fp_web_aula_1.Models.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bandeira");

                    b.Property<string>("EnderecoDeEmail");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<bool>("Publicado");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });
#pragma warning restore 612, 618
        }
    }
}
