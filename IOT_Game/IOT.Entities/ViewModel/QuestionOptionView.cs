using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Entities.ViewModel
{
    [DataContract]
   public class QuestionOptionView
    {
        [DataMember]
        public int QuestionOptionID { get; set; }
        [DataMember]
        public Nullable<int> QuestionID { get; set; }
        [DataMember]
        public Nullable<int> OptionID { get; set; }
        [DataMember]
        public string AnswerText { get; set; }
        [DataMember]
        public Nullable<bool> AnswerStatus { get; set; }
        [DataMember]
        public string QuestionName { get; set; }
        [DataMember]
        public string OptionName { get; set; }
    }
}
