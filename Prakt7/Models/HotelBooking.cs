using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prakt7.Models
{
    public class HotelBooking:INotifyPropertyChanged
    {
        private string guestName = ""; //Гость
        private int pricePerNight = 0; //цена за ночь
        private int nights = 0; //ночи
        private double discount = 0;  //скидка

        public string GuestName
        {
            get => guestName;
            set
            {
                if (guestName != value)
                {
                    guestName = value;
                    OnPropertyChanged();
                }
            }
        }
        public int PricePerNight
        {
            get => pricePerNight;
            set
            {
                if(pricePerNight != value)
                {
                    pricePerNight = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PriceDiscount));
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public int Nights
        {
            get => nights;
            set
            {
                if (nights != value)
                {
                    nights = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PriceDiscount));
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }
        public double Discount
        {
            get => discount;
            set
            {
                if (discount != value)
                {
                    discount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PriceDiscount));
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        public double PriceDiscount => PricePerNight * Nights * Discount;
        public double TotalPrice => (PricePerNight * Nights) - PriceDiscount;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
