using Grammophone.DataAccess.EntityFramework;

namespace Grammophone.DataAccess.Tests.Domain.EntityFramework
{
	/// <summary>
	/// Entity Framework 6 test domain container adapter.
	/// </summary>
	public class EFTestDomainContainerAdapter : EFDomainContainerAdapter<EFTestDomainContainer>, ITestDomainContainer
	{
		#region Private fields

		private IEntitySet<Parent> parents;
		private IEntitySet<Child> children;
		private IEntitySet<Dependent> dependents;
		private IEntitySet<EventRecord> events;

		#endregion

		#region Construction

		/// <summary>
		/// Create.
		/// </summary>
		/// <param name="innerContainer">The adapted domain container.</param>
		public EFTestDomainContainerAdapter(EFTestDomainContainer innerContainer)
			: base(innerContainer)
		{
		}

		#endregion

		#region ITestDomainContainer implementation

		/// <inheritdoc/>
		public IEntitySet<Parent> Parents => parents ??= new EFSet<Parent>(this.InnerDomainContainer.Parents, this);

		/// <inheritdoc/>
		public IEntitySet<Child> Children => children ??= new EFSet<Child>(this.InnerDomainContainer.Children, this);

		/// <inheritdoc/>
		public IEntitySet<Dependent> Dependents => dependents ??= new EFSet<Dependent>(this.InnerDomainContainer.Dependents, this);

		/// <inheritdoc/>
		public IEntitySet<EventRecord> Events => events ??= new EFSet<EventRecord>(this.InnerDomainContainer.Events, this);

		#endregion
	}
}
