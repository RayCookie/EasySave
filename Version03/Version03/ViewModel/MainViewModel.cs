using System;
using System.Collections.Generic;
using System.Text;
using Version03.Core;

namespace Version03.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ControlViewCommand { get; set; }
        public RelayCommand ExecuteViewCommand { get; set; }
        public RelayCommand SettingViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public ControlViewModel ControlVM { get; set; }
        public ExecuteViewModel ExecuteVM { get; set; }
        public SettingViewModel SettingVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ControlVM = new ControlViewModel();
            ExecuteVM = new ExecuteViewModel();
            SettingVM = new SettingViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            ControlViewCommand = new RelayCommand(o =>
            {
                CurrentView = ControlVM;
            });
            ExecuteViewCommand = new RelayCommand(o =>
            {
                CurrentView = ExecuteVM;
            });
            SettingViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingVM;
            });

        }
    }
}
