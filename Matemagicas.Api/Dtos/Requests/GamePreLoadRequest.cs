namespace Matemagicas.Api.Dtos.Requests;

public record GamePreLoadRequest(int UserId, int[] Topics, int Difficulty);