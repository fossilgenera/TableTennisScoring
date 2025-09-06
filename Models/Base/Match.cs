using System.ComponentModel.DataAnnotations;

namespace TableTennisScoring.Models.Base
{
    public class Match
    {
        /// <summary>
        /// Gets or sets the match ID.
        /// </summary>
        public int MatchId { get; set; }

        /// <summary>
        /// Gets or sets the match date and time.
        /// </summary>
        public DateTime MatchDateTime { get; set; }

        /// <summary>
        /// Gets or sets the best of amount (e.g., best of 3, best of 5).
        /// </summary>
        public int BestOfAmount { get; set; }

        /// <summary>
        /// Gets or sets the comment about the match.
        /// </summary>
        [StringLength(1000)]
        public string Comment { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of match competitors.
        /// </summary>
        public ICollection<MatchCompetitor> MatchCompetitors { get; set; } = new List<MatchCompetitor>();
    }
}
