namespace Matemagicas.Application.Games.DataTransfer.Requests;

public record GamePreloadRequest(string UserId, IEnumerable<int> Topics, int Difficulty);