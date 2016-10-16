namespace BusinessLib
{
    /// <summary>
    /// A data source that provides raw data objects.  In a real
    /// application this class would make calls to a database.
    /// </summary>
    public static class Database
    {
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
                    };

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