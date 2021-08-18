using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFileTask
{
    public static class Helper
    {
       public static void AddFoldersAndFiles(TreeNode node, string path)
        {
            node.Nodes.Clear();
            var dirInfo = new DirectoryInfo(path);
            var subDirs = dirInfo.GetDirectories();
            foreach (var item in subDirs)
            {
                TreeNode childNode = new TreeNode(item.Name);
                childNode.Tag = item.FullName;
                node.Nodes.Add(childNode);
                List<FileInfo> _fileInfo = new List<FileInfo>();
                _fileInfo.AddRange(dirInfo.GetFiles("*.jpg"));
                _fileInfo.AddRange(dirInfo.GetFiles("*.jpeg"));
                _fileInfo.AddRange(dirInfo.GetFiles("*.png"));
                _fileInfo.AddRange(dirInfo.GetFiles("*.gif"));
                _fileInfo.AddRange(dirInfo.GetFiles("*.tiff"));
                foreach (var file in _fileInfo)
                {
                    TreeNode child = new TreeNode(file.Name);
                    child.Tag = file.FullName;
                    childNode.Nodes.Add(child);
                }
            }
            List<FileInfo> fileInfo = new List<FileInfo>();
            fileInfo.AddRange(dirInfo.GetFiles("*.jpg"));
            fileInfo.AddRange(dirInfo.GetFiles("*.jpeg"));
            fileInfo.AddRange(dirInfo.GetFiles("*.png"));
            fileInfo.AddRange(dirInfo.GetFiles("*.gif"));
            fileInfo.AddRange(dirInfo.GetFiles("*.tiff"));
            foreach (var file in fileInfo)
            {
                TreeNode child = new TreeNode(file.Name);
                child.Tag = file.FullName;
                node.Nodes.Add(child);
            }
        }
        public static Byte[] ImgToByte(Image img)
        {


            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap i = new Bitmap(img);
                i.Save(ms, ImageFormat.Png);
                return ms.ToArray();


            }

        }

    }
}
