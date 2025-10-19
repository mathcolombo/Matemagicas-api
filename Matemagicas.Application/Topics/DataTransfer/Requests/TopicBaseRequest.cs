using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Topics.DataTransfer.Requests;

public record TopicBaseRequest
{
    public string Title { get; init; }
    public string Description { get; init; }
    public List<SeriesEnum>? Series { get; init; }
}