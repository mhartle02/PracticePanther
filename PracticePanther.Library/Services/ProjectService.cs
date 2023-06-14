using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;
using System.Xml.Linq;

namespace PracticePanther.Library.Services
{
    public class ProjectService
    {
        private static object _lock = new object();
        private static ProjectService? instance;
        public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }
                }
                return instance;
            }

        }

        private List<Project> CurrentProjects;
        private ProjectService()
        {
            CurrentProjects = new List<Project>();
        }

        public Project? Get(int id)
        {
            return CurrentProjects.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Project? project)
        {
            if (project != null)
            {
                CurrentProjects.Add(project);
            }
        }

        public void Read()
        {
            CurrentProjects.ForEach(Console.WriteLine);
        }

        public void Delete(int id)
        {
            var ProjectToRemove = Get(id);
            if (ProjectToRemove != null)
            {
                CurrentProjects.Remove(ProjectToRemove);
            }

        }
    }

}
