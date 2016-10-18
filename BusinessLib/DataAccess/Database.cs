using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;

namespace BusinessLib
{
    /// <summary>
    /// A data source that provides raw data objects.  In a real
    /// application this class would make calls to a database.
    /// To open the database, instantiate a class then call initialize
    /// This should return an observable collection that has all the data rows. 
    /// </summary>
    public static class Database
    {

        private static OleDbConnection connection;
        public static OleDbConnection GetConnection() { return connection; }
        private static bool result;
        public static bool GetResult() { return result; }
        public static ObservableCollection<Description> GetDescriptionFromDB()
        {
            return new ObservableCollection<Description>
            {

            }

        }
        public static void Initialize()
        {

            string connectionString = GetConnectionString();
            connection = new OleDbConnection(connectionString);
            result = OpenConnection();
        }

        private static string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = "D:\\MAIZSIM07\\ASA2013\\Lizaso-GrignonFR\\Grignon_inputs.xlsx";
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }
            return sb.ToString();
        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                // MessageBox.Show("Open successful");
                return true;
            }
            catch (OleDbException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.

                MessageBoxResult result = MessageBox.Show(ex.Message);
                return false;
            }
        }



        #region GetRegions

        public static Region[] GetRegions()
        {
            return new Region[]
            {
                new Region("WUF10B_CK"),
                new Region("WU10B_F1")
            };
        }

        #endregion // GetRegions

        #region GetStates

        public static State[] GetStates(Region region)
        {
            switch (region.RegionName)
            {
                case "WUF10B_CK":
                    return new State[]
                    {
                        new State("Biology"),
                        new State("Climate"),
                        new State("Fertilization")
                    }; //add new comment
                case "WU10B_F1":
                    return new State[]
                    {
                        new State("Biology"),
                        new State("Climate"),
                        new State("Fertilization")
                    };
            }

            return null;
        }

        #endregion // GetStates

        #region GetCities

        public static City[] GetCities(State state)
        {
            switch (state.StateName)
            {
                case "Biology":
                    return new City[]
                    {
                        new City("BiologyDefault")
                    };

                case "Climate":
                    return new City[]
                    {
                        new City("Wufeng"),
                        new City("Sheulin")
                    };

                case "Fertilization":
                    return new City[]
                    {
                        new City("WUF10B_CK"),
                        new City("WUF10B_F1"),
                        new City("WUF10B_F2"),
                        new City("WUF10B_F3")
                    };
            }

            return null;
        }

        #endregion // GetCities

        #region GetFamilyTree

        public static Person GetFamilyTree()
        {
            // In a real app this method would access a database.
            return new Person
            {
                Name = "WUF10B_CK",
                Children =
                {
                    new Person
                    {
                        Name="Biology",
                        Children=
                        {
                            new Person
                            {
                                Name="BiologyDefault",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="QT",
                                    }
                                }
                            }
                        }
                    },
                           new Person
                            {
                                Name="Climate",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="Latitude",
                                    },
                                    new Person
                                    {
                                        Name="Longitude",
                                    },
                                    new Person
                                    {
                                        Name="DailyBulb",
                                    }
                                }
                            }
                    ,
                    new Person
                    {
                        Name="Fertilization",
                        Children=
                        {
                            new Person
                            {
                                Name="ID",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="Date",
                                    },
                                      new Person
                                    {
                                        Name="Amount",
                                    }
                                }
                            }
                        }
                    },
                            new Person
                            {
                                Name="GridRatio",
                                Children=
                                {
                                    new Person
                                    {
                                        Name="SoilFile",
                                    },
                                    new Person
                                    {
                                        Name="SR1",
                                    }
                                }
                            }
                        }
            }
            ;
        }

        #endregion // GetFamilyTree
    }
}