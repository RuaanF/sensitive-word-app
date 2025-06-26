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
