using System.ComponentModel.DataAnnotations;

namespace TableTennisScoring.Application.Commands
{
    /// <summary>
    /// Create competitor command.
    /// </summary>
    public class CreateCompetitorCommand
    {
        /// <summary>
        /// ets or sets the competitor first name.
        /// </summary>
        [StringLength(50)]
        [Required]
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
        public string? CompetitorNickname { get; set; } = string.Empty;
    }
}
