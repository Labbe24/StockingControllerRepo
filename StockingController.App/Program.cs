using System;
using System.Threading;
using StockingController;

namespace StockingController.App
{
    class TimedCompression : ICompressionCtrl, ITimer, ILED, IVibrator
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
                TurnLEDOn("green");
                Vibrate();
                StartTimer(5000);
                _stockingState = StockingState.Compressed;
            }
            Console.WriteLine("Compressing finished");
            TurnLEDOff("green");
            Console.WriteLine();
        }

        public void Decompress()
        {
            if (_stockingState == StockingState.Compressed)
            {
                Console.WriteLine("Decompressing");
                TurnLEDOn("red");
                Vibrate();
                StartTimer(2000);
                _stockingState = StockingState.Relaxed;
            }
            Console.WriteLine("Decompressing finished");
            TurnLEDOff("red");
            Console.WriteLine();
        }

        public void StartTimer(int time)
        {
            Thread.Sleep(time);
        }

        public void TurnLEDOn(string color)
        {
            switch (color.ToLower())
            {
                case "green":
                    Console.WriteLine("GREEN LED ON");
                    break;

                case "red":
                    Console.WriteLine("RED LED ON");
                    break;

                default:
                    break;
            }
        }

        public void TurnLEDOff(string color)
        {
            switch (color)
            {
                case "green":
                    Console.WriteLine("GREEN LED OFF");
                    break;

                case "red":
                    Console.WriteLine("RED LED OFF");
                    break;

                default:
                    break;
            }
        }

        public void Vibrate()
        {
            Console.WriteLine("Wruum Wruum");
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
