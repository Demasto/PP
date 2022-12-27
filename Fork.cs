using System.Threading;

namespace Философы
{

    public class Fork
    {
        Semaphore semaphore = new Semaphore(1, 1); // семафор
        //разрешения будут предоставляться ожидающим потокам в том порядке, в каком они запрашивали доступ.
        public void TakeFork() // взять вилку
        {
            semaphore.WaitOne(); // ждать пока освободится ресурс!           
        }

        public void PutFork() // положить вилку
        {
            semaphore.Release(); // Положить вилку!
        }
    }

}
