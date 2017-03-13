using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest_csvToJson
{
    public class Order
    {
        //CSV file has one File record, designated "F" and one End record, designated "E"
        //Each F record can contain multiple Order records, designated "O".
        //Each O record contains a single B, S & M & T records
        //Each O record can contain multiple Line Item records, designated "L"
        public List<Line> Lines { get; set; }

        public Order(List<Line> lines)
        {
            Lines = lines;
        }
    }

    public class Column
    {
        public string ColumnNumber { get; set; }
        public string ColumnValue { get; set; }
    }

    public class Line
    {
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
        public Line(string name)
        {
            Name = name;
        }

    }
    public class ELine : Line
    {
        public ELine(string name) : base(name)
        {
        }
    }
    public class LLine : Line
    {
        public LLine(string name) : base(name)
        {
        }
    }
    public class TLine : Line
    {
        public TLine(string name) : base(name)
        {
        }
    }
    public class MLine : Line
    {
        public MLine(string name) : base(name)
        {
        }
    }

    public class FLine : Line
    {
        public FLine(string name) : base(name)
        {
        }
    }
    public class OLine : Line
    {
        public OLine(string name) : base(name)
        {
        }
    }
    public class BLine : Line
    {
        public BLine(string name) : base(name)
        {
        }
    }

    public class SLine : Line
    {
        public SLine(string name) : base(name)
        {
        }
    }
}
