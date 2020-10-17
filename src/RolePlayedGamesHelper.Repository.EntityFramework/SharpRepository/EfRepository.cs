﻿using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.SharpRepository.Interfaces.Repository;

namespace RolePlayedGamesHelper.Repository.EntityFramework.SharpRepository
{
    public class EfRepository<T, TKey, TKey2> : EfCompoundKeyRepositoryBase<T, TKey, TKey2> where T : class
    {
        public EfRepository(IEfDbContext dbContext, ICompoundKeyCachingStrategy<T, TKey, TKey2> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
        }
    }

    public class EfRepository<T, TKey, TKey2, TKey3> : EfCompoundKeyRepositoryBase<T, TKey, TKey2, TKey3> where T : class, new()
    {
        public EfRepository(IEfDbContext dbContext, ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
        }
    }

    public class EfCompoundKeyRepository<T> : EfCompoundKeyRepositoryBase<T> where T : class
    {
        public EfCompoundKeyRepository(IEfDbContext dbContext, ICompoundKeyCachingStrategy<T> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
        }
    }

    /// <summary>
    /// Entity Framework repository layer
    /// </summary>
    /// <typeparam name="T">The Entity type</typeparam>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public class EfRepository<T, TKey> : EfRepositoryBase<T, TKey> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository&lt;T, TKey&gt;"/> class.
        /// </summary>
        /// <param name="dbContext">The Entity Framework DbContext.</param>
        /// <param name="cachingStrategy">The caching strategy to use.  Defaults to <see cref="NoCachingStrategy&lt;T, TKey&gt;" /></param>
        public EfRepository(IEfDbContext dbContext, ICachingStrategy<T, TKey> cachingStrategy = null) : base(dbContext, cachingStrategy)
        {
        }
    }

    /// <summary>
    /// Entity Framework repository layer
    /// </summary>
    /// <typeparam name="T">The Entity type</typeparam>
    public class EfRepository<T> : EfRepositoryBase<T, int>, IRepository<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="dbContext">The Entity Framework DbContext.</param>
        /// <param name="cachingStrategy">The caching strategy to use.  Defaults to <see cref="NoCachingStrategy&lt;T, TKey&gt;" /></param>
        public EfRepository(IEfDbContext dbContext, ICachingStrategy<T, int> cachingStrategy = null) : base(dbContext, cachingStrategy)
        {
        }
    }
}
