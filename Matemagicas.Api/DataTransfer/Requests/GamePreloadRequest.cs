using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Requests;

public record GamePreloadRequest(ObjectId UserId, IEnumerable<int> Topics, int Difficulty);