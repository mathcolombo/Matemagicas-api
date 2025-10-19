using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Matemagicas.Domain.Topics.Entities;

public class Topic
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public IList<SeriesEnum>? Series { get; protected set; }

    public Topic() {}
    
    public Topic(string title,
        string description,
        IEnumerable<SeriesEnum>? series)
    {
        SetTitle(title);
        SetDescription(description);
        SetSeries(series);
    }
    
    public void SetTitle(string title)
    {
        title.ValidateProperty(3, 100);
        Title = title;
    }
    
    public void SetDescription(string description)
    {
        description.ValidateProperty(10, 500);
        Description = description;
    }
    
    public void SetSeries(IEnumerable<SeriesEnum>? series) => Series = series?.ToList();
}