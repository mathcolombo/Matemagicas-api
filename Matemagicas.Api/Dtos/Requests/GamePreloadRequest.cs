namespace Matemagicas.Api.Dtos.Requests;

public record GamePreloadRequest(int UserId, int[] Topics, int Difficulty);