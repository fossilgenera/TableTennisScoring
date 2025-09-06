using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisScoring.Models.Base
{
    /// <summary>
    /// Match competitor association class.
    /// </summary>
    public class MatchCompetitor
    {
        /// <summary>
        /// Gets or sets the match competitor ID.
        /// </summary>
        public int MatchCompetitorId { get; set; }

        /// <summary>
        /// Gets or sets the match ID.
        /// </summary>
        [Required]
        public int MatchId { get; set; }

        /// <summary>
        /// Gets or sets the competitor ID.
        /// </summary>
        [Required]
        public int CompetitorId { get; set; }

        /// <summary>
        /// Gets or sets the score of the competitor in the match.
        /// </summary>
        [Required]
        [MaxLength(2)]
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the competitor is the winner of the match.
        /// </summary>
        [Required]
        public bool IsWinner { get; set; }

        [ForeignKey(nameof(MatchId))]
        public Match Match { get; set; } = null!;

        [ForeignKey(nameof(CompetitorId))]
        public Competitor Competitor { get; set; } = null!;
    }
}
