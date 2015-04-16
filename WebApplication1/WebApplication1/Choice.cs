using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Choice
    {
        private int question_id;
        private decimal points;
        private string label_text;
        private int order_number;
        private string FeedBack;
        private int Term_Id;

        public int Question_id
        {
            get
            {
                return this.question_id;
            }
            set
            {
                this.question_id = value;
            }
        }
    }
}