
namespace HardkorowyKodsu.WindowsFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            GetTablesButton = new Button();
            databaseStructureGridView = new DataGridView();
            tableStructureGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)databaseStructureGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tableStructureGridView).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(GetTablesButton);
            splitContainer1.Panel1.Controls.Add(databaseStructureGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableStructureGridView);
            splitContainer1.Size = new Size(784, 444);
            splitContainer1.SplitterDistance = 371;
            splitContainer1.TabIndex = 0;
            // 
            // GetTablesButton
            // 
            GetTablesButton.Location = new Point(12, 12);
            GetTablesButton.Name = "GetTablesButton";
            GetTablesButton.Size = new Size(75, 23);
            GetTablesButton.TabIndex = 1;
            GetTablesButton.Text = "Get Tables";
            GetTablesButton.UseVisualStyleBackColor = true;
            GetTablesButton.Click += GetTablesButton_ClickAsync;
            // 
            // databaseStructureGridView
            // 
            databaseStructureGridView.AllowUserToAddRows = false;
            databaseStructureGridView.AllowUserToDeleteRows = false;
            databaseStructureGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            databaseStructureGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            databaseStructureGridView.Location = new Point(12, 42);
            databaseStructureGridView.MultiSelect = false;
            databaseStructureGridView.Name = "databaseStructureGridView";
            databaseStructureGridView.ReadOnly = true;
            databaseStructureGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            databaseStructureGridView.Size = new Size(356, 390);
            databaseStructureGridView.TabIndex = 0;
            databaseStructureGridView.CellClick += DatabaseStructureGridView_ClickAsync;
            // 
            // tableStructureGridView
            // 
            tableStructureGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableStructureGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableStructureGridView.Location = new Point(3, 12);
            tableStructureGridView.MultiSelect = false;
            tableStructureGridView.Name = "tableStructureGridView";
            tableStructureGridView.Size = new Size(394, 420);
            tableStructureGridView.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 444);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(400, 300);
            Name = "MainForm";
            Text = "HardkorowyKodsu";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)databaseStructureGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)tableStructureGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView databaseStructureGridView;
        private DataGridView tableStructureGridView;
        private Button GetTablesButton;
    }
}
