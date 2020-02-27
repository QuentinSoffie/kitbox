﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kitbox.Components;
using Kitbox.GUI;

namespace Kitbox.Order
{
    public class Order
    {
        private List<Cupboard> cupboardList;
        public Order()
        {
            cupboardList = new List<Cupboard>();
        }

        public void Add(int uid, ViewCupboard view)
        {
            cupboardList.Add(new Cupboard(uid, view));
        }

        public Cupboard GetCupboard(int index)
        {
            if (index > cupboardList.Count() - 1)
            {
                return null;
            }
            else
            {
                return cupboardList[index];
            }
        }
        public void Remove(int index)
        {
            if (index < cupboardList.Count() - 1)
            {
                cupboardList.RemoveAt(index);
            }
        }
        public List<Cupboard> GetCupboardList()
        {
            return cupboardList;
        }
    }
}
