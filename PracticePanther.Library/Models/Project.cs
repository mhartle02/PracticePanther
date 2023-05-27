using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.CLI.Models
{
    public class Project
    {



        public int Id { get; set; }
        public string Name { get; set; }



        public Project()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }


        /*
        private int Id, ClientId;
        private DateTime OpenDate, CloseDate;
        private bool IsActive;
        private string ShortName, LongName;

        public int id
        {
            get
            {
                return Id;
            }
            set
            {

            }
        }

        public int clientid
        {
            get
            {
                return ClientId;
            }
            set
            {

            }
        }

        public DateTime opendate
        {
            get
            {
                return OpenDate;
            }
            set
            {

            }
        }

        public DateTime closedate
        {
            get
            {
                return CloseDate;
            }
            set
            {

            }
        }

        public bool isactive
        {
            get
            {
                return IsActive;
            }
            set
            {

            }
        }

        public string shortname
        {
            get
            {
                return ShortName;
            }
            set
            {

            }
        }

        public string longname
        {
            get
            {
                return LongName;
            }
            set
            {

            }
        }



        */


    }
}
