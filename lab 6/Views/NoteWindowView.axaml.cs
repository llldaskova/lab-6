using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab_6.Views
{
    public partial class NoteWindowView : UserControl
    {
        public NoteWindowView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
