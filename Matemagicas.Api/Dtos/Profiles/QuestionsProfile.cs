using AutoMapper;
using Matemagicas.Api.Dtos.Responses;
using Matemagicas.Api.Entities;

namespace Matemagicas.Api.Dtos.Profiles;

public class QuestionsProfile : Profile
{
    public QuestionsProfile()
    {
        CreateMap<Question, QuestionResponse>();
    }
}