using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Classes.Repositories.Filters;

public class ClassPagedFilter
{
    public string? Name { get; protected set; }
    public int? Series { get; protected set; }
    public SchoolShiftEnum? SchoolShift { get; protected set; }
    public ObjectId? SchoolId { get; protected set; }
    public ObjectId? ProfessorId { get; protected set; }
    public IEnumerable<ObjectId>? StudentsIds { get; protected set; }
    public IEnumerable<ObjectId>? AllowedTopicsIds { get; protected set; }
    public StatusEnum? Status { get; protected set; }
}