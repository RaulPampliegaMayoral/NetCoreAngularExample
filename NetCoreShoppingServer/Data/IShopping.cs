using NetCoreAngularExample.Models;
using System.Collections.Generic;

namespace NetCoreAngularExample.Data
{
    public interface IShopping
    {
        public List<Shopping> GetAll();
        public Shopping FindById(int id);
        public Shopping SaveOrUpdate(int id, string name);
        public Shopping AddItem(int shopping, string item);
        public Shopping UpdateItem(int shopping, string item, string newName);
        public Shopping DeleteItem(int shopping, string name);
    }
}
