using Contracts;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RT.Foxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public DialogsController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Post dialog
        /// </summary>
        /// <returns>Returns new Created MessageId</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateDialog([FromBody] DialogForAddDto dialogMessage)
        {
            if (dialogMessage.Messages == null || !dialogMessage.Messages.Any())
            {
                return BadRequest("Messages is empty");
            }

            var user = await _repository.UserRepository.GetByIdAsync(dialogMessage.UserId);
            if (user.Id == 0)
            {
                return BadRequest("User not found");
            }

            var task = await _repository.TaskRepository.GetByIdAsync(dialogMessage.TaskId);
            if (task.Id == 0)
            {
                return BadRequest("Task not found");
            }

            try
            {
                var createdMessages = await _repository.DialogRepository.CreateAsync(dialogMessage);
                if (createdMessages == 0)
                {
                    return BadRequest("Something went wrong");
                }

                var result =
                    await _repository.DialogRepository.GetDialogResultAsync(dialogMessage.UserId, dialogMessage.TaskId);

                return Created(string.Empty, result);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(UpdateDialog)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
