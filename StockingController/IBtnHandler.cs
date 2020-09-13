using System;
using System.Collections.Generic;
using System.Text;

namespace StockingController
{
    interface IBtnHandler
    {
        void StartBtnPushed();
        void StopBtnPushed();
    }
}
