using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")] //    /api/todo/5
    [ApiController]
    public class TodoController : ControllerBase
    {
        /// <summary>
        /// Временное хранилище ToDo
        /// </summary>
        private static List<ToDoItem> _items = new();
        /// <summary>
        /// Id новой заметки
        /// </summary>
        private static int _nextId = 1;

        /// <summary>
        /// Получение всех ToDo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() => Ok(_items);

        /// <summary>
        /// Поиск ToDo по id
        /// </summary>
        /// <param name="id">id ToDo</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            return item == null ? NotFound() : Ok(item);
        }

        /// <summary>
        /// Создание нового ToDo
        /// </summary>
        /// <param name="toDoItem">Новый ToDo</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] ToDoItem toDoItem)
        {
            toDoItem.Id = _nextId++;
            _items.Add(toDoItem);
            // Возвращает 201 при успешном создании нового ресурса (например, объекта ToDo)
            // Это часть принципов REST API — если ты создал ресурс,
            // нужно сообщить клиенту, где он теперь находится.
            return CreatedAtAction(nameof(Get), new { id = toDoItem.Id}, toDoItem);
        }

        /// <summary>
        /// Метод по обновлению ToDo
        /// </summary>
        /// <param name="id">id ToDo</param>
        /// <param name="toDoItem">Новые входной ToDo</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(int id, [FromBody] ToDoItem toDoItem)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();

            item.Title = toDoItem.Title;
            item.Description = toDoItem.Description;
            item.IsDone = toDoItem.IsDone;

            // Если обновление успешно — 204 No Content
            return NoContent();
        }

        /// <summary>
        /// Удаление ToDo по id
        /// </summary>
        /// <param name="id">id ToDo</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if(item == null) return NotFound();

            _items.Remove(item);

            // Если удалена — 204 No Content
            return NoContent();
        }
    }
}
