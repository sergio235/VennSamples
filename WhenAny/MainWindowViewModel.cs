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

namespace WhenAny
{
    public partial class MainWindowViewModel : ExtendedBindableObject
    {
        [VennBindable]
        private string _name;

        [VennBindable]
        private string _surname;

        private CompositeDisposable _disposables;

        public MainWindowViewModel()
        {
            InitVariables();
            InitEvents();
        }

        private void InitVariables()
        {
            Name = string.Empty;
            Surname = string.Empty;

            _disposables = new CompositeDisposable();
        }

        public void InitEvents()
        {
            this.WhenAny(x => x.Name)
                .Subscribe(x => 
                {
                    Surname = "Please, write your surname";
                })            
                .DisposeWith(_disposables);
        }
    }
}
