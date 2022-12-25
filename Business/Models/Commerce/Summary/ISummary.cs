using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Business.Models.Commerce.Summary
{
    public interface ISummary
    {
        string CreateOrderSummary(Order order);

        string Send();
    }

    public class EmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order) => "This,is,an,,email,summary!";

        public string Send() => "Sending CsvSummary";
    }

    public class CsvSummary : ISummary
    {
        public string CreateOrderSummary(Order order) => "This is CsvSummary Order!";

        public string Send() => "Sending CsvSummary";
    }
}
