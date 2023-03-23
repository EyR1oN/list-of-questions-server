namespace LoQ.BLL.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public QuestionDTO? Question { get; set; }
    }
}
