using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Topics.Repositories.Filters;

public record TopicPagedFilter(
   ObjectId? Id,
   string? Title,
   string? Description,
   IEnumerable<SeriesEnum>? Series
);