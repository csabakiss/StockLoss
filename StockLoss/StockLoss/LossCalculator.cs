namespace StockLoss
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Responsible for calculating stock losses.
    /// </summary>
    public class LossCalculator
    {
        /// <summary>
        /// The method is able to analyze a chronological series of stock values in order to show the largest loss that it is 
        /// possible to make by buying a share at a given time t0 and by selling it at a later date t1. 
        /// </summary>
        /// <param name="values">Array containing the stock values.</param>
        /// <returns>
        /// The loss expressed as the difference in value between t0 and t1. 
        /// If there is no loss, the loss will be worth 0
        /// </returns>        
        public int CalculateMaxLoss(int[] values)
        {
            throw new NotImplementedException();
        }
    }
}
