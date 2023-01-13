using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace wpf_net48_behavior_example1
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public string Text { get => _text; set => SetProperty(ref _text, value); }
        private string _text = string.Empty;

        public ICommand ShowMessageBoxCommand { get; }

        public MainWindowViewModel()
        {
            ShowMessageBoxCommand = new RelayCommand(() =>
            {
                Messenger.Send(new ShowMessageBoxMessage { Text = this.Text});
            });
        }
    }
}
