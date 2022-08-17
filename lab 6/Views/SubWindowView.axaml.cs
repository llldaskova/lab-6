using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using lab_6.ViewModels;

namespace lab_6.Views
{
    public partial class SubWindowView : UserControl
    {
        public SubWindowView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

       /* private async void OkButton(object sender, RoutedEventArgs e)
        {
            string? str = await new Regex().ShowDialog<string?>((Window)this.VisualRoot);
            if (str != null)
            {
                var context = this.DataContext as MainWindowViewModel;
                context.RegexInput = str;
            }
        }*/
    }
}
