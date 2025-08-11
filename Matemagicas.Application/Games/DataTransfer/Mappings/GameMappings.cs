using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Repositories.Filters;
using Matemagicas.Domain.Games.Services.Commands;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Application.Games.DataTransfer.Mappings;

public static class GameMappings
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

    public static GamePagedFilter MapToGamePagedFilter(this GamePagedRequest request) =>
        new GamePagedFilter()
        {
            UserId = request.UserId is null ? null : ObjectId.Parse(request.UserId),
            Date = request.Date,
            Score = request.Score,
            CorrectAnswers = request.CorrectAnswers,
            IncorrectAnswers = request.IncorrectAnswers,
            QuestionsIds = request.QuestionsIds?.Select(ObjectId.Parse),
            Topics = request.Topics?.Select(t => (TopicEnum)t),
        };
}