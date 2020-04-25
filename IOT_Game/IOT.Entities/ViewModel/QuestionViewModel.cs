using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Entities.ViewModel
{
    [DataContract]
    public class QuestionViewModel
    {
        [DataMember]
        public Nullable<int> DodID { get; set; } 
        [DataMember]
        public Nullable<int> QuestionID { get; set; } 
        [DataMember]
        public List<QuestionOption> QuestionOption { get; set; } 
        [DataMember]
        public string  QuestionName { get; set; } 

    }
}
