using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Repositories.Interfaces;
using Matemagicas.Domain.Classes.Services.Commands;
using Matemagicas.Domain.Classes.Services.Interfaces;
using Matemagicas.Domain.Schools.Repositories.Interfaces;
using Matemagicas.Domain.Schools.Services.Interfaces;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Classes.Services;

public class ClassesService : IClassesService
{
    private readonly IClassesRepository _repository;
    public readonly ISchoolsService _schoolsService;
    private readonly IUsersService _usersService;

    public ClassesService(IClassesRepository repository, ISchoolsService schoolsService, IUsersService usersService)
    {
        _repository = repository;
        _schoolsService = schoolsService;
        _usersService = usersService;
    }

    // Falta validar se o professor e alunos existem
    // Falta validar se o professor pertence a escola
    // Falta validar se os alunos pertencem a escola
    public async Task<Class> InstantiateAsync(ClassCreateCommand command)
    {
        await _schoolsService.Validate(command.SchoolId);
        
        return new Class(command.Name,
            command.Series,
            command.SchoolShift,
            command.SchoolId,
            command.ProfessorId,
            command.StudentsIds,
            command.AllowedTopicsIds);
    }
    
    public async Task<Class> ValidateAsync(ObjectId id) =>
        await _repository.GetByIdAsync(id) ?? throw new Exception("Class not found");

    public async Task<Class> UpdateAsync(ObjectId id, ClassUpdateCommand command)
    {
        Class classRoom = await ValidateAsync(id);
        
        classRoom.SetName(command.Name);
        classRoom.SetSeries(command.Series);
        classRoom.SetSchoolShift(command.SchoolShift);
        classRoom.SetProfessorId(command.ProfessorId);
        classRoom.SetStudentsIds(command.StudentsIds);
        classRoom.SetAllowedTopics(command.AllowedTopicsIds);

        return classRoom;
    }

    public async Task<Class> InactivateAsync(ObjectId id)
    {
        Class classRoom = await ValidateAsync(id);
        classRoom.SetStatus(StatusEnum.Inactive);
        return classRoom;
    }
}