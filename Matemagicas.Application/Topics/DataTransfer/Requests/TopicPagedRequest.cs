using Matemagicas.Application.Utils.Requests;
using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Topics.DataTransfer.Requests;

public record TopicPagedRequest(
    string? Id,
    string? Title,
    string? Description,
    IEnumerable<SeriesEnum>? Series
) : PagedRequest;