using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;

namespace Matemagicas.Api.Domain.Extensions;

public static class GameExtension
{
    public static GameResponse MapToGameResponse(this Game game) => new GameResponse
    {
        Id = game.Id,
        UserId = game.UserId,
        Date = game.Date,
        Score = game.Score,
        CorrectAnswers = game.CorrectAnswers,
        IncorrectAnswers = game.IncorrectAnswers,
        QuestionsIds = game.QuestionsIds,
        Topics = game.Topics.Select(t => (int)t)
    };
}