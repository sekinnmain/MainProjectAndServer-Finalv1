
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NewUsers;
using Main;

namespace main
{
    public class OrderService
    {

        public int idOrder;
        public User user;
        public List<Dish> dishes;
        public Pay pay;
        public Stopwatch timer;
        public string seatOrGo;
        public int tableBnum;
        public double price;
        public Feedback feedBack;
        public string notes;

        public OrderService()
        {
            Random r = new Random();
            this.idOrder = r.Next();
            this.tableBnum = r.Next();
            this.timer = new Stopwatch();
            timer.Start();
        }
        public OrderService(User user, List<Dish> dish, Pay pay, string seatOrGo, double Price,Feedback feedback,string nots)/*בנאי להזמנה מהמסעדב*/
        {
            Random r = new Random();
            this.idOrder = r.Next();
            this.user = user;
            this.dishes = dish;
            this.pay = pay;
            this.seatOrGo = seatOrGo;
            this.tableBnum = r.Next(1,40);
            this.feedBack = feedback;
            this.price = Price;
            this.notes = nots;
        }

        public OrderService(User user, List<Dish> dish, Pay pay,  string seatOrGo)
        {
            this.user = user;
            this.dishes = dish;
            this.pay = pay;
            this.seatOrGo = seatOrGo;
            this.timer = new Stopwatch();

        }

        public User UserP { get { return this.user; } set { this.user = value; } }
        public int idOrderP() { return this.idOrder; }
        public Pay PayP { get { return this.pay; } set { this.pay = value; } }
        public Stopwatch TimerP() { return this.timer; }
        public string seatOrGoP { get { return this.seatOrGo; } set { this.seatOrGo = value; } }
        public int tableBnumP { get { return this.tableBnum; } set { this.tableBnum = value; } }
        public double PriceP { get { return this.price; } set { this.price = value; } }


        public string  dishNameFromOrder()//שיטה המחזירה את שמות המנות שנבחרו
        {
            string dishNames = " ";
            foreach (Dish  d in dishes)
            {
                dishNames += " "+d.dishName;
            }
            return dishNames;
        }

    }
}
