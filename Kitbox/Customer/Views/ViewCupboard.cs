using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Kitbox.Models.Components;
using Kitbox.Models.Order;
using MySql.Data.MySqlClient;
namespace Kitbox.Customer.Views
{
    /// <summary>
    /// This is the cupboard view. It displays the cupboard's informations. 
    /// </summary>
    public partial class ViewCupboard : UserControl
    {
        private TreeviewManager MainTreeView;
        public int Uid;
        private Cupboard Cupboard;
        public MySqlConnection DataBase;
        public Dictionary<string, Dictionary<string, object>> Components;
        public ViewCupboard(int uid, Cupboard cupboard, MySqlConnection dataBase, TreeviewManager treeView)
        {
            InitializeComponent();
            this.Uid = uid;
            this.Cupboard = cupboard;
            MainTreeView = treeView;
            DataBase = dataBase;
            pepCombobox6.SelectedIndex = 0;
            LoadGUI(); 
        }

        private void LoadGUI()
        {
            LoadCombobox();
            LoadChat();
            label13.Text = "Cupboard - " + Uid;
            label4.Text = Uid.ToString();
        }

        private void pepButton1_Click(object sender, EventArgs e)
        {
            MainTreeView.MainTreeview.ExpandAll();
            MainTreeView.MainTreeview.SelectedNode = null;
            AddBox();
        }

        private void AddBox()
        {
            if (Cupboard.CountBox() < 7)
            {
                string colorPanel = pepCombobox4.SelectedItem == null || pepCombobox4.SelectedIndex == 0 ? "?" : pepCombobox4.SelectedItem.ToString();
                string colorDoor = pepCombobox3.SelectedItem == null || pepCombobox3.SelectedIndex == 0 ? "?" : pepCombobox3.SelectedItem.ToString();
                string height = pepCombobox5.SelectedItem == null || pepCombobox5.SelectedIndex == 0 ? "?" : (int.Parse(pepCombobox5.SelectedItem.ToString()) - 4).ToString();
                string width = pepCombobox2.SelectedItem == null || pepCombobox2.SelectedIndex == 0 ? "?" : pepCombobox2.SelectedItem.ToString();
                string depth = pepCombobox1.SelectedItem == null || pepCombobox1.SelectedIndex == 0 ? "?" : pepCombobox1.SelectedItem.ToString();

                Components = MainTreeView.GetBoxComponents(width, depth, height, colorDoor, colorPanel, Cupboard);

                Dictionary<string, Specs> result = MainTreeView.CheckBox(Uid, Components);

                if (result.Count != 0)
                {
                    AddChat("We are very sorry! This(Those) components is(are) no longer available :", Color.Red);

                    foreach (KeyValuePair<string, Specs> component in result)
                    {
                        AddChat($"\"{component.Key}({component.Value.Code})\"", Color.LightCoral);
                    }

                    AddChat("Please continue, pay a deposit and get your order later or select other(s) component(s) ", Color.Red);

                    pepButton4.Visible = true;
                }
                else
                {
                    MainTreeView.AddBox(Uid, Components, Cupboard);
                }

                RefreshView();
            }
            else
            {
                AddChat("You have too many boxes in your cupboard !", Color.Red);
            }
        }

        private void AddChat(string message, Color color)
        {
            string hours = DateTime.Now.ToString("[HH:mm:ss] ");
            RichTextBox_console.RT.AppendText(hours  + message + Environment.NewLine);
            RichTextBox_console.RT.SelectionStart = RichTextBox_console.RT.Find(hours + message, RichTextBoxFinds.Reverse);
            RichTextBox_console.RT.SelectionColor = color;
            RichTextBox_console.RT.DeselectAll();
            RichTextBox_console.RT.ScrollToCaret();
        }
        private void LoadChat()
        {
            AddChat("Welcome to Kitbox designer !", Color.Chartreuse);
            AddChat("Please choose width and depth to make your cupboard...", Color.Khaki);
        }

