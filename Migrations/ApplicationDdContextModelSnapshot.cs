// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyecto24BM.Context;

namespace proyecto24BM.Migrations
{
    [DbContext(typeof(ApplicationDdContext))]
    partial class ApplicationDdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("proyecto24BM.Models.Articulos", b =>
                {
                    b.Property<int>("PkArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urlimg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkArticulo");

                    b.ToTable("articulos");
                });

            modelBuilder.Entity("proyecto24BM.Models.roles", b =>
                {
                    b.Property<int>("Pkrol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pkrol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("proyecto24BM.Models.usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Fkrol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("Fkrol");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("proyecto24BM.Models.usuario", b =>
                {
                    b.HasOne("proyecto24BM.Models.roles", "Roles")
                        .WithMany()
                        .HasForeignKey("Fkrol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
