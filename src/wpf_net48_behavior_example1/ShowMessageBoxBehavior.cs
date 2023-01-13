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

namespace wpf_net48_behavior_example1
{
    internal class ShowMessageBoxBehavior : Behavior<Window>, IRecipient<ShowMessageBoxMessage>
    {
        public static readonly DependencyProperty MessengerProperty =
            DependencyProperty.Register(
                "Messenger",
                typeof(IMessenger),
                typeof(ShowMessageBoxBehavior),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnMessengerChanged)
                )
            );

        public IMessenger Messenger
        {
            get { return (IMessenger)GetValue(MessengerProperty); }
            set { SetValue(MessengerProperty, value); }
        }

        private static void OnMessengerChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            (e.OldValue as IMessenger)?.UnregisterAll(obj);
            (e.NewValue as IMessenger)?.RegisterAll(obj);
        }

        public void Receive(ShowMessageBoxMessage message)
        {
            MessageBox.Show(this.AssociatedObject, message.Text);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            Messenger?.UnregisterAll(this);

            base.OnDetaching();
        }
    }
}
