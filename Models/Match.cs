using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisScoring.Models
{
    public class Match
    {
        /// <summary>
        /// Gets or sets the match ID.
        /// </summary>
        public int MatchId { get; set; }

        [Required]
        public int CompetitorId1 { get; set; }

        [Required]
        public int CompetitorId2 { get; set; }

        public int? CompetitorId3 { get; set; }

        public int? CompetitorId4 { get; set; }

        public DateTime MatchDateTime { get; set; }

        [Required]
        public int CompetitorId1FinalScore { get; set; }

        [Required]
        public int CompetitorId2FinalScore { get; set; }

        public int CompetitorId3FinalScore { get; set; }

        public int CompetitorId4FinalScore { get; set; }

        [ForeignKey(nameof(CompetitorId1))]
        public Competitor? Competitor1 { get; set; }

        [ForeignKey(nameof(CompetitorId2))]
        public Competitor? Competitor2 { get; set; }

        [ForeignKey(nameof(CompetitorId3))]
        public Competitor? Competitor3 { get; set; }

        [ForeignKey(nameof(CompetitorId4))]
        public Competitor? Competitor4 { get; set; }

        public int BestOfAmount { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; } = string.Empty;
    }
}
