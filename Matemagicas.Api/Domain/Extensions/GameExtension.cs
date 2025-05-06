using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.Domain.Extensions;

public static class GameExtension
{
    public static GameResponse MapToGameResponse(this Game game) =>
        new GameResponse
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

    public static GamePreloadCommand MapToGamePreloadCommand(this GamePreloadRequest request) =>
        new GamePreloadCommand()
        {
            UserId = request.UserId,
            Topics = request.Topics.Select(t => (TopicEnum)t),
            Difficulty = (DifficultyEnum)request.Difficulty,
        };

    public static GameSaveCommand MapToGameSaveCommand(this GameSaveRequest request) =>
        new GameSaveCommand()
        {
            Score = request.Score,
            CorrectAnswers = request.CorrectAnswers,
            IncorrectAnswers = request.IncorrectAnswers,
        };
}