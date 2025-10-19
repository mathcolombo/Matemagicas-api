using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Domain.Topics.Services.Commands;

public class TopicBaseCommand
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IEnumerable<SeriesEnum>? Series { get; set; }
}