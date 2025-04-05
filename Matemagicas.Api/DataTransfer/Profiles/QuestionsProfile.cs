using AutoMapper;
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.DataTransfer.Profiles;

public class QuestionsProfile : Profile
{
    public QuestionsProfile()
    {
        CreateMap<Question, QuestionResponse>();
        
        CreateMap<QuestionCreateRequest, QuestionCreateCommand>();
        CreateMap<QuestionUpdateRequest, QuestionUpdateCommand>();
    }
}