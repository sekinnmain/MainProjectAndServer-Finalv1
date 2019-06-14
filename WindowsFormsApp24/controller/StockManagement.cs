namespace Main.yonor
{

    public class StockManagement
    {
        /// <summary>
        /// This Class is responsible of the setting the amount of Raw materials the restaurant uses.
        /// Has no impact in any other class therefore the implementation is on RAM but can be extended in futures update of the software.
        /// Developed by Yonatan Orozko.
        /// </summary>
        /// 
        //Here we can lock it to be threat safe! to discuss with the team.
        public StockManagement() { }
        public int burgetStock { get; set; }
        public int steakStock { get; set; }
        public int pulletStock { get; set; }
        public int sodaStock { get; set; }
        public int waterStock { get; set; }
        public int colaStock { get; set; }
        public int remainingDishes()//Returns the Total amount of raw items in the Restaurant
        {
            return (burgetStock + steakStock + pulletStock + sodaStock + waterStock + colaStock);
        }
    }

}