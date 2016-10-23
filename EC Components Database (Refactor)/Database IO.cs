using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace EC_Components_Database__Refactor_
{
    class DatabaseIO
    {
        public string FileLocation { get; private set; }

        public DataTable MyDataTable { get; }

        public DatabaseIO()
        {
            this.FileLocation = null;

            this.MyDataTable = GenerateDefaultTable();
        }

        public DatabaseIO(string fileLocation)
        {
            this.FileLocation = fileLocation;

            this.MyDataTable = Open(fileLocation);
        }

        private DataTable GenerateDefaultTable()
        {
            DataTable defaultTable = new DataTable();

            DatabaseColumn[] defaultColumns = {
                new DatabaseColumn("Part Number", typeof(string)), 
                new DatabaseColumn("Manufacturer No", typeof(string)), 
                new DatabaseColumn("Component Type", typeof(string)), 
                new DatabaseColumn("Package", typeof(string)), 
                new DatabaseColumn("Value", typeof(string)), 
                new DatabaseColumn("Unit Price", typeof(string)), 
                new DatabaseColumn("Stock", typeof(int))
            };

            foreach (DatabaseColumn defaultColumn in defaultColumns)
            {
                defaultTable.Columns.Add(defaultColumn.Heading, defaultColumn.DataType);
            }

            return defaultTable;
        }

        public void Save()
        {
            SaveAs(this.FileLocation);
        }

        public void SaveAs(string fileLocation)
        {
            if (fileLocation == null)
            {
                throw new ArgumentNullException(nameof(fileLocation), @"File location cannot be enpty when saving");
            }

            if (this.FileLocation == null) // Saving a new database for the first time
            {
                this.FileLocation = fileLocation;
            }

            using (FileStream fs = new FileStream(fileLocation, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter { TypeFormat = FormatterTypeStyle.TypesWhenNeeded };

                bf.Serialize(fs, this.MyDataTable);
            }
        }

        private DataTable Open(string fileLocation)
        {
            using (FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();

                return (DataTable)bf.Deserialize(fs);
            }
        }
    }

    class DatabaseColumn
    {
        public Type DataType { get; }

        public string Heading { get; }

        public DatabaseColumn(string heading, Type dataType)
        {
            this.Heading = heading;
            this.DataType = dataType;
        }
    }
}
