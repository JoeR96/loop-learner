using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScaleSlayer.Domain.Common.Entities;
using ScaleSlayer.Domain.ScaleAggregate.ValueObjects;
using ScaleSlayer.Domain.UserAggregate;

namespace ScaleSlayer.Infrastructure.Persistence;

public static class DataSeed
{
    public static void Seed(ModelBuilder modelBuilder, IPasswordHasher<User> passwordHasher)
    {
        var alincoln = User.CreateNew("Abraham", "Lincoln", "alincoln", "lincoln.abraham@example.com", "HonestAbe1865");
        var jcaesar = User.CreateNew("Julius", "Caesar", "jcaesar", "caesar.julius@example.com", "EtTuBrute44BC");
        var aeinstein = User.CreateNew("Albert", "Einstein", "aeinstein", "einstein.albert@example.com", "E=mc2Genius");
        var mcurie = User.CreateNew("Marie", "Curie", "mcurie", "curie.marie@example.com", "Radioactive1898");
        var ldavinci = User.CreateNew("Leonardo", "da Vinci", "ldavinci", "davinci.leonardo@example.com",
            "Renaissance1452");
        var wshakespeare = User.CreateNew("William", "Shakespeare", "wshakespeare", "shakespeare.william@example.com",
            "ToBeOrNotToBe1600");
        var ccleopatra = User.CreateNew("Cleopatra", "", "ccleopatra", "cleopatra@example.com", "QueenOfEgypt30BC");
        var aalexander = User.CreateNew("Alexander", "the Great", "aalexander", "alexander@example.com",
            "Conqueror356BC");
        var ntesla = User.CreateNew("Nikola", "Tesla", "ntesla", "tesla.nikola@example.com", "ACPowerGenius1856");
        var wgenghis = User.CreateNew("Genghis", "Khan", "wgenghis", "genghis.khan@example.com", "MongolEmpire1162");

        var users = new[]
            { alincoln, jcaesar, aeinstein, mcurie, ldavinci, wshakespeare, ccleopatra, aalexander, ntesla, wgenghis };
        foreach (var user in users)
        {
            var hashedPassword = passwordHasher.HashPassword(user, user.Password);
            user.UpdatePassword(hashedPassword);
        }

        modelBuilder.Entity<User>().HasData(users);

    }

    public static async Task SeedNotes(ScaleSlayerDbContext context)
    {
        var notes = new List<FretNote>
        {
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(6, 0)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(6, 1)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(6, 2)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(6, 3)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(6, 4)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(6, 5)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(6, 6)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(6, 7)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(6, 8)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(6, 9)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(6, 10)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(6, 11)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(6, 12)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(6, 13)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(6, 14)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(6, 15)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(6, 16)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(6, 17)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(6, 18)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(6, 19)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(6, 20)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(6, 21)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(6, 22)),

            FretNote.CreateNew(Note.A, NotePosition.CreateNew(5, 0)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(5, 1)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(5, 2)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(5, 3)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(5, 4)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(5, 5)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(5, 6)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(5, 7)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(5, 8)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(5, 9)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(5, 10)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(5, 11)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(5, 12)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(5, 13)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(5, 14)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(5, 15)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(5, 16)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(5, 17)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(5, 18)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(5, 19)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(5, 20)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(5, 21)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(5, 22)),

            FretNote.CreateNew(Note.D, NotePosition.CreateNew(4, 0)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(4, 1)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(4, 2)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(4, 3)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(4, 4)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(4, 5)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(4, 6)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(4, 7)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(4, 8)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(4, 9)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(4, 10)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(4, 11)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(4, 12)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(4, 13)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(4, 14)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(4, 15)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(4, 16)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(4, 17)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(4, 18)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(4, 19)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(4, 20)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(4, 21)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(4, 22)),

            FretNote.CreateNew(Note.G, NotePosition.CreateNew(3, 0)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(3, 1)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(3, 2)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(3, 3)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(3, 4)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(3, 5)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(3, 6)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(3, 7)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(3, 8)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(3, 9)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(3, 10)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(3, 11)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(3, 12)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(3, 13)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(3, 14)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(3, 15)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(3, 16)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(3, 17)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(3, 18)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(3, 19)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(3, 20)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(3, 21)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(3, 22)),

            FretNote.CreateNew(Note.B, NotePosition.CreateNew(2, 0)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(2, 1)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(2, 2)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(2, 3)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(2, 4)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(2, 5)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(2, 6)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(2, 7)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(2, 8)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(2, 9)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(2, 10)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(2, 11)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(2, 12)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(2, 13)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(2, 14)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(2, 15)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(2, 16)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(2, 17)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(2, 18)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(2, 19)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(2, 20)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(2, 21)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(2, 22)),

            FretNote.CreateNew(Note.E, NotePosition.CreateNew(1, 0)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(1, 1)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(1, 2)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(1, 3)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(1, 4)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(1, 5)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(1, 6)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(1, 7)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(1, 8)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(1, 9)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(1, 10)),
            FretNote.CreateNew(Note.DSharp, NotePosition.CreateNew(1, 11)),
            FretNote.CreateNew(Note.E, NotePosition.CreateNew(1, 12)),
            FretNote.CreateNew(Note.F, NotePosition.CreateNew(1, 13)),
            FretNote.CreateNew(Note.FSharp, NotePosition.CreateNew(1, 14)),
            FretNote.CreateNew(Note.G, NotePosition.CreateNew(1, 15)),
            FretNote.CreateNew(Note.GSharp, NotePosition.CreateNew(1, 16)),
            FretNote.CreateNew(Note.A, NotePosition.CreateNew(1, 17)),
            FretNote.CreateNew(Note.ASharp, NotePosition.CreateNew(1, 18)),
            FretNote.CreateNew(Note.B, NotePosition.CreateNew(1, 19)),
            FretNote.CreateNew(Note.C, NotePosition.CreateNew(1, 20)),
            FretNote.CreateNew(Note.CSharp, NotePosition.CreateNew(1, 21)),
            FretNote.CreateNew(Note.D, NotePosition.CreateNew(1, 22)),
        };

        await context.Notes.AddRangeAsync(notes);
        await context.SaveChangesAsync();
    }


    public static void SeedNotePositions(ModelBuilder modelBuilder)
    {
        var notePositions = new List<NotePosition>
        {
            NotePosition.CreateNew(6, 0),
            NotePosition.CreateNew(6, 1),
            NotePosition.CreateNew(6, 2),
            NotePosition.CreateNew(6, 3),
            NotePosition.CreateNew(6, 4),
            NotePosition.CreateNew(6, 5),
            NotePosition.CreateNew(6, 6),
            NotePosition.CreateNew(6, 7),
            NotePosition.CreateNew(6, 8),
            NotePosition.CreateNew(6, 9),
            NotePosition.CreateNew(6, 10),
            NotePosition.CreateNew(6, 11),
            NotePosition.CreateNew(6, 12),
            NotePosition.CreateNew(6, 13),
            NotePosition.CreateNew(6, 14),
            NotePosition.CreateNew(6, 15),
            NotePosition.CreateNew(6, 16),
            NotePosition.CreateNew(6, 17),
            NotePosition.CreateNew(6, 18),
            NotePosition.CreateNew(6, 19),
            NotePosition.CreateNew(6, 20),
            NotePosition.CreateNew(6, 21),
            NotePosition.CreateNew(6, 22),
            NotePosition.CreateNew(6, 23),
            NotePosition.CreateNew(6, 24),

            NotePosition.CreateNew(5, 0),
            NotePosition.CreateNew(5, 1),
            NotePosition.CreateNew(5, 2),
            NotePosition.CreateNew(5, 3),
            NotePosition.CreateNew(5, 4),
            NotePosition.CreateNew(5, 5),
            NotePosition.CreateNew(5, 6),
            NotePosition.CreateNew(5, 7),
            NotePosition.CreateNew(5, 8),
            NotePosition.CreateNew(5, 9),
            NotePosition.CreateNew(5, 10),
            NotePosition.CreateNew(5, 11),
            NotePosition.CreateNew(5, 12),
            NotePosition.CreateNew(5, 13),
            NotePosition.CreateNew(5, 14),
            NotePosition.CreateNew(5, 15),
            NotePosition.CreateNew(5, 16),
            NotePosition.CreateNew(5, 17),
            NotePosition.CreateNew(5, 18),
            NotePosition.CreateNew(5, 19),
            NotePosition.CreateNew(5, 20),
            NotePosition.CreateNew(5, 21),
            NotePosition.CreateNew(5, 22),
            NotePosition.CreateNew(5, 23),
            NotePosition.CreateNew(5, 24),

            NotePosition.CreateNew(4, 0),
            NotePosition.CreateNew(4, 1),
            NotePosition.CreateNew(4, 2),
            NotePosition.CreateNew(4, 3),
            NotePosition.CreateNew(4, 4),
            NotePosition.CreateNew(4, 5),
            NotePosition.CreateNew(4, 6),
            NotePosition.CreateNew(4, 7),
            NotePosition.CreateNew(4, 8),
            NotePosition.CreateNew(4, 9),
            NotePosition.CreateNew(4, 10),
            NotePosition.CreateNew(4, 11),
            NotePosition.CreateNew(4, 12),
            NotePosition.CreateNew(4, 13),
            NotePosition.CreateNew(4, 14),
            NotePosition.CreateNew(4, 15),
            NotePosition.CreateNew(4, 16),
            NotePosition.CreateNew(4, 17),
            NotePosition.CreateNew(4, 18),
            NotePosition.CreateNew(4, 19),
            NotePosition.CreateNew(4, 20),
            NotePosition.CreateNew(4, 21),
            NotePosition.CreateNew(4, 22),
            NotePosition.CreateNew(4, 23),
            NotePosition.CreateNew(4, 24),

            NotePosition.CreateNew(3, 0),
            NotePosition.CreateNew(3, 1),
            NotePosition.CreateNew(3, 2),
            NotePosition.CreateNew(3, 3),
            NotePosition.CreateNew(3, 4),
            NotePosition.CreateNew(3, 5),
            NotePosition.CreateNew(3, 6),
            NotePosition.CreateNew(3, 7),
            NotePosition.CreateNew(3, 8),
            NotePosition.CreateNew(3, 9),
            NotePosition.CreateNew(3, 10),
            NotePosition.CreateNew(3, 11),
            NotePosition.CreateNew(3, 12),
            NotePosition.CreateNew(3, 13),
            NotePosition.CreateNew(3, 14),
            NotePosition.CreateNew(3, 15),
            NotePosition.CreateNew(3, 16),
            NotePosition.CreateNew(3, 17),
            NotePosition.CreateNew(3, 18),
            NotePosition.CreateNew(3, 19),
            NotePosition.CreateNew(3, 20),
            NotePosition.CreateNew(3, 21),
            NotePosition.CreateNew(3, 22),
            NotePosition.CreateNew(3, 23),
            NotePosition.CreateNew(3, 24),

            NotePosition.CreateNew(2, 0),
            NotePosition.CreateNew(2, 1),
            NotePosition.CreateNew(2, 2),
            NotePosition.CreateNew(2, 3),
            NotePosition.CreateNew(2, 4),
            NotePosition.CreateNew(2, 5),
            NotePosition.CreateNew(2, 6),
            NotePosition.CreateNew(2, 7),
            NotePosition.CreateNew(2, 8),
            NotePosition.CreateNew(2, 9),
            NotePosition.CreateNew(2, 10),
            NotePosition.CreateNew(2, 11),
            NotePosition.CreateNew(2, 12),
            NotePosition.CreateNew(2, 13),
            NotePosition.CreateNew(2, 14),
            NotePosition.CreateNew(2, 15),
            NotePosition.CreateNew(2, 16),
            NotePosition.CreateNew(2, 17),
            NotePosition.CreateNew(2, 18),
            NotePosition.CreateNew(2, 19),
            NotePosition.CreateNew(2, 20),
            NotePosition.CreateNew(2, 21),
            NotePosition.CreateNew(2, 22),
            NotePosition.CreateNew(2, 23),
            NotePosition.CreateNew(2, 24),

            NotePosition.CreateNew(1, 0),
            NotePosition.CreateNew(1, 1),
            NotePosition.CreateNew(1, 2),
            NotePosition.CreateNew(1, 3),
            NotePosition.CreateNew(1, 4),
            NotePosition.CreateNew(1, 5),
            NotePosition.CreateNew(1, 6),
            NotePosition.CreateNew(1, 7),
            NotePosition.CreateNew(1, 8),
            NotePosition.CreateNew(1, 9),
            NotePosition.CreateNew(1, 10),
            NotePosition.CreateNew(1, 11),
            NotePosition.CreateNew(1, 12),
            NotePosition.CreateNew(1, 13),
            NotePosition.CreateNew(1, 14),
            NotePosition.CreateNew(1, 15),
            NotePosition.CreateNew(1, 16),
            NotePosition.CreateNew(1, 17),
            NotePosition.CreateNew(1, 18),
            NotePosition.CreateNew(1, 19),
            NotePosition.CreateNew(1, 20),
            NotePosition.CreateNew(1, 21),
            NotePosition.CreateNew(1, 22),
            NotePosition.CreateNew(1, 23),
            NotePosition.CreateNew(1, 24),
        };

        modelBuilder.Entity<NotePosition>().HasData(notePositions);
    }
}



