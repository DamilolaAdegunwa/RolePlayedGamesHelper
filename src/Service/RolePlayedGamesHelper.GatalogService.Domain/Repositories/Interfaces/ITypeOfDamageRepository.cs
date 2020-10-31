﻿using RolePlayedGamesHelper.GatalogService.Domain.Scaffold;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.GatalogService.Domain.Repositories.Interfaces
{
    /// <inheritdoc cref="IRepository" />
    public interface ITypeOfDamageRepository : IRepository<TypeOfDamage, int>
    {
    }
}