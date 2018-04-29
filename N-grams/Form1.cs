using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_grams
{
    public partial class Form1 : Form
    {
        List<mSet> l;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.chooseDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.setLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.caseSensitive = new System.Windows.Forms.CheckBox();
            this.Build = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pencentageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chooseDirectory
            // 
            this.chooseDirectory.Location = new System.Drawing.Point(11, 12);
            this.chooseDirectory.Name = "chooseDirectory";
            this.chooseDirectory.Size = new System.Drawing.Size(116, 23);
            this.chooseDirectory.TabIndex = 0;
            this.chooseDirectory.Text = "Choose directory";
            this.chooseDirectory.UseVisualStyleBackColor = true;
            this.chooseDirectory.Click += new System.EventHandler(this.chooseDirectory_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Choose folder with texts";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // setLength
            // 
            this.setLength.AccessibleDescription = "";
            this.setLength.Location = new System.Drawing.Point(12, 66);
            this.setLength.Name = "setLength";
            this.setLength.Size = new System.Drawing.Size(115, 20);
            this.setLength.TabIndex = 1;
            this.setLength.Text = "1";
            this.setLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.setLength_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set length";
            // 
            // caseSensitive
            // 
            this.caseSensitive.AutoSize = true;
            this.caseSensitive.Location = new System.Drawing.Point(33, 103);
            this.caseSensitive.Name = "caseSensitive";
            this.caseSensitive.Size = new System.Drawing.Size(94, 17);
            this.caseSensitive.TabIndex = 3;
            this.caseSensitive.Text = "Case sensitive";
            this.caseSensitive.UseVisualStyleBackColor = true;
            // 
            // Build
            // 
            this.Build.Location = new System.Drawing.Point(11, 138);
            this.Build.Name = "Build";
            this.Build.Size = new System.Drawing.Size(116, 23);
            this.Build.TabIndex = 4;
            this.Build.Text = "Build";
            this.Build.UseVisualStyleBackColor = true;
            this.Build.Click += new System.EventHandler(this.Build_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView.Location = new System.Drawing.Point(164, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(684, 345);
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "n-грамма";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Частота";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Первый контекст";
            this.columnHeader3.Width = 551;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(164, 363);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(684, 23);
            this.progressBar.TabIndex = 6;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // pencentageLabel
            // 
            this.pencentageLabel.AutoSize = true;
            this.pencentageLabel.Location = new System.Drawing.Point(123, 363);
            this.pencentageLabel.Name = "pencentageLabel";
            this.pencentageLabel.Size = new System.Drawing.Size(0, 13);
            this.pencentageLabel.TabIndex = 7;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(860, 390);
            this.Controls.Add(this.pencentageLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.Build);
            this.Controls.Add(this.caseSensitive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setLength);
            this.Controls.Add(this.chooseDirectory);
            this.Name = "Form1";
            this.Text = "N-grams";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void chooseDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                MessageBox.Show("Your directory is: \n\n" + folderBrowserDialog.SelectedPath);
        }

        private void setLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void Build_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();  
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                counts();
                backgroundWorker.ReportProgress(i);
            }
        }

        private void counts()
        {
            l = new List<mSet>();
            Data data = new Data(Directory.GetFiles(@folderBrowserDialog.SelectedPath, "*.txt").ToList<string>(), setLength.Text, caseSensitive.Checked);
            data.Build(out l);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            pencentageLabel.Text = e.ProgressPercentage.ToString() + " %";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var i in l)
            {
                ListViewItem item = new ListViewItem(i.str);
                item.SubItems.Add(Convert.ToString(i.fr));
                item.SubItems.Add(i.context);
                listView.Items.Add(item);
            }
        }
    }

    public struct mSet
    {
        public string str;
        public int fr;
        public string context;

        public mSet(string _str, int _fr, string _context)
        {
            this.str = _str;
            this.fr = _fr;
            this.context = _context;
        }
    }

    public class Data
    {
        private List<string> files;
        private String length;
        private Boolean check;

        public Data(List<string> _files, String _length, Boolean _check)
        {
            this.files = _files;
            this.length = _length;
            this.check = _check;
        }

        public void Build(out List<mSet> list)
        {
            List<string[]> grams = new List<string[]>();
            List<string[]> sentences = new List<string[]>();
            foreach (var file in files)
            {
                StreamReader streamReader = new StreamReader(file, Encoding.Unicode);
                StreamReader stream = new StreamReader(file, Encoding.Unicode);
                // основные знаки, которые могут выступать в качестве разделителей
                string[] separators = new string[] {",", ".", "?", "!", ";", ":", "-", "(", ")", "\r\n", "–"};
                string[] sentence = new string[] { ".", "?", "!", "\r\n" };
                string[] g = streamReader.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray<string>();
                string[] st = stream.ReadToEnd().Split(sentence, StringSplitOptions.RemoveEmptyEntries).ToArray<string>();
                grams.Add(g);
                sentences.Add(st);
            }
            List<string> ngrams = Ngrams(grams, length, check); // находим все n-граммы
            List<mSet> table = Frequency(ngrams, sentences, length, check); // находим частоту каждой n-граммы по всем текстам и первый контекст
            var sorted = table.OrderByDescending(mSet => mSet.fr).ToList(); // сортируем
            list = sorted;
        }

        private List<string> Ngrams(List<string[]> grams, String length, Boolean check) // находим все n-граммы 
        {
            List<string> ngrams = new List<string>();
            string[] separator = new string[] {" "};
            foreach (var gr in grams)
            {
                foreach (var singleGram in gr)
                {
                    string[] words = singleGram.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray<string>();
                    for (int i = 0; i < words.Length; i++)
                    {
                        string ngram = null;
                        if (words.Length >= Convert.ToInt32(length) + i)
                        {
                            for (int j = 0, k = i; j < Convert.ToInt32(length); j++)
                            {
                                if (j == 0)
                                {
                                    if (check)
                                        ngram = words[k].ToLower();
                                    else
                                        ngram = words[k];
                                }
                                else
                                {
                                    k++;
                                    if (check)
                                        ngram += " " + words[k].ToLower();
                                    else
                                        ngram += " " + words[k];
                                }
                            }
                        }
                        if (ngram != null)
                        {
                            ngrams.Add(ngram);
                            //MessageBox.Show(ngram);
                        }
                    }
                }
            }
            return ngrams;
        }

        private List<mSet> Frequency(List<string> ngrams, List<string[]> sentences, String length, Boolean ch) // определяем частоту 
        {
            List<mSet> set = new List<mSet>();
            var item = new mSet();
            int i = 0;
            foreach (var ngram in ngrams)
            {
                item.str = ngram;
                item.fr = 0;
                foreach (var check in ngrams)
                {
                    if (ngram == check)
                        item.fr++;
                }
                item.context = firstMatch(ngram, sentences, length, ch); // нахождение первого контекста
                if (!set.Contains(item))
                {
                    set.Add(item);
                    i++;
                }
            }
            return set;
        }

        private string firstMatch(string ngram, List<string[]> sentences, String length, Boolean check) // ищем первое вхождение 
        {
            string firstSentence = null;
            string[] separators = new string[] { ",", ";", ":", "-", "(", ")", "\r\n", "–"};
            string[] separator = new string[] { " "};
            foreach (var set in sentences)
            {
                foreach (var singleSentence in set)
                {
                    string[] ngrams = singleSentence.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray<string>();
                    foreach (var ng in ngrams)
                    {
                        string[] words = ng.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray<string>();
                        
                        for (int i = 0; i < words.Length; i++)
                        {
                            string n = null;
                            if (words.Length >= Convert.ToInt32(length) + i)
                            {
                                for (int j = 0, k = i; j < Convert.ToInt32(length); j++)
                                {
                                    if (j == 0)
                                    {
                                        if (check)
                                            n = words[k].ToLower();
                                        else
                                            n = words[k];
                                    }
                                    else
                                    {
                                        k++;
                                        if (check)
                                            n += " " + words[k].ToLower();
                                        else
                                            n += " " + words[k];
                                    }
                                }
                            }
                            if (n == ngram)
                            {
                                return singleSentence;
                            }
                        }
                    }

                }
            }
            return firstSentence;
        }

    }
    
}