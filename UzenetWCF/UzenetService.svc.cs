using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetWCF.Models;
using UzenetWCF.Services;

namespace UzenetWCF
{
    public class UzenetService : IUzenetService
    {
        public List<Uzenet> GetAllUzenetek()
        {
            List<Uzenet> uzenetList = new List<Uzenet>();
            List<Tablazat> tablazatList = new UzenetServices().Read();
            foreach (var tablazat in tablazatList)
            {
                uzenetList.Add((Uzenet)tablazat);
            }

            return uzenetList;
        }

        public string PostUzenet(Uzenet uzenet)
        {
            return new UzenetServices().Create(uzenet);
        }

        public string PutUzenet(Uzenet uzenet)
        {
            return new UzenetServices().Update(uzenet);
        }

        public string DeleteUzenet(int id)
        {
            return new UzenetServices().Delete(id);
        }
    }
}
