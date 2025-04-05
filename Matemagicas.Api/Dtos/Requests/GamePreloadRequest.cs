namespace Matemagicas.Api.Dtos.Requests;

public record GamePreloadRequest(int UserId, IEnumerable<int> Topics, int Difficulty);