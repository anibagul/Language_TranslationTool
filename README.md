# Language Translation Web App

A beginner-friendly language translation web application developed with **ASP.NET Core MVC** and **C#**.

The application allows users to enter text, select source and target languages, and receive a translated result through a free external translation API. This project was created for learning and practicing ASP.NET Core MVC, API integration, service-based code organization, form handling, and responsive web-interface development.

---

## Project Overview

The Language Translation Web App is a simple educational project that provides basic text translation between selected languages.

The project does not use a custom artificial-intelligence or machine-learning translation model. Translation is performed by sending the user's text and selected language information to a free external translation API. The translated result is then returned and displayed on the web page.

This application is intended for learning, practice, and portfolio demonstration rather than advanced or commercial translation use.

---

## Features

- Enter text for translation
- Select a source language
- Select a target language
- Translate text using a free external API
- Display the translated result
- Copy translated text
- Clear input and translated text
- Simple and user-friendly interface
- Responsive page styling
- Basic validation and error handling
- ASP.NET Core MVC project structure
- Separate service layer for API communication

---

## Technologies Used

| Technology | Purpose |
|---|---|
| ASP.NET Core MVC | Organizes the application using Models, Views, and Controllers |
| C# | Handles backend logic and API communication |
| Razor Views | Creates dynamic web pages |
| HTML | Provides the page structure |
| CSS | Styles the user interface |
| JavaScript | Supports basic page interaction |
| Free Translation API | Performs text translation |
| HttpClient | Sends requests to the external API |
| Git and GitHub | Provides version control and project hosting |

---

## How the Application Works

1. The user enters text in the input field.
2. The user selects the source language.
3. The user selects the target language.
4. The user clicks the **Translate** button.
5. The controller receives the submitted information.
6. The translation service sends a request to the free translation API.
7. The API returns the translated text.
8. The translated result is displayed on the page.
9. The user can copy the result or clear the form.

---

## Project Structure

```text
Language-Translation-Web-App/
├── Controllers/
├── Models/
├── Services/
├── Views/
├── wwwroot/
├── Properties/
├── Program.cs
├── appsettings.json
├── CodeAlpha_LanguageTranslationTool.csproj
├── .gitignore
└── README.md
```

### Main Folders

- **Controllers** — Handles user requests and connects the interface with application logic.
- **Models** — Stores the data used by the translation form and result.
- **Services** — Handles communication with the external translation API.
- **Views** — Contains the Razor pages displayed to the user.
- **wwwroot** — Contains CSS, JavaScript, images, and other static files.

---

## Installation and Setup

### Requirements

- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code
- Internet connection for API requests
- Git

### Clone the Repository

```bash
git clone https://github.com/anibagul/Language-Translation-Web-App.git
cd Language-Translation-Web-App
```

### Restore Dependencies

```bash
dotnet restore
```

### Run the Application

```bash
dotnet run
```

After the application starts, open the localhost URL displayed in the terminal.

---

## Project Limitations

- Translation quality depends on the free external API.
- The free API may have request limits or temporary availability issues.
- Some translations may not be completely accurate.
- Language support depends on the API being used.
- The project does not use a custom AI or machine-learning model.
- It is designed for basic translation and learning purposes.
- It is not intended for professional, legal, medical, or commercial translation.

---

## Learning Outcomes

This project helped develop practical understanding of:

- ASP.NET Core MVC architecture
- C# backend development
- Razor Views and form handling
- External API integration
- `HttpClient` usage
- Service-layer organization
- Handling API responses
- Basic input validation
- Responsive web-interface development
- Git and GitHub workflow

---

## Project Status

The basic translation workflow is complete and includes language selection, text translation, result display, copy, and clear functionality.

---

## Author

**Aniba Gul**

GitHub: [@anibagul](https://github.com/anibagul)

---

This project was developed as a beginner-friendly ASP.NET Core MVC practice project.
