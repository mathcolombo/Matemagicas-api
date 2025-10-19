using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Classes.DataTransfer.Requests;

public record ClassPagedRequest(
    string? Name,
    int? Series,
    SchoolShiftEnum? SchoolShift,
    string? SchoolId,
    string? ProfessorId,
    IEnumerable<string>? StudentsIds,
    IEnumerable<string>? AllowedTopicsIds,
    StatusEnum? Status,
    int PageNumber,
    int PageSize
);