using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Contracts;

namespace RT.Foxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public UsersController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns>Returns Users from db</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _repository.UserRepository.GetAllAsync();

                return Ok(users);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(Get)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <returns>Returns User from db</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _repository.UserRepository.GetByIdAsync(id);
                if (user.Id == 0)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetById)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get User Tasks by Id
        /// </summary>
        /// <returns>Returns User Tasks from db</returns>
        [HttpGet("{id:int}/tasks")]
        public async Task<IActionResult> GetTasksById(int id)
        {
            try
            {
                var user = await _repository.UserRepository.GetByIdAsync(id);
                if (user.Id == 0)
                {
                    return NotFound();
                }

                return Ok(user.Tasks);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetById)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
