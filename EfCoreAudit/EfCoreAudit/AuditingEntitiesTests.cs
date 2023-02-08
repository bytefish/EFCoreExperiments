// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EfCoreAudit.Model;
using EfCoreAudit.Tests;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EfCoreAudit
{
    [TestFixture]
    internal class AuditingEntitiesTests : TransactionalTestBase
    {
        public override async Task OnSetupBeforeTransaction()
        {
            await _applicationDbContext.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task AuditingEntites_SaveChanges_SetsCreatedDateTime()
        {
            // Prepare
            var person = new Person 
            {
                FullName = "Philipp Wagner"
            };

            // Act
            await _applicationDbContext.AddAsync(person);
            await _applicationDbContext.SaveChangesAsync();

            // Assert
            var people = await _applicationDbContext.People
                .AsNoTracking()
                .ToListAsync();

            Assert.AreEqual(1, people.Count);

            Assert.AreEqual("Philipp Wagner", people[0].FullName);

            Assert.IsNotNull(people[0].CreatedDateTime);
            Assert.IsNull(people[0].ModifiedDateTime);
        }

        [Test]
        public async Task AuditingEntites_SaveChanges_SetsModifiedDateTime()
        {
            // Prepare
            var person = new Person
            {
                FullName = "Philipp Wagner"
            };
            
            await _applicationDbContext.AddAsync(person);
            await _applicationDbContext.SaveChangesAsync();

            // Act
            person.FullName = "Edited Name";

            await _applicationDbContext.SaveChangesAsync();

            // Assert
            var people = await _applicationDbContext.People
                .AsNoTracking()
                .ToListAsync();

            Assert.AreEqual(1, people.Count);

            Assert.AreEqual("Edited Name", people[0].FullName);

            Assert.IsNotNull(people[0].CreatedDateTime);
            Assert.IsNotNull(people[0].ModifiedDateTime);
        }

        [Test]
        public async Task AuditingEntites_ExecuteUpdate_SetsModifiedDateTime()
        {
            // Prepare
            var person = new Person
            {
                FullName = "Philipp Wagner"
            };

            await _applicationDbContext.AddAsync(person);
            await _applicationDbContext.SaveChangesAsync();

            // Act
            await _applicationDbContext.People.ExecuteUpdateAsync(s => 
                s.SetProperty(p => p.FullName, p => "Edited Name"));

            // Assert
            var people = await _applicationDbContext.People
                .AsNoTracking()
                .ToListAsync();

            Assert.AreEqual(1, people.Count);

            Assert.AreEqual("Edited Name", people[0].FullName);

            Assert.IsNotNull(people[0].CreatedDateTime);
            Assert.IsNotNull(people[0].ModifiedDateTime);
        }
    }
}
