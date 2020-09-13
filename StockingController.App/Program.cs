using System;
using System.Threading;
using StockingController;

namespace StockingController.App
{
    class TimedCompression : ICompressionCtrl, ITimer
    {
        enum StockingState
        {
            Relaxed,
            Compressed,
        }

        private StockingState _stockingState = StockingState.Relaxed;
        public void Compress()
        {
            if (_stockingState == StockingState.Relaxed)
            {
                Console.WriteLine("Compressing");
                StartTimer(5000);
                _stockingState = StockingState.Compressed;
            }
            Console.WriteLine("Compressing finished");
        }

        public void Decompress()
        {
            if (_stockingState == StockingState.Compressed)
            {
                Console.WriteLine("Decompressing");
                StartTimer(2000);
                _stockingState = StockingState.Relaxed;
            }
            Console.WriteLine("Decompressing finished");
        }

        public void StartTimer(int time)
        {
            Thread.Sleep(time);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stockingController = new StockingController(new TimedCompression());
            ConsoleKeyInfo consoleKeyInfo;

            Console.WriteLine("Compression Stocking Control User Interface");
            Console.WriteLine("A:   Compress");
            Console.WriteLine("Z:   Decompress");
            Console.WriteLine("ESC: Terminate application");

            do
            {
                consoleKeyInfo = Console.ReadKey(true); // true = do not echo character
                if (consoleKeyInfo.Key == ConsoleKey.A) stockingController.StartBtnPushed();
                if (consoleKeyInfo.Key == ConsoleKey.Z) stockingController.StopBtnPushed();

            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }
    }
}
