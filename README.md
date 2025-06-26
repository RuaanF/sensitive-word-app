# 🧼 Sensitive Word Sanitization Microservice

A Blazor + .NET Core microservice to detect and sanitize sensitive words from input text.  
Includes a RESTful API (with Swagger), MSSQL persistence, and a retro-styled Blazor Server frontend.

---

## 🔧 Tech Stack

- ASP.NET Core Minimal API
- Entity Framework Core (MSSQL)
- Blazor Server (.NET 8)
- Swagger / OpenAPI
- Retro 8-bit styled UI 🎮

---

## 📦 Features

### ✅ RESTful API

- `GET /sensitivewords` – Get all sensitive words  
- `GET /sensitivewords/{id}` – Get word by ID  
- `POST /sensitivewords` – Add a new word  
- `PUT /sensitivewords/{id}` – Update a word  
- `DELETE /sensitivewords/{id}` – Delete a word  
- `POST /sanitize` – Replace all sensitive words in a string with asterisks

All endpoints are documented in Swagger.

### ✅ Blazor UI

- View, add, update, and delete sensitive words
- Mock chat interface for testing sanitization
- Retro terminal-inspired styling with 8-bit fonts

---

## 🚀 How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/yourusername/sensitive-words-app.git
   cd sensitive-words-app

🧠 Performance Considerations
If this system were to scale or be used in production, I’d explore:
In-memory caching of the sensitive word list to avoid DB reads on every /sanitize request.
Using compiled Regex or Trie-based matching for faster word detection.
Batch API endpoints for bulk operations.
Database indexing or partitioning for large datasets.
Async queuing or rate-limiting for high-load scenarios.

✨ Project Enhancement Ideas
Given more time or in a real-world scenario, I’d consider:
Authentication/authorization for managing words
Categorization (e.g., SQL keywords, profanity, etc.)
Analytics on word usage (e.g., most flagged words)
Real-time sanitization via SignalR
Export/import for word lists
Toggle for strict vs lenient matching


