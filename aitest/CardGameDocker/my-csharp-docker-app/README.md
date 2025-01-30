# my-csharp-docker-app/my-csharp-docker-app/README.md

# My C# Docker App

This project is a simple C# application that demonstrates the use of classes and Docker containerization. The application includes a `Cards` class that represents a playing card and a `Player` class that represents a player with a hand of cards.

## Project Structure

- **src/**: Contains the main application files.
  - **Program.cs**: Contains the main application logic.
  - **Dockerfile**: Instructions to build the Docker image.
  - **my-csharp-docker-app.csproj**: Project file for the C# application.

- **.dockerignore**: Specifies files and directories to ignore when building the Docker image.

## Getting Started

To build and run this application in a Docker container, follow these steps:

1. **Clone the repository**:
   ```
   git clone <repository-url>
   cd my-csharp-docker-app
   ```

2. **Build the Docker image**:
   ```
   docker build -t my-csharp-docker-app ./src
   ```

3. **Run the Docker container**:
   ```
   docker run my-csharp-docker-app
   ```

## Dependencies

This project uses the .NET SDK for building and running the application. Ensure you have Docker installed on your machine.

## License

This project is licensed under the MIT License.