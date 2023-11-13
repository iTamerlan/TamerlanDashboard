using System.IO;
using System.Text;

namespace Engine.EngineApp.GenCodeApp
{
    /// <summary>
    /// Класс для сохранения сгенерированного кода по заданному пути.
    /// </summary>
    public class GenSave
    {
        /// <summary>
        /// Функция сохранения сгенерированного кода по заданному пути.
        /// </summary>
        /// <param name="path">Полный путь для сохранения</param>
        /// <param name="code">Сгенерированный исходный код</param>
        public async static Task Save(string path, string code) 
        {
            // $"{di1.FullName}/Generated.cs"
            using (FileStream fstream = new FileStream(path, FileMode.Create))
            {
                // операции с fstream
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(code);
                // запись массива байтов в файл
                /*await*/ fstream.WriteAsync(buffer, 0, buffer.Length);
                //Console.WriteLine("Текст записан в файл");
            }
        }
    }
}
