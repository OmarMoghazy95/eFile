using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFileTask
{
    public partial class Main : Form
    {
        private Services.SaveImageService _imageService;
        public Main()
        {
            InitializeComponent();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Helper.FillTreeView(treeView1);
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                var fPath = folderDialog.SelectedPath;
                string folder = new DirectoryInfo(fPath).Name;
                var mainNode = new TreeNode { Text = folder, ImageIndex = 2, Tag = fPath };
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(mainNode);
                pictureBox1.Image = Properties.Resources.gallery_image_landscape_mobile_museum_open_line_icon_1320183049020185924_256;
                pictureBox1.Tag = null;
                Helper.AddFoldersAndFiles(mainNode, fPath);
            }
        }

        private void treeView1_BeforeExpand_1(object sender, TreeViewCancelEventArgs e)
        {
        }


        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                if (e.Node.Nodes.Count > 0) return;
                var img = File.Exists(e.Node.Tag.ToString());
                if (!img) return;
                pictureBox1.Image = Image.FromFile(e.Node.Tag.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Tag = e.Node.Tag;
            });

        }

        private async void btnSave_Click(object sender, EventArgs e)
        
        {
            await SaveImage();
        }

        private async Task SaveImage()
        {
            #region Validation
            if (pictureBox1.Tag == null)
            {
                MessageBox.Show("Please Select Image ", "No image Seletced", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtAddress.Text.Trim() == string.Empty || txtMail.Text.Trim() == string.Empty || txtName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill required data  { Name, Address, Mail .. }!", "Data is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            var image = new Domain.Image_Data { Address = txtAddress.Text.Trim(), Email = txtMail.Text.Trim(), Name = txtName.Text.Trim(), Image_Path = pictureBox1.Tag.ToString(), Image_Blob = Helper.ImgToByte(pictureBox1.Image) };
            _imageService = new Services.SaveImageService();
            var res = await _imageService.AddNewImage(image);
            if (res < 1) { MessageBox.Show($"an Error Occured While saving Data ..!{res} Data saved "); return; }
            MessageBox.Show("Image Data Saved Succesfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cls();
        }

        void cls()
        {
            txtAddress.Text = txtMail.Text = txtName.Text = string.Empty;
            pictureBox1.Image  = Properties.Resources.gallery_image_landscape_mobile_museum_open_line_icon_1320183049020185924_256;
            pictureBox1.Tag = null;
        }
    }
}
