using Matemagicas.Domain.Classes.Enums;
using MongoDB.Bson;

namespace Matemagicas.Application.Classes.DataTransfer.Requests;

public record ClassUpdateRequest(
    string Name,
    int Series,
    SchoolShiftEnum SchoolShift,
    string? ProfessorId,
    IEnumerable<string>? StudentsIds,
    IEnumerable<string> AllowedTopicsIds
);