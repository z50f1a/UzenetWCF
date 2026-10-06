using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UzenetWCF.Models
{
    [DataContract]
    public class Uzenet : Tablazat
    {
        // Az Id a Tablazat osztályból öröklődik.

        [DataMember]
        public string Szoveg { get; set; }
        [DataMember]
        public DateTime KüldesiIdo { get; set; }
        [DataMember]
        public string UzenetTipus { get; set; }
        [DataMember]
        public string Telefon { get; set; }
        [DataMember]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Szöveg: {Szoveg}, Küldési idő: {KüldesiIdo}, " +
                   $"Típus: {UzenetTipus}, Telefon: {Telefon}, Email: {Email}";
        }
    }
}
