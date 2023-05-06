using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab27OOP
{
    public partial class Form1 : Form
    {
        private string selectedFilePath;
        private string selectedDirectoryPath;
        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }
        private void LoadDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                TreeNode node = new TreeNode(drive.Name);
                node.Tag = drive.RootDirectory;
                node.Nodes.Add("");
                treeView.Nodes.Add(node);
            }
        }

        private void LoadDirectories(TreeNode parentNode)
        {
            try
            {
                DirectoryInfo directory = (DirectoryInfo)parentNode.Tag;
                directory.GetDirectories();
                foreach (DirectoryInfo subdirectory in directory.GetDirectories())
                {
                    TreeNode node = new TreeNode(subdirectory.Name);
                    node.Tag = subdirectory;
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // не маємо дозволу на доступ до цього каталогу
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFiles(TreeNode parentNode)
        {
            try
            {
                DirectoryInfo directory = (DirectoryInfo)parentNode.Tag;
                foreach (FileInfo file in directory.GetFiles())
                {
                    // фільтрація списку файлів
                    if (Path.GetExtension(file.Name) == ".txt")
                    {
                        TreeNode node = new TreeNode(file.Name);
                        node.Tag = file;
                        parentNode.Nodes.Add(node);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // не маємо дозволу на доступ до цього каталогу
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "")
            {
                e.Node.Nodes.Clear();
                LoadDirectories(e.Node);
                LoadFiles(e.Node);
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is DriveInfo)
            {
                // перегляд основних властивостей виділеного диску
                DriveInfo drive = (DriveInfo)e.Node.Tag;
                propertyGrid.SelectedObject = drive;
            }
            else if (e.Node.Tag is DirectoryInfo)
            {
                // перегляд основних властивостей виділеного каталогу
                DirectoryInfo directory = (DirectoryInfo)e.Node.Tag;
                propertyGrid.SelectedObject = directory;

                // фільтрація списку каталогів
                if (checkBoxFilterDirectories.Checked)
                {
                    e.Node.Nodes.Clear();
                    LoadDirectories(e.Node);
                }
            }
            else if (e.Node.Tag is FileInfo)
            {   // перегляд основних властивостей виділеного файлу
                FileInfo file = (FileInfo)e.Node.Tag;
                propertyGrid.SelectedObject = file;

                // фільтрація списку файлів
                if (checkBoxFilterFiles.Checked)
                {
                    e.Node.Parent.Nodes.Clear();
                    LoadFiles(e.Node.Parent);
                }

                // перегляд вмісту текстових файлів
                if (Path.GetExtension(file.Name) == ".txt")
                {
                    selectedFilePath = file.FullName;
                    textBoxFileContent.Text = File.ReadAllText(selectedFilePath);
                }
                else
                {
                    selectedFilePath = null;
                    textBoxFileContent.Clear();
                }

                // перегляд вмісту графічних файлів
                if (Path.GetExtension(file.Name) == ".jpg" || Path.GetExtension(file.Name) == ".png")
                {
                    pictureBoxImage.Image = Image.FromFile(file.FullName);
                }
                else
                {
                    pictureBoxImage.Image = null;
                }

                // перегляд атрибутів безпеки файлів та каталогів
                try
                {
                    FileSystemSecurity security = File.GetAccessControl(file.FullName);
                    textBoxSecurity.Text = security.GetSecurityDescriptorSddlForm(AccessControlSections.All);
                }
                catch (UnauthorizedAccessException)
                {
                    textBoxSecurity.Text = "Не маємо дозволу на доступ до цього файлу";
                }
                catch (Exception ex)
                {
                    textBoxSecurity.Text = ex.Message;
                }
            }
        }
        private void checkBoxFilterDirectories_CheckedChanged(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Tag is DirectoryInfo)
            {
                treeView.SelectedNode.Nodes.Clear();
                LoadDirectories(treeView.SelectedNode);
            }
        }

        private void checkBoxFilterFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Tag is DirectoryInfo)
            {
                treeView.SelectedNode.Nodes.Clear();
                LoadFiles(treeView.SelectedNode);
            }
        }

        private void textBoxFileContent_TextChanged(object sender, EventArgs e)
        {
            if (selectedFilePath != null)
            {
                File.WriteAllText(selectedFilePath, textBoxFileContent.Text);
            }
        }
    }
}
