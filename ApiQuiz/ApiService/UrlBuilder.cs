using System;
using System.Collections.Generic;
using System.Text;

namespace ApiQuiz.ApiService
{
    internal class UrlBuilder
    {
        const string url = "https://opentdb.com/api.php?";
        Category category;
        short amount;

        public UrlBuilder()
        {
            this.category = Category.GeneralKnowledge;
            this.amount = 10;
        }

        public UrlBuilder SetCategory(Category category)
        {
            this.category = category;
            return this;
        }
        public UrlBuilder SetAmount(short amount)
        {
            if (amount > 20 || amount <= 0)
            {
                throw new ArgumentException("amount of question can't exceed 20");
            }

            this.amount = amount;
            return this;
        }

        public string Build()
        {
            return url + $"amount={this.amount}&category={(int)this.category}";
        }

    }
}
