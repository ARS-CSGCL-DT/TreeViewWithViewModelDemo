using BusinessLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TreeViewWithViewModelDemo.Helpers;
namespace TreeViewWithViewModelDemo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Database _model;

        private DataTable _fileData;

        private RelayCommand _getDataCommand;

        public MainViewModel()
        {
            _model = new Database();
            _fileData = new DataTable();
        }

        public DataTable FileData
        {
            get
            {
                return _fileData;
            }

            set
            {
                _fileData = value;
                OnPropertyChanged("FileData");
            }
        }

        public ICommand GetDataCommand
        {
            get
            {
                if (_getDataCommand == null)
                {
                    _getDataCommand = new RelayCommand(param => GetData());
                }

                return _getDataCommand;
            }
        }

        public void GetData()
        {
            _model.GetFileData("Description");
            FileData = _model.FileData;
        }
    }
}
