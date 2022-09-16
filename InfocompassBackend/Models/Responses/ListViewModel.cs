namespace InfocompassBackend.Models.Responses
{
    public class ListViewModel
    {
        private string id;
        private string name;

        public ListViewModel()
        {
        }

        public ListViewModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
