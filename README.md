Habit Tracker – .NET 9 Application

The Habit Tracker is a modern productivity application built using ASP.NET Core (.NET 9). It helps users create habits, track daily progress, analyze performance, and maintain long-term consistency. 
Designed with clean architecture principles, the project demonstrates scalable backend development, efficient database management, and secure user authentication.
🌟 Key Features

Create & Manage Habits
Add, update, delete, and categorize daily habits.

Daily Progress Tracking
Mark habits as completed and view history on a calendar/timeline basis.

Streak Monitoring
Automatic calculation of current and longest streaks.

Analytics Dashboard
Weekly, monthly, and category-wise summaries.

User Authentication
Secure login, registration, password hashing.

Clean Architecture
Controller → Service → Repository pattern for maintainability.

SQL Server + EF Core
Efficient CRUD operations, migrations, and relational modeling.

Swagger API Documentation
Easy testing of all endpoints.

🛠️ Tech Stack

.NET 9 / ASP.NET Core MVC

C#

Entity Framework Core

SQL Server

LINQ

Dependency Injection

Swagger / OpenAPI

HTML, CSS, Bootstrap (if UI included)


📐 Architecture Diagram
                        ┌────────────────────────────┐
                        │        Presentation         │
                        │        (Controllers)        │
                        └───────────────┬─────────────┘
                                        │
                                        ▼
                        ┌────────────────────────────┐
                        │         Service Layer       │
                        │  (Business Logic & Rules)   │
                        └───────────────┬─────────────┘
                                        │
                                        ▼
                        ┌────────────────────────────┐
                        │       Repository Layer      │
                        │ (Data Access via EF Core)   │
                        └───────────────┬─────────────┘
                                        │
                                        ▼
                        ┌────────────────────────────┐
                        │        SQL Server DB        │
                        │  (Habits, Users, Tracking)  │
                        └─────────────────────────────┘

📂 Project Structure
HabitTracker/
│── Controllers/        → API or MVC controllers  
│── Services/           → Business logic  
│── Repositories/       → EF Core DB operations  
│── Models/             → Entity classes  
│── DTOs/               → Data transfer objects  
│── Views/              → Razor UI (if MVC)  
│── Migrations/         → EF Core migrations  
│── appsettings.json    → Connection strings & settings  
│── Program.cs          → Startup configuration (.NET 9)

⚙️ Installation & Setup
1. Clone the repository
git clone https://github.com/yourusername/HabitTracker.git
cd HabitTracker

2. Restore dependencies
dotnet restore

3. Update connection string

Edit appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=HabitTrackerDB;Trusted_Connection=True;"
}

4. Run migrations
dotnet ef database update

5. Start the application
dotnet run

📘 API Documentation (Swagger)

Once running, open:

https://localhost:{port}/swagger


Use Swagger UI to test all habit, user, and tracking endpoints.

🔐 Authentication

Send JWT token with each request:

Authorization: Bearer <token>

🧪 Testing Tools

Swagger

Postman

Thunder Client

🤝 Contributing

Contributions are welcome!
Feel free to submit Issues and Pull Requests
