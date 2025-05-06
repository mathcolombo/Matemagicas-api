using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Requests;

public record GamePreloadRequest(string UserId, IEnumerable<int> Topics, int Difficulty);