using AutoMapper;
using Matemagicas.Api.Services.Interfaces;
using Matemagicas.Api.Dtos.Requests;
using Matemagicas.Api.Dtos.Responses;
using Matemagicas.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
   private readonly IUsersService _usersService;
   private readonly IMapper _mapper;

   public UsersController(IUsersService usersService,
                        IMapper mapper)
   {
      _usersService = usersService;
      _mapper = mapper;
   }

   /// <summary>
   /// Register a new user
   /// </summary>
   /// <param name="request"></param>
   /// <returns>UserResponse</returns>
   [HttpPost]
   public ActionResult<UserResponse> Register([FromBody] UserRegisterRequest request)
   {
      User user = _usersService.Register(request);
      UserResponse response = _mapper.Map<UserResponse>(user);
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
      User user = _usersService.Login(request);
      UserResponse response = _mapper.Map<UserResponse>(user);
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
   [HttpGet("{id:int}")]
   public ActionResult<UserResponse> GetById(int id)
   {
      User user = _usersService.GetById(id);
      UserResponse response = _mapper.Map<UserResponse>(user);
      return Ok(response);
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
      User user = _usersService.Update(id, request);
      UserResponse response = _mapper.Map<UserResponse>(user);
      return Ok(response);
   }   
   
   /// <summary>
   /// Inactive a user
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpPut("{id:int}/inactivate")]
   public ActionResult<UserResponse> Inactivate(int id)
   {
      User user = _usersService.Inactivate(id);
      UserResponse response = _mapper.Map<UserResponse>(user);
      return Ok(response);
   }
   
   /// <summary>
   /// Delete a user
   /// </summary>
   /// <param name="id"></param>
   /// <returns>UserResponse</returns>
   [HttpDelete("{id:int}")]
   public ActionResult<UserResponse> Delete(int id)
   {
      User user = _usersService.Delete(id);
      UserResponse response = _mapper.Map<UserResponse>(user);
      return Ok(response);
   }
}