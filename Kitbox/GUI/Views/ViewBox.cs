using System;
using System.Windows.Forms;
using Kitbox.Order;

namespace Kitbox.GUI
{
    /// <summary>
    /// This is the box view. It displays the box's informations.
    /// </summary>
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
            label2.Text = Uid.ToString();
            label4.Text = UidCupboard.ToString();
            label10.Text = $"• Dimensions : {Box.Width} * {Box.Depth} * {Box.Height} (cm)" + Environment.NewLine + $"• Panel color  : {Box.Panels[0].Color}" + Environment.NewLine + "• Door color  : " + (Box.Door is null ? "no door" : Box.Door.Color);
            label6.Text = Box.Width.ToString() +" cm (define by cupboard)";
            label7.Text = Box.Depth.ToString() + " cm (define by cupboard)";
            label8.Text = Box.Height.ToString() + " cm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainTreeView.RemoveBox(Uid,UidCupboard);
        }
    }
}
