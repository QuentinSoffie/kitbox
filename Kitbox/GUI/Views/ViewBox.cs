using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kitbox.Order;

namespace Kitbox.GUI
{
    public partial class ViewBox : UserControl
    {
        public int Uid { get; set; }
        public int UidCupboard { get; set; }
        public Box Box;
        public TreeviewManager MainTreeView;

        public ViewBox(int uidCupboard,int uid, Box box, TreeviewManager treeView)
        {
            InitializeComponent();
            this.Uid = uid;
            this.Box = box;
            this.MainTreeView = treeView;
            this.UidCupboard = uidCupboard;
            LoadGUI();
        }
        private void LoadGUI()
        {
            LoadCombobox();
            LoadChat();
          
            label2.Text = Uid.ToString();
            label4.Text = UidCupboard.ToString();
            label10.Text = $"• Dimensions : {Box.Width} * {Box.Depth} * {Box.Height} (cm)" + Environment.NewLine + $"• Panel color  : {Box.Panels[0].Color}" + Environment.NewLine + "• Door color  : " + (Box.Door is null ? "no door" : Box.Door.Color);
            label6.Text = Box.Width.ToString() +" cm (define by cupboard)";
            label7.Text = Box.Depth.ToString() + " cm (define by cupboard)";
            label8.Text = Box.Height.ToString() + " cm";
        }

        private void LoadCombobox()
        {

        }
        private void LoadChat()
        {

        }

        private void ViewCupboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainTreeView.RemoveBox(Uid,UidCupboard);
        }
    }
}
