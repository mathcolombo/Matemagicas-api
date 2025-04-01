using Matemagicas.Api.Context;
using Matemagicas.Api.Services.Interfaces;
using Matemagicas.Api.Dtos.Requests;
using Matemagicas.Api.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUsersService usersService) : Controller
{
   private readonly IUsersService _usersService = usersService;

   /// <summary>
   /// Register a new user
   /// </summary>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPost]
   public ActionResult<UserResponse> Register([FromBody] UserRegisterRequest request)
   {
      return Ok();
   }
   
   /// <summary>
   /// Validates a user's login
   /// </summary>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPost]
   public ActionResult<UserResponse> Login([FromBody] UserLoginRequest request)
   {
      return Ok();
   }
   
   /// <summary>
   /// List all users
   /// </summary>
   /// <returns>UserResponse</returns>
   [HttpGet]
   public ActionResult<UserResponse> GetAll()
   {
      return Ok();
   }
   
   /// <summary>
   /// Retrieves a user based on its id
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpGet("{id:int}")]
   public ActionResult<UserResponse> GetById(int id)
   {
      return Ok();
   }
   
   /// <summary>
   /// Update a user
   /// </summary>
   /// <param name="id"></param>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPut("{id:int}")]
   public ActionResult<UserResponse> Update(int id, [FromBody] UserUpdateRequest request)
   {
      return Ok();
   }   
   
   /// <summary>
   /// Logically delete a question
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpDelete("{id:int}")]
   public ActionResult<UserResponse> Delete(int id)
   {
      return Ok();
   }
}