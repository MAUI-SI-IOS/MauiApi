using System;
using System.Collections.Generic;
using System.Text;



namespace ApiQuiz.Logic.ApiService
{
    public class UrlBuilder
    {
        const string url = "https://opentdb.com/api.php?";
        Category category;
        short amount;

        public UrlBuilder()
        {
            //default param
            this.category = Category.GeneralKnowledge;
            this.amount = 20;
        }

        public string TrySetCategory(string category)
        {
            if (!Enum.TryParse(category, out Category cat))
            {
                return "Category Invalid";
            }

            this.category = cat;
            return String.Empty;
        }

        public string TrySetAmount(short amount)
        {
            if(amount < 20)
            {
                this.amount = 20;
                return "Minimum questions is 20";
            }
            if (amount > 30)
            {
                this.amount = 30;
                return "Max questions is 30";
            }

            this.amount = amount;
            return String.Empty;
        }

        public string Build()
        {
            return url + $"amount={this.amount}&category={(int)this.category}";
        }

    }
}
