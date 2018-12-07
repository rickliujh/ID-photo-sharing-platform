using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessingCenter.DataProcessor
{
    public interface ISuitableBlockData
    {
        int LimitBlockByteSize { get; set; }

        List<string> GetArrayListForSaving(string data);
    }
}
