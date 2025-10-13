using Mapster;
using Matemagicas.Application.Questions.DataTransfer.Requests;
using Matemagicas.Application.Questions.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Filters;
using Matemagicas.Domain.Questions.Services.Commands;
using Matemagicas.Domain.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Matemagicas.Application.Questions.DataTransfer.Mappings;

public static class QuestionMappingConfigurations
{
    public static void RegisterQuestionMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Question, QuestionResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString())
            .Map(dest => dest.UserId, src => src.UserId.ToString());

        TypeAdapterConfig<QuestionCreateRequest, QuestionCreateCommand>
            .NewConfig()
            .Map(dest => dest.UserId, src => ObjectId.Parse(src.UserId));
        
        TypeAdapterConfig<QuestionUpdateRequest, QuestionUpdateCommand>
            .NewConfig();
        
        TypeAdapterConfig<QuestionPagedRequest, QuestionPagedFilter>
            .NewConfig()
            .Map(dest => dest.UserId, src => src.UserId.ToObjectIdOrNullable());
        
        TypeAdapterConfig<PagedResult<Question>, PagedResult<QuestionResponse>>
            .NewConfig();
    }
}