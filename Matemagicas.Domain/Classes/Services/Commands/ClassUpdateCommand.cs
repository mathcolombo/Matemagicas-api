using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Classes.Services.Commands;

public class ClassUpdateCommand
{
    public string Name { get; protected set; }
    public int Series { get; protected set; }
    public SchoolShiftEnum SchoolShift { get; set; }
    public ObjectId? ProfessorId { get; protected set; }
    public IEnumerable<ObjectId>? StudentsIds { get; protected set; }
    public IEnumerable<TopicEnum> AllowedTopics { get; protected set; }
}