using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumber.Models
{
    class Phonebook
    {
        string name, mobileno;
        public Phonebook(string name, string mobileno)
        {
            this.name = name;
            this.mobileno = mobileno;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Mobileno
        {
            get { return mobileno; }
            set { mobileno = value; }
        }
    }
}
