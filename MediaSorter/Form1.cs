using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace MediaSorter
{
    public partial class Form1 : Form
    {
        List<string> duplicates = new List<string>();

        public Form1()
        {
            InitializeComponent();
            txtSortDir.Text = "";
            txtDestDir.Text = "";
        }

        private void btnSortBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fDiag = new FolderBrowserDialog();
            if (fDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSortDir.Text = fDiag.SelectedPath;
                txtDestDir.Text = fDiag.SelectedPath;
            }
        }

        private void btnDestBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fDiag = new FolderBrowserDialog();
            if (fDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDestDir.Text = fDiag.SelectedPath;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            btnDestBrowse.Enabled = false;
            btnSortBrowse.Enabled = false;
            btnSave.Enabled = false;
            btnSort.Enabled = false;
            lstResults.BackColor = Color.Gray;
            if (txtDestDir.Text != "" && txtSortDir.Text != "")
            {
                Sorting();
            }
            btnDestBrowse.Enabled = true;
            btnSortBrowse.Enabled = true;
            btnSave.Enabled = true;
            btnSort.Enabled = true;
            lstResults.BackColor = Color.White;
            lstResults.Items.Add("Done....");
        }

        private void Sorting()
        {
            int itemCount = 0;
            foreach (string fileName in Directory.GetFiles(txtSortDir.Text))
            {
                itemCount++;
                if (System.IO.Path.GetExtension(fileName).ToLower() == ".mp3")
                {
                    TagLib.File tFile = TagLib.File.Create(fileName);
                    string artistCheck = "";
                    if (tFile.Tag.AlbumArtists.Length > 0)
                    {
                        artistCheck = tFile.Tag.AlbumArtists[0];
                    }
                    string albumCheck = tFile.Tag.Album;
                    if (albumCheck == null)
                    {
                        albumCheck = "";
                    }


                    if (artistCheck != "")
                    {
                        if (!FoundArtist(artistCheck, txtDestDir.Text))
                        {
                            artistCheck = IllegalCheck(artistCheck);
                            Directory.CreateDirectory(txtDestDir.Text + "\\" + artistCheck);
                        }
                    }
                    else
                    {
                        lstResults.Items.Add(fileName + " has no artist");
                    }

                    if (albumCheck != "")
                    {
                        if (artistCheck != "")
                        {
                            if (!FoundAlbum(artistCheck, albumCheck, txtDestDir.Text))
                            {
                                albumCheck = IllegalCheck(albumCheck);
                                Directory.CreateDirectory(txtDestDir.Text + "\\" + artistCheck + "\\" + albumCheck);
                                lstResults.Items.Add("Created directory " + txtDestDir.Text + "\\" + artistCheck + "\\" + albumCheck);
                            }
                        }
                        else
                        {
                            if (!FoundArtist(albumCheck, txtDestDir.Text))
                            {
                                albumCheck = IllegalCheck(albumCheck);
                                Directory.CreateDirectory(txtDestDir.Text + "\\" + albumCheck);
                                lstResults.Items.Add("Created directory " + txtDestDir.Text + "\\" + albumCheck);
                            }
                        }
                    }
                    else
                    {
                        lstResults.Items.Add(fileName + " has no album");
                    }
                    if (artistCheck != "")
                    {
                        if (!System.IO.File.Exists(txtDestDir.Text + "\\" + artistCheck + "\\" + albumCheck + "\\" + System.IO.Path.GetFileName(fileName)))
                        {
                            System.IO.File.Move(fileName, txtDestDir.Text + "\\" + artistCheck + "\\" + albumCheck + "\\" + System.IO.Path.GetFileName(fileName));
                            lstResults.Items.Add("Moved " + fileName + " to " + txtDestDir.Text + "\\" + artistCheck);
                        }
                        else
                        {
                            duplicates.Add(fileName);
                        }
                    }
                    else if (albumCheck != "")
                    {
                        if (!System.IO.File.Exists(txtDestDir.Text + "\\" + albumCheck + "\\" + System.IO.Path.GetFileName(fileName)))
                        {
                            System.IO.File.Move(fileName, txtDestDir.Text + "\\" + albumCheck + "\\" + System.IO.Path.GetFileName(fileName));
                            lstResults.Items.Add("Moved " + fileName + " to " + txtDestDir.Text + "\\" + albumCheck);
                        }
                        else
                        {
                            duplicates.Add(fileName);
                        }
                    }
                    else
                    {
                        lstResults.Items.Add(fileName + " has no info to use for sorting. Not moved.");
                    }
                }
            }
            foreach (string dupe in duplicates)
            {
                lstResults.Items.Add(dupe + " is a duplicate file");
            }
            lstResults.Items.Add("Analyzed " + itemCount + " items");
        }

        private bool FoundArtist(string artistToCheck, string dirCheck)
        {
            foreach (string dName in Directory.GetDirectories(dirCheck))
            {
                if (System.IO.Path.GetFileNameWithoutExtension(dName) == artistToCheck)
                {
                    return true;
                }                
            }

            return false;
        }

        private bool FoundAlbum(string artistToCheck, string albumToCheck, string dirCheck)
        {
            foreach (string dName in Directory.GetDirectories(dirCheck))
            {
                if (System.IO.Path.GetFileNameWithoutExtension(dName) == artistToCheck)
                {
                    foreach (string idName in Directory.GetDirectories(dirCheck + "\\" + artistToCheck))
                    {
                        if (System.IO.Path.GetFileNameWithoutExtension(idName) == albumToCheck)
                        {
                            return true;
                        }                        
                    }
                    return false;
                }
            }

            return false;
        }

        private string IllegalCheck(string toCheck)
        {
            string temp = toCheck;
            string invalid = new string(System.IO.Path.GetInvalidPathChars()) + new string(System.IO.Path.GetInvalidFileNameChars());
            foreach (char c in invalid)
            {
                temp = temp.Replace(c.ToString(), "");
            }
            return temp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDiag = new SaveFileDialog();
            if (saveFileDiag.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDiag.FileName))
                {
                    foreach (object item in lstResults.Items)
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
            }
        }
    }
}
