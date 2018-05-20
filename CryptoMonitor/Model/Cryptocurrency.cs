using System;
using System.ComponentModel;

namespace CryptoMonitor.Model
{
    public class Cryptocurrency
    {
        public string Name { get; set; }
        public string NameKurz { get; set; }
        public int Price { get; set; }
        private double networkhash;
        public double Networkhash
        {
            get { return networkhash; }
            set { networkhash = value; OnPropertyChanged("Networkhash"); }
        }
        public double Blocktime { get; set; }
        public double Blockreward { get; set; }
        public string Time { get; set; }
        private double minedPerDay;
        public double MinedPerDay
        {
            get { return minedPerDay; }
            set { minedPerDay = value; OnPropertyChanged("MinedPerDay"); }
        }
        private double minedPerMonth;
        public double MinedPerMonth
        {
            get { return minedPerMonth; }
            set { minedPerMonth = value; OnPropertyChanged("MinedPerMonth"); }
        }
        private double minedPerYear;
        public double MinedPerYear
        {
            get { return minedPerYear; }
            set { minedPerYear = value; OnPropertyChanged("MinedPerYear"); }
        }
        private string minedPerDayShow;
        public string MinedPerDayShow
        {
            get { return minedPerDayShow; }
            set { minedPerDayShow = value; OnPropertyChanged("MinedPerDayShow"); }
        }
        private string minedPerMonthShow;
        public string MinedPerMonthShow
        {
            get { return minedPerMonthShow; }
            set { minedPerMonthShow = value; OnPropertyChanged("MinedPerMonthShow"); }
        }
        private string minedPerYearShow;
        public string MinedPerYearShow
        {
            get { return minedPerYearShow; }
            set { minedPerYearShow = value; OnPropertyChanged("MinedPerYearShow"); }
        }
        public double PowerCostPerDay { get; set; }
        public double PowerCostPerMonth { get; set; }
        public double PowerCostPerYear { get; set; }
        private string powerCostPerDayShow;
        public string PowerCostPerDayShow
        {
            get { return powerCostPerDayShow; }
            set { powerCostPerDayShow = value; OnPropertyChanged("PowerCostPerDayShow"); }
        }
        private string powerCostPerMonthShow;
        public string PowerCostPerMonthShow
        {
            get { return powerCostPerMonthShow; }
            set { powerCostPerMonthShow = value; OnPropertyChanged("PowerCostPerMonthShow"); }
        }
        private string powerCostPerYearShow;
        public string PowerCostPerYearShow
        {
            get { return powerCostPerYearShow; }
            set { powerCostPerYearShow = value; OnPropertyChanged("PowerCostPerYearShow"); }
        }       
        public double ProfitPerDay { get; set; }
        public double ProfitPerMonth { get; set; }
        public double ProfitPerYear { get; set; }
        private string profitPerDayShow;
        public string ProfitPerDayShow
        {
            get { return profitPerDayShow; }
            set { profitPerDayShow = value; OnPropertyChanged("ProfitPerDayShow"); }
        }
        private string profitPerMonthShow;
        public string ProfitPerMonthShow
        {
            get { return profitPerMonthShow; }
            set { profitPerMonthShow = value; OnPropertyChanged("ProfitPerMonthShow"); }
        }
        private string profitPerYearShow;
        public string ProfitPerYearShow
        {
            get { return profitPerYearShow; }
            set { profitPerYearShow = value; OnPropertyChanged("ProfitPerYearShow"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
