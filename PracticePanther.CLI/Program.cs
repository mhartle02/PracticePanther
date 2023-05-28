using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using System;

namespace PracticePanther
{
    public class Program
    {
        static public void Main(string[] args)
        {
            var MyClientService = ClientService.Current;
            var MyProjectService = ProjectService.Current;
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

                            Console.Write("Open Date: ");
                            var openDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                            Console.Write("Close Date: ");
                            var closeDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                            Console.Write("Notes: ");
                            var notes = Console.ReadLine();


                            MyClientService.Add(
                                new Client
                                {
                                    Id = id,
                                    Name = name ?? "Unnamed Client",
                                    OpenDate = openDate,
                                    CloseDate = closeDate,
                                    Notes = notes

                                }
                            );
                        }
                        else if (MenuInput == 2)
                        {
                            //list clients
                            Console.WriteLine("\n---Clients---");
                            MyClientService.Read();

                        }
                        else if (MenuInput == 3)
                        {
                            //update clients
                            Console.WriteLine("Which client would you like to Update?");
                            MyClientService.Read();
                            Console.Write("\n> ");
                            var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                            var clientToUpdate = MyClientService.Get(updateChoice);
                            if (clientToUpdate != null)
                            {
                                Console.WriteLine("What would you like to update? \n 1) Name 2) Open Date 3) Close Date 4) Notes");
                                Console.Write("> ");
                                int WhichUpdate = Convert.ToInt32(Console.ReadLine());
                                if(WhichUpdate == 1) 
                                {
                                    Console.Write("What is the client's updated name?\n > ");
                                    clientToUpdate.Name = Console.ReadLine() ?? "Unnamed Client";
                                }
                                else if(WhichUpdate == 2)
                                {
                                    Console.Write("What is the client's updated Open Date?\n > ");
                                    clientToUpdate.OpenDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

                                }
                                else if(WhichUpdate == 3)
                                {
                                    Console.Write("What is the client's updated Close Date?\n > ");
                                    clientToUpdate.CloseDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());
                                }
                                else if(WhichUpdate == 4)
                                {
                                    Console.Write("Enter new client note.\n > ");
                                    clientToUpdate.Notes = Console.ReadLine() ?? "null";
                                }
                            }
                        }
                        else if (MenuInput == 4)
                        {
                            //delete clients
                            Console.WriteLine("Which client would you like to delete?");
                            MyClientService.Read();
                            Console.Write("\n> ");
                            var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                            var clientToRemove = MyClientService.Get(deleteChoice);
                            if (clientToRemove != null)
                            {
                                MyClientService.Delete(deleteChoice);
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

                            MyProjectService.Add(
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
                            MyProjectService.Read();
                        }
                        else if (MenuInput == 3)
                        {
                            //Update existing project
                            Console.WriteLine("Which project would you like to Update?");
                            MyProjectService.Read();
                            Console.Write("\n> ");
                            var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                            var projectToUpdate = MyProjectService.Get(updateChoice);
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
                            MyProjectService.Read();
                            Console.Write("\n> ");
                            var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                            var projectToRemove = MyProjectService.Get(deleteChoice);
                            if (projectToRemove != null)
                            {
                                MyProjectService.Delete(deleteChoice);
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