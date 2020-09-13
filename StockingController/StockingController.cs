using System;

namespace StockingController
{
    public class StockingController : IBtnHandler
    {
        private ICompressionCtrl _compressionCtrl;

        public StockingController(ICompressionCtrl comp)
        {
            _compressionCtrl = comp;
        }

        public void StartBtnPushed()
        {
            _compressionCtrl.Compress();
        }

        public void StopBtnPushed()
        {
            _compressionCtrl.Decompress();

        }

    }
}
