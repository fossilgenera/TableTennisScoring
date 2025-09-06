using System.ComponentModel.DataAnnotations;

namespace TableTennisScoring.Models.Base
{
    public class Competitor
    {
        /// <summary>
        /// Gets or sets the competitor ID.
        /// </summary>
        public int CompetitorId { get; set; }

        /// <summary>
        /// Gets or sets the competitor first name.
        /// </summary>
        [StringLength(50)]
        public string CompetitorFirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the competitor last name.
        /// </summary>
        [StringLength(50)]
        public string CompetitorLastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the competitor nickname.
        /// </summary>
        [StringLength(50)]
        public string CompetitorNickname { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of match competitors.
        /// </summary>
        public ICollection<MatchCompetitor> MatchCompetitors { get; set; } = new List<MatchCompetitor>();
    }
}
