using Mapster;
using Matemagicas.Application.Schools.DataTransfer.Requests;
using Matemagicas.Application.Schools.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Schools.Entities.ValueObjects;
using Matemagicas.Domain.Schools.Services.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Application.Schools.DataTransfer.Mappings;

public static class SchoolMappingConfigurations
{
    public static void RegisterSchoolMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<School, SchoolResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString());

        TypeAdapterConfig<SchoolCreateRequest, SchoolCreateCommand>
            .NewConfig(); 
        
        
        TypeAdapterConfig<Address, AddressResponse>
            .NewConfig();
        
        TypeAdapterConfig<AddressRequest, AddressCommand>
            .NewConfig();
    }
}