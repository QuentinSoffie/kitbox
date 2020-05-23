﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitbox.GUI.StoreKeeper.Views
{
    public partial class ViewOrderSuppliers : UserControl
    {

        OrderSuppliers Parent;
        Dictionary<string, string> Component;

        public ViewOrderSuppliers(OrderSuppliers parent, Dictionary<string, string> components)
        {
            InitializeComponent();
            Parent = parent;
            Component = components;
            LoadComponents();
        }

        public void LoadComponents()
        {

        }

    }
}
