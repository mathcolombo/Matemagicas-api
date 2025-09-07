using Matemagicas.Application.Classes.DataTransfer.Requests;
using Matemagicas.Application.Classes.DataTransfer.Responses;
using Matemagicas.Application.Classes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers.Classes;

[ApiController]
[Route("api/classes")]
public class ClassesController(IClassesAppService classesAppService) : ControllerBase
{
    /// <summary>
    /// Creates a Class
    /// </summary>
    /// <param name="request"></param>
    /// <returns>ClassResponse</returns>
    [HttpPost]
    public async Task<ActionResult<ClassResponse>> CreateAsync(ClassCreateRequest request) =>
        Ok(await classesAppService.CreateAsync(request));

    /// <summary>
    /// Retrieves a Class based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ClassResponse</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ClassResponse>> GetByIdAsync(string id) =>
        Ok(await classesAppService.GetByIdAsync(id));
    
    /// <summary>
    /// Retrieves a Class based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>ClassResponse</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ClassResponse>> UpdateAsync(string id, [FromBody] ClassUpdateRequest request) =>
        Ok(await classesAppService.UpdateAsync(id, request));
    
    /// <summary>
    /// Retrieves a Class based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ClassResponse</returns>
    [HttpPut("{id}/inactivate")]
    public async Task<ActionResult<ClassResponse>> InactivateAsync(string id) =>
        Ok(await classesAppService.InactivateAsync(id));
    
    /// <summary>
    /// Retrieves a Class based on its id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(string id) =>
        await classesAppService.DeleteAsync(id);
}