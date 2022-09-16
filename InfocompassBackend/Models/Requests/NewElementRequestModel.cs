namespace InfocompassBackend.Models.Requests
{
    public class NewElementRequestModel
    {
        private string name;

        public NewElementRequestModel(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}
