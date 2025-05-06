using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Extensions;

public static class GameExtension
{
    public static GameResponse MapToGameResponse(this Game game) =>
        new GameResponse
        {
            Id = game.Id.ToString(),
            UserId = game.UserId.ToString(),
            Date = game.Date,
            Score = game.Score,
            CorrectAnswers = game.CorrectAnswers,
            IncorrectAnswers = game.IncorrectAnswers,
            QuestionsIds = game.QuestionsIds.Select(q => q.ToString()),
            Topics = game.Topics.Select(t => (int)t)
        };

    public static GamePreloadCommand MapToGamePreloadCommand(this GamePreloadRequest request) =>
        new GamePreloadCommand()
        {
            UserId = ObjectId.Parse(request.UserId),
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