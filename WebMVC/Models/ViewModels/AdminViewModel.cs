using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebMVC.Models
{
    public class AdminViewModel
    {
        //View Budget Summary
        public string myChartKey { get; set; }
        public SingleDataElementChart MyChart1 { get; set; }
    }
    public class SingleDataElementChart
    {
        public string ChartTitle { get; set; }
        //public List<ChartColumnValues> ChartValues { get; set; }
        public string [] ColumnName { get; set; }
        public Nullable<int> [] ColumnIntValue { get; set; }
        public Nullable<float> [] ColumnFloatValue { get; set; }
        public Nullable<decimal> [] ColumnDecValue { get; set; }
    }
    public class ChartColumnValues
    {
        public string ColumnName { get; set; }
        public Nullable<int> ColumnIntValue { get; set; }
        public Nullable<float> ColumnFloatValue { get; set; }
        public Nullable<decimal> ColumnDecValue { get; set; }
    }

    [DataContract]
    public class DataPoint
    {
        public DataPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<double> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }
}