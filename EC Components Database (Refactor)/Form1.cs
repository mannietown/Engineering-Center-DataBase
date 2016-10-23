using System.Windows.Forms;

namespace EC_Components_Database__Refactor_
{
    public partial class Form1 : Form
    {
        private DatabaseIO MyDatabase { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.MyDatabase = new DatabaseIO();

            this.dgvECComponents.DataSource = this.MyDatabase.MyDataTable;
        }

        private void dgvECComponents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.cmsColumnHeader.Show(Cursor.Position);
            }
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.MyDatabase = new DatabaseIO();

            this.dgvECComponents.DataSource = this.MyDatabase.MyDataTable;

            this.saveToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.ofdOpenDatabase.ShowDialog() == DialogResult.OK)
            {
                this.MyDatabase = new DatabaseIO(this.ofdOpenDatabase.FileName);

                this.dgvECComponents.DataSource = this.MyDatabase.MyDataTable;

                this.saveToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.MyDatabase.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.sfdSaveDatabase.ShowDialog() == DialogResult.OK)
            {
                this.MyDatabase.SaveAs(this.sfdSaveDatabase.FileName);

                this.saveToolStripMenuItem.Enabled = true;
            }
        }

        private void addColumnToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FormAddColumn addColumnDialog = new FormAddColumn();

            if (addColumnDialog.ShowDialog() == DialogResult.OK)
            {
                this.MyDatabase.MyDataTable.Columns.Add(
                    addColumnDialog.ColumnTitle,
                    addColumnDialog.SelectedDataType.ToType());
            }
        }
    }
}
