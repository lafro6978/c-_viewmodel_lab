using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mmmmmmmm.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Добавлен знак вопроса (?) к типу
        public event PropertyChangedEventHandler? PropertyChanged;

        // Добавлен знак вопроса (?) к string
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}