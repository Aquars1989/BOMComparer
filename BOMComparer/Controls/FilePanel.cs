using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOMComparer.Controls
{
    public partial class FilePanel : Control
    {
        public event EventHandler FileSelected;

        protected void OnFileSelected()
        {
            FileSelected?.Invoke(this,null);
        }

        private static Pen PenBorderEmpty = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        private static Color BackColorEmpty = SystemColors.GradientInactiveCaption;
        private static Brush BrushFontColorEmpty = Brushes.Gray;
        private static Font BrushFontEmpty = new Font("Consolas", 12);
        private static Pen PenBorderLoad = new Pen(Color.Black, 1);
        private static Font BrushFontLoad = new Font("Consolas", 10);
        private static Brush BrushFontColorLoad = Brushes.Blue;
        private static Color BackColorLoad = Color.LightYellow;


        private static StringFormat FormatCenter = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoWrap };
        private static StringFormat FormatLeft = new StringFormat() { LineAlignment = StringAlignment.Center,FormatFlags= StringFormatFlags.NoWrap };
        public string FilePath { get; private set; }

        public string FileName { get; private set; }
        public string LastWrite { get; private set; }

        public FilePanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (string.IsNullOrWhiteSpace(FilePath))
            {
                pe.Graphics.Clear(BackColorEmpty);
                pe.Graphics.DrawRectangle(PenBorderEmpty, 0, 0, Width - 1, Height - 1);
                pe.Graphics.DrawString("Drop file to here, or click", BrushFontEmpty, BrushFontColorEmpty, pe.ClipRectangle, FormatCenter);
            }
            else
            {
                pe.Graphics.Clear(BackColorLoad);
                pe.Graphics.DrawRectangle(PenBorderLoad, 0, 0, Width - 1, Height - 1);

                Rectangle rect1 = new Rectangle(5, 5, Height - 10, Height - 10);
                Rectangle rect2 = new Rectangle(Height + 10, 4, Width - Height + 13, Height / 2-2);
                Rectangle rect3 = new Rectangle(Height + 10, Height / 2, Width - Height + 13, Height / 2-2);
                pe.Graphics.DrawImage(Properties.Resources.Microsoft_Excel_2013_icon, rect1);
                pe.Graphics.DrawString(FileName, BrushFontLoad, BrushFontColorLoad, rect2, FormatLeft);
                pe.Graphics.DrawString(LastWrite, BrushFontLoad, BrushFontColorLoad, rect3, FormatLeft);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadFile(openFileDialog1.FileName);
            }
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string extension = Path.GetExtension(((string[])drgevent.Data.GetData(DataFormats.FileDrop))[0]);
                if (extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    drgevent.Effect = DragDropEffects.Copy;
                }
            } 
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            string[] files = (string[])drgevent.Data.GetData(DataFormats.FileDrop);
            LoadFile(files[0]);
        }

        private void LoadFile(string path)
        {
            FilePath = path;
            FileName = Path.GetFileName(FilePath);
            LastWrite = File.GetLastWriteTime(FilePath).ToString("yyyy/MM/dd HH:mm:ss");
            Invalidate();
            OnFileSelected();
        }

        public void ClearSelected()
        {
            FilePath = "";
            FileName = "";
            LastWrite = "";
            Invalidate();
        }
    }
}
