using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Matemagicas.Domain.Classes.Entities;

public class Class
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
    public string Name { get; protected set; }
    public int Series { get; protected set; }
    public SchoolShiftEnum SchoolShift { get; protected set; }
    public ObjectId SchoolId { get; protected set; }
    public ObjectId? ProfessorId { get; protected set; }
    public IEnumerable<ObjectId>? StudentsIds { get; protected set; }
    public IList<TopicEnum> AllowedTopics { get; protected set; }
    public StatusEnum Status { get; protected set; }

    #region Navigations

    public School School { get; protected set; }
    public User? Professor { get; protected set; }
    public IEnumerable<User>? Students { get; protected set; }

    #endregion

    public Class() {}
    
    public Class(string name,
        int series,
        SchoolShiftEnum schoolShift,
        ObjectId schoolId,
        ObjectId? professorId,
        IEnumerable<ObjectId>? studentsIds,
        IEnumerable<TopicEnum> allowedTopics)
    {
        SetName(name);
        SetSeries(series);
        SetSchoolShift(schoolShift);
        SchoolId = schoolId;
        SetProfessorId(professorId);
        SetStudentsIds(studentsIds);
        SetAllowedTopics(allowedTopics);
        SetStatus(StatusEnum.Active);
    }

    public void SetName(string name)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        name.ValidateProperty(minLength, maxLength);
        
        Name = name;
    }
    
    public void SetSeries(int series)
    {
        series.ValidateProperty();
        Series = series;
    }

    public void SetSchoolShift(SchoolShiftEnum schoolShift) => SchoolShift = schoolShift;
    
    public void SetProfessorId(ObjectId? professorId) => ProfessorId = professorId;
    
    public void SetStudentsIds(IEnumerable<ObjectId>? studentsIds) => StudentsIds = studentsIds;
    
    public void SetAllowedTopics(IEnumerable<TopicEnum> allowedTopics) => AllowedTopics = allowedTopics.ToList();
    
    public void SetStatus(StatusEnum status) => Status = status;
}