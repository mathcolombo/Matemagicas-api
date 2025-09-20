using Matemagicas.Application.Users.DataTransfer.Requests;
using Matemagicas.Application.Users.DataTransfer.Responses;
using Matemagicas.Application.Users.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers.Users;

[ApiController]
[Route("api/users")]
public class UsersController(IUsersAppService usersAppService) : ControllerBase
{
   /// <summary>
   /// Register a new user
   /// </summary>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPost]
   public async Task<ActionResult<UserResponse>> RegisterAsync([FromBody] UserCreateRequest request) =>
      Ok(await usersAppService.CreateAsync(request));
   
   /// <summary>
   /// Validates a user's login
   /// </summary>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPost]
   [Route("login")]
   public async Task<ActionResult<UserResponse>> LoginAsync([FromBody] UserLoginRequest request) =>
      Ok(await usersAppService.LoginAsync(request));
   
   // /// <summary>
   // /// List all games
   // /// </summary>
   // /// <param name="request"></param>
   // /// <param name="pageNumber"></param>
   // /// <param name="pageSize"></param>
   // /// <returns>PagedResult</returns>
   // [HttpGet]
   // public ActionResult<PagedResult<UserResponse>> Get([FromQuery] UserPagedRequest request, [FromQuery] int pageNumber, [FromQuery] int pageSize)
   // {
   //    var filter = request.MapToUserPagedFilter();
   //      
   //    IQueryable<User> games = _usersService.Get(filter);
   //    var response = games.MapToPagedResult(q => q.MapToUserResponse(), pageNumber, pageSize);
   //      
   //    return Ok(response);
   // }
   
   /// <summary>
   /// Retrieves a user based on its id
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpGet("{id}")]
   public async Task<ActionResult<UserResponse>> GetByIdAsync(string id) =>
      Ok(await usersAppService.GetByIdAsync(id));
   
   /// <summary>
   /// Update a user
   /// </summary>
   /// <param name="id"></param>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPut("{id}")]
   public async Task<ActionResult<UserResponse>> UpdateAsync(string id, [FromBody] UserUpdateRequest request) =>
      Ok(await usersAppService.UpdateAsync(id, request));
   
   /// <summary>
   /// Inactive a user
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpPut("{id}/inactivate")]
   public async Task<ActionResult<UserResponse>> InactivateAsync(string id) =>
      Ok(await usersAppService.InactivateAsync(id));
   
   /// <summary>
   /// Delete a user
   /// </summary>
   /// <param name="id"></param>
   [HttpDelete("{id}")]
   public async Task DeleteAsync(string id) =>
      await usersAppService.DeleteAsync(id);
}