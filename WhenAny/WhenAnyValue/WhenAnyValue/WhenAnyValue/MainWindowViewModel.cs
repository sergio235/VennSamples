using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Venn;
using Venn.Atributtes;
using Venn.Base.Bindables;
using Venn.Extensions;

namespace WhenAnyValue
{
    public partial class MainWindowViewModel : ExtendedBindableObject
    {
        [VennBindable]
        private string _surname;

        [VennBindable]
        private string _grettings;

        private CompositeDisposable _disposables;

        public MainWindowViewModel()
        {
            InitVariables();
            InitEvents();
        }

        private void InitVariables()
        {
            Surname = string.Empty;
            Grettings = string.Empty;

            _disposables = new CompositeDisposable();
        }

        public void InitEvents()
        {
            this.WhenAnyValue(x => x.Surname)
                .Subscribe(x => 
                {
                    Grettings = $"Good Morning, Mr {x}";
                })            
                .DisposeWith(_disposables);
        }
    }
}
