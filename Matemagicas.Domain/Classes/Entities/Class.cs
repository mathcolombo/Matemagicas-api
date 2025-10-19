using System.ComponentModel.DataAnnotations.Schema;
using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Topics.Entities;
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
    public IList<ObjectId>? StudentsIds { get; protected set; }
    public IList<ObjectId> AllowedTopicsIds { get; protected set; }
    public StatusEnum Status { get; protected set; }

    #region Navigations

    [NotMapped]
    public School School { get; protected set; }
    [NotMapped]
    public User? Professor { get; protected set; }
    [NotMapped]
    public IEnumerable<User>? Students { get; protected set; }
    [NotMapped]
    public IEnumerable<Topic> AllowedTopics { get; protected set; }

    #endregion

    public Class() {}
    
    public Class(string name,
        int series,
        SchoolShiftEnum schoolShift,
        ObjectId schoolId,
        ObjectId? professorId,
        IEnumerable<ObjectId>? studentsIds,
        IEnumerable<ObjectId> allowedTopicsIds)
    {
        SetName(name);
        SetSeries(series);
        SetSchoolShift(schoolShift);
        SchoolId = schoolId;
        SetProfessorId(professorId);
        SetStudentsIds(studentsIds);
        SetAllowedTopics(allowedTopicsIds);
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
    
    public void SetStudentsIds(IEnumerable<ObjectId>? studentsIds) => StudentsIds = studentsIds?.ToList();
    
    public void SetAllowedTopics(IEnumerable<ObjectId> allowedTopicsIds) => AllowedTopicsIds = allowedTopicsIds.ToList();
    
    public void SetStatus(StatusEnum status) => Status = status;
}