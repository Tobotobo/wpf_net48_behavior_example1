using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace wpf_net48_behavior_example1
{
    internal abstract class ViewModelBase : ObservableObject
    {
        public IMessenger Messenger { get; } = new WeakReferenceMessenger();
    }
}
