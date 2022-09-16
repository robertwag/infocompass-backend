using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class ListModel
    {
        private string id;
        private string name;
        private DateTime created;
        private DateTime updated;

        public ListModel(string id, string name, DateTime created, DateTime updated)
        {
            Id = id;
            Name = name;
            Created = created;
            Updated = updated;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Created { get => created; set => created = value; }
        public DateTime Updated { get => updated; set => updated = value; }
    }
}
