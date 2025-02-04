using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MauiTodo.Models;
using Microsoft.Maui.Controls;

namespace MauiTodo
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private readonly Database _database;

        private ObservableCollection<TodoItem> _todos;
        public ObservableCollection<TodoItem> Todos
        {
            get => _todos;
            set
            {
                _todos = value;
                OnPropertyChanged(nameof(Todos)); // ✅ Notify UI to refresh
            }
        }

        public MainPage()
        {
            InitializeComponent();
            _database = new Database();
            Todos = new ObservableCollection<TodoItem>();
            BindingContext = this; // ✅ Ensures UI listens for changes
            _ = Initialize();
        }

        private async Task Initialize()
        {
            var todosFromDb = await _database.GetTodos();
            Todos.Clear();

            foreach (var todo in todosFromDb)
            {
                Todos.Add(todo);
            }

            // Debugging: Check if todos were loaded
            Console.WriteLine($"Loaded {Todos.Count} todos from the database.");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TodoTitleEntry.Text))
            {
                var newTodo = new TodoItem
                {
                    Title = TodoTitleEntry.Text,
                    Due = DueDatePicker.Date
                };

                await _database.Addtodo(newTodo);
                Todos.Add(newTodo); // ✅ Ensures UI updates dynamically
                OnPropertyChanged(nameof(Todos)); // ✅ Notify UI manually

                // Debugging: Check if item was added
                Console.WriteLine($"Added Todo: {newTodo.Title}, Due: {newTodo.Due}");
                
                TodoTitleEntry.Text = string.Empty; // ✅ Clear input field
            }
        }
    }
}
