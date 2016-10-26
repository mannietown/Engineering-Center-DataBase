using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;


namespace EC_Components_DataBase
{

    public partial class Form1 : Form
    {

        public static DataTable AllComponentsDT = new DataTable();//DT = dataTAble. Houses all the components, this dataTable is serialized and deserialized to
        public DataTable AllComponentsDTBuffer = new DataTable();//Changes before they are saved are made to this table, if changes abandoned, main data table is unaffected
        //Link Attachment for digikey product
        public string DigiKeyLink = "http://www.digikey.com/product-search/en?keywords=";


        public Form1()
        {
            InitializeComponent();

        }

        //public instances of controls that will nowbe accesible to other classes
        public static DataGridView dataGRid = new DataGridView();
        public ComboBox comboBox = new ComboBox();

        //indicates whether form3 is loaded by projet click
        public static bool Form3FromProjectsList = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.MaximizeBox = false;          
            SetColour();
            //upon loading, Create the directories if they dont exist
            FileIO IO = new FileIO();
            IO.CreateFolderPaths();
            dataGRid = dataGridView1;

            //Deserializes the DataTable to both the allcomponents table and its buffer
            IO.LoadDataTable(AllComponentsDT, AllComponentsDTBuffer, dataGridView1);

            AllComponentsDT = (DataTable)dataGridView1.DataSource;
            AllComponentsDTBuffer = (DataTable)dataGridView1.DataSource;
            //Gets the Compotent Type columns elements, adds to an array and sets the combo box value to them
            List<string> ComponentTypeList = new List<string>();
            ComponentTypeList.Add("All Components");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (ComponentTypeList.Contains(dataGridView1.Rows[i].Cells[2].Value.ToString()))
                {
                    continue;
                }
                else
                {
                    ComponentTypeList.Add(dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
            }

            comboBox1.DataSource = ComponentTypeList;
            comboBox = comboBox1;
            //this is for when the form is loaded only

            //Load the components of the dataGridView1 to the components(Filtering Strcture) class
            Components C = new Components();
            C.InitializeComponents((DataTable)dataGridView1.DataSource);

            //Sets the ProjectsToolStripItem to DropDown With the Created Projects Names
            SetProjectsList(sender, e);
            //Adds and Event To the CreatedProjects Names
            for (int i = 0; i < projectsToolStripMenuItem.DropDownItems.Count; i++)
            {
                ToolStripMenuItem Item = (ToolStripMenuItem)projectsToolStripMenuItem.DropDownItems[i];
                Item.Click += new EventHandler(Item_Click);
            }




        }

        //Opens the Project upon clicking it the ToolStripMenu
        public static string ClickedProject = "";
        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem thisItem = sender as ToolStripMenuItem;
            Form3FromProjectsList = true;
            ClickedProject = thisItem.Text;
            Form3 form3 = new Form3();
            form3.Show();


        }

        //Sets the names of the created Projects into the toolstripmenu
        public void SetProjectsList(object sender, EventArgs e)
        {
            ToolStripDropDownItem ProjectsDropDownItem = projectsToolStripMenuItem;
            foreach (Projects L in Projects.ProjectList)
            {
                ProjectsDropDownItem.DropDownItems.Add(L.ProjectName);
            }
        }

        public void SetColour()
        {
            this.BackColor = Color.LightBlue;
            dataGridView1.BackgroundColor = Color.MintCream;
            toolStrip1.BackColor = Color.Moccasin;

        }

        private void addComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTableProperties M = new MainTableProperties();
            //Sets the bools that will determine if the newly added textboxes are visible or not based
            //on the number of columns that have been added
            switch (MainTableProperties.ColumnsAdded)
            {
                case 1:
                    Form2.NAT1isEnabled = true;//for the first text box(NACP1
                    break;
                case 2:
                    Form2.NAT2isEnabled = true;//for the second(NACP2
                    Form2.NAT1isEnabled = true;//for the first // two will be switched in the case of 2 being added
                    break;
                case 3:
                    Form2.NAT2isEnabled = true;//for the second
                    Form2.NAT1isEnabled = true;//for the first // All three will be switched in the case of 3 columns being added
                    Form2.NAT3isEnabled = true;//for the third(NACP3
                    break;

            }

