using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plan_Calculator.Models
{
    public class Plan
    {
        public double price { get; set; }
        public DateTime purchaseDate { get; set; }

        public double initDepositeRate { get; set; }
        public double installmentInterval { get; set; }
        public int installments { get; set; }

        public Double initDeposite()
        {
            return price * initDepositeRate;
        }

        public Double installmentAmount()
        {
            return price * (1 - initDepositeRate) / installments;
        }

        public List<DateTime> installmentDates()
        {
            DateTime lastDate = purchaseDate.AddDays(installmentInterval);
            double installmentGapDays = installmentInterval / installments;
            List<DateTime> payDates = new List<DateTime>();

            for (int i = 1; i < installments; i++)
            {
                DateTime payDate = purchaseDate.AddDays(installmentGapDays * i);
                payDates.Add(payDate);
            }

            payDates.Add(lastDate);
            return payDates;
        }

    }
}
