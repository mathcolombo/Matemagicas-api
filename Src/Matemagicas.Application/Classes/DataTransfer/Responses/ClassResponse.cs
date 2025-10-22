using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Application.Classes.DataTransfer.Responses;

public record ClassResponse(
    string Id,
    string Name,
    int Series,
    SchoolShiftEnum SchoolShift,
    string SchoolId,
    string? ProfessorId,
    IEnumerable<string>? StudentsIds,
    IEnumerable<ObjectId> AllowedTopicsIds
);