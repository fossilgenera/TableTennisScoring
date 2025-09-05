using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Reflection.Emit;
using System.Threading.Tasks;


namespace TableTennisScoring.Models
{
    public class TableTennisScoringContext : DbContext
    {
        public string DbPath { get; }

        public TableTennisScoringContext(DbContextOptions<TableTennisScoringContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "tabletennisscoring.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<Rule> GameTypeRules { get; set; } = null!;
        public DbSet<Competitor> Competitors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Competitors
            modelBuilder.Entity<Competitor>().HasData(
                new Competitor { CompetitorId = 1, CompetitorFirstName = "Monique", CompetitorLastName = "Springer", CompetitorNickname = "Monik" },
                new Competitor { CompetitorId = 2, CompetitorFirstName = "Bob", CompetitorLastName = "Jones", CompetitorNickname = "Smash" },
                new Competitor { CompetitorId = 3, CompetitorFirstName = "Alice", CompetitorLastName = "Smith", CompetitorNickname = "Ace" }
            );

            // Seed Rules
            modelBuilder.Entity<Rule>().HasData(
                new Rule { RuleId = 1, RuleName = "Game Objective", RuleDescription = "The goal is to score points by hitting the ball over the net so that the opponent cannot return it legally." },
                new Rule { RuleId = 2, RuleName = "Scoring System", RuleDescription = "Games are typically played to 11 points, and a player must win by at least a 2-point margin." },
                new Rule { RuleId = 3, RuleName = "Service Rules", RuleDescription = "The serve must be made from behind the end line and the ball must bounce once on the server's side before crossing the net." },
                new Rule { RuleId = 4, RuleName = "Serve Rotation", RuleDescription = "In singles, players alternate serves every 2 points. In doubles, each player serves for 2 points in a fixed rotation." },
                new Rule { RuleId = 5, RuleName = "Legal Return", RuleDescription = "After the serve, the ball must be hit over the net and bounce once on the opponent's side. It cannot bounce more than once on your own side." },
                new Rule { RuleId = 6, RuleName = "Ball In Play", RuleDescription = "A rally continues until a player fails to make a legal return, hits the ball off the table without touching the opponent's side, or commits a fault." },
                new Rule { RuleId = 7, RuleName = "Let", RuleDescription = "A let is called when the serve touches the net but still lands in the correct service box. The serve is retaken without penalty." },
                new Rule { RuleId = 8, RuleName = "Ball Touching the Net During Play", RuleDescription = "If the ball touches the net during a rally but still lands on the opponent's side, play continues." });
        }

    }
}
