using DataAccess;
using DataAccess.Models;
using InfocompassBackend.Models;
using InfocompassBackend.Models.Requests;
using InfocompassBackend.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace InfocompassBackend.Services
{
    public class ListService : IListService
    {

        //private List<ListViewModel> _list = new List<ListViewModel>();

        private readonly ILiteDbContext _db;

        public ListService(ILiteDbContext db)
        {
            _db = db;
        }

        public List<ListViewModel> GetAllElements()
        {
            List<ListViewModel> list = new List<ListViewModel>();
            var elements = _db.GetList();
            foreach (var element in elements)
            {
                list.Add(new ListViewModel(element.Id, element.Name));
            }
            return list;
        }

        public List<ListViewModel> AddElement(string name)
        {
            ListModel listElement = new ListModel(Guid.NewGuid().ToString(), name, DateTime.UtcNow, DateTime.UtcNow);
            try
            {
                var elements = _db.AddElement(listElement);
                List<ListViewModel> list = new List<ListViewModel>();
                foreach (var element in elements)
                {
                    list.Add(new ListViewModel(element.Id, element.Name));
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<ListViewModel> DeleteElement(string id)
        {
            try
            {
                var elements = _db.DeleteElement(id);
                List<ListViewModel> list = new List<ListViewModel>();
                foreach (var element in elements)
                {
                    list.Add(new ListViewModel(element.Id, element.Name));
                }
                return list;
            }catch(Exception e)
            {
                return null;
            }

        }

        public List<ListViewModel> UpdateElement(ListViewModel Model)
        {
            try
            {
                ListModel element = _db.GetElementById(Model.Id);
                if (element != null)
                {
                    element.Name = Model.Name;
                    element.Updated = DateTime.UtcNow;
                    var elements = _db.UpdateElement(element);
                    List<ListViewModel> list = new List<ListViewModel>();
                    foreach (var listElement in elements)
                    {
                        list.Add(new ListViewModel(listElement.Id, listElement.Name));
                    }
                    return list;
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }            
        }
    }
}
