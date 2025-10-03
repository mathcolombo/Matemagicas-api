using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Games.Services.Commands;

public class GameCreateCommand
{
    public ObjectId UserId { get; set; }
}