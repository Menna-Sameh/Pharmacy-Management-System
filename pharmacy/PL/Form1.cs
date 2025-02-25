using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using System.Data;

namespace pharmacy
{
    public partial class Form1 : Form
    {
        private string selectedFilePath;

        public DataTable ImportedData { get; set; } = new DataTable();

        private static readonly Dictionary<string, List<string>> ValidClasses = new Dictionary<string, List<string>>
        {
            { "Customers", new List<string> { "ID", "Name", "Address", "Phone" } },
            { "Employees", new List<string> { "ID", "Name", "HireDate", "Salary" } },
            { "Medicines", new List<string> { "ID", "Name", "Quantity", "Type", "Price" } },
            { "Orders", new List<string> { "ID", "OrderDate", "Status", "CustomerId", "TotalAmount", "EmployeeId" } },
            { "OrderMedicines", new List<string> { "OrderId", "MedicineId", "Quantity" } },
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(new FileInfo(selectedFilePath)))
                    {
                        comboBox1.Items.Clear();
                        foreach (var sheet in package.Workbook.Worksheets)
                        {
                            comboBox1.Items.Add(sheet.Name);
                        }
                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath)) return;
            string sheetName = comboBox1.SelectedItem.ToString();
            ImportedData = ReadExcelToDataTable(selectedFilePath, sheetName);
            if (ValidateSheetColumns(ImportedData))
            {
                dataGridView1.DataSource = ImportedData;
            }
            else
            {
                MessageBox.Show("The sheet does not match the expected structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            //{
            string tableName = comboBox1.SelectedItem.ToString();
            if (ValidClasses != null && !ValidClasses.ContainsKey(tableName))
            {
                MessageBox.Show("Table name does not match expected database tables.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection("Server=.;Database=Pharmacy;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"))
            {
                conn.Open();
                foreach (DataRow row in ImportedData.Rows)
                {
                    // Exclude the identity column (e.g., "ID") from the insert
                    List<string> columnNames = ValidClasses[tableName]
                        .Where(col => ImportedData.Columns.Contains(col) && col != "ID") // Exclude "ID"
                        .ToList();

                    string columns = string.Join(", ", columnNames);
                    string values = string.Join(", ", columnNames.Select((col, index) => $"@value{index}"));

                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        for (int i = 0; i < columnNames.Count; i++)
                        {
                            cmd.Parameters.AddWithValue($"@value{i}", row[columnNames[i]] ?? DBNull.Value);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Data successfully saved to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            // this.Close();
        }



        private static DataTable ReadExcelToDataTable(string filePath, string sheetName)
        {
            DataTable dt = new DataTable();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var sheet = package.Workbook.Worksheets[sheetName];
                if (sheet == null)
                {
                    MessageBox.Show("Sheet not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return dt;
                }

                for (int col = 1; col <= sheet.Dimension.End.Column; col++)
                {
                    dt.Columns.Add(sheet.Cells[1, col].Text);
                }

                for (int row = 2; row <= sheet.Dimension.End.Row; row++)
                {
                    DataRow dr = dt.NewRow();
                    for (int col = 1; col <= sheet.Dimension.End.Column; col++)
                    {
                        dr[col - 1] = sheet.Cells[row, col].Text;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private bool ValidateSheetColumns(DataTable dt)
        {
            if (dt == null || dt.Columns.Count == 0) return false;

            string tableName = comboBox1.SelectedItem.ToString();
            if (!ValidClasses.ContainsKey(tableName)) return false;

            List<string> expectedColumns = ValidClasses[tableName];

            return expectedColumns.All(col => dt.Columns.Contains(col));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}