using APIDashboard.Application.Interface;
using APIDashboard.Application.Services;
using APIDashBoard.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement_APIDashboard.Models;

namespace ProductManagement_APIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticateResponce>> Login(LoginModel model)
        {

            try { 

               if (model.Username == "admin" && model.Password == "admin123")
               {
                  var token =  await _authenticateService.GenerateToken(model.Username);

                  if (token != null)
                  {
                        return Ok(new AuthenticateResponce
                        {
                            Success = true,
                            Token = token,
                            
                        });
                   }

                   return Unauthorized();
                    
               }

                return Ok(new AuthenticateResponce
                {
                    Success=false,
                    Message = "UserName or Password is Incorrect !"
                });     
            }

            catch
            {
                return StatusCode(500);
            }
        }

    }
}
