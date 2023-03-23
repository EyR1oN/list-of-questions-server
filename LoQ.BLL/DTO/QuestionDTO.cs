namespace LoQ.BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }

        public int QuestionnaireId { get; set; }
        public QuestionnaireDTO? Questionnaire { get; set; }

        public List<AnswerDTO>? Answers { get; set; }
    }
}
