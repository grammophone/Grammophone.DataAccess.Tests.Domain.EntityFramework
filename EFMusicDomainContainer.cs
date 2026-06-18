using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using Grammophone.DataAccess.EntityFramework;

namespace Grammophone.DataAccess.Tests.Domain.EntityFramework
{
	/// <summary>
	/// Entity Framework 6 test domain container.
	/// </summary>
	public class EFMusicDomainContainer : EFDomainContainer
	{
		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		public EFMusicDomainContainer()
		{
		}

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="nameOrConnectionString">The database name or connection string.</param>
		public EFMusicDomainContainer(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{
		}

		#endregion

		#region Public properties

		/// <summary>Artists.</summary>
		public DbSet<Artist> Artists { get; set; }

		/// <summary>Albums.</summary>
		public DbSet<Album> Albums { get; set; }

		/// <summary>Tracks.</summary>
		public DbSet<Track> Tracks { get; set; }

		/// <summary>Genres.</summary>
		public DbSet<Genre> Genres { get; set; }

		#endregion

		#region Protected methods

		/// <inheritdoc/>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Artist>().HasKey(a => a.ID);
			modelBuilder.Entity<Artist>().Property(a => a.Name).IsRequired().HasMaxLength(200)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName,
					new IndexAnnotation(new IndexAttribute("IX_Artists_Name") { IsUnique = true }));

			modelBuilder.Entity<Album>().HasKey(a => a.ID);
			modelBuilder.Entity<Album>().Property(a => a.Name).IsRequired().HasMaxLength(200)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName,
					new IndexAnnotation(new IndexAttribute("IX_Albums_Name") { IsUnique = true }));
			modelBuilder.Entity<Album>()
				.HasRequired(a => a.Artist)
				.WithMany(a => a.Albums)
				.HasForeignKey(a => a.ArtistID);
			modelBuilder.Entity<Album>()
				.HasRequired(a => a.Genre)
				.WithMany(g => g.Albums)
				.HasForeignKey(a => a.GenreID);

			modelBuilder.Entity<Track>().HasKey(t => t.ID);
			modelBuilder.Entity<Track>().Property(t => t.Name).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Track>()
				.HasRequired(t => t.Album)
				.WithMany(a => a.Tracks)
				.HasForeignKey(t => t.AlbumID);
			modelBuilder.Entity<Track>()
				.HasRequired(t => t.Genre)
				.WithMany(g => g.Tracks)
				.HasForeignKey(t => t.GenreID);

			modelBuilder.Entity<Genre>().HasKey(g => g.ID);
			modelBuilder.Entity<Genre>().Property(g => g.Name).IsRequired().HasMaxLength(200)
				.HasColumnAnnotation(
					IndexAnnotation.AnnotationName,
					new IndexAnnotation(new IndexAttribute("IX_Genres_Name") { IsUnique = true }));
		}

		#endregion
	}
}
