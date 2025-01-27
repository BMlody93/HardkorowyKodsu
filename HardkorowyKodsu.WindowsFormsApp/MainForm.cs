using HardkorowyKodsu.WebApi.CommonModel.Structures;
using HardkorowyKodsu.WebApiClient;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace HardkorowyKodsu.WindowsFormsApp
{
    public partial class MainForm : Form
    {
        private DatabaseStructureApiClient _databaseStructureApiClient;
        public MainForm()
        {
            try
            {
                Log.Information("Initializing Components");
                InitializeComponent();

                string apiUri = Program.Configuration["AppSettings:ApiUri"];
                Log.Debug("AppSettings:ApiUri [{ApiUri}]", apiUri);

                Log.Debug("Initializing DatabaseStructureApiClient");
                _databaseStructureApiClient = new DatabaseStructureApiClient(apiUri);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Fatal error when initializing Windows Form");
                MessageBox.Show($"Error when starting an app. {ex.Message}", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}

        private async Task PopulateDatabaseStructureGridViewAsync()
        {
            // Get database structure from web api
            var databaseStructure = await _databaseStructureApiClient.GetDatabaseStructureAsync();
            if (databaseStructure != null && databaseStructure.NamesType != null && databaseStructure.NamesType.Count != 0)
            {
                // Parse database structure and set it as data source for grid view
                var data = databaseStructure.NamesType.Select(kv => new { Key = kv.Key, Value = kv.Value }).ToList();
                databaseStructureGridView.DataSource = data;

                databaseStructureGridView.Columns[0].HeaderText = "Table Name";
                databaseStructureGridView.Columns[1].HeaderText = "Table Type";

                databaseStructureGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Database has no tables");
            }
        }

        private async void DatabaseStructureGridView_ClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Log.Information("Populating table structure grid view");

                // Check if the click was on a valid row (not header row)
                if (e.RowIndex >= 0)
                {
                    // Access data from the clicked row
                    var row = databaseStructureGridView.Rows[e.RowIndex];
                    var tableName = databaseStructureGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

                    // Get table structure from  web api
                    var tableStructure = await _databaseStructureApiClient.GetTableStructureAsync(tableName);

                    if (tableStructure != null && tableStructure.Columns != null && tableStructure.Columns.Count != 0)
                    {
                        // Parse table structure and set it as data source for grid view
                        var data = tableStructure.Columns.Select(kv => new { Key = kv.Key, Value = kv.Value }).ToList();
                        tableStructureGridView.DataSource = data;

                        tableStructureGridView.Columns[0].HeaderText = "Column Name";
                        tableStructureGridView.Columns[1].HeaderText = "Column Type";

                        tableStructureGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Table has no rows");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error when populating table structure grid view");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void GetTablesButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                Log.Information("Populating database structure grid view");
                await PopulateDatabaseStructureGridViewAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error when populating database structure grid view");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
