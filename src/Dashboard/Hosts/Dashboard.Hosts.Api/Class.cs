using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboard.Hosts.Api
{
    public interface IMyDependency
    {
        void WriteMessage(string message);
    }

    public class MyDependency: IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage called. Message: {message}");
        }
    }

    public class IndexModel : PageModel
    {
        private readonly MyDependency _dependency = new MyDependency();

        public void OnGet()
        {
            _dependency.WriteMessage("IndexModel.OnGet");
        }
    }
}

/*
 * Планы
 * Category
 */
