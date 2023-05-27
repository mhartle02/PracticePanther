using PracticePanther.CLI.Models;
using System;
//hii
namespace PracticePanther
{
    public class Program
    {
        static public void Main(string[] args)
        {
            var CurrentClients = new List<Client>();
            var Projects = new List<Project>();
            int MenuInput;
            bool Quit = false;

            while (Quit == false)
            {

                Console.WriteLine("What would you like to manage?\n");
                Console.Write("1) Clients 2) Projects 3) Quit\n> ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    do
                    {
                        Console.WriteLine("\n---Client Menu---");
                        Console.Write("1) Add Client 2) List Clients 3) Update Client 4) Delete Client 5) Back \n> ");
                        MenuInput = Convert.ToInt32(Console.ReadLine());
                        if (MenuInput == 1)
                        {
                            //create client
                            Console.Write("Id: ");
                            var id = int.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Name: ");
                            var name = Console.ReadLine();

                            CurrentClients.Add(
                                new Client
                                {
                                    Id = id,
                                    Name = name ?? "Unnamed Client"
                                }
                            );
                        }
                        else if (MenuInput == 2)
                        {
                            //list clients
                            Console.WriteLine("\n---Clients---");
                            CurrentClients.ForEach(Console.WriteLine);

                        }
                        else if (MenuInput == 3)
                        {
                            //update clients
                            Console.WriteLine("Which client would you like to Update?");
                            CurrentClients.ForEach(Console.WriteLine);
                            Console.Write("\n> ");
                            var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                            var clientToUpdate = CurrentClients.FirstOrDefault(c => c.Id == updateChoice);
                            if (clientToUpdate != null)
                            {
                                Console.Write("What is the client's updated name?\n > ");
                                clientToUpdate.Name = Console.ReadLine() ?? "Unnamed Client";
                            }
                        }
                        else if (MenuInput == 4)
                        {
                            //delete clients
                            Console.WriteLine("Which client would you like to delete?");
                            CurrentClients.ForEach(Console.WriteLine);
                            Console.Write("\n> ");
                            var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                            var clientToRemove = CurrentClients.FirstOrDefault(c => c.Id == deleteChoice);
                            if (clientToRemove != null)
                            {
                                CurrentClients.Remove(clientToRemove);
                            }
                        }
                    } while (MenuInput != 5);
                }

                else if (input == 2)
                {
                    do
                    {
                        Console.WriteLine("\n---Project Menu---");
                        Console.Write("1) Add Project 2) List Project 3) Update Project 4) Delete Project 5) Back  \n> ");
                        MenuInput = Convert.ToInt32(Console.ReadLine());
                        if (MenuInput == 1)
                        {
                            //Adds new project
                            Console.Write("Id: ");
                            var id = int.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Name: ");
                            var name = Console.ReadLine();

                            Projects.Add(
                                new Project
                                {
                                    Id = id,
                                    Name = name ?? "Unnamed Project"
                                }
                            );
                        }
                        else if (MenuInput == 2)
                        {
                            Console.WriteLine("\n---Projects---");
                            Projects.ForEach(Console.WriteLine);
                        }
                        else if (MenuInput == 3)
                        {
                            //Update existing project
                            Console.WriteLine("Which project would you like to Update?");
                            Projects.ForEach(Console.WriteLine);
                            Console.Write("\n> ");
                            var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                            var projectToUpdate = Projects.FirstOrDefault(p => p.Id == updateChoice);
                            if (projectToUpdate != null)
                            {
                                Console.Write("What is the project's updated name?\n > ");
                                projectToUpdate.Name = Console.ReadLine() ?? "Unnamed Project";
                            }
                        }
                        else if (MenuInput == 4)
                        {
                            //Delete existing project
                            Console.WriteLine("Which project would you like to delete?");
                            Projects.ForEach(Console.WriteLine);
                            Console.Write("\n> ");
                            var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                            var projectToRemove = Projects.FirstOrDefault(c => c.Id == deleteChoice);
                            if (projectToRemove != null)
                            {
                                Projects.Remove(projectToRemove);
                            }
                        }

                    } while (MenuInput != 5);
                }

                else if(input == 3)
                {
                    Quit = true;
                }
            }

        }
    }
}