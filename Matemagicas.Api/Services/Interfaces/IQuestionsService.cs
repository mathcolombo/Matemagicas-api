using Matemagicas.Api.Dtos.Requests;
using Matemagicas.Api.Entities;
using Matemagicas.Api.Services.Commands;

namespace Matemagicas.Api.Services.Interfaces;

public interface IQuestionsService
{
    Question Create(QuestionCreateCommand command);
    Question GetById(int id);
    Question Update(int id, QuestionUpdateCommand command);
    Question Inactive(int id);
}