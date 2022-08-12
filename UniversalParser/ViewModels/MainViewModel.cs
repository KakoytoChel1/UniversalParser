using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using UniversalParser.Models;
using System.Windows.Controls;

namespace UniversalParser.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {
            StateText = "Enter to start..";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //tell user pasring is finished or not
        private string _statetext;
        public string StateText
        {
            get { return _statetext; }
            set { _statetext = value; OnPropertyChanged(nameof(StateText));}
        }

        //true or false
        private bool _statebool;
        public bool Statebool
        {
            get { return _statebool; }
            set { _statebool = value; OnPropertyChanged(nameof(Statebool));}
        }

        //show user result of parsing
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(nameof(Text)); }
        }

        //our target
        private string _usrl;
        public string Url
        {
            get { return _usrl; }
            set { _usrl = value; OnPropertyChanged(nameof(Url)); }
        }

        private bool _hrefState;
        public bool HrefState
        {
            get { return _hrefState; }
            set { _hrefState = value; OnPropertyChanged(nameof(HrefState)); }
        }

        //our selector
        private string _selectedSelector;
        public string SelectedSelector
        {
            get { return _selectedSelector; }
            set { _selectedSelector = value; OnPropertyChanged(nameof(SelectedSelector));
                if(value == "a")
                {
                    HrefState = true;
                }
                else { HrefState = false; }
            }
        }
        //close app
        private ICommand _closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(p => {
                        MainWindow win = p as MainWindow;
                        win.Close();
                    });
                }
                return _closeCommand;
            }
        }
        //minimize app
        private ICommand _minimizeCommand;
        public ICommand MinimizeAppCommand
        {
            get
            {
                if (_minimizeCommand == null)
                {
                    _minimizeCommand = new RelayCommand(p => {
                        MainWindow win = p as MainWindow;
                        win.WindowState = WindowState.Minimized;
                    });
                }
                return _minimizeCommand;
            }
        }

        //start parsing
        private ICommand _startpars;
        public ICommand StartparsCommand
        {
            get
            {
                if (_startpars == null)
                {
                    _startpars = new RelayCommand(async p =>
                    {
                        Text = "Waiting for result...";
                        StateText = "Parsing has been started...";
                        Text = await Parse.GetParseResultAsync(Url, SelectedSelector, HrefState);
                        StateText = "Parsing has been finished!";

                    });
                }
                return _startpars;
            }
        }

        private ICommand _managemenu;
        public ICommand ManageMenuCommand
        {
            get
            {
                if (_managemenu == null)
                {
                    _managemenu = new RelayCommand(p =>
                    {
                        //if statebool is false then change text and in another case
                    });
                }
                return _managemenu;
            }
        }
    }
}
