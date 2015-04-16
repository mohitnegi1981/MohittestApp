using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Question
    {
        private int question_type_id;
        private int quiz_id;
        private string title;
        private string subtitle;
        private string question_text;
        private decimal points;
        private string choice_numbering_mode;
        private int sequence;
        private string legacy_question_id;
        private string answer;
        private string agilix_question_id;

        public int Question_Type_Id
        {
            get
            {
                return this.question_type_id;
            }
            set
            {
                this.question_type_id = value;
            }
        }

        public int Quiz_Id
        {
            get
            {
                return this.quiz_id;
            }
            set
            {
                this.quiz_id = value;
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public string SubTitle
        {
            get
            {
                return this.subtitle;
            }
            set
            {
                this.subtitle = value;
            }
        }


        public string Question_Text
        {
            get
            {
                return this.question_text;
            }
            set
            {
                this.question_text = value;
            }
        }

        public decimal Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }
        public string Choice_NUmbering_Mode
        {
            get
            {
                return this.choice_numbering_mode;
            }
            set
            {
                this.choice_numbering_mode = value;
            }
        }
        public int Sequence
        {
            get
            {
                return this.sequence;
            }
            set
            {
                this.sequence = value;
            }
        }
        public string Legacy_Question_Id
        {
            get
            {
                return this.legacy_question_id;
            }
            set
            {
                this.legacy_question_id = value;
            }
        }
        public string Answer
        {
            get
            {
                return this.answer;
            }
            set
            {
                this.answer = value;
            }
        }
        public string Agilix_Question_Id
        {
            get
            {
                return this.agilix_question_id;
            }
            set
            {
                this.agilix_question_id = value;
            }
        }

    }
}