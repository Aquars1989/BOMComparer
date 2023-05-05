using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOMComparer
{
    public partial class MainForm : Form
    {
        private Dictionary<string, int> _ColumnMap1 = new Dictionary<string, int>();
        private DataTable _Data1 = null;
        public DataTable Data1
        {
            get { return _Data1; }
            set
            {
                if (_Data1 == null && value == null) return;
                _Data1 = value;
                CompareData();
            }
        }


        private Dictionary<string, int> _ColumnMap2 = new Dictionary<string, int>();
        private DataTable _Data2 = null;
        public DataTable Data2
        {
            get { return _Data2; }
            set
            {
                if (_Data2 == null && value == null) return;
                _Data2 = value;
                CompareData();
            }
        }

        private List<MarkInfo> Mark1 { get; set; } = new List<MarkInfo>();
        private List<MarkInfo> Mark2 { get; set; } = new List<MarkInfo>();

        private string Logs { get; set; }

        public MainForm()
        {
            InitializeComponent();

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable LoadExcel(string path, ref Dictionary<string, int> columnMap)
        {
            using (XLWorkbook wb = new XLWorkbook(path))
            {
                var workshee = wb.Worksheets.First();
                DataTable table = new DataTable();
                table.Columns.Add("id", typeof(int));
                table.Columns.Add("action");
                table.Columns.Add("level");
                table.Columns.Add("item_number");
                table.Columns.Add("quantity");
                table.Columns.Add("reference_designator");

                columnMap.Clear();
                for (int i = 1; i <= workshee.ColumnCount(); i++)
                {
                    string columnName = workshee.Cell(1, i).Value.ToString().Trim().ToLower();
                    if (!columnMap.ContainsKey(columnName))
                        columnMap.Add(columnName, i);
                }
                if (!columnMap.ContainsKey("action")) throw new Exception("Lost column: action");
                if (!columnMap.ContainsKey("level")) throw new Exception("Lost column: level");
                if (!columnMap.ContainsKey("item_number")) throw new Exception("Lost column: item_number");
                if (!columnMap.ContainsKey("quantity")) throw new Exception("Lost column: quantity");
                if (!columnMap.ContainsKey("reference_designator")) throw new Exception("Lost column: reference_designator");

                for (int i = 3; i <= workshee.LastRowUsed().RowNumber(); i++)
                {
                    string action = workshee.Cell(i, columnMap["action"]).Value.ToString().Trim();
                    string level = workshee.Cell(i, columnMap["level"]).Value.ToString().Trim();
                    string item_number = workshee.Cell(i, columnMap["item_number"]).Value.ToString().Trim();
                    string quantity = workshee.Cell(i, columnMap["quantity"]).Value.ToString().Trim();
                    string reference_designator = workshee.Cell(i, columnMap["reference_designator"]).Value.ToString().Trim();
                    table.Rows.Add(i, action, level, item_number, quantity, reference_designator);
                }
                table.DefaultView.Sort = "item_number";
                return table;
            }
        }

        private void CompareData()
        {
            lnkClear1.Visible = Data1 != null;
            lnkClear2.Visible = Data2 != null;

            DataTable table = new DataTable();
            table.Columns.Add("id1");
            table.Columns.Add("action1");
            table.Columns.Add("level1");
            table.Columns.Add("item_number1");
            table.Columns.Add("quantity1");
            table.Columns.Add("reference_designator1");
            table.Columns.Add("id2");
            table.Columns.Add("action2");
            table.Columns.Add("level2");
            table.Columns.Add("item_number2");
            table.Columns.Add("quantity2");
            table.Columns.Add("reference_designator2");

            if (Data1 != null)
            {
                if (Data2 != null)
                {
                    int i1 = 0, i2 = 0;
                    DataView view1 = Data1.DefaultView;
                    DataView view2 = Data2.DefaultView;
                    while (i1 < view1.Count || i2 < view2.Count)
                    {
                        string number1 = i1 < view1.Count ? view1[i1]["item_number"] as string : "";
                        string number2 = i1 < view2.Count ? view2[i2]["item_number"] as string : "";
                        DataRow newRow = table.NewRow();
                        if (i1 >= view1.Count || string.Compare(number1, number2) > 0)
                        {
                            newRow["id2"] = view2[i2]["id"];
                            newRow["action2"] = view2[i2]["action"];
                            newRow["level2"] = view2[i2]["level"];
                            newRow["item_number2"] = view2[i2]["item_number"];
                            newRow["quantity2"] = view2[i2]["quantity"];
                            newRow["reference_designator2"] = view2[i2]["reference_designator"];
                            i2++;
                        }
                        else if (i2 >= view2.Count || string.Compare(number1, number2) < 0)
                        {
                            newRow["id1"] = view1[i1]["id"];
                            newRow["action1"] = view1[i1]["action"];
                            newRow["level1"] = view1[i1]["level"];
                            newRow["item_number1"] = view1[i1]["item_number"];
                            newRow["quantity1"] = view1[i1]["quantity"];
                            newRow["reference_designator1"] = view1[i1]["reference_designator"];
                            i1++;
                        }
                        else
                        {
                            newRow["id1"] = view1[i1]["id"];
                            newRow["action1"] = view1[i1]["action"];
                            newRow["level1"] = view1[i1]["level"];
                            newRow["item_number1"] = view1[i1]["item_number"];
                            newRow["quantity1"] = view1[i1]["quantity"];
                            newRow["reference_designator1"] = view1[i1]["reference_designator"];
                            newRow["id2"] = view2[i2]["id"];
                            newRow["action2"] = view2[i2]["action"];
                            newRow["level2"] = view2[i2]["level"];
                            newRow["item_number2"] = view2[i2]["item_number"];
                            newRow["quantity2"] = view2[i2]["quantity"];
                            newRow["reference_designator2"] = view2[i2]["reference_designator"];
                            i1++;
                            i2++;
                        }
                        table.Rows.Add(newRow);
                    }
                }
                else
                {
                    foreach (DataRowView row in Data1.DefaultView)
                    {
                        DataRow newRow = table.NewRow();
                        newRow["id1"] = row["id"]; 
                        newRow["action1"] = row["action"];
                        newRow["level1"] = row["level"];
                        newRow["item_number1"] = row["item_number"];
                        newRow["quantity1"] = row["quantity"];
                        newRow["reference_designator1"] = row["reference_designator"];
                        table.Rows.Add(newRow);
                    }
                }
            }
            else if (Data2 != null)
            {
                foreach (DataRowView row in Data2.DefaultView)
                {
                    DataRow newRow = table.NewRow();
                    newRow["id2"] = row["id"];
                    newRow["action2"] = row["action"];
                    newRow["level2"] = row["level"];
                    newRow["item_number2"] = row["item_number"];
                    newRow["quantity2"] = row["quantity"];
                    newRow["reference_designator2"] = row["reference_designator"];
                    table.Rows.Add(newRow);
                }
            }
            dataGridView1.DataSource = table;
        }

        private void MarkExcel(string path, List<MarkInfo> marks)
        {
            if (marks.Count == 0) return;
            using (XLWorkbook wb = new XLWorkbook(path))
            {
                var workshee = wb.Worksheets.First();
                foreach (MarkInfo mark in marks)
                {
                    if (mark.ColId < 0)
                    {
                        workshee.Row(mark.RowId).Style.Fill.SetBackgroundColor(mark.Color);
                    }
                    else
                    {
                        workshee.Cell(mark.RowId,mark.ColId).Style.Fill.SetBackgroundColor(mark.Color);
                    }
                }
                wb.Save();
            }
        }

        private void filePanel1_FileSelected(object sender, EventArgs e)
        {
            try
            {
                Data1 = LoadExcel(filePanel1.FilePath, ref _ColumnMap1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                filePanel1.ClearSelected();
                Data1 = null;
            }
        }

        private void filePanel2_FileSelected(object sender, EventArgs e)
        {
            try
            {
                Data2 = LoadExcel(filePanel2.FilePath, ref _ColumnMap2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                filePanel2.ClearSelected();
                Data2 = null;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Logs = "";
            Mark1.Clear();
            Mark2.Clear();
            panel1.Visible = false;
            if (Data1 != null)
            {
                if (Data2 != null)
                {
                    int diff = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string number1 = row.Cells["grid_item_number1"].Value.ToString();
                        string number2 = row.Cells["grid_item_number2"].Value.ToString();
                        if (string.IsNullOrWhiteSpace(number1))
                        {
                            row.Cells["grid_action1"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_level1"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_item_number1"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_quantity1"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_reference_designator1"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_action2"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_level2"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_item_number2"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_quantity2"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_reference_designator2"].Style.BackColor = Color.Yellow;
                            Logs += $"{number2}: Record in [{filePanel2.FileName}] / not in [{filePanel1.FileName}]\r\n";
                            Mark2.Add(new MarkInfo(Convert.ToInt32( row.Cells["grid_id2"].Value),-1, XLColor.Yellow));
                            diff++;
                            continue;
                        }
                        else if (string.IsNullOrWhiteSpace(number2))
                        {
                            row.Cells["grid_action1"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_level1"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_item_number1"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_quantity1"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_reference_designator1"].Style.BackColor = Color.Yellow;
                            row.Cells["grid_action2"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_level2"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_item_number2"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_quantity2"].Style.BackColor = SystemColors.AppWorkspace;
                            row.Cells["grid_reference_designator2"].Style.BackColor = SystemColors.AppWorkspace;
                            Logs += $"{number1}: Record in [{filePanel1.FileName}] / not in [{filePanel2.FileName}]\r\n";
                            Mark1.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id1"].Value),-1, XLColor.Yellow));
                            diff++;
                            continue;
                        }
                        else
                        {
                            string action1 = row.Cells["grid_action1"].Value.ToString();
                            string level1 = row.Cells["grid_level1"].Value.ToString();
                            string quantity1 = row.Cells["grid_quantity1"].Value.ToString();
                            string reference_designator1 = row.Cells["grid_reference_designator1"].Value.ToString();
                            string action2 = row.Cells["grid_action2"].Value.ToString();
                            string level2 = row.Cells["grid_level2"].Value.ToString();
                            string quantity2 = row.Cells["grid_quantity2"].Value.ToString();
                            string reference_designator2 = row.Cells["grid_reference_designator2"].Value.ToString();
                            if (action1 != action2)
                            {
                                row.Cells["grid_action1"].Style.BackColor = Color.Pink;
                                row.Cells["grid_action2"].Style.BackColor = Color.Pink;
                                Logs += $"{number1}:Action: \"{action1}\" in [{filePanel1.FileName}] / \"{action2}\" in [{filePanel2.FileName}]\r\n";
                                Mark1.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id1"].Value),_ColumnMap1["action"], XLColor.Pink));
                                Mark2.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id2"].Value), _ColumnMap2["action"], XLColor.Pink));
                                diff++;
                            }
                            if (level1 != level2)
                            {
                                row.Cells["grid_level1"].Style.BackColor = Color.Pink;
                                row.Cells["grid_level2"].Style.BackColor = Color.Pink;
                                Logs += $"{number1}:Level: \"{level1}\" in [{filePanel1.FileName}] / \"{level2}\" in [{filePanel2.FileName}]\r\n";
                                Mark1.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id1"].Value), _ColumnMap1["level"], XLColor.Pink));
                                Mark2.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id2"].Value), _ColumnMap2["level"], XLColor.Pink));
                                diff++;
                            }
                            if (quantity1 != quantity2)
                            {
                                row.Cells["grid_quantity1"].Style.BackColor = Color.Pink;
                                row.Cells["grid_quantity2"].Style.BackColor = Color.Pink;
                                Logs += $"{number1}:Quantity: \"{grid_quantity1}\" in [{filePanel1.FileName}] / \"{grid_quantity2}\" in [{filePanel2.FileName}]\r\n";
                                Mark1.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id1"].Value), _ColumnMap1["quantity"], XLColor.Pink));
                                Mark2.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id2"].Value), _ColumnMap2["quantity"], XLColor.Pink)); 
                                diff++;
                            }
                            if (reference_designator1 != reference_designator2)
                            {
                                row.Cells["grid_reference_designator1"].Style.BackColor = Color.Pink;
                                row.Cells["grid_reference_designator2"].Style.BackColor = Color.Pink;
                                Logs += $"{number1}:Reference_designator: \"{reference_designator1}\" in [{filePanel1.FileName}] / \"{reference_designator2}\" in [{filePanel2.FileName}]\r\n";
                                Mark1.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id1"].Value), _ColumnMap1["reference_designator"], XLColor.Pink));
                                Mark2.Add(new MarkInfo(Convert.ToInt32(row.Cells["grid_id2"].Value), _ColumnMap2["reference_designator"], XLColor.Pink));
                                diff++;
                            }
                        }
                    }
                    if (diff == 0)
                    {
                        label3.Text = "Completely same";
                        label3.ForeColor = Color.Blue;
                        inkExportLog.Enabled = inkMarkExcel.Enabled = false;
                    }
                    else
                    {
                        label3.Text = $"{diff} differences";
                        label3.ForeColor = Color.Red;
                        inkExportLog.Enabled = inkMarkExcel.Enabled = true;
                    }
                    panel1.Visible = true;
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells["grid_action2"].Style.BackColor = SystemColors.AppWorkspace;
                        row.Cells["grid_level2"].Style.BackColor = SystemColors.AppWorkspace;
                        row.Cells["grid_item_number2"].Style.BackColor = SystemColors.AppWorkspace;
                        row.Cells["grid_quantity2"].Style.BackColor = SystemColors.AppWorkspace;
                        row.Cells["grid_reference_designator2"].Style.BackColor = SystemColors.AppWorkspace;
                    }
                }
            }
            else if (Data2 != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["grid_action1"].Style.BackColor = SystemColors.AppWorkspace;
                    row.Cells["grid_level1"].Style.BackColor = SystemColors.AppWorkspace;
                    row.Cells["grid_item_number1"].Style.BackColor = SystemColors.AppWorkspace;
                    row.Cells["grid_quantity1"].Style.BackColor = SystemColors.AppWorkspace;
                    row.Cells["grid_reference_designator1"].Style.BackColor = SystemColors.AppWorkspace;
                }
            }
        }

        private void inkExportLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName1 = Path.GetFileNameWithoutExtension(filePanel1.FileName);
            string fileName2 = Path.GetFileNameWithoutExtension(filePanel2.FileName);
            string logFileName = $"Log_{fileName1}_{fileName2}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.txt";
            File.WriteAllText(logFileName, Logs);
            Process notePad = new Process();
            notePad.StartInfo.FileName = "notepad.exe";
            notePad.StartInfo.Arguments = Path.Combine(Application.StartupPath, logFileName);
            notePad.Start();
        }

        private void lnkClear1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            filePanel1.ClearSelected();
            Data1 = null;
        }

        private void lnkClear2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            filePanel2.ClearSelected();
            Data2 = null;
        }

        private void inkMarkExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                MarkExcel(filePanel1.FilePath, Mark1);
                MarkExcel(filePanel2.FilePath, Mark2);
                MessageBox.Show("Mark excel done.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private class MarkInfo
        {
            public int RowId { get; set; }
            public int ColId { get; set; }
            public XLColor Color { get; set; }

            public MarkInfo(int rowId, int colId, XLColor color)
            {
                RowId = rowId;
                ColId = colId;
                Color = color;
            }
        }
    }
}
