﻿using DataAccess.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class LiteDbContext : ILiteDbContext
    {

        public List<ListModel> GetList()
        {
            List<ListModel> list = new List<ListModel>();

            using (var db = new LiteDatabase(@"LiteDb.db"))
            {
                var listCollection = db.GetCollection<ListModel>("list");
                var elements = listCollection.FindAll();                
                foreach(var listItem in elements)
                {
                    list.Add(listItem);
                }
            }
            return list;
        }

        public ListModel GetElementById(string id)
        {
            using (var db = new LiteDatabase(@"LiteDb.db"))
            {
                var listCollection = db.GetCollection<ListModel>("list");
                ListModel element = listCollection.FindOne(_ => _.Id.Equals(id));
                return element;
            }
        }

        public List<ListModel> AddElement(ListModel Model)
        {
            using (var db = new LiteDatabase(@"LiteDb.db"))
            {
                var listCollection = db.GetCollection<ListModel>("list");
                listCollection.Insert(Model);
            }
            return GetList();
        }

        public List<ListModel> DeleteElement(string id)
        {
            using (var db = new LiteDatabase(@"LiteDb.db"))
            {
                var listCollection = db.GetCollection<ListModel>("list");
                ListModel element = listCollection.FindOne(_ => _.Id.Equals(id));
                if(element != null)
                {
                    listCollection.Delete(element.Id);
                }                
            }
            return GetList();
        }

        public List<ListModel> UpdateElement(ListModel Model)
        {
            using (var db = new LiteDatabase(@"LiteDb.db"))
            {
                var listCollection = db.GetCollection<ListModel>("list");
                listCollection.Update(Model);                
            }
            return GetList();
        }
    }
}
