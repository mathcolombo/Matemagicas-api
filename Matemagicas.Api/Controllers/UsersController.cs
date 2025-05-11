using Matemagicas.Api.DataTransfer.Mappings;
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
   private readonly IUsersService _usersService;
   private readonly IUnitOfWork _unitOfWork;

   public UsersController(IUsersService usersService,
                        IUnitOfWork unitOfWork)
   {
      _usersService = usersService;
      _unitOfWork = unitOfWork;
   }

   /// <summary>
   /// Register a new user
   /// </summary>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPost]
   public ActionResult<UserResponse> Register([FromBody] UserRegisterRequest request)
   {
      var command = request.MapToUserRegisterCommand();
      
      User user = _usersService.Register(command);
      _unitOfWork.SaveChanges();
      
      UserResponse response = user.MapToUserResponse();
      return Ok(response);
      
   }
   
   /// <summary>
   /// Validates a user's login
   /// </summary>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPost]
   [Route("login")]
   public ActionResult<UserResponse> Login([FromBody] UserLoginRequest request)
   {
      var command = request.MapToUserLoginCommand();
      
      User user = _usersService.Login(command);
      
      UserResponse response = user.MapToUserResponse();
      return Ok(response);
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
   [HttpGet("{id}")]
   public ActionResult<UserResponse> GetById(string id)
   {
      var objectId = ObjectId.Parse(id);
      User user = _usersService.GetById(objectId);
      
      var response = user.MapToUserResponse();
      return Ok(response);
   }
   
   /// <summary>
   /// Update a user
   /// </summary>
   /// <param name="id"></param>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPut("{id}")]
   public ActionResult<UserResponse> Update(string id, [FromBody] UserUpdateRequest request)
   {
      var objectId = ObjectId.Parse(id);
      var command = request.MapToUserUpdateCommand();
      
      User user = _usersService.Update(objectId, command);
      _unitOfWork.SaveChanges();
      
      var response = user.MapToUserResponse();
      return Ok(response);
   }   
   
   /// <summary>
   /// Inactive a user
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpPut("{id}/inactivate")]
   public ActionResult<UserResponse> Inactivate(string id)
   {
      var objectId = ObjectId.Parse(id);
      
      User user = _usersService.Inactivate(objectId);
      _unitOfWork.SaveChanges();
      
      var response = user.MapToUserResponse();
      return Ok(response);
   }
   
   /// <summary>
   /// Delete a user
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpDelete("{id}")]
   public ActionResult<UserResponse> Delete(string id)
   {
      var objectId = ObjectId.Parse(id);
      
      User user = _usersService.Delete(objectId);
      _unitOfWork.SaveChanges();
      
      var response = user.MapToUserResponse();
      return Ok(response);
   }
}