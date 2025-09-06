using System.ComponentModel.DataAnnotations;

namespace TableTennisScoring.Application.Commands
{
    public class CreateMatchCommand
    {
        [Required]
        public int CompetitorId1 { get; set; }

        [Required]
        public int CompetitorId2 { get; set; }

        public int? CompetitorId3 { get; set; }

        public int? CompetitorId4 { get; set; }

        [Required]
        public DateTime MatchDateTime { get; set; }

        [Required]
        public int CompetitorId1FinalScore { get; set; }

        [Required]
        public int CompetitorId2FinalScore { get; set; }

        public int? CompetitorId3FinalScore { get; set; }

        public int? CompetitorId4FinalScore { get; set; }

        public int BestOfAmount { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; } = string.Empty;
    }
}