        private void LoadCombobox()
        {

            for (int i = 0; i < Kitbox.Models.Database.Components.Doors.CountDoor(); i += 1)
            {
                if (pepCombobox3.Items.Contains(Kitbox.Models.Database.Components.Doors.GetColorDoor(i)) == false)
                {
                    pepCombobox3.Items.Add(Kitbox.Models.Database.Components.Doors.GetColorDoor(i));
                }
            }

            for (int i = 0; i < Kitbox.Models.Database.Components.CupboardAngles.CountCupboardAngle(); i += 1)
            {
                if (pepCombobox6.Items.Contains(Kitbox.Models.Database.Components.CupboardAngles.GetColorCupboardAngle(i)) == false)
                {
                    pepCombobox6.Items.Add(Kitbox.Models.Database.Components.CupboardAngles.GetColorCupboardAngle(i));
                }
            }

            for (int i = 0; i < Kitbox.Models.Database.Components.Panels.CountPanel(); i += 1)
            {
                if (pepCombobox4.Items.Contains(Kitbox.Models.Database.Components.Panels.GetColorPanel(i, "HB")) == false && Kitbox.Models.Database.Components.Panels.GetColorPanel(i, "HB") != "none")
                {
                    pepCombobox4.Items.Add(Kitbox.Models.Database.Components.Panels.GetColorPanel(i, "HB"));
                }

                if (pepCombobox5.Items.Contains(Kitbox.Models.Database.Components.Panels.GetHeightPanel(i, "GD")) == false && Kitbox.Models.Database.Components.Panels.GetHeightPanel(i, "GD") != -1)
                {
                    pepCombobox5.Items.Add(Kitbox.Models.Database.Components.Panels.GetHeightPanel(i, "GD"));
                }

                if (pepCombobox2.Items.Contains(Kitbox.Models.Database.Components.Panels.GetWidthPanel(i, "Ar")) == false && Kitbox.Models.Database.Components.Panels.GetWidthPanel(i, "Ar") != -1)
                {
                    pepCombobox2.Items.Add(Kitbox.Models.Database.Components.Panels.GetWidthPanel(i, "Ar"));
                }

                if (pepCombobox1.Items.Contains(Kitbox.Models.Database.Components.Panels.GetDepthPanel(i, "GD")) == false && Kitbox.Models.Database.Components.Panels.GetDepthPanel(i, "GD") != -1)
                {
                    pepCombobox1.Items.Add(Kitbox.Models.Database.Components.Panels.GetDepthPanel(i, "GD"));
                }
            }
        }

        private void pepCombobox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProgressionBox();
        }

        private void refreshProgressionBox()
        {
            int totalCompletion = 0;
            if (pepCombobox3.SelectedIndex != 0 && pepCombobox3.SelectedIndex != -1)
            {
                totalCompletion += 1;
            }
            if (pepCombobox4.SelectedIndex != 0 && pepCombobox4.SelectedIndex != -1)
            {
                totalCompletion += 1;
            }
            if (pepCombobox5.SelectedIndex != 0 && pepCombobox5.SelectedIndex != -1)
            {
                totalCompletion += 1;
            }

            int percentage = Convert.ToInt32((Math.Round((Convert.ToDouble((Convert.ToDouble(totalCompletion) / 3)) * 100))));

            if (percentage == 100) 
            {
                pepButton1.Enabled = true;
            } 
            else 
            {
                pepButton1.Enabled = false;
            }

            pepProgressBar2.Value = percentage;
            pepProgressBar2.Text = "Add box progress - " + percentage +"%";
        }

        private void refreshProgressionCupboard()
        {
            int totalCompletion = 0;
            if (pepCombobox1.SelectedIndex != 0 && pepCombobox1.SelectedIndex != -1)
            {
                totalCompletion += 1;
            }
            if (pepCombobox2.SelectedIndex != 0 && pepCombobox2.SelectedIndex != -1)
            {
                totalCompletion += 1;
            }

            int percentage = Convert.ToInt32((Math.Round((Convert.ToDouble((Convert.ToDouble(totalCompletion) / 2)) * 100))));
            if (percentage == 100)
            {
                pepButton3.Enabled = true;
                AddChat("Attention you can not go back, are you sure of your choice?", Color.White);
            }
            else
            {
                pepButton3.Enabled = false;
            }
            pepProgressBar3.Value = percentage;

            pepProgressBar3.Text = "Completion percentage - " + percentage + "%";

        }

