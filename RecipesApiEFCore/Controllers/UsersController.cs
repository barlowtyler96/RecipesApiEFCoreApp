using Microsoft.AspNetCore.Mvc;
using RecipeLibraryEFCore.DataAccess;
using RecipeLibraryEFCore.Models.Dtos;
using RecipeLibraryEFCore.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesApiEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserData data) : ControllerBase
    {
        private readonly IUserData _data = data;

        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<UserDto> GetById(int id)
        {
            UserDto user = await _data.GetById(id);
            return user;
        }

        // POST api/Users
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto user)
        {
            try
            {
                await _data.AddNewUser(user);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        // POST: api/Users/favorite
        [HttpPost("favorite")]
        public async Task<ActionResult> PostUserFavorite([FromBody] UserFavoriteDto userFavoriteDto)
        {
            try
            {
                UserFavorite userFavorite = new(userFavoriteDto);
                await _data.AddUserFavorite(userFavorite);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Users/favorite
        
        [HttpDelete("favorite")]
        public async Task<ActionResult> DeleteUserFavorite([FromBody] UserFavorite userFavorite)
        {
            try
            {
                await _data.DeleteUserFavorite(userFavorite);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("favorites")]
        public async Task<ActionResult<List<int>>> GetUserFavorites(int userId)
        {
            try
            {
                var userfavorites = await _data.GetUserFavorites(1);
                return Ok(userfavorites);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
