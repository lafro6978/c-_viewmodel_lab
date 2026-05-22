using System.Windows;
using mmmmmmmm.ViewModel;

namespace mmmmmmmm
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow()
        {
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
            InitializeComponent();
        } // <-- ВАЖНО: конструктор должен закрываться здесь!

        // Все обработчики кнопок идут НИЖЕ конструктора:

        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Undo();
        }

        private void Redo_OnClick(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Redo();
        }

        private void SelectFile_OnClick(object sender, RoutedEventArgs e)
        {
            _mainViewModel.InputViewModel.SelectFile();
        }

        private void LoadData_OnClick(object sender, RoutedEventArgs e)
        {
            _mainViewModel.InputViewModel.LoadDataFromFile();
            _mainViewModel.SolverViewModel.Solve();
        }
    }
}