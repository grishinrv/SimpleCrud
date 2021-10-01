﻿using SimpleCrud.Storage.Models;
using System.Collections.ObjectModel;

namespace SimpleCrud.Desktop.ViewModels
{

    public class CompaniesViewModel : TaskExecutionViewModel
    {
        public CompaniesViewModel()
        {
            Rows = new ObservableCollection<Company>();
        }

        public ObservableCollection<Company> Rows { get; }
    }
}
