using System;
using System.Windows.Forms;

namespace EC_Components_Database__Refactor_
{
    public partial class FormAddColumn : Form
    {
        public FormAddColumn()
        {
            InitializeComponent();

            SetTypeComboBoxItems();
        }

        private void SetTypeComboBoxItems()
        {
            this.cmbDataType.Items.Clear();

            foreach (object dataType in Enum.GetValues(typeof(ColumnDataType)))
            {
                this.cmbDataType.Items.Add(dataType.ToString());
            }

            if (this.cmbDataType.Items.Count > 0)
            {
                this.cmbDataType.SelectedIndex = 0; // Selects the first item automatically
            }
        }

        private void FormAddColumn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && e.Modifiers == Keys.None)
            {
                this.DialogResult = DialogResult.Cancel;

                Close();
            }
        }

        public string ColumnTitle => this.txtColumnHeading.Text;

        public ColumnDataType SelectedDataType => (ColumnDataType)this.cmbDataType.SelectedIndex;

        public enum ColumnDataType : byte
        {
            Text,
            Integer,
            Decimal,
            DateAndTime,
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public static class ColumnDataTypeExtensions
    {
        public static Type ToType(this FormAddColumn.ColumnDataType cdt)
        {
            switch (cdt)
            {
                case FormAddColumn.ColumnDataType.Text:
                    return typeof(string);
                case FormAddColumn.ColumnDataType.Integer:
                    return typeof(int);
                case FormAddColumn.ColumnDataType.Decimal:
                    return typeof(double);
                case FormAddColumn.ColumnDataType.DateAndTime:
                    return typeof(double);
                default:
                    throw new ArgumentOutOfRangeException(nameof(cdt), cdt, null);
            }
        }
    }
}
