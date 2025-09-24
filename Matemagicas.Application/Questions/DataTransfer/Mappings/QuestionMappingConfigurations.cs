using Mapster;
using Matemagicas.Application.Questions.DataTransfer.Requests;
using Matemagicas.Application.Questions.DataTransfer.Responses;
using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Services.Commands;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Matemagicas.Application.Questions.DataTransfer.Mappings;

public static class QuestionMappingConfigurations
{
    public static void RegisterQuestionMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Question, QuestionResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString());

        TypeAdapterConfig<QuestionCreateRequest, QuestionCreateCommand>
            .NewConfig()
            .Map(dest => dest.UserId, src => ObjectId.Parse(src.UserId));
        
        TypeAdapterConfig<QuestionUpdateRequest, QuestionUpdateCommand>
            .NewConfig();
    }
}