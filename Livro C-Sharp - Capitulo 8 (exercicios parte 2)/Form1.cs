using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Livro_C_Sharp___Capitulo_8__exercicios_parte_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                if (treeView1.SelectedNode.Text != "C:")
                {
                    DirectoryInfo dirC = new DirectoryInfo(@"C:\" + treeView1.SelectedNode.Text);
                    DirectoryInfo[] subDirs = dirC.GetDirectories();
                    foreach (DirectoryInfo dir in subDirs)
                    {
                        if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        {
                            ListViewItem itemDir = listView1.Items.Add(dir.Name);
                            itemDir.ImageIndex = 1;
                        }

                    }
                    FileInfo[] fichs = dirC.GetFiles();
                    foreach (FileInfo fich in fichs)
                    {
                        if ((fich.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        {
                            ListViewItem itemFich = listView1.Items.Add(fich.Name);
                            itemFich.ImageIndex = 2;
                        }
                    }
                }
            }

            catch
            {
                //caso excepção ao nivel de acesso
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode root = treeView1.Nodes.Add("C:");
            root.ImageIndex = 0;
            DirectoryInfo dirC = new DirectoryInfo("c:/");
            DirectoryInfo[] subDirs = dirC.GetDirectories();
            foreach (DirectoryInfo dir in subDirs) {
                if ((dir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden) {
                    TreeNode subDir = root.Nodes.Add(dir.Name);
                    subDir.ImageIndex = 1;
                    subDir.SelectedImageIndex = 1;
                }
            }
            FileInfo[] fichs = dirC.GetFiles();
            foreach (FileInfo fich in fichs) {
                if ((fich.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden) {
                    TreeNode subDir = root.Nodes.Add(fich.Name);
                    subDir.ImageIndex = 2;
                    subDir.SelectedImageIndex = 2;
                }
            }
            treeView1.ExpandAll();
        }
    }
}
