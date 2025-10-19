using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Classes.Services.Commands;

public class ClassCreateCommand
{
    public string Name { get; set; }
    public int Series { get; set; }
    public SchoolShiftEnum SchoolShift { get; set; }
    public ObjectId SchoolId { get; set; }
    public ObjectId? ProfessorId { get; set; }
    public IEnumerable<ObjectId>? StudentsIds { get; set; }
    public IEnumerable<ObjectId> AllowedTopicsIds { get; set; }
}