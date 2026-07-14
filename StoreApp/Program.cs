
namespace StoreApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            StoreConsoleApp oStore = new StoreConsoleApp();
            await oStore.RunAsync();
        }
    }
}
