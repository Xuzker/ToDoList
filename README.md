# 📝 ToDoList Web API

Простое приложение на ASP.NET Core Web API для управления списком задач (ToDo).  
Проект демонстрирует реализацию REST API с возможностью создавать, просматривать, редактировать и удалять задачи.

---

## 🚀 Технологии

- .NET 8
- ASP.NET Core Web API
- Docker (опционально)
- C#

---

## 📦 Установка и запуск

### 🔧 Локальный запуск

1. Клонируйте репозиторий:

```bash
git clone gh repo clone Xuzker/ToDoList
cd ToDoList
```

2. Постройте и запустите:
```bash
dotnet restore
dotnet build
dotnet run --project ToDoList
```
3. API будет доступно по адресу:
   http://localhost:5141

4. 🐳 Запуск в Docker
```bash
docker build -t todolist-api .
docker run -d -p 8080:80 todolist-api
http://localhost:8080/api/todo
```

## 📚 API Эндпоинты

| Метод  | URL               | Описание                     |
|--------|-------------------|------------------------------|
| GET    | `/api/todo`       | Получить все задачи          |
| GET    | `/api/todo/{id}`  | Получить задачу по ID        |
| POST   | `/api/todo`       | Создать новую задачу         |
| PUT    | `/api/todo/{id}`  | Обновить существующую задачу |
| DELETE | `/api/todo/{id}`  | Удалить задачу               |

📂 Пример JSON задачи
``bash
{
  "title": "Купить молоко",
  "isDone": false
}
```

