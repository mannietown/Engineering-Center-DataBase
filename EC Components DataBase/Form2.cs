using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace EC_Components_DataBase
{
    public partial class Form2 : Form
    {
        public Form1 form1 = new Form1();
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        public static bool NAT1isEnabled = false;//Newly Added Text box: is set to true when the text box has been added, this will set the enabled property
        public static bool NAT2isEnabled = false;
        public static bool NAT3isEnabled = false;

        private void Form2_Load(object sender, EventArgs e)
        {
            //Makes the text boxes visible based on the number of columns added            
            #region
            if (NAT1isEnabled)
            {
                txt_NACP1.Visible = true;
                lab_NACP1.Text = MainTableProperties.AddedColumnNames[0];
            }
            else
            {
                txt_NACP1.Visible = false;
                lab_NACP1.Visible = false;
            }

            if (NAT2isEnabled)
            {
                txt_NACP2.Visible = true;
                lab_NACP2.Text = MainTableProperties.AddedColumnNames[1];
            }
            else
            {
                txt_NACP2.Visible = false;
                lab_NACP2.Visible = false;

            }

            if (NAT3isEnabled)
            {
                txt_NACP3.Visible = true;
                lab_NACP3.Text = MainTableProperties.AddedColumnNames[2];
            }
            else
            {
                txt_NACP3.Visible = false;
                lab_NACP3.Visible = false;
            }
            #endregion
            //Name of label associated with texbox is set to the name of the newly added column

            //Bind combo boxes with text boxes
            #region
            BindingSource bsComponents = new BindingSource();
            bsComponents.DataSource = cb_CT;
            BindingSource bsValues = new BindingSource();
            bsValues.DataSource = cb_V;
            txt_CT.DataBindings.Add("Text", bsComponents, "Text");
            txt_V.DataBindings.Add("Text", bsValues, "Text");
            //set the dataSources of the combo boxes to the ManageInputClass
            cb_CT.DataSource = ManageInputs.ComponentNames.GetKeyList();           
            cb_CT.SelectedIndex = -1;
            cb_V.SelectedIndex = -1;
            //This will allow for selected text in the combo boxto be displayed in the text box           

            #endregion
            //upon loadidng of the form, the combobox list is populated. The source list is static
            // so that the form does not need to be closed but the added components will exist until the users saves via form1

        }

        private void btn_AddComponent_Click(object sender, EventArgs e)
        {
            //sets the values in the ECDataGridView Class to the text box texts in this form
            ECDataGridViewClass EC = new ECDataGridViewClass();
            ECDataGridViewClass.PartNo = txt_PN.Text;
            ECDataGridViewClass.ManufacturerNo = txt_MN.Text;
            ECDataGridViewClass.ComponentType = txt_CT.Text;
            ECDataGridViewClass.Package = txt_P.Text;
            ECDataGridViewClass.Value = txt_V.Text;
            ECDataGridViewClass.UnitPrice = txt_UP.Text;
            try
            {
                ECDataGridViewClass.Stock = int.Parse(txt_S.Text.ToString());
            }
            catch (FormatException)
            {
                ECDataGridViewClass.Stock = 0;
            }
            
            ECDataGridViewClass.NACP1 = txt_NACP1.Text;
            ECDataGridViewClass.NACP2 = txt_NACP2.Text;
            ECDataGridViewClass.NACP3 = txt_NACP3.Text;
            //

            //Sets the component names and values in the ManageInputs class
            ManageInputs M = new ManageInputs();
            M.AddComponentToList(txt_CT.Text, txt_V);
            //The lists set by this method will be used to populate combobox

            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //This event will Add components to the Buffer dataTAble in the main form(form1)
            ECDataGridViewClass ECD = new ECDataGridViewClass();
            ECD.AddRow(form1.AllComponentsDTBuffer);
            
        }

       
        private void cb_CT_TextChanged(object sender, EventArgs e)
        {

            txt_CT_TextChanged(sender, e);
        }

        private void txt_CT_TextChanged(object sender, EventArgs e)
        {
            ManageInputs M = new ManageInputs();
            if (txt_CT.Text != "" || txt_CT.Text != null)
            {
                string text = txt_CT.Text;
                M.AccesSpecificComponentValue(txt_CT.Text, cb_V);
            }

            if(txt_CT.Text == string.Empty)
            {//if text is deleted, the value combo box should also be be empty as it has no dataSource
                cb_V.DataSource = null;
            }
        }
    }

    public class ManageInputs
    {
        //Keeps and updates the info already added by the user such as Component names and its values
        //Also ensures the entry format for components is always correct
        public static SortedList ComponentNames = new SortedList();        
        public static int componentIndex = 0;//the index of the current component displayed in the component text box

        public void AddComponentToList(string ComponentName, TextBox Value)
        {
            int NumOfEqualKeys = 0;
            foreach(object o in ComponentNames.GetKeyList())
            {
                if(o.ToString() == ComponentName)
                {
                    NumOfEqualKeys++;  //will always be 1 as it breaks after a truth outcome                  
                    break;//if found already, ther is not need to iterate through the others
                }
            }

            if (NumOfEqualKeys > 0)
            {
                //if a entry already exists, append to its Value the contents of the value text box
                int index = ComponentNames.IndexOfKey(ComponentName);
                string value = ComponentNames[ComponentName].ToString();
                ComponentNames.SetByIndex(index,value + " " + Value.Text);
            }
            else
            {
                //if new component then add to the list
                ComponentNames.Add(ComponentName, Value.Text);
            }

        }

         

        //to be called in the text changed event of the textbox
        //call this event in the combo Box text changed event
        public void AccesSpecificComponentValue(string S,ComboBox CB)
        {
            foreach(object s  in ComponentNames.Keys)
            {//this code does not exist in the combo box text changed  event
                if (s.ToString() == S)
                {
                    CB.DataSource = ComponentNames[S].ToString().Split(' ');
                }
            }
           
        }
    }
}
