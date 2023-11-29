using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Step
    {
        public int StepID { get; set; }
        public int StepNumber { get; set; }
        public string Instruction { get; set; }
        // Navigation properties

        [ForeignKey("PostID")]
        public int PostID { get; set; }
        public Post? Post { get; set; }
    }
}
