﻿using System.Collections.Concurrent;
using System.Threading;
using FluentAssertions;
using Microsoft.Extensions.Caching.Memory;
using RolePlayedGamesHelper.Repository.InMemoryRepository.SharpRepository;
using RolePlayedGamesHelper.Repository.SharpRepository.Caching;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects;
using RolePlayedGamesHelper.Repository.UnitTests.TestObjects.Assert;
using Xunit;

namespace RolePlayedGamesHelper.Repository.UnitTests.Caching
{
    public class TimeoutCachingStrategyTests : TestBase
    {
        private ICachingProvider cacheProvider;

        public TimeoutCachingStrategyTests()
        {
            cacheProvider = new InMemoryCachingProvider(new MemoryCache(new MemoryCacheOptions()));
        }

        [Fact]
        public void Second_Get_Call_Should_Get_New_Item_From_Cache()
        {
            var repository = new InMemRepository<Contact, int>(
                    new ConcurrentDictionary<int, Contact>(), new TimeoutCachingStrategy<Contact, int>(10, cacheProvider) { CachePrefix = "#RepoTimeoutCache" });

            repository.Add(new Contact() { Name = "Test User" });

            var item = repository.Get(1); // after this call it's in cache
            item.Name.Should().Be("Test User");

            repository.Update(new Contact() { ContactId = 1, Name = "Test User EDITED" }); // does update cache

            var item2 = repository.Get(1); // should get from cache since the timeout hasn't happened
            item2.Name.Should().Be("Test User EDITED");
        }

        [Fact]
        public void Cache_Should_Timeout()
        {
            var repository = new InMemRepository<Contact, int>(
                    new ConcurrentDictionary<int, Contact>(), new TimeoutCachingStrategy<Contact, int>(2, cacheProvider) { CachePrefix = "#RepoTimeoutCache" });
            repository.Add(new Contact() { Name = "Test User" });

            repository.Get(1);
            repository.CacheUsed.Should().BeTrue();

            Thread.Sleep(5000);

            repository.Get(1);
            repository.CacheUsed.Should().BeFalse();
        }
    }
}
