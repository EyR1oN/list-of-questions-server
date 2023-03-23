using AutoMapper;
using LoQ.BLL.DTO;
using LoQ.DAL.Entities;

namespace LoQ.BLL.Mapper
{
    public class QuestionnaireProfile : Profile
    {
        public QuestionnaireProfile()
        {
            CreateMap<Questionnaire, QuestionnaireDTO>().ReverseMap();
        }
    }
}