        private void pepCombobox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProgressionBox();
        }

        private void pepCombobox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProgressionBox();
        }

        private void pepCombobox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProgressionCupboard();
            Console.WriteLine(pepCombobox2.SelectedItem.ToString());
            try
            {
                if (int.Parse(pepCombobox2.SelectedItem.ToString()) < 60)
                {
                    AddChat("Wait ! You can't have a door with this width.", Color.Orange);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
        }

        private void pepCombobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProgressionCupboard();
        }

        private void pepButton2_Click(object sender, EventArgs e)
        {
            ShowPreview();
        }
        private void ShowPreview()
        {
            string colorPanel = pepCombobox4.SelectedItem == null || pepCombobox4.SelectedIndex == 0  ? "?" : pepCombobox4.SelectedItem.ToString();
            string colorDoor = pepCombobox3.SelectedItem == null || pepCombobox3.SelectedIndex == 0 ? "?" : pepCombobox3.SelectedItem.ToString();
            string height = pepCombobox5.SelectedItem == null || pepCombobox5.SelectedIndex == 0 ? "?" : (int.Parse(pepCombobox5.SelectedItem.ToString()) - 4).ToString();
            string width = pepCombobox2.SelectedItem == null || pepCombobox2.SelectedIndex == 0 ? "?" : pepCombobox2.SelectedItem.ToString();
            string depth = pepCombobox1.SelectedItem == null || pepCombobox1.SelectedIndex == 0 ? "?" : pepCombobox1.SelectedItem.ToString();

            Preview obj = new Preview(colorPanel,colorDoor,height, width, depth);
            obj.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainTreeView.RemoveCupboard(Uid,Cupboard);
        }

        private void ReduceGUI()
        {
            pepProgressBar3.Visible = false;
            pepButton3.Visible = false;
            pepCombobox1.Enabled = false;
            pepCombobox2.Enabled = false;
           
        }
        private void EnlargesGUI()
        {
            pepButton1.Visible = true;
            pepButton2.Visible = true;
            pepCombobox3.Visible = true;
            pepCombobox4.Visible = true;
            pepCombobox5.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            pepGroupBox2.Visible = true;
            pictureBox5.Visible = true;
            pictureBox4.Visible = true;
            pictureBox8.Visible = true;
            pepCombobox6.Visible = true;
            label14.Visible = true;
            pictureBox9.Visible = true;
            pepProgressBar2.Visible = true;
        }

        private void pepButton3_Click(object sender, EventArgs e)
        {
            ReduceGUI();
            AddChat("Woh nice dimensions for your cupboard !", Color.White);
            EnlargesGUI();
            if (int.Parse(pepCombobox2.SelectedItem.ToString()) < 60)
            {
                pepCombobox3.SelectedIndex = 1;
                pepCombobox3.Enabled = false; 
            }
        }

        private void RefreshProgressBar()
        {
            pepProgressBar1.Value = Cupboard.CountBox()*(15);
        }

        public void RefreshView()
        {
            pepProgressBar1.Text = string.Format("{0}/7", Cupboard.CountBox());
            RefreshProgressBar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckCupboard();
        }

        private void CheckCupboard()
        {
            if(Cupboard.CountBox() > 0)
            {
                if (pepCombobox6.SelectedItem.ToString() != "Undefined")
                {
                    CupboardAngle cupboardAngle = GetGoodCupAngle();
                    if (cupboardAngle is null)
                    {
                        AddChat($"✗ We are very sorry, we cannot find CupboardAngle. Please select an another one.", Color.Red);
                        return;
                    }

                    if (MainTreeView.CheckAngle(cupboardAngle))
                    {
                        Cupboard.CupboardAngle = cupboardAngle;
                        if (Cupboard.CheckState() == "Completed ✓")
                        {
                            MainTreeView.UpdateTag(Uid, "true");
                            AddChat($"✓ Your cupboard (height: {Cupboard.GetSizes()["Height"]} cm, width: {Cupboard.GetSizes()["Width"]} cm, depth: {Cupboard.GetSizes()["Depth"]} cm) is approved !", Color.White);
                        }

                        else
                        {
                            MainTreeView.UpdateTag(Uid, null);
                            AddChat("Your cupboard is approved but some components are missing!", Color.White);
                        }
                    }

                    else
                    {
                        AddChat($"We are very sorry, your CupboardAngle ({cupboardAngle.Code}) is no longer available. Please continue, pay a deposit and get your order later or select an another CupboardAngle.", Color.Red);
                        pepButton5.Visible = true;
                    }
                }

                else
                {
                    AddChat($"✗ Please select your angle color !", Color.Red);
                }
            }
            
            else
            {
                AddChat($"✗ We are very sorry, your Cupboard contains 0 box. Please make your box.", Color.Red);
            }
        }

        private CupboardAngle GetGoodCupAngle()
        {
            int totalHeight = Cupboard.ListeBoxes.Sum(o => o.Height);
            Console.WriteLine(totalHeight);
            return Models.Database.Reader.SearchCupboardAngle(totalHeight, pepCombobox6.SelectedItem.ToString(), DataBase);
        }

        private void pepCombobox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainTreeView.UpdateTag(Uid);
        }

        private void pepButton4_Click(object sender, EventArgs e)
        {
            MainTreeView.AddBox(Uid, Components, Cupboard, "Not completed");
            pepButton4.Visible = false;
        }

        private void pepButton5_Click(object sender, EventArgs e)
        {
            Cupboard.CupboardAngle = GetGoodCupAngle();
            Cupboard.State = "Not completed";
            MainTreeView.UpdateTag(Uid, null);
            AddChat("Your cupboard is approved but some components are missing!", Color.White);
            pepButton5.Visible = false;
        }
    }
}
