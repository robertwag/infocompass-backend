using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface ILiteDbContext
    {
        public List<ListModel> GetList();
        public List<ListModel> AddElement(ListModel Model);
        public List<ListModel> DeleteElement(string id);
        public List<ListModel> UpdateElement(ListModel Model);
        public ListModel GetElementById(string id);

    }
}
