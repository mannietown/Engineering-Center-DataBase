using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EC_Components_DataBase
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        static public DataTable ProjectComponentsDT = new DataTable();
        static public DataGridView ProjectDataGridView = new DataGridView();

        private void Form3_Load(object sender, EventArgs e)
        {
            SetColour();

            if (Form1.Form3FromProjectsList == false)
            {
                Projects.SetDataGridViewColumns((DataTable)Form1.dataGRid.DataSource, ProjectComponentsDT);
                dataGridView1.DataSource = ProjectComponentsDT;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                btn_CreateProject.Enabled = false;
                foreach (Projects projects in Projects.ProjectList)
                {
                    if (projects.ProjectName == Form1.ClickedProject && Form1.dataGRid.Columns.Count == projects.ProjectDT.Columns.Count)
                    {
                        Projects P = new Projects();
                        dataGridView1.DataSource = projects.ProjectDT;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        txt_projectName.Text = projects.ProjectName;
                        txt_Builds.Text = projects.CreatedCount.ToString();
                        txt_Deduct.Text = projects.DeductedCount.ToString();
                        Projects.CreatedCountValue = projects.CreatedCount;
                        P.InitializeProperties(txt_projectName.Text);
                        Components C = new Components();
                        Components.AllComponentsListBuffer.Clear();
                        C.InitializeComponents(projects.ProjectDT);

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
                        //this is for when the form is loaded only via clicking a Project

                    }
                    else
                    {
                        Projects P = new Projects();
                        dataGridView1.DataSource = projects.ProjectDT;
                        txt_projectName.Text = projects.ProjectName;
                        txt_Builds.Text = projects.CreatedCount.ToString();
                        txt_Deduct.Text = projects.DeductedCount.ToString();
                        Projects.CreatedCountValue = projects.CreatedCount;
                        P.InitializeProperties(txt_projectName.Text);
                        Components C = new Components();
                        Components.AllComponentsListBuffer.Clear();
                        

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
                        switch (MainTableProperties.ColumnsAdded)
                        {
                            case 1:
                                DataGridViewTextBoxColumn ColumnToAdd = new DataGridViewTextBoxColumn();
                                ColumnToAdd.HeaderText = MainTableProperties.AddedColumnNames[0];
                                dataGridView1.Columns.Insert(6,ColumnToAdd);                                
                                break;
                            case 2:                                
                                DataGridViewTextBoxColumn ColumnToAdd1 = new DataGridViewTextBoxColumn();
                                ColumnToAdd1.HeaderText = MainTableProperties.AddedColumnNames[0];
                                if (dataGridView1.Columns.Contains(MainTableProperties.AddedColumnNames[0]))
                                {

                                }else
                                {
                                    dataGridView1.Columns.Insert(6, ColumnToAdd1);
                                }                                   

                                DataGridViewTextBoxColumn ColumnToAdd2 = new DataGridViewTextBoxColumn();
                                ColumnToAdd2.HeaderText = MainTableProperties.AddedColumnNames[1];
                                dataGridView1.Columns.Insert(7, ColumnToAdd2);
                                
                                break;
                            case 3:
                                DataGridViewTextBoxColumn ColumnToAdd3 = new DataGridViewTextBoxColumn();
                                ColumnToAdd3.HeaderText = MainTableProperties.AddedColumnNames[0];
                                
                                if (dataGridView1.Columns.Contains(MainTableProperties.AddedColumnNames[0]))
                                {

                                }else
                                {
                                    dataGridView1.Columns.Insert(6, ColumnToAdd3);
                                }

                                DataGridViewTextBoxColumn ColumnToAdd4 = new DataGridViewTextBoxColumn();
                                ColumnToAdd4.HeaderText = MainTableProperties.AddedColumnNames[1];
                                

                                if (dataGridView1.Columns.Contains(MainTableProperties.AddedColumnNames[1]))
                                {

                                }
                                else
                                {
                                    dataGridView1.Columns.Insert(7, ColumnToAdd4);
                                }

                                DataGridViewTextBoxColumn ColumnToAdd5 = new DataGridViewTextBoxColumn();
                                ColumnToAdd5.HeaderText = MainTableProperties.AddedColumnNames[2];
                                dataGridView1.Columns.Insert(8, ColumnToAdd5);
                                break;


                        }
                    }
                }

            }
        

            
        }
        
        

        private void btn_CreateProject_Click(object sender, EventArgs e)
        {
            Projects P = new Projects();
            Projects.AddToProjectsList(txt_projectName.Text, (DataTable)dataGridView1.DataSource);
            Form1 form1 = new Form1();
            P.SaveProjects();
            P.LoadProjects();
            form1.SetProjectsList(sender, e);
            this.Close();      
            
                                   
           
            
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectComponentsDT.Rows.Clear();
            ProjectComponentsDT.Columns.Clear();
            Projects p = new Projects();
            p.LoadProjects();
            Form1 form1 = new Form1();
            form1.SetProjectsList(sender, e);
            Form1.Form3FromProjectsList = false;
            Components.AllComponentsListBuffer.Clear();
            Components C = new Components();
            C.InitializeComponents((DataTable)Form1.dataGRid.DataSource);            
            
        }

        
        private void btn_Add1_Click(object sender, EventArgs e)
        {
            Projects P = new Projects();
            Projects.NewlyCreatedCountValue++;
            txt_Builds.Text = (int.Parse(txt_Builds.Text) + 1).ToString();
            

        }

        //Sets the changes to the current Running Projects Properties
        private void btn_Update_Click(object sender, EventArgs e)
        {
            Projects P = new Projects();
            Projects.CreatedCountValue += Projects.NewlyCreatedCountValue;
            P.UpdateProjectList(txt_projectName.Text);
            txt_Builds.Text = Projects.CreatedCountValue.ToString();
            
            
            
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All Components")
            {
                foreach(Projects P in Projects.ProjectList)
                {
                    if(txt_projectName.Text == P.ProjectName)
                    {
                        dataGridView1.DataSource =  P.ProjectDT;
                    }
                }
                
            }
            else
            {

                foreach (Projects P in Projects.ProjectList)
                {
                    if (txt_projectName.Text == P.ProjectName)
                    {
                        Components C = new Components();
                        Components.AllComponentsListBuffer.Clear();
                        C.InitializeComponents(P.ProjectDT);
                        dataGridView1.DataSource = C.SortTable(comboBox1);
                        break;
                        
                    }
                }
                
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        bool ColumnHeaderMouseClickEventOn = false;
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if(txt_Search.Text == "" && ColumnHeaderMouseClickEventOn == false)
            {
                comboBox1.Text = "All Components";
                foreach (Projects P in Projects.ProjectList)
                {
                    if (txt_projectName.Text == P.ProjectName)
                    {                       
                        
                        dataGridView1.DataSource = P.ProjectDT;
                        break;

                    }
                }

                
            }else if (txt_Search.Text != "" && ColumnHeaderMouseClickEventOn == false)
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
            }
            else if (txt_Search.Text != "" && ColumnHeaderMouseClickEventOn == true)
            {
                DynamicSearch D = new DynamicSearch();
                dataGridView1.DataSource = D.SortSingleColumn(txt_Search.Text,clickedColumnIndex);
                        
            }
            else if (txt_Search.Text == "" && ColumnHeaderMouseClickEventOn == true)
            {
                comboBox1.Text = "All Components";
                foreach (Projects P in Projects.ProjectList)
                {
                    if (txt_projectName.Text == P.ProjectName)
                    {                        
                        dataGridView1.DataSource = P.ProjectDT;
                        break;

                    }
                }
            }
        }

        static int clickedColumnIndex = 0;
        //Indicates that column header has been clicked
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ColumnHeaderMouseClickEventOn = true;
            clickedColumnIndex = e.ColumnIndex;

        }

        private void Form3_Click(object sender, EventArgs e)
        {
            ColumnHeaderMouseClickEventOn = false;
            
        }

        public void SetColour()
        {
            this.BackColor = Color.LightBlue;
            dataGridView1.BackgroundColor = Color.MintCream;
            

        }

        private void btn_deduct_Click(object sender, EventArgs e)
        {
            Projects P = new Projects();
            if(int.Parse(txt_Deduct.Text) == 0)
            {
                Projects.DeductedValue = int.Parse(txt_Builds.Text);
                txt_Deduct.Text = Projects.DeductedValue.ToString();
                foreach (Projects project in Projects.ProjectList)
                {
                    if (project.ProjectName == txt_projectName.Text)
                    {
                        string deductedText = txt_Deduct.Text;
                        P.DeductFromMainDataTable((DataTable)Form1.dataGRid.DataSource, project.ProjectDT, int.Parse(txt_Deduct.Text));
                    }
                }

            }
            else
            {
                Projects.DeductedValue += int.Parse(txt_Builds.Text) - Projects.DeductedValue;                
                foreach (Projects project in Projects.ProjectList)
                {
                    if (project.ProjectName == txt_projectName.Text)
                    {
                        
                        P.DeductFromMainDataTable((DataTable)Form1.dataGRid.DataSource, project.ProjectDT, int.Parse(txt_Builds.Text) - int.Parse(txt_Deduct.Text));
                    }
                }

            }
            txt_Deduct.Text = Projects.DeductedValue.ToString();



        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Projects P in Projects.ProjectList)
            {
                if(txt_projectName.Text == P.ProjectName)
                {
                    Projects.ProjectList.Remove(P);
                    Projects projects = new Projects();
                    projects.SaveProjects();
                    this.Close();
                    break;
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(clickedRow);
        }
        public static int clickedRow = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickedRow = e.RowIndex;
        }
    }

    [Serializable]
    class Projects
    {
        public static string ProjectsFileName = "EC Projects.txt";
        //Contains properties for each project
        public  int CreatedCount { get; set; }        
        //This datatable property will be what will be loaded back into the ProjectComponentsDT
        public DataTable ProjectDT { get; set; }
        public string ProjectName { get; set; }
        public int DeductedCount { get; set; }

        //these variables are used to set the properties which are then added to the ProjectList
        public static int CreatedCountValue = 0;
        public static int NewlyCreatedCountValue = 0;
        public static int DeductedValue = 0;
        public static DataTable ProjectDTValue = new DataTable();


        public static List<Projects> ProjectList = new List<Projects>();

        public static void AddToProjectsList(string ProjectSavedName, DataTable Form3ProjectsDT)//This argument setsthe ProjectName Property
        {
            ProjectDTValue = Form3ProjectsDT;   
            ProjectList.Add(new Projects { ProjectName = ProjectSavedName,CreatedCount = CreatedCountValue, ProjectDT = ProjectDTValue ,DeductedCount = DeductedValue});
        }

        //Sets the Properties of the current Projects for edits to be done on it
        public void InitializeProperties(string CurrentProjectName)
        {
            foreach(Projects P in ProjectList)
            {
                if(P.ProjectName == CurrentProjectName)
                {
                    CreatedCount = P.CreatedCount;                  
                    ProjectDT = P.ProjectDT;
                    ProjectName = P.ProjectName;
                    DeductedValue = P.DeductedCount;
                    break;
                }
            }
        }

        //Edits the current project by setting its properties to the new values
        public void UpdateProjectList(string CurrentProjectName)
        {
           foreach(Projects P in ProjectList)
            {
                if(P.ProjectName == CurrentProjectName)
                {
                    ProjectList[ProjectList.IndexOf(P)].ProjectName = CurrentProjectName;
                    ProjectList[ProjectList.IndexOf(P)].CreatedCount = CreatedCountValue;
                    ProjectList[ProjectList.IndexOf(P)].DeductedCount = DeductedValue;
                    SaveProjects();
                    break;
                }
                
            }
        }



        //Gets the names of the columns from the main dataGridView in form1 and sets the columns in this form
        //to the same column names
        public static void SetDataGridViewColumns(DataTable Form1DT,DataTable ProjectsDT)
        {
            foreach(DataColumn D in Form1DT.Columns)
            {
                if(D.ColumnName != "Stock")
                {
                    ProjectsDT.Columns.Add(D.ColumnName);
                }else
                {
                    ProjectsDT.Columns.Add("Quantity");
                }
                
            }
        }

        public void SaveProjects()
        {

            if (Directory.Exists(FileIO.ProjectsFolderPath))
            {
                if (!File.Exists(Path.Combine(FileIO.ProjectsFolderPath, ProjectsFileName)))
                {
                    using(FileStream fs = new FileStream(Path.Combine(FileIO.ProjectsFolderPath, ProjectsFileName), FileMode.Create, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, ProjectList);
                        
                    }
                }else
                {
                    using (FileStream fs = new FileStream(Path.Combine(FileIO.ProjectsFolderPath, ProjectsFileName), FileMode.Open, FileAccess.Write))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, ProjectList);
                        
                    }
                }
            }

            
        }

        public void LoadProjects()
        {
            if (Directory.Exists(FileIO.ProjectsFolderPath))
            {
               if(File.Exists(Path.Combine(FileIO.ProjectsFolderPath, ProjectsFileName)))
                {
                    using (FileStream fs = new FileStream(Path.Combine(FileIO.ProjectsFolderPath, ProjectsFileName), FileMode.Open, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        ProjectList = (List<Projects>)bf.Deserialize(fs);
                    }
                }
            }
        }

        public void DeductFromMainDataTable(DataTable Main, DataTable Project, int multiplier)
        {
            foreach (DataRow row1 in Main.Rows)
            {
                string[] row1Data = new string[3];
                for (int i = 0; i < row1Data.Length; i++)
                {
                    row1Data[i] = row1.ItemArray[i].ToString();
                }

                foreach (DataRow row2 in Project.Rows)
                {
                    string[] row2Data = new string[3];
                    for (int j = 0; j < row1Data.Length; j++)
                    {
                        row2Data[j] = row2.ItemArray[j].ToString();
                    }

                    int equalcount = 0;
                    for (int k = 0; k < row2Data.Length; k++)
                    {
                        if (row1Data[k] == row2Data[k])
                        {
                            equalcount++;
                        }
                    }

                    int StockValue = int.Parse(row1.ItemArray[row1.ItemArray.Count() - 1].ToString());
                    if (equalcount == 3)
                    {
                        row1.SetField(row1.ItemArray.Count() - 1, StockValue - (multiplier * int.Parse(row2.ItemArray[row2.ItemArray.Count() - 1].ToString())));
                        break;
                    }
                }
            }
        }


    }

    
}
