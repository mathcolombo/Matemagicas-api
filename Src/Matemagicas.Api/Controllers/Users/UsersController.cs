using Matemagicas.Application.Users.DataTransfer.Requests;
using Matemagicas.Application.Users.DataTransfer.Responses;
using Matemagicas.Application.Users.Services.Interfaces;
using Matemagicas.Application.Utils.ValueObjects;
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
   
   /// <summary>
   /// List all users
   /// </summary>
   /// <param name="request"></param>
   /// <returns>PagedResult UserResponse</returns>
   [HttpGet]
   public async Task<ActionResult<PagedResult<UserResponse>>> GetAsync([FromQuery] UserPagedRequest request) =>
      Ok(await usersAppService.GetAsync(request));
   
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