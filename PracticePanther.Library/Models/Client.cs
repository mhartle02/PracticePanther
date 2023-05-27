using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.CLI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }


        public Client()
        {
            Name = string.Empty;
            Notes= string.Empty;
        }

        public override string ToString()
        {
            return $"{Id}. {Name}  (Open Date: {OpenDate} Close Date: {CloseDate}) Notes: {Notes}";
        }










        /*
        
        
        
        
        private int id;
        private DateTime opendate, closedate;
        private bool isactive;
        private string name, notes;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
          
            }
        }
        public DateTime OpenDate
        {
            get
            {
                return opendate;
            }
            set
            {

            }
        }

        public DateTime CloseDate
        {
            get
            {
                return closedate;
            }
            set
            {

            }
        }

        public bool IsActive
        {
            get
            {
                return isactive;
            }
            set
            {

            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {

            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {

            }
        }

        public List<Project> ClientProjects
        {
            get
            {
                return ClientProjects;
            }
            set
            {

            }
        }
     








        */
    } 
}
