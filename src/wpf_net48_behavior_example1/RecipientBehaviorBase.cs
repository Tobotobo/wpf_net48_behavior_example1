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
    internal abstract class RecipientBehaviorBase<TFrameworkElement, TMessage>
        : Behavior<TFrameworkElement>, IRecipient<TMessage>
        where TFrameworkElement : FrameworkElement
        where TMessage : class
    {
        protected IMessenger _messenger;

        protected override void OnAttached()
        {
            base.OnAttached();

            RegistForMessenger();
            this.AssociatedObject.DataContextChanged += AssociatedObject_DataContextChanged;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.DataContextChanged -= AssociatedObject_DataContextChanged;
            UnregistForMessenger();

            base.OnDetaching();
        }

        private IMessenger GetMessenger(object dataContext)
        {
            if (dataContext == null) return null;
            var p = dataContext.GetType().GetProperty("Messenger");
            return p.GetValue(dataContext) as IMessenger;
        }

        private void RegistForMessenger()
        {
            UnregistForMessenger();
            _messenger = GetMessenger(this.AssociatedObject.DataContext);
            if (_messenger != null)
            {
                _messenger.RegisterAll(this);
            }
        }

        private void UnregistForMessenger()
        {
            if (_messenger == null) return;
            _messenger.UnregisterAll(this);
            _messenger = null;
        }

        private void AssociatedObject_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RegistForMessenger();
        }

        public abstract void Receive(TMessage message);
    }
}
