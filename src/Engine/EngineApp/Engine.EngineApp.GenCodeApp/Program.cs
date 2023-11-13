using System.CodeDom.Compiler;
using System.IO;
using System.Runtime;
using System.Text;

namespace Engine.EngineApp.GenCodeApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            int first = Directory.GetCurrentDirectory().IndexOf("Engine");
            MapSave MapSaver = new MapSave(Directory.GetCurrentDirectory().Substring(0, first - 1));

            MapSaver.Run();

            //Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());

            /*
            DirectoryInfo di1;
            di1 = new DirectoryInfo(@"..\..\..");
            Console.WriteLine("Base Directory: " + di1.FullName);

            di1 = new DirectoryInfo($"{di1.FullName}/test");

            if (!di1.Exists)
            {
                di1.Create();
            }

            GenSave.Save($"{di1.FullName}/Generated.cs", str);
            */
        }
    }
}