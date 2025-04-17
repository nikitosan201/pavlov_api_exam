using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Models;
using TaskManagerApi.Services;

namespace TaskManagerApi.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<TaskItem>> GetAll() => _service.GetAll();

        [HttpPost]
        public ActionResult<TaskItem> Create(TaskCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var task = _service.Create(dto);
            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = _service.Update(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
