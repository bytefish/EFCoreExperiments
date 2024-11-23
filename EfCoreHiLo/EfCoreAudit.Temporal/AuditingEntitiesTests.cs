// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EfCoreAudit.Temporal.Model;
using EfCoreAudit.Temporal.Tests;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EfCoreAudit.Temporal
{
    [TestFixture]
    internal class AuditingEntitiesTests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            using (var context = CreateDbContext())
            {
                context.Database.ExecuteSqlRaw("EXEC [Application].[usp_Database_ResetForTests]");
            }
        }

        [Test]
        public async Task AuditingEntites_SaveChanges_SetsCreatedDateTime()
        {
            // Prepare
            using var context = CreateDbContext();

            var person = new Person
            {
                FullName = "Philipp Wagner"
            };

            // Act
            await context.AddAsync(person);
            await context.SaveChangesAsync();

            // Assert
            var people = await context.People
                .AsNoTracking()
                .ToListAsync();

            var peopleHistory = await context.People.TemporalAll()
                .AsNoTracking()
                .ToListAsync();

            Assert.AreEqual(1, people.Count);

            Assert.AreEqual("Philipp Wagner", people[0].FullName);

            Assert.That(people[0].ValidFrom, Is.EqualTo(DateTime.UtcNow).Within(1).Seconds);
            Assert.That(people[0].ValidTo, Is.EqualTo(new DateTime(9999, 12, 31, 23, 59, 59)).Within(1).Seconds);

            Assert.AreEqual(1, peopleHistory.Count);

            Assert.That(peopleHistory[0].ValidFrom, Is.EqualTo(DateTime.UtcNow).Within(1).Seconds);
            Assert.That(peopleHistory[0].ValidTo, Is.EqualTo(new DateTime(9999, 12, 31, 23, 59, 59)).Within(1).Seconds);
        }

        [Test]
        public async Task AuditingEntites_SaveChanges_SetsModifiedDateTime()
        {

            // Prepare
            using var context = CreateDbContext();
            
            var person = new Person
            {
                FullName = "Philipp Wagner"
            };

            await context.AddAsync(person);
            await context.SaveChangesAsync();

            // Act
            person.FullName = "Edited Name";

            await context.SaveChangesAsync();

            // Assert
            var people = await context.People
                .AsNoTracking()
                .ToListAsync();

            var peopleHistory = await context.People.TemporalAll()
                .OrderByDescending(x => x.ValidFrom)
                .AsNoTracking()
                .ToListAsync();

            // Check Current Entity
            Assert.AreEqual(1, people.Count);

            Assert.AreEqual("Edited Name", people[0].FullName);

            Assert.IsNotNull(people[0].ValidFrom);
            Assert.IsNotNull(people[0].ValidTo);

            // Check Person History
            Assert.AreEqual(2, peopleHistory.Count);

            Assert.AreEqual("Edited Name", peopleHistory[0].FullName);
            Assert.That(peopleHistory[0].ValidTo, Is.EqualTo(new DateTime(9999, 12, 31, 23, 59, 59)).Within(1).Seconds);

            Assert.AreEqual("Philipp Wagner", peopleHistory[1].FullName);
            Assert.That(peopleHistory[1].ValidTo, Is.LessThan(new DateTime(9999, 12, 31, 23, 59, 59)));
        }

        [Test]
        public async Task AuditingEntites_ExecuteUpdate_SetsModifiedDateTime()
        {
            // Prepare
            using var context = CreateDbContext();

            var person = new Person
            {
                FullName = "Philipp Wagner"
            };

            await context.AddAsync(person);
            await context.SaveChangesAsync();

            // Act
            await context.People.ExecuteUpdateAsync(s =>
                s.SetProperty(p => p.FullName, p => "Edited Name"));

            // Assert
            var people = await context.People
                .AsNoTracking()
                .ToListAsync();

            var peopleHistory = await context.People.TemporalAll()
                .OrderByDescending(x => x.ValidFrom)
                .AsNoTracking()
                .ToListAsync();

            // Check Current Entity
            Assert.AreEqual(1, people.Count);

            Assert.AreEqual("Edited Name", people[0].FullName);

            Assert.IsNotNull(people[0].ValidFrom);
            Assert.IsNotNull(people[0].ValidTo);

            // Check Person History
            Assert.AreEqual(2, peopleHistory.Count);

            Assert.AreEqual("Edited Name", peopleHistory[0].FullName);
            Assert.That(peopleHistory[0].ValidTo, Is.EqualTo(new DateTime(9999, 12, 31, 23, 59, 59)).Within(1).Seconds);


            Assert.AreEqual("Philipp Wagner", peopleHistory[1].FullName);
            Assert.That(peopleHistory[1].ValidTo, Is.LessThan(new DateTime(9999, 12, 31, 23, 59, 59)));
        }
    }
}
