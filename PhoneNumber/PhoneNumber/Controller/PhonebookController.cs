using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tambahkan using berikut
using MySql.Data.MySqlClient;
using PhoneNumber.Models;
using PhoneNumber.DAO;
using System.Data;

namespace PhoneNumber.Controller
{
    class PhonebookController
    {
        PhonebookDAO pc = new PhonebookDAO();
        //Show Data Phone
        public MySqlDataAdapter showPhone()
        {
            return pc.showPhone();
        }

        //Insert Data Phone
        public bool Insert(Phonebook P)
        {
            return pc.insertPhone(P);
        }

        //Update Data Phone
        public bool Update(Phonebook P, int id)
        {
            return pc.updatePhone(P, id);
        }

        //Delete Data Phone
        public bool Delete(int id)
        {
            return pc.deletePhone(id);
        }
    }
}
