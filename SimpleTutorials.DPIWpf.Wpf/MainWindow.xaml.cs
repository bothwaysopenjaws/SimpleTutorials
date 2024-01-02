using SimpleTutorials.DPIWpf.DBLib;
using SimpleTutorials.DPIWpf.Wpf.StartupHelpers;
using System.Windows;


namespace SimpleTutorials.DPIWpf.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataAccess _DataAccess;
        private readonly IAbstractFactory<ChildFormWindow> _ChildFormWindowFactory;

        public MainWindow(IDataAccess dataAccess, IAbstractFactory<ChildFormWindow> childFormWindowFactory)
        {
            InitializeComponent();
            this._DataAccess = dataAccess;
            this._ChildFormWindowFactory = childFormWindowFactory;
        }

        private void ButtonGetData_Click(object sender, RoutedEventArgs e) => TextBlockDatas.Text = _DataAccess.GetData();

        private void ButtonOpenChild_Click(object sender, RoutedEventArgs e) => _ChildFormWindowFactory.Create().Show();
    }
}