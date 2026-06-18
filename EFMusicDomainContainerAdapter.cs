using Grammophone.DataAccess.EntityFramework;

namespace Grammophone.DataAccess.Tests.Domain.EntityFramework
{
	/// <summary>
	/// Entity Framework 6 test domain container adapter.
	/// </summary>
	public class EFMusicDomainContainerAdapter : EFDomainContainerAdapter<EFMusicDomainContainer>, IMusicDomainContainer
	{
		#region Private fields

		private IEntitySet<Artist> artists;
		private IEntitySet<Album> albums;
		private IEntitySet<Track> tracks;
		private IEntitySet<Genre> genres;

		#endregion

		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="innerContainer">The adapted domain container.</param>
		public EFMusicDomainContainerAdapter(EFMusicDomainContainer innerContainer)
			: base(innerContainer)
		{
		}

		#endregion

		#region IMusicDomainContainer implementation

		/// <inheritdoc/>
		public IEntitySet<Artist> Artists => artists ??= new EFSet<Artist>(this.InnerDomainContainer.Artists, this);

		/// <inheritdoc/>
		public IEntitySet<Album> Albums => albums ??= new EFSet<Album>(this.InnerDomainContainer.Albums, this);

		/// <inheritdoc/>
		public IEntitySet<Track> Tracks => tracks ??= new EFSet<Track>(this.InnerDomainContainer.Tracks, this);

		/// <inheritdoc/>
		public IEntitySet<Genre> Genres => genres ??= new EFSet<Genre>(this.InnerDomainContainer.Genres, this);

		#endregion
	}
}
