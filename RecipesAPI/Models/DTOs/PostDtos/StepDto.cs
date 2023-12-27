namespace RecipesAPI.Models.DTOs.PostDtos
{
    public class StepDto
    {
        public int? StepID { get; set; }
        public required string Instruction { get; set; }
    }
}
