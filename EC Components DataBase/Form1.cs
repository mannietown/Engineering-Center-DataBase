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


namespace EC_Components_DataBase
{
    
    public partial class Form1 : Form
    {       
        
        public static DataTable AllComponentsDT = new DataTable();//DT = dataTAble. Houses all the components, this dataTable is serialized and deserialized to
        public DataTable AllComponentsDTBuffer = new DataTable();//Changes before they are saved are made to this table, if changes abandoned, main data table is unaffected
        public DataTable VolitableDT = new DataTable();//sorts of Buffer table are contained here

        public Form1()
        {
            InitializeComponent();
            
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //upon loading, Create the directories if they dont exist
            FileIO IO = new FileIO();
            IO.CreateFolderPaths();

            //Deserializes the DataTable to both the allcomponents table and its buffer
            IO.LoadDataTable(AllComponentsDT, AllComponentsDTBuffer, dataGridView1);          

            




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
            M.AddColumn(AllComponentsDTBuffer);
        }

        //sets the currently clicked row's index to the ECDataGridViewClass variable
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ECDataGridViewClass.clickedRowTableIndex = e.RowIndex;
            
        }

        //sets the currently clicked column's index to the ECDataGridViewClass variable
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainTableProperties.ClickedColumnGridIndex = e.ColumnIndex;
        }

        //Saves info to the designated Folders
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileIO IO = new FileIO();
            IO.SaveChanges(AllComponentsDTBuffer);
            
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
        public object NewlyAddedColumnProperty1/*index 6*/ { get; set; }//Excess properties newly added columns, only initilized when
        public object NewlyAddedColumnProperty2/*index7*/ { get; set; }//columns are added, the column indexes which they refer to are
        public object NewlyAddedColumnProperty3/*index 8*/ { get; set; }//pre-determined
        public int Stock { get; set; }//index 9

        enum CellIndex
        {
            PN, MN, CT, P, V, UP, NACP1, NACP2, NACP3, S//Abbreviated form of the properties of this class, each corresponding to the column index
        }

        public List<Components> AllComponentsListBuffer = new List<Components>();

        public void InitializeComponents(DataTable MainComponentsDT)//DT = DataTable
        {
            MainTableProperties MTP = new MainTableProperties();
            
            try
            {
                for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                {
                    AllComponentsListBuffer.Add(new Components
                    {
                        PartNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.PN.ToString())].ToString(),
                        ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.MN.ToString())].ToString(),
                        ComponentType = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.CT.ToString())].ToString(),
                        Package = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.P.ToString())].ToString(),
                        Value = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.V.ToString())].ToString(),
                        UnitPrice = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.UP.ToString())].ToString(),
                        NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP1.ToString())].ToString(),
                        NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP2.ToString())].ToString(),
                        NewlyAddedColumnProperty3 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP3.ToString())].ToString(),
                        Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.S.ToString())].ToString())

                    });
                }
            }catch(FormatException f)
            {
                //This exception still needs to be handled => A NOTE TO THE DEVELOPPER
                int tempStore = MainTableProperties.MaxColumnsAllowed;
                switch (tempStore)
                {
                    case 1:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.PN.ToString())].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.MN.ToString())].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.CT.ToString())].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.P.ToString())].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.V.ToString())].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.UP.ToString())].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP1.ToString())].ToString(),
                                NewlyAddedColumnProperty2 = "XXXX",
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = 0//int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Rows.Count - 1].ToString())

                            });
                        }

                        break;
                    case 2:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.PN.ToString())].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.MN.ToString())].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.CT.ToString())].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.P.ToString())].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.V.ToString())].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.UP.ToString())].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP1.ToString())].ToString(),
                                NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP2.ToString())].ToString(),
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = 0//int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Rows.Count - 1].ToString())

                            });
                        }

                        break;
                        //There is no case three as the OutOfRangeException will not me thrown since the max number of
                        //rows will be accessible

                }
            
        }
            catch (IndexOutOfRangeException I)
            {
                //Get the current number of newly Added Columns
                int tempStore = MainTableProperties.MaxColumnsAllowed;
                switch (tempStore)
                {
                    case 1:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.PN.ToString())].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.MN.ToString())].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.CT.ToString())].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.P.ToString())].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.V.ToString())].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.UP.ToString())].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP1.ToString())].ToString(),
                                NewlyAddedColumnProperty2 = "XXXX",
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Rows.Count -1].ToString())

                            });
                        }

                        break;
                    case 2:
                        for (int i = 0; i < MainComponentsDT.Rows.Count; i++)
                        {
                            AllComponentsListBuffer.Add(new Components
                            {
                                PartNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.PN.ToString())].ToString(),
                                ManufacturerNo = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.MN.ToString())].ToString(),
                                ComponentType = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.CT.ToString())].ToString(),
                                Package = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.P.ToString())].ToString(),
                                Value = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.V.ToString())].ToString(),
                                UnitPrice = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.UP.ToString())].ToString(),
                                NewlyAddedColumnProperty1 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP1.ToString())].ToString(),
                                NewlyAddedColumnProperty2 = MainComponentsDT.Rows[i].ItemArray[int.Parse(CellIndex.NACP2.ToString())].ToString(),
                                NewlyAddedColumnProperty3 = "XXXX",
                                Stock = int.Parse(MainComponentsDT.Rows[i].ItemArray[MainComponentsDT.Rows.Count - 1].ToString())

                            });
                        }

                        break;
                        //There is no case three as the OutOfRangeException will not me thrown since the max number of
                        //rows will be accessible

                }
            }
            
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
        
        public bool MaxReached = false;//indicates if the max number of columns have been added

        public static int ClickedColumnGridIndex = 0;

        public static ICollection FixedColumnNames = new string [7] { "Part Number", "Manufacturer No", "Component Type", "Package", "Value", "Unit Price", "Stock" };
        public static IList<string> AddedColumnNames = new List<string>() { "", "", "" };

        public static IList<object> TableInfo = new List<object>();//Cotains info to be serialized
        
                
        
                                                                
        public void AddColumn(DataTable ATable)
        {          
            IList<int> LastColumnContents = new int[ATable.Rows.Count];//Store the contents of the Stock Column(last column) before it is removed
            for (int i = 0; i < ATable.Rows.Count; i++)
            {
                //set the contents of the last column(Stock Column) to the lastcolumncontents list
                LastColumnContents[i] = int.Parse(ATable.Rows[i].ItemArray[ATable.Columns.Count -1].ToString());
            }
            //remove the column, this is done such that the last column is always the stock column as it would be added last
            ATable.Columns.RemoveAt(ATable.Columns.Count - 1);
            string UserTypedColumnName = Interaction.InputBox("Enter the column's name...", "Column name", "", -1, -1);//Gets the user typed column name
            AddedColumnNames.Add(UserTypedColumnName);//Store the names of the added column
            ATable.Columns.Add(UserTypedColumnName);//Add new use column before the stock
            ATable.Columns.Add("Stock");//Add stock column and set back the data from the list
            for (int i = 0; i < ATable.Rows.Count; i++)
            {
                ATable.Rows[i].SetField<int>(ATable.Columns.Count - 1, LastColumnContents[i]);
               
            }
            
            if(ColumnsAdded >= 3)
            {
                MaxReached = true;
            } else
            {
                ColumnsAdded++;//Increment the columns added by 1
            }
        }

        public void SaveTableInfo()
        {
            //the first and last indexes are designated for columns added count adn max columns reached count
            TableInfo.Add(ColumnsAdded);
            for(int i = 0; i < 3; i++)
            {   //if all the columns have not been initialized yet then the lsit will contain empty strings
                //hence empty strings will be an indication to ignore             
                TableInfo.Add(AddedColumnNames[i]);
            }
            TableInfo.Add(MaxReached);

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
                    TableInfo = (IList<object>)bf.Deserialize(fs);
                }

                MaxReached = (bool)TableInfo[4];
                ColumnsAdded = (int)TableInfo[0];
                for(int i = 0; i < AddedColumnNames.Count; i++)
                {
                    AddedColumnNames[i] = TableInfo[i + 1].ToString();
                }
            }
            else
            {
                //if file does not exis do nothing
            }
        }
        
    }


    public class ECDataGridViewClass
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
        public static string ValuesFolderPath = Path.Combine(ComponentsFolder, ValuesFolder);
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
        }

        public void SaveChanges(DataTable D)//Serializes the main dataTable(all Components) to the componentsFolderPath
        {
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
        }

        //Loads Data to data Table to be displayed by the dataGridView
        public void LoadDataTable(DataTable AllComponentsDT, DataTable AllComponentsDTBuffer, DataGridView dataGridView1)
        {
            if (!File.Exists(Path.Combine(FileIO.ComponentsFolderPath, FileIO.ComponentsFileName)))
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
                using (FileStream fs = new FileStream(Path.Combine(FileIO.ComponentsFolderPath, FileIO.ComponentsFileName), FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    AllComponentsDTBuffer = (DataTable)bf.Deserialize(fs);
                    fs.Position = 0;
                    AllComponentsDT = (DataTable)bf.Deserialize(fs);
                    dataGridView1.DataSource = AllComponentsDTBuffer;
                }
            }

            MainTableProperties M = new MainTableProperties();
            M.LoadTableInfo();
        }

        }

    }





