using DataAccess;
using DataAccess.Models;
using InfocompassBackend.Models.Requests;
using InfocompassBackend.Models.Responses;
using InfocompassBackend.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InfocompassBackend.Services
{
    public class ListService : IListService
    {
        // Database interface
        private readonly ILiteDbContext _db;

        public ListService(ILiteDbContext db)
        {
            _db = db;
        }

        public List<ListViewModel> GetAllElements()
        {
            var elements = _db.GetList();
            return AddElementsToViewModel(elements);
        }

        public List<ListViewModel> AddElement(string name)
        {
            ListModel listElement = new ListModel(Guid.NewGuid().ToString(), name, DateTime.UtcNow, DateTime.UtcNow);
            
            // First get the elements from the interface
            // Add the elements to the ViewModel
            // Return the ViewModel
            
            try
            {
                var elements = _db.AddElement(listElement);
                return AddElementsToViewModel(elements);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ListViewModel> DeleteElement(string id)
        {

            // First get the elements from the interface
            // Add the elements to the ViewModel
            // Return the ViewModel

            try
            {
                var elements = _db.DeleteElement(id);
                return AddElementsToViewModel(elements);
            }
            catch(Exception e)
            {
                return null;
            }

        }

        public List<ListViewModel> UpdateElement(ListViewModel Model)
        {

            // First get the elements from the interface
            // Add the elements to the ViewModel
            // Return the ViewModel

            try
            {
                ListModel element = _db.GetElementById(Model.Id);
                if (element != null)
                {
                    element.Name = Model.Name;
                    element.Updated = DateTime.UtcNow;
                    var elements = _db.UpdateElement(element);
                    return AddElementsToViewModel(elements);
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }            
        }

        private List<ListViewModel> AddElementsToViewModel(List<ListModel> elements)
        {
            List<ListViewModel> list = new List<ListViewModel>();
            foreach (var listElement in elements)
            {
                list.Add(new ListViewModel(listElement.Id, listElement.Name));
            }
            return list;
        }
    }
}
