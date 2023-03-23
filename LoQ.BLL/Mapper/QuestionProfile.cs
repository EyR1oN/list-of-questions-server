using AutoMapper;
using LoQ.BLL.DTO;
using LoQ.DAL.Entities;

namespace LoQ.BLL.Mapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDTO>().ForPath(q => q.Questionnaire, conf => conf.Ignore());
        }
    }
}