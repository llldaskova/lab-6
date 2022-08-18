using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.ViewModels
{
    public class SubWindowViewModel:ViewModelBase
    {
        public SubWindowViewModel()
        {
            var msgEnabled = this.WhenAnyValue(
                msg => msg.Text,
                msg=>!string.IsNullOrWhiteSpace(msg)
                );
            OkButton = ReactiveCommand.Create(() => Text, msgEnabled);
            CancelButton= ReactiveCommand.Create(() => { });

        }
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref text, value);
            }
        }

        private string bodyNote;
        public string BodyNote
        {
            get
            {
                return bodyNote;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref bodyNote, value);
            }
        }

        public ReactiveCommand<Unit, string> OkButton { get; }
        public ReactiveCommand<Unit, Unit> CancelButton { get; }
    }
}
