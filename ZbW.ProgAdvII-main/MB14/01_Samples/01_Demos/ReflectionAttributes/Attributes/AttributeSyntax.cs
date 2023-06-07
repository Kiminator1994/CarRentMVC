using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAttributes.Attributes {
[DataContract, Serializable]
[Obsolete]
public class Auto {
    [DataMember]
    public string Marke { get; set; }

    [DataMember]
    public string Typ { get; set; }
}

}
