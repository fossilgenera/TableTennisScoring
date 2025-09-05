using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisScoring.Models
{
    public class Rule
    {
        /// <summary>
        /// Gets or sets the rule ID.
        /// </summary>
        public int RuleId { get; set; }


        /// <summary>
        /// Gets or sets the rule name.
        /// </summary>
        [StringLength(50)]
        public string RuleName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rule description.
        /// </summary>\
        [StringLength(1000)]
        public string RuleDescription { get; set; } = string.Empty;
    }
}
