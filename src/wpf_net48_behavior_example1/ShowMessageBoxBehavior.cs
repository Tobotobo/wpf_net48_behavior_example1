using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Runtime.CompilerServices;

namespace wpf_net48_behavior_example1
{
    internal class ShowMessageBoxBehavior : RecipientBehaviorBase<Window, ShowMessageBoxMessage>
    {
        public override void Receive(ShowMessageBoxMessage message)
        {
            MessageBox.Show(this.AssociatedObject, message.Text);
        }   
    }
}
