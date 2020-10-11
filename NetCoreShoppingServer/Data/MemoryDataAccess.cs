using NetCoreAngularExample.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreAngularExample.Data
{
    public class MemoryDataAccess : IShopping
    {
        private static ConcurrentDictionary<int, Shopping> _shoppings = new ConcurrentDictionary<int, Shopping>();

        public Shopping AddItem(int shopping, string item)
        {
            var shoppingValue = FindById(shopping);
            if( shoppingValue != null )
            {
                if (shoppingValue.Items == null)
                    shoppingValue.Items = new List<Item>();

                shoppingValue.Items.Add(new Item { Name = item, Created = DateTime.Now });
            }

            return shoppingValue;
        }

        public Shopping DeleteItem(int shopping, string name)
        {
            var shoppingValue = FindById(shopping);
            if (shoppingValue != null)
            {
                shoppingValue.Items.RemoveAll(c => c.Name.Equals(name));
            }

            return shoppingValue;
        }

        public Shopping FindById(int name)
        {
            return _shoppings.GetValueOrDefault(name);
        }

        public List<Shopping> GetAll()
        {
            return _shoppings.Values.ToList();
        }

        public Shopping SaveOrUpdate(int id, string name)
        {
            var shopping = FindById(id);
            if (shopping != null )
            {
                shopping.Name = name;
            }
            else
            {
                shopping = new Shopping
                {
                    Id = _shoppings.Values.Any() ? _shoppings.Values.Max(c => c.Id) + 1 : 1,
                    Name = name,
                    Created = DateTime.Now
                };
                _shoppings.TryAdd(shopping.Id, shopping);
            }
            return shopping;
        }

        public Shopping UpdateItem(int shopping, string item, string newName)
        {
            var shoppingValue = FindById(shopping);
            if (shoppingValue != null )
            {
                foreach(var itemValue in shoppingValue.Items.Where(c => c.Name.Equals(item)))
                {
                    itemValue.Name = newName;
                }
            }

            return shoppingValue;
        }
    }
}
