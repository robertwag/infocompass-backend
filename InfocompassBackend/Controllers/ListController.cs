using InfocompassBackend.Models;
using InfocompassBackend.Models.Requests;
using InfocompassBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InfocompassBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService; 

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public List<ListViewModel> GetAllElements()
        {
            return _listService.GetAllElements();
        }
        [HttpPost]
        public List<ListViewModel> AddElementToList(string name)
        {
            if (ModelState.IsValid)
            {
                return _listService.AddElement(name);
            }

            return null;
        }
        [HttpDelete]
        public List<ListViewModel> DeleteElementFromList(string id)
        {
            if(id != null)
            {
                return _listService.DeleteElement(id);
            }
            return null;
        }
        [HttpPut]
        public List<ListViewModel> UpdateElement(ListViewModel Model)
        {
            if (ModelState.IsValid)
            {
                return _listService.UpdateElement(Model);
            }
            return null;
        }
    }
}
