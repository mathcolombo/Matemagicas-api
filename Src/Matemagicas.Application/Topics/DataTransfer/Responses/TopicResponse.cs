using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Topics.DataTransfer.Responses;

public record TopicResponse(
    string Id,
    string Title,
    string Description,
    IEnumerable<SeriesEnum>? Series
);