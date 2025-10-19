using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Application.Classes.DataTransfer.Requests;

public record ClassCreateRequest(
    string Name,
    int Series,
    SchoolShiftEnum SchoolShift,
    string SchoolId,
    string? ProfessorId,
    IEnumerable<string>? StudentsIds,
    IEnumerable<string> AllowedTopicsIds
);