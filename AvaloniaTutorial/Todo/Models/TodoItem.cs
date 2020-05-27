namespace Todo.Models
{
    public class TodoItem
    {
        public TodoItem(string description, bool isChecked = false)
        {
            Description = description;
            IsChecked = isChecked;
        }

        public string Description { get; }

        public bool IsChecked { get; set; }
    }
}
