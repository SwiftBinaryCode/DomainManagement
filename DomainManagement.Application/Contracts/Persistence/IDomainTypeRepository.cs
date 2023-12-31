﻿using DomainManagement.Domain;

namespace DomainManagement.Application.Contracts.Persistence
{
  
    public interface IDomainTypeRepository : IGenericRepository<DomainType>
    {
        Task<bool> IsDomainTypeUnique(string name);

    }
}