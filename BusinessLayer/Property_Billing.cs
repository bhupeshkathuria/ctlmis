using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class Property_Billing
    {

        private int _InvoicingId;
        public int InvoicingId
        {
            get { return _InvoicingId; }
            set { _InvoicingId = value; }
        }

        private int _CountryId;
        public int CountryId
        {
            get { return _CountryId; }
            set { _CountryId = value; }
        }

        private int _LanguageId;
        public int LanguageId
        {
            get { return _LanguageId; }
            set { _LanguageId = value; }
        }

        private int _PaymentTypeId;
        public int PaymentTypeId
        {
            get { return _PaymentTypeId; }
            set { _PaymentTypeId = value; }
        }

        private int _ProviderId;
        public int ProviderId
        {
            get { return _ProviderId; }
            set { _ProviderId = value; }
        }
        private int _Months;
        public int Months
        {
            get { return _Months; }
            set { _Months = value; }
        }

        private int _Years;
        public int Years
        {
            get { return _Years; }
            set { _Years = value; }
        }

        private string _MonthsMultiple;
        public string MonthsMultiple
        {
            get { return _MonthsMultiple; }
            set { _MonthsMultiple = value; }
        }

        private string _CountryName;
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }
    }
}
