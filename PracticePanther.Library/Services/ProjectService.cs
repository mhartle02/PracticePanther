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
        private List<Project> projects;
        public List<Project> Projects
        {
            get
            {
                return projects;
            }
        }

        private static ProjectService? instance;
        public static ProjectService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectService();
                }

                return instance;
            }
        }

        private ProjectService()
        {
            projects = new List<Project> {
                new Project { Id = 1, Name = "Test Project", ClientId = 1 }
            };
        }

        public Project? Get(int id)
        {
            return Projects.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Project project)
        {
            if (project.Id == 0)
            {
                project.Id = LastId + 1;
            }
            projects.Add(project);
        }

        public void Delete(int id)
        {
            var projectToDelete = Projects.FirstOrDefault(c => c.Id == id);
            if (projectToDelete != null)
            {
                Projects.Remove(projectToDelete);
            }
        }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;
            }
        }
    }
}
