using AutoMapper;
using LoQ.BLL.DTO;
using LoQ.DAL.Entities;

namespace LoQ.BLL.Mapper
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerDTO>().ForPath(q => q.Question, conf => conf.Ignore());
        }
    }
}
