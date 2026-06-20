# Grammophone.DataAccess.Tests.Domain.EntityFramework

Entity Framework 6 implementation of the shared music test domain.

This project defines `EFMusicDomainContainer` and `EFMusicDomainContainerAdapter`, mapping the portable `IMusicDomainContainer` contract from `Grammophone.DataAccess.Tests.Domain` to EF6 `DbSet` properties and adapted `IEntitySet<T>` properties.

It references [Grammophone.DataAccess](https://github.com/grammophone/Grammophone.DataAccess/tree/adaptQueryOperations) and [Grammophone.DataAccess.EntityFramework](https://github.com/grammophone/Grammophone.DataAccess.EntityFramework/tree/adaptQueryOperations). It is used by the EF6 concrete MSTest project to verify the same query and exception behavior as the EF Core implementation.
