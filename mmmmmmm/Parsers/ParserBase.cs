using System;
using System.IO;
using mmmmmmmm.Data;

namespace mmmmmmmm.Parsers
{
    public abstract class ParserBase : IDisposable
    {
        protected FileStream _fileStream;

        public ParserBase(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }
            _fileStream = File.OpenRead(path);
        }

        public abstract InputData? Parse(); // Добавлен ?

        public void Dispose()
        {
            _fileStream?.Dispose();
        }
    }
}