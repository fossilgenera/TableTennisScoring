namespace TableTennisScoring.Application.Lookups
{
    public class CompetitorLookup
    {
        /// <summary>
        /// Gets or sets the competitor ID.
        /// </summary>
        public int CompetitorId { get; set; }

        /// <summary>
        /// Gets or sets the competitor full name.
        /// </summary>
        public string CompetitorFullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the competitor nickname.
        /// </summary>
        public string CompetitorNickname { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the number of matches played.
        /// </summary>
        public int NumberOfMatchesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of wins.
        /// </summary>
        public int NumberOfWins { get; set; }
    }
}
