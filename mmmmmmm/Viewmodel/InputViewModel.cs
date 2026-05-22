using System.IO;
using Microsoft.Win32;
using mmmmmmmm.Data;
using mmmmmmmm.Common;
using mmmmmmmm.Parsers;

namespace mmmmmmmm.ViewModel
{
    public class InputViewModel : ViewModelBase
    {
        private readonly UndoRedoManager _undoRedoManager;
        private string? _filePath; // Добавлен ?
        private InputData? _currentImportedData; // Добавлен ?
        private bool _isUpdating = false;

        public InputViewModel(UndoRedoManager undoRedoManager)
        {
            _undoRedoManager = undoRedoManager;
        }

        public string? FilePath // Добавлен ?
        {
            get => _filePath;
            set
            {
                if (_filePath == value) return;
                string? oldVal = _filePath;
                _filePath = value;
                OnPropertyChanged();

                if (!_isUpdating)
                {
                    _undoRedoManager.AddUndoRedo(
                        () => { _isUpdating = true; FilePath = oldVal; _isUpdating = false; },
                        () => { _isUpdating = true; FilePath = value; _isUpdating = false; }
                    );
                }
            }
        }

        public InputData? CurrentImportedData // Добавлен ?
        {
            get => _currentImportedData;
            set
            {
                if (_currentImportedData == value) return;
                var oldVal = _currentImportedData;
                _currentImportedData = value;
                OnPropertyChanged();

                if (!_isUpdating)
                {
                    _undoRedoManager.AddUndoRedo(
                        () => { _isUpdating = true; CurrentImportedData = oldVal; _isUpdating = false; },
                        () => { _isUpdating = true; CurrentImportedData = value; _isUpdating = false; }
                    );
                }
            }
        }

        public void SelectFile()
        {
            var dialog = new OpenFileDialog { Filter = "Все файлы|*.txt;*.json;*.xml" };
            if (dialog.ShowDialog() == true)
            {
                FilePath = dialog.FileName;
            }
        }

        public void LoadDataFromFile()
        {
            if (string.IsNullOrWhiteSpace(FilePath) || !File.Exists(FilePath)) return;

            string? firstLine;
            using (var reader = new StreamReader(FilePath)) { firstLine = reader.ReadLine()?.Trim().ToLower(); }

            ParserBase? parser = firstLine switch
            {
                "oscillator" => new OscillatorParser(FilePath),
                "rc" => new RcParser(FilePath),
                "cooling" => new CoolingParser(FilePath),
                _ => null
            };

            if (parser != null)
            {
                using (parser) { CurrentImportedData = parser.Parse(); }
            }
        }
    }
}