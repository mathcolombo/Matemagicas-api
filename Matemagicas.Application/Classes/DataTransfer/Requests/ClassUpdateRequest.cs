using Matemagicas.Domain.Classes.Enums;
using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Classes.DataTransfer.Requests;

public record ClassUpdateRequest(
    string Name,
    int Series,
    SchoolShiftEnum SchoolShift,
    string? ProfessorId,
    IEnumerable<string>? StudentsIds,
    IEnumerable<TopicEnum> AllowedTopics
);