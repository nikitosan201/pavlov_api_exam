using System.Xml.Linq;
using TaskManagerApi.Models;

namespace TaskManagerApi.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public List<TaskItem> GetAll() => _tasks;

        public TaskItem? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public TaskItem Create(TaskCreateDto dto)
        {
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status
            };
            _tasks.Add(task);
            return task;
        }

        public bool Update(int id, TaskCreateDto dto)
        {
            var task = GetById(id);
            if (task == null) return false;
            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            return true;
        }

        public bool Delete(int id)
        {
            var task = GetById(id);
            if (task == null) return false;
            _tasks.Remove(task);
            return true;
        }
    }
}
