using System;
using System.Collections.Generic;
using System.Text;

namespace RubickReptile
{
    public interface DataSourceAnalysisInterface
    {
        void Load(int Page);
        List<Item> Source { get;  }
    }
}
