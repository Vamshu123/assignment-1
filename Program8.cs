using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsApp01
{
    class Program8
    {
        class teacher_accounts

        {

            public int id { get; set; }
            public string teachername { get; set; }
            public int Class { get; set; }
            public char section { get; set; }
            public string email { get; set; }

        }
        class ass1teacher_records

        {

            static public void add_teachers(teacher_accounts new_acc, List<teacher_accounts> teacher_list)
            {

                Console.WriteLine("\nEnter the number of teacher records to be added");
                int record_count = int.Parse(Console.ReadLine());


                for (int i = 0; i < record_count; i++)
                {
                    Console.WriteLine("\nEnter the teacher's ID :");
                    int ID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the teacher's name :");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the teacher email :");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Class :");
                    int clss = int.Parse(Console.ReadLine()); // reading class from user input

                    Console.WriteLine("Enter Section :");
                    char sec = Console.ReadLine()[0];  // reading signle char from user
                         

                    new_acc = new teacher_accounts();
                    new_acc.id = ID;
                    new_acc.teachername = name;
                    new_acc.Class = clss;
                    new_acc.section = sec;
                    new_acc.email = email;
                    teacher_list.Add(new_acc);

                }
            }




            static public void display_teachers(teacher_accounts new_acc, List<teacher_accounts> teacher_list)
            {
                

                for (int i = 0; i < teacher_list.Count; i++)

                {
                    Console.WriteLine("\n\nID = " + teacher_list[i].id);
                    Console.WriteLine("Teacher Name = " + teacher_list[i].teachername);
                    Console.WriteLine("Class = " + teacher_list[i].Class);
                    Console.WriteLine("Section = " + teacher_list[i].section);
                    Console.WriteLine("Teacher Email = " + teacher_list[i].email + "\n\n");
                }

                if (teacher_list.Count < 1)
                    Console.WriteLine("\n  No teacher's data found \n");

            }
            static public void update_teachers_data(List<teacher_accounts> teacher_list)
            {
                Console.WriteLine("Enter the teacher's id to update account ..");
                int update_id = int.Parse(Console.ReadLine());

                int index = teacher_list.FindIndex(x => x.id == update_id);
                if (index > -1)
                {
                    Console.WriteLine("Enter option \n1. Name \n2. Class\n3. Section\n4. email");
                    int option = int.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        Console.WriteLine("Enter new name to be updated ..");
                        string nn = Console.ReadLine();
                        teacher_list[index].teachername = nn;
                    }

                    if (option == 2)
                    {
                        Console.WriteLine("Enter new class to be updated ..");
                        int nc = int.Parse(Console.ReadLine());
                        teacher_list[index].Class = nc;
                    }

                    if (option == 3)
                    {
                        Console.WriteLine("Enter new section to be updated ..");
                        char ns = Console.ReadLine()[0];
                        teacher_list[index].section = ns;
                    }
                    if (option == 4)
                    {
                        Console.WriteLine("Enter new email to be updated..");
                        string ei = Console.ReadLine();
                        teacher_list[index].email = ei;
                    }

                }

                else
                    Console.WriteLine("\nIndex not found in records");

            }




            static public void delete_records(List<teacher_accounts> teacher_list)
            {
                Console.WriteLine("\nEnter the teacher's id to delete record ..");
                int delete_id = int.Parse(Console.ReadLine());
                int index = teacher_list.FindIndex(x => x.id == delete_id);

                if (index > -1)
                {
                    Console.WriteLine("\nTeacher's Name :" + teacher_list[index].teachername + "\nAllocated Class :" + teacher_list[index].Class + "\nAllocated Section :" + teacher_list[index].section + "\ngiven email:" + teacher_list[index].email);
                    Console.WriteLine("Will be deleted from records ..\n");
                    teacher_list.RemoveAt(index);
                }

                else
                    Console.WriteLine("ID not found in records \n");



            }
            static public void save_to_text_file(List<teacher_accounts> teacher_list)
            {
                string path_to_file = @"C:\Users\11035922\Desktop\teachers record.txt";
                string rec = "";


                for (int i = 0; i < teacher_list.Count; i++)
                {
                    rec += teacher_list[i].id + " " + teacher_list[i].teachername + " " + teacher_list[i].Class +
                        " " + teacher_list[i].section + " "+teacher_list[i].email+"\n";
                }

                File.WriteAllText(path_to_file, rec);

            }


            static void Main(string[] args)
            {


                List<teacher_accounts> teacher_list = new List<teacher_accounts>();


                teacher_accounts new_account = null;




                while (true)
                {
                    Console.WriteLine("Enter option \n 1. Add a record \n 2. Display record  \n 3. Update data\n 4. Delete record\n 5. Save the data to text file\n");
                    
                    int choice = int.Parse(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:
                            add_teachers(new_account, teacher_list);
                            break;

                        case 2:
                            display_teachers(new_account, teacher_list);
                            break;

                        case 3:
                            update_teachers_data(teacher_list);
                            break;

                        case 4:
                            delete_records(teacher_list);
                            Console.WriteLine("Deleted");
                            break;

                        case 5:
                            save_to_text_file(teacher_list);
                            Console.WriteLine("Saved....!!!");
                            break;
                        case 6:
                            break;




                    }

                    if (choice == 5 || choice == 6)  // breaking out of the while loop
                        break;

                }



            }

        }
    }
}