            Form2 form2 = new Form2(this);
            form2.Show();
        }

        //Event for adding a new column
        private void newColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTableProperties M = new MainTableProperties();
            Components C = new Components();
            M.AddColumn((DataTable)dataGridView1.DataSource);
            //The Static list in Components must be cleared after each addition of a column and a new row, the Initialization
            //Method must be called to reset the list with the new changes
            Components.AllComponentsListBuffer.Clear();
            C.InitializeComponents((DataTable)dataGridView1.DataSource);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGRid = dataGridView1;
        }

        //sets the currently clicked row's index to the ECDataGridViewClass variable
        public static string clickedRowName = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            Form OnForms = Application.OpenForms["Form3"];
            if(OnForms == null)
            {
                try
                {
                    clickedRowName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ECDataGridViewClass.clickedRowGridIndex = e.RowIndex;
                    if (Directory.Exists(FileIO.DataSheetFolderPath + "\\" + clickedRowName))
                    {
                        foreach (string s in Directory.GetFiles(FileIO.DataSheetFolderPath + "\\" + clickedRowName))
                        {
                            string[] fileparts = s.Split('\\');
                            foreach (string splitParts in fileparts[fileparts.Length - 1].Split('.'))
                            {
                                if (splitParts == "jpg")
                                {
                                    try
                                    {
                                        //pictureBox1.ImageLocation = s;
                                        Image image = Image.FromFile(s);
                                        pictureBox1.Image = image;
                                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

                                        string SizeOfImage = "";
                                        for (int i = 0; i < fileparts[fileparts.Length - 1].Split('.').Length - 1; i++)
                                        {
                                            SizeOfImage += fileparts[fileparts.Length - 1].Split('.')[i];
                                        }
                                        txt_ImageSize.Text = SizeOfImage;
                                    }
                                    catch (OutOfMemoryException)
                                    {
                                        MessageBox.Show("The Picture is too big to be loaded");
                                        string SizeOfImage = "";
                                        for (int i = 0; i < fileparts[fileparts.Length - 1].Split('.').Length - 1; i++)
                                        {
                                            SizeOfImage += fileparts[fileparts.Length - 1].Split('.')[i];
                                        }
                                        pictureBox1.Image = null;
                                        txt_ImageSize.Text = SizeOfImage;
                                    }

                                    goto here;

                                }
                            }

                        }


                    }
                    here:;

                }
                catch (NullReferenceException)
                {

                }
                catch (ArgumentOutOfRangeException)
                {

                }

            }else
            {
                ECDataGridViewClass.clickedRowGridIndex = e.RowIndex;
            }




        }

        //sets the currently clicked column's index to the ECDataGridViewClass variable
        public bool ColumnHeaderMouseClickEventOn = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainTableProperties.ClickedColumnGridIndex = e.ColumnIndex;
            ColumnHeaderMouseClickEventOn = true;

        }

        //Saves info to the designated Folders
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileIO IO = new FileIO();
            IO.SaveChanges((DataTable)dataGridView1.DataSource);

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //Sets Volitile DataTable to Sorted List according to text in the combo box

            if (comboBox1.Text == "All Components")
            {
                dataGridView1.DataSource = AllComponentsDTBuffer;
            } else
            {
                Components C = new Components();
                dataGridView1.DataSource = C.SortTable(comboBox1);
            }


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //search method via typing
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {

            if (txt_Search.Text == "" && ColumnHeaderMouseClickEventOn == false)
            {
                comboBox1.Text = "All Components";
                dataGridView1.DataSource = AllComponentsDTBuffer;
            } else if (txt_Search.Text != "" && ColumnHeaderMouseClickEventOn == false)
            {
                DynamicSearch D = new DynamicSearch();
                D.TextChanged += D.Sort1;
                D.TextChanged += D.Sort2;
                D.TextChanged += D.Sort3;
                D.TextChanged += D.Sort4;
                D.TextChanged += D.Sort5;
                D.TextChanged += D.Sort6;
                D.TextChanged += D.Sort7;
                D.TextChanged += D.Sort8; //Subscribe all the sorts to the one event

                D.InvokeDynamicSearch(txt_Search.Text);
                List<DataTable> ListToDisplay = new List<DataTable>();
                ListToDisplay.Add(D.Sort1(txt_Search.Text));
                ListToDisplay.Add(D.Sort2(txt_Search.Text));
                ListToDisplay.Add(D.Sort3(txt_Search.Text));
                ListToDisplay.Add(D.Sort4(txt_Search.Text));
                ListToDisplay.Add(D.Sort5(txt_Search.Text));
                ListToDisplay.Add(D.Sort6(txt_Search.Text));
                ListToDisplay.Add(D.Sort7(txt_Search.Text));
                ListToDisplay.Add(D.Sort8(txt_Search.Text));

                var dataTable = from T in ListToDisplay
                                orderby T.Rows.Count descending
                                select T;

                List<DataTable> SortedDataTableList = new List<DataTable>(dataTable);
                dataGridView1.DataSource = SortedDataTableList[0];
            } else if (txt_Search.Text != "" && ColumnHeaderMouseClickEventOn == true)
            {
                DynamicSearch D = new DynamicSearch();
                dataGridView1.DataSource = D.SortSingleColumn(txt_Search.Text, MainTableProperties.ClickedColumnGridIndex);
            } else if (txt_Search.Text == "" && ColumnHeaderMouseClickEventOn == true)
            {
                dataGridView1.DataSource = AllComponentsDTBuffer;
            }


        }

        //sets ColumnHeaderMouseClickEvent back to false
        private void Form1_Click(object sender, EventArgs e)
        {
            ColumnHeaderMouseClickEventOn = false;
        }

        private void updateComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ECDataGridViewClass EC = new ECDataGridViewClass();
            EC.UpdateRow(AllComponentsDTBuffer, dataGridView1);
            txt_Search.Text = "";
            comboBox1.Text = "All Components";
            Components C = new Components();
            //Set buffer table back to dataGridView Source and theninitializecomponents to ensure changes have been activated
            AllComponentsDTBuffer = (DataTable)dataGridView1.DataSource;
            Components.AllComponentsListBuffer.Clear();
            C.InitializeComponents(AllComponentsDTBuffer);

        }

        private void removeComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ECDataGridViewClass EC = new ECDataGridViewClass();
            EC.RemoveRow(AllComponentsDTBuffer/*(DataTable)dataGridView1.DataSource*/, dataGridView1);
            txt_Search.Text = "";
            comboBox1.Text = "All Components";
            Components C = new Components();
            AllComponentsDTBuffer = (DataTable)dataGridView1.DataSource;
            Components.AllComponentsListBuffer.Clear();
            C.InitializeComponents(AllComponentsDTBuffer);

        }

        private void rowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeComponentToolStripMenuItem_Click(sender, e);
        }

        private void updateRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateComponentToolStripMenuItem_Click(sender, e);
        }

        //Selects the double clicked row and adds to the currentls opened project
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form OnForms = Application.OpenForms["Form3"];
            if (OnForms != null)
            {
                ECDataGridViewClass EC = new ECDataGridViewClass();
                DataGridViewRow clickedRow = dataGridView1.Rows[ECDataGridViewClass.clickedRowGridIndex];
                object[] clickedRowItems = new object[clickedRow.Cells.Count];
                try
                {
                    int quantityToDeduct = int.Parse(Interaction.InputBox("Enter quantity to deduct", "Quantity to deduct", "", -1, -1));
                    for (int i = 0; i < clickedRow.Cells.Count; i++)
                    {
                        if (i == clickedRowItems.Length - 1)
                        {
                            clickedRowItems[i] = quantityToDeduct;
                        } else
                        {
                            clickedRowItems[i] = clickedRow.Cells[i].Value.ToString();
                        }

                    }
                    DataRow DR = Form3.ProjectComponentsDT.NewRow();
                    DR.ItemArray = clickedRowItems;
                    Form3.ProjectComponentsDT.Rows.Add(DR);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Value Entered is in an incorrect format, Please enter an integer");
                }




            }
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            Form OnForms = Application.OpenForms["Form3"];
            form3.Show();

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGRid = dataGridView1;
        }

        //Loads the pdf dataSheet files that have been down loaded from the website, in this case the digikey website
        private void PDFItems_Clicked(object sender, EventArgs e)
        {
            ToolStripMenuItem T = sender as ToolStripMenuItem;
            if (File.Exists(T.Text))
            {
                Process.Start(T.Text);
            }
            else
            {
                MessageBox.Show("FileNot Found");
            }

        }

        //Adds the pdf files to the context menu strip underneath View DataSheets
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            (contextMenuStrip1.Items[4] as ToolStripMenuItem).DropDownItems.Clear();
            if (e.Button == MouseButtons.Right)
            {
                try { 
                    if (Directory.Exists(FileIO.DataSheetFolderPath +"\\"+ dataGRid.Rows[ECDataGridViewClass.clickedRowGridIndex].Cells[0].Value.ToString()))
                    {
                        if (contextMenuStrip1.Items[4].Text == "View Data Sheet" && (contextMenuStrip1.Items[4] as ToolStripMenuItem).DropDownItems.Count == 0)
                        {
                            
                            string[] PDFList = Directory.GetFiles(Path.Combine(FileIO.DataSheetFolderPath,clickedRowName));
                            int count = 0;

                            foreach (string PDF in PDFList)
                            {
                                if (PDF.Split('.').Contains("pdf"))
                                {
                                    (contextMenuStrip1.Items[4] as ToolStripDropDownItem).DropDownItems.Add(PDF);
                                    ToolStripMenuItem T = (contextMenuStrip1.Items[4] as ToolStripMenuItem);
                                   T.DropDownItems[count].Click += new EventHandler(PDFItems_Clicked);
                                    count++;
                                }else
                                {

                                }
                                
                            }
                        }

                    }
                    else
                    {

                        Directory.CreateDirectory(Path.Combine(FileIO.DataSheetFolderPath, dataGridView1.Rows[ECDataGridViewClass.clickedRowGridIndex].Cells[0].Value.ToString()));

                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("This row does not exist");
                }
                
               
            }
        }

        private void goToSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Link = dataGridView1.Rows[ECDataGridViewClass.clickedRowGridIndex].Cells[0].Value.ToString();
            richTextBox1.Text = DigiKeyLink + Link;
            richTextBox1_LinkClicked(sender, new LinkClickedEventArgs(richTextBox1.Text));
        }

        //Loads all the dataSheets for the clicked row
        private void viewDataSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((contextMenuStrip1.Items[4] as ToolStripMenuItem).DropDownItems.Count == 0)
            {
                DialogResult response = MessageBox.Show("There are no datasheets for this components. Download its datasheets?\n DownLoad an image of the component if non exists", "No existing datasheets\n DownLoad an image of the component if non exists", MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {                    
                    Directory.CreateDirectory(FileIO.DataSheetFolderPath + "\\"+dataGridView1.Rows[ECDataGridViewClass.clickedRowGridIndex].Cells[0].Value.ToString());
                    goToSiteToolStripMenuItem_Click(sender, new EventArgs());

                }
            }
        }

        //Activates the hpyerlink
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {           
          Process.Start(e.LinkText);
        }

       
    }


    public class Components//Filtering Structure
    {
        public string PartNo { get; set; }//index 0
        public string ManufacturerNo { get; set; }//index 1
        public string ComponentType { get; set; }//index 2
        public string Package { get; set; }//index 3
        public string Value { get; set; }//index 4
        public string UnitPrice { get; set; }//index 5
        public string NewlyAddedColumnProperty1/*index 6*/ { get; set; }//Excess properties newly added columns, only initilized when
        public string NewlyAddedColumnProperty2/*index7*/ { get; set; }//columns are added, the column indexes which they refer to are
        public string NewlyAddedColumnProperty3/*index 8*/ { get; set; }//pre-determined
        public int Stock { get; set; }//index 9

        enum CellIndex
        {
            PN, MN, CT, P, V, UP, NACP1, NACP2, NACP3, S//Abbreviated form of the properties of this class, each corresponding to the column index
        }

        public static List<Components> AllComponentsListBuffer = new List<Components>();

        public void InitializeComponents(DataTable MainComponentsDT)//DT = DataTable
        {
            MainTableProperties MTP = new MainTableProperties();
            
            try
            {
                for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                {
                    AllComponentsListBuffer.Add(new Components
                    {
                        PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                        ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                        ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                        Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                        Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                        UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                        NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP1].ToString(),
                        NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP2].ToString(),
                        NewlyAddedColumnProperty3 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP3].ToString(),
                        Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.S.ToString())].ToString())

                    });
                }
            }catch(FormatException f)
            {                
                int tempStore = MainTableProperties.ColumnsAdded;
                switch (tempStore)
                {
                    case 1:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP1].ToString(),
                                NewlyAddedColumnProperty2 = "XXXX",
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Columns.Count - 1].ToString())

                            });
                        }

                        break;
                    case 2:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP1].ToString(),
                                NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP2].ToString(),
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Columns.Count - 1].ToString())

                            });
                        }

                        break;
                    case 3:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP1].ToString(),
                                NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP2].ToString(),
                                NewlyAddedColumnProperty3 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP3].ToString(),
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Columns.Count - 1].ToString())

                            });
                        }

                        break;
                    case 0:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 = "XXXX",
                                NewlyAddedColumnProperty2 = "XXXX",
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Columns.Count -1].ToString())

                            });
                        }

                        break;
                        

                }



            
        }
            catch (IndexOutOfRangeException I)
            {
                //Get the current number of newly Added Columns
                int tempStore = MainTableProperties.ColumnsAdded;
                switch (tempStore)
                {
                    case 1:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {                                
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP1].ToString(),
                                NewlyAddedColumnProperty2 = "XXXX",
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Columns.Count - 1].ToString())

                            });
                        }

                        break;
                    case 2:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP1].ToString(),
                                NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP2].ToString(),
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Columns.Count - 1].ToString())

                            });
                        }

                        break;
                    case 0:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 ="XXXX",
                                NewlyAddedColumnProperty2 = "XXXX",
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Columns.Count - 1].ToString())

                            });
                        }

                        break;
                    case 3:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.PN].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.MN].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.CT].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.P].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.V].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.UP].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP1].ToString(),
                                NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP2].ToString(),
                                NewlyAddedColumnProperty3 = MainComponentsDT.Rows[i].ItemArray[(int)CellIndex.NACP3].ToString(),
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[9].ToString())

                            });
                        }

                        break;


                }
            }
            
        }

        public void SortSwitch(List<Components> List, DataTable SortedDT)
        {
            switch (MainTableProperties.ColumnsAdded)
            {
                case 0:
                    for (int i = 0; i < MainTableProperties.FixedColumnNames.Count; i++)
                    {
                        SortedDT.Columns.Add(MainTableProperties.FixedColumnNames[i].ToString());
                    }

                    foreach (Components C in List)
                    {
                        SortedDT.Rows.Add(C.PartNo, C.ManufacturerNo, C.ComponentType, C.Package, C.Value, C.UnitPrice, C.Stock);
                    }

                    break;
                case 1:
                    for (int i = 0; i < MainTableProperties.FixedColumnNames.Count - 1; i++)
                    {
                        SortedDT.Columns.Add(MainTableProperties.FixedColumnNames[i].ToString());
                    }

                    SortedDT.Columns.Add(MainTableProperties.AddedColumnNames[0]);
                    SortedDT.Columns.Add(MainTableProperties.FixedColumnNames[6].ToString());

                    foreach (Components C in List)
                    {
                        SortedDT.Rows.Add(C.PartNo, C.ManufacturerNo, C.ComponentType, C.Package, C.Value, C.UnitPrice, C.NewlyAddedColumnProperty1, C.Stock);
                    }

                    break;
                case 2:
                    for (int i = 0; i < MainTableProperties.FixedColumnNames.Count - 1; i++)
                    {
                        SortedDT.Columns.Add(MainTableProperties.FixedColumnNames[i].ToString());
                    }

                    SortedDT.Columns.Add(MainTableProperties.AddedColumnNames[0]);
                    SortedDT.Columns.Add(MainTableProperties.AddedColumnNames[1]);
                    SortedDT.Columns.Add(MainTableProperties.FixedColumnNames[6].ToString());

                    foreach (Components C in List)
                    {
                        SortedDT.Rows.Add(C.PartNo, C.ManufacturerNo, C.ComponentType, C.Package, C.Value, C.UnitPrice, C.NewlyAddedColumnProperty1, C.NewlyAddedColumnProperty2, C.Stock);
                    }

                    break;
                case 3:
                    for (int i = 0; i < MainTableProperties.FixedColumnNames.Count - 1; i++)
                    {
                        SortedDT.Columns.Add(MainTableProperties.FixedColumnNames[i].ToString());
                    }

                    SortedDT.Columns.Add(MainTableProperties.AddedColumnNames[0]);
                    SortedDT.Columns.Add(MainTableProperties.AddedColumnNames[1]);
                    SortedDT.Columns.Add(MainTableProperties.AddedColumnNames[2]);
                    SortedDT.Columns.Add(MainTableProperties.FixedColumnNames[6].ToString());

                    foreach (Components C in List)
                    {
                        SortedDT.Rows.Add(C.PartNo, C.ManufacturerNo, C.ComponentType, C.Package, C.Value, C.UnitPrice, C.NewlyAddedColumnProperty1, C.NewlyAddedColumnProperty2, C.NewlyAddedColumnProperty3, C.Stock);
                    }

                    break;
            }
        }

        //Sorts the AllComponentsList according to the text in the combobox
        //Based on the number of columns existing, the sort will only set the columns visible
        public DataTable SortTable(ComboBox ComponentTypeCB)
        {
            DataTable SortedDT = new DataTable();
            List<Components> List = new List<Components>();           
            

            var query = from  Components C in AllComponentsListBuffer
                        where C.ComponentType == ComponentTypeCB.Text
                        select C;

            List = new List<Components>(query);

            //Sorts according to the number of columns added
            SortSwitch(List, SortedDT);

           

            return SortedDT;
            

        }
       


    }

    public class MainTableProperties//Store of information and a few methods partaining to the main components
    {
        public Form1 form1 = new Form1();        
        public static string TableInfoFileName = "TableProperties.txt";
        public static string TableInfoFolderName = "TableProperties";
        public static string TableInfoFolderPath = Path.Combine(FileIO.MainFolderpath, TableInfoFolderName);

        public const int MaxColumnsAllowed = 3;
        public static int ColumnsAdded = 0;//this value will be incremented no greater than three
                                           //if so, user will be notified that no more columns can be added
        
        public static bool MaxReached = false;//indicates if the max number of columns have been added

        public static int ClickedColumnGridIndex = 0;

        public static IList FixedColumnNames = new string [7] { "Part Number", "Manufacturer No", "Component Type", "Package", "Value", "Unit Price", "Stock" };
        public static string[] AddedColumnNames = new string[3];

        public static object [] TableInfo = new object[5];//Cotains info to be serialized

        static int countColumnsAddedIndex = 0;
                
        
                                                                
        public void AddColumn(DataTable ATable)
        {
            if (ColumnsAdded < 3)
            {
                ColumnsAdded++;//Increment the columns added by 1

            }
            else
            {
                MaxReached = true;
            }

            if (MaxReached)
            {
                MessageBox.Show("You cannot add anymore columns,the maximum limit of 3 has been reached.");
                return;
            }
            IList<int> LastColumnContents = new int[ATable.Rows.Count];//Store the contents of the Stock Column(last column) before it is removed
            for (int i = 0; i < ATable.Rows.Count; i++)
            {
                //set the contents of the last column(Stock Column) to the lastcolumncontents list
                LastColumnContents[i] = int.Parse(ATable.Rows[i].ItemArray[ATable.Columns.Count -1].ToString());
            }
            //remove the column, this is done such that the last column is always the stock column as it would be added last
            ATable.Columns.RemoveAt(ATable.Columns.Count - 1);
            string UserTypedColumnName = Interaction.InputBox("Enter the column's name...", "Column name", "", -1, -1);//Gets the user typed column name
            AddedColumnNames[countColumnsAddedIndex] = UserTypedColumnName;//Store the names of the added column
            countColumnsAddedIndex++;

           

            ATable.Columns.Add(UserTypedColumnName);//Add new use column before the stock
            ATable.Columns.Add("Stock");//Add stock column and set back the data from the list
            for (int i = 0; i < ATable.Rows.Count; i++)
            {
                ATable.Rows[i].SetField<int>(ATable.Columns.Count - 1, LastColumnContents[i]);
               
            }
            
            
        }

        public void SaveTableInfo()
        {
            //the first and last indexes are designated for columns added count adn max columns reached count
            TableInfo[0] = ColumnsAdded;           
            TableInfo[1] = AddedColumnNames[0];
            TableInfo[2] = AddedColumnNames[1];
            TableInfo[3] = AddedColumnNames[2];
            TableInfo[4]=MaxReached;

            if (!File.Exists(Path.Combine(TableInfoFolderPath,TableInfoFileName)))
            {
                using (File.Create(Path.Combine(TableInfoFolderPath, TableInfoFileName))) ;
                using (FileStream fs = new FileStream(Path.Combine(TableInfoFolderPath, TableInfoFileName), FileMode.Open, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, TableInfo);
                }
                
            } else
            {
                using (FileStream fs = new FileStream(Path.Combine(TableInfoFolderPath, TableInfoFileName), FileMode.Open, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, TableInfo);
                }
            }
            
        }
        //Load properties of the table back into the table when form is laoded only
        //since table is static, during the operation of the program its values will remain and can be used by other objects
        //no need for recall during runtime
        public void LoadTableInfo()
        {
            if (File.Exists(Path.Combine(TableInfoFolderPath,TableInfoFileName)))
            {
                using (FileStream fs = new FileStream(Path.Combine(TableInfoFolderPath, TableInfoFileName), FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    TableInfo = (object[])bf.Deserialize(fs);
                }

                MaxReached = (bool)TableInfo[4];                
                ColumnsAdded = countColumnsAddedIndex = (int)TableInfo[0];

                if (ColumnsAdded >= 3)
                {
                    MaxReached = true;
                }
                for(int i = 0; i < AddedColumnNames.Length; i++)
                {
                    try
                    {
                        AddedColumnNames[i] = TableInfo[i + 1].ToString();
                    }
                    catch (NullReferenceException)
                    {
                        AddedColumnNames[i] = string.Empty;
                    }
                   
                }
            }
            else
            {
                //if file does not exis do nothing
            }
        }
        
    }

    public class ECDataGridViewClass//Contains methods to edit DataGridView
    {
        //Cell Click event will set these variables with the cell values
        //Add component button from form2 will set these, then the close event will set them to a dataGridView
        public static string PartNo = "";
        public static string ManufacturerNo = "";
        public static string ComponentType = "";
        public static string Package = "";
        public static string Value= "";
        public static string UnitPrice = "";
        public static int Stock = 0;
        public static object NACP1 = null;
        public static object NACP2 = null;
        public static object NACP3 = null;

        public static int clickedRowGridIndex = 0;
        public static int clickedRowTableIndex = 0;

        public void AddRow(DataTable ATable)
        {
            //Based on the number of columns added, a case will allow the corresponding amount of row elements to be Added
            switch (MainTableProperties.ColumnsAdded)
            {
               
                case 1:
                    try
                    {
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, NACP1, Stock);
                    }catch (FormatException)
                    {
                        Stock = 0;
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, NACP1, Stock);

                    }
                    
                    break;
                case 2:
                    try
                    {//includes the second excess property
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, NACP1, NACP2, Stock);
                    }catch(FormatException)
                    {
                        Stock = 0;
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, NACP1, NACP2, Stock);
                    }
                    
                    break;
                case 3:
                    try
                    {//includes the third excess property
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, NACP1, NACP2, NACP3, Stock);
                    }catch(FormatException)
                    {
                        Stock = 0;
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, NACP1, NACP2, NACP3, Stock);
                    }
                   
                    break;
                default://Default is when no columns have been added
                    try
                    {//Adds noExcess property
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, Stock);
                    }
            
                    catch (FormatException)
                    {
                        //the format exception is in case the stock amount is not known
                        Stock = 0;
                        ATable.Rows.Add(PartNo, ManufacturerNo, ComponentType, Package, Value, UnitPrice, Stock);
                    }
                    
                    break;
            }
        }

        public void RemoveRow(DataTable ATable, DataGridView dataGridView1)
        {
            DataGridViewRow ClickedRow = dataGridView1.Rows[clickedRowGridIndex];
            DataRow R = ATable.NewRow();
            string[] RowCellValues = new string[ClickedRow.Cells.Count];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {

                RowCellValues[i] = dataGridView1.Rows[clickedRowGridIndex].Cells[i].Value.ToString();

            }

            R.ItemArray = RowCellValues;

            switch (MainTableProperties.ColumnsAdded)
            {
                case 0:
                    for(int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if(R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString())
                        {
                            ATable.Rows.RemoveAt(i);
                            if (dataGridView1.Rows.Count-1  != ATable.Rows.Count)
                            {
                                dataGridView1.Rows.RemoveAt(clickedRowGridIndex);
                            }
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if (R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString() &&
                            R.ItemArray[7].ToString() == ATable.Rows[i].ItemArray[7].ToString())
                        {
                            ATable.Rows.RemoveAt(i);
                            if (dataGridView1.Rows.Count-1  != ATable.Rows.Count)
                            {
                                dataGridView1.Rows.RemoveAt(clickedRowGridIndex);
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if (R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString() &&
                            R.ItemArray[7].ToString() == ATable.Rows[i].ItemArray[7].ToString() &&
                            R.ItemArray[8].ToString() == ATable.Rows[i].ItemArray[8].ToString())
                        {
                            ATable.Rows.RemoveAt(i);
                            if(dataGridView1.Rows.Count -1 != ATable.Rows.Count)
                            {
                                dataGridView1.Rows.RemoveAt(clickedRowGridIndex);
                            }
                           
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if (R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString() &&
                            R.ItemArray[7].ToString() == ATable.Rows[i].ItemArray[7].ToString() &&
                            R.ItemArray[8].ToString() == ATable.Rows[i].ItemArray[8].ToString() &&
                            R.ItemArray[9].ToString() == ATable.Rows[i].ItemArray[9].ToString())
                        {
                            ATable.Rows.RemoveAt(i);
                            if (dataGridView1.Rows.Count-1!= ATable.Rows.Count)
                            {
                                dataGridView1.Rows.RemoveAt(clickedRowGridIndex);
                            }
                        }
                        
                    }
                    break;
            }

        }    

        public void UpdateRow(DataTable ATable, DataGridView dataGridView1)
        {
            //Similar to remove but instead or removing the row at the index where found
            //it will be rewritten using Interaction.InputBox
            DataGridViewRow ClickedRow = dataGridView1.Rows[clickedRowGridIndex];
            DataRow R = ATable.NewRow();
            string[] RowCellValues = new string[ClickedRow.Cells.Count];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {

                RowCellValues[i] = dataGridView1.Rows[clickedRowGridIndex].Cells[i].Value.ToString();

            }

            R.ItemArray = RowCellValues;

            switch (MainTableProperties.ColumnsAdded)
            {
                case 0:
                    for (int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if (R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString())
                        {
                            for (int j = 0; j < ATable.Columns.Count; j++)
                            {                                
                                ATable.Rows[i].SetField(j, Interaction.InputBox("Enter new " + ATable.Columns[j].ColumnName.ToString(), ATable.Columns[j].ColumnName.ToString(), ATable.Rows[i].ItemArray[j].ToString(), -1, -1));
                                if (dataGridView1.Rows.Count-1 != ATable.Rows.Count)
                                {
                                    dataGridView1.Rows[clickedRowGridIndex].Cells[j].Value = ATable.Rows[i].ItemArray[j].ToString();
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if (R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString() &&
                            R.ItemArray[7].ToString() == ATable.Rows[i].ItemArray[7].ToString())
                        {
                            for (int j = 0; j < ATable.Columns.Count; j++)
                            {
                                ATable.Rows[i].SetField(j, Interaction.InputBox("Enter new " + ATable.Columns[j].ColumnName.ToString(), ATable.Columns[j].ColumnName.ToString(), ATable.Rows[i].ItemArray[j].ToString(), -1, -1));
                                if (dataGridView1.Rows.Count-1  != ATable.Rows.Count)
                                {
                                    dataGridView1.Rows[clickedRowGridIndex].Cells[j].Value = ATable.Rows[i].ItemArray[j].ToString();
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if (R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString() &&
                            R.ItemArray[7].ToString() == ATable.Rows[i].ItemArray[7].ToString() &&
                            R.ItemArray[8].ToString() == ATable.Rows[i].ItemArray[8].ToString())
                        {
                            for (int j = 0; j < ATable.Columns.Count; j++)
                            {
                                ATable.Rows[i].SetField(j, Interaction.InputBox("Enter new " + ATable.Columns[j].ColumnName.ToString(), ATable.Columns[j].ColumnName.ToString(),ATable.Rows[i].ItemArray[j].ToString(), -1, -1));
                                if (dataGridView1.Rows.Count-1 != ATable.Rows.Count)
                                {
                                    dataGridView1.Rows[clickedRowGridIndex].Cells[j].Value = ATable.Rows[i].ItemArray[j].ToString();
                                } 
                                
                                
                            }
                            

                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < ATable.Rows.Count; i++)
                    {
                        if (R.ItemArray[0].ToString() == ATable.Rows[i].ItemArray[0].ToString() &&
                            R.ItemArray[1].ToString() == ATable.Rows[i].ItemArray[1].ToString() &&
                            R.ItemArray[2].ToString() == ATable.Rows[i].ItemArray[2].ToString() &&
                            R.ItemArray[3].ToString() == ATable.Rows[i].ItemArray[3].ToString() &&
                            R.ItemArray[4].ToString() == ATable.Rows[i].ItemArray[4].ToString() &&
                            R.ItemArray[5].ToString() == ATable.Rows[i].ItemArray[5].ToString() &&
                            R.ItemArray[6].ToString() == ATable.Rows[i].ItemArray[6].ToString() &&
                            R.ItemArray[7].ToString() == ATable.Rows[i].ItemArray[7].ToString() &&
                            R.ItemArray[8].ToString() == ATable.Rows[i].ItemArray[8].ToString() &&
                            R.ItemArray[9].ToString() == ATable.Rows[i].ItemArray[9].ToString())
                        {
                            for (int j = 0; j < ATable.Columns.Count; j++)
                            {
                                ATable.Rows[i].SetField(j, Interaction.InputBox("Enter new " + ATable.Columns[j].ColumnName.ToString(), ATable.Columns[j].ColumnName.ToString(),ATable.Rows[i].ItemArray[j].ToString(), -1, -1));
                                if (dataGridView1.Rows.Count-1 != ATable.Rows.Count)
                                {
                                    dataGridView1.Rows[clickedRowGridIndex].Cells[j].Value = ATable.Rows[i].ItemArray[j].ToString();
                                }
                            }
                        }
                    }
                    break;
            }

        }         
                    
               

    }

    public class FileIO//Performs all the saving and loading operations
    {
        public static string MainFolderName = "EC Components DataBase";//Parent folder of all folders partaining to this application
        public static string MainFolderpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), MainFolderName);//its path
        public static string ProjectsFolderName = "Projects";
        public static string ProjectsFolderPath = Path.Combine(MainFolderpath, ProjectsFolderName);
        public static string ComponentsFolder = "Components";
        public static string ComponentsFolderPath = Path.Combine(MainFolderpath, ComponentsFolder);
        public static string ComponentsFileName = "ComponentsInfoList.txt";
        public static string ValuesFolder = "Values";
        public static string ValuesFolderPath = Path.Combine(ComponentsFolderPath, ValuesFolder);
        public static string ValuesFileName = "SortedListofValues.txt";
        public static string DataSheetFolder = "DataSheet";
        public static string DataSheetFolderPath = Path.Combine(MainFolderpath, DataSheetFolder);
        
        MainTableProperties M = new MainTableProperties();


        //this method will be called just  after teh Form1.InitializeComponents declaration in the begininning of the code.
        public void CreateFolderPaths()
        {
            if (!Directory.Exists(MainFolderpath))
            {
                Directory.CreateDirectory(MainFolderpath);
            }

            if (!Directory.Exists(ComponentsFolderPath))
            {
                Directory.CreateDirectory(ComponentsFolderPath);
            }

            if (!Directory.Exists(MainTableProperties.TableInfoFolderPath))
            {
                Directory.CreateDirectory(MainTableProperties.TableInfoFolderPath);
            }

            if (!Directory.Exists(ProjectsFolderPath))
            {
                Directory.CreateDirectory(ProjectsFolderPath);
            }

            if (!Directory.Exists(ValuesFolderPath))
            {
                Directory.CreateDirectory(ValuesFolderPath);
            }

            if (!Directory.Exists(DataSheetFolderPath))
            {
                Directory.CreateDirectory(DataSheetFolderPath);
            }
        }

        public void SaveChanges(DataTable D)//Serializes the main dataTable(all Components) to the componentsFolderPath
        {//All saves are contained within this method
            //Double checks if the main folder exists before serializing to it, although creation of folders has taken place
            //in the loading of the program
            #region
            if (!Directory.Exists(ComponentsFolderPath))
            {
                Directory.CreateDirectory(ComponentsFolderPath);
                if (!File.Exists(Path.Combine(ComponentsFolderPath,ComponentsFileName)))
                {
                    using (File.Create(Path.Combine(ComponentsFolderPath, ComponentsFileName))) ;
                    using (FileStream fs = new FileStream(Path.Combine(ComponentsFolderPath, ComponentsFileName), FileMode.Open, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, D);
                    }
                }
                else
                {
                    using (FileStream fs = new FileStream(Path.Combine(ComponentsFolderPath, ComponentsFileName), FileMode.Open, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, D);
                    }
                }
            }
            else
            {
                if (!File.Exists(Path.Combine(ComponentsFolderPath, ComponentsFileName)))
                {
                    using (File.Create(Path.Combine(ComponentsFolderPath, ComponentsFileName))) ;
                    using (FileStream fs = new FileStream(Path.Combine(ComponentsFolderPath, ComponentsFileName), FileMode.Open, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, D);
                    }
                }
                else
                {
                    using (FileStream fs = new FileStream(Path.Combine(ComponentsFolderPath, ComponentsFileName), FileMode.Open, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, D);
                    }
                }
            }
            #endregion

            //This section handles the saving of the MainTablePropertiesClass
            //Also double checks if the tableproperties folder exists
            if (!Directory.Exists(MainTableProperties.TableInfoFolderPath))
            {
                Directory.CreateDirectory(MainTableProperties.TableInfoFolderPath);
                MainTableProperties M = new MainTableProperties();
                //Method from the MainTableProperties class that handles the saving of the table
                M.SaveTableInfo();
               
            }else
            {
                M.SaveTableInfo();
            }

            ManageInputs MI = new ManageInputs();
            MI.SaveSortedList();
            Projects P = new Projects();
            P.SaveProjects();
        }

        //Loads Data to data Table to be displayed by the dataGridView
        public void LoadDataTable(DataTable AllComponentsDT, DataTable AllComponentsDTBuffer, DataGridView dataGridView1)
        {
            if (!File.Exists(Path.Combine(ComponentsFolderPath, ComponentsFileName)))
            {
                foreach (string s in MainTableProperties.FixedColumnNames)
                {
                    AllComponentsDTBuffer.Columns.Add(s);
                    dataGridView1.DataSource = AllComponentsDTBuffer;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            else
            {
                using (FileStream fs = new FileStream(Path.Combine(ComponentsFolderPath, ComponentsFileName), FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    AllComponentsDTBuffer = (DataTable)bf.Deserialize(fs);                   
                    AllComponentsDT = AllComponentsDTBuffer;
                    dataGridView1.DataSource = AllComponentsDTBuffer;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            MainTableProperties M = new MainTableProperties();
            M.LoadTableInfo();

            ManageInputs MI = new ManageInputs();
            MI.LoadSortedList();

            Projects P = new Projects();
            P.LoadProjects();
        }

        }
      
    public class DynamicSearch//Searches and sorts based on texchanged event
    {

        public delegate DataTable TextChangedEventHandler(string s);

        public event TextChangedEventHandler TextChanged;


        public void InvokeDynamicSearch(string s)
        {
            OnTextChanged(s);
        }
        protected virtual void OnTextChanged(string s)
        {
            TextChanged(s);
        }

        #region EventInvokedSorts

        public DataTable Sort1(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();

            var query = from Components i in Components.AllComponentsListBuffer
                        where i.PartNo.Contains(s.ToUpper()) || i.PartNo.Contains(s.ToLower())
                        select i;
            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);            

            return SortedDT;

        }

        public DataTable Sort2(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();
                        

            var query = from Components i in Components.AllComponentsListBuffer
                        where i.ManufacturerNo.Contains(s)
                        select i;
            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);
            return SortedDT;
        }

        public DataTable Sort3(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();


            var query = from Components i in Components.AllComponentsListBuffer
                        where i.ComponentType.Contains(s)
                        select i;
            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);
            return SortedDT;
        }

        public DataTable Sort4(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();


            var query = from Components i in Components.AllComponentsListBuffer
                        where i.Package.Contains(s)
                        select i;

            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);
            return SortedDT;
        }

        public DataTable Sort5(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();


            var query = from Components i in Components.AllComponentsListBuffer
                        where i.Value.Contains(s)
                        select i;

            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);
            return SortedDT;
        }

        public DataTable Sort6(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();


            var query = from Components i in Components.AllComponentsListBuffer
                        where i.NewlyAddedColumnProperty1.Contains(s)
                        select i;

            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);
            return SortedDT;
        }

        public DataTable Sort7(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();


            var query = from Components i in Components.AllComponentsListBuffer
                        where i.NewlyAddedColumnProperty2.Contains(s)
                        select i;
            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);
            return SortedDT;
        }

        public DataTable Sort8(string s)
        {
            Components C = new Components();
            List<Components> List = new List<Components>();
            DataTable SortedDT = new DataTable();


            var query = from Components i in Components.AllComponentsListBuffer
                        where i.NewlyAddedColumnProperty3.Contains(s)
                        select i;

            List = new List<Components>(query);
            C.SortSwitch(List, SortedDT);
            return SortedDT;
        }

        #endregion

        //Sort by Column only
        public DataTable SortSingleColumn(string s,int ClickedColumnIndex)
        {
            DataTable SortedDataTable = new DataTable();
            switch (ClickedColumnIndex)
            {
                case 0:
                    SortedDataTable = Sort1(s);
                        break;
                case 1:
                    SortedDataTable = Sort2(s);
                    break;
                case 2:
                    SortedDataTable = Sort3(s);
                    break;
                case 3:
                    SortedDataTable = Sort4(s);
                    break;
                case 4:
                    SortedDataTable = Sort5(s);
                    break;
                case 6:
                    SortedDataTable = Sort6(s);
                    break;
                case 7:
                    SortedDataTable = Sort7(s);
                    break;
                case 8:
                    SortedDataTable = Sort8(s);
                    break;
               
            }
            return SortedDataTable;
        }
        
        
    }

    

   
        
}





