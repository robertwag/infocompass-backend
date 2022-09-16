using InfocompassBackend.Models.Requests;
using InfocompassBackend.Models.Responses;
using System.Collections.Generic;

namespace InfocompassBackend.Services.Interfaces
{
    public interface IListService
    {
        public List<ListViewModel> GetAllElements();
        public List<ListViewModel> AddElement(string name);
        public List<ListViewModel> DeleteElement(string id);
        public List<ListViewModel> UpdateElement(ListViewModel Model);
    }
}
