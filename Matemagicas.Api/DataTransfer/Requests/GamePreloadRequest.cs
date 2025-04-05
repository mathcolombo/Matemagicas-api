namespace Matemagicas.Api.DataTransfer.Requests;

public record GamePreloadRequest(int UserId, IEnumerable<int> Topics, int Difficulty);