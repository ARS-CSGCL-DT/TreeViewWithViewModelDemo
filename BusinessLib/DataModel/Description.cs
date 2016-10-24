namespace BusinessLib.DataModel;
{
    public class Description  // use INotifyPropertyChanged Later when we need to change it
    {
        #region
        public Description()
        {
            this.TableName = "Description";

        }

        public string TableName;
        public string parameter { get; set; }

        string _ID;
        public string ID { get; private set; }
        string _SoilFile;
        public string SoilFile { get; private set; }
        string _WeatherFileName;
        public string WeatherFileName { get; private set; }
        string _Hybrid;
        public string Hybrid { get; private set; }
        string _VarietyFile;
        public string VarietyFile { get; private set; }
        string _ClimateFile;
        public string ClimateFile { get; private set; }
        string _Location;
        public string Location { get; private set; }
        string _NitrogenFile;
        public string NitrogenFile { get; private set; }
        string _Solute;
        public string Solute { get; private set; }
        string _Path;
        public string Path { get; private set; }
        string _Biology;
        public string Biology { get; private set; }

        #endregion
    }
}