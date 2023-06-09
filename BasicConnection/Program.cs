﻿using System.Data;
using System.Data.SqlClient;
using BasicConnection.Context;
using BasicConnection.Controller;
using BasicConnection.Model;
using BasicConnection.View;

namespace BasicConnection;

public class Program
{
    private UniversityController universityController = new();
    private MenuView menuView = new();
    
    public static void Menu()
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("|                  MENU                 |");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("| 1.   Insert                           |");
        Console.WriteLine("| 2.   Select                           |");
        Console.WriteLine("| 3.   Update                           |");
        Console.WriteLine("| 4.   Delete                           |");
        Console.WriteLine("| 5.   Insert to ALL                    |");
        Console.WriteLine("| 6.   Get ALL                          |");
        Console.WriteLine("| 7.   Get Profiling                    |");
        Console.WriteLine("| 8.   Get GPA = 4                      |");
        Console.WriteLine("| 9.   Get All EMP                      |");
        Console.WriteLine("| 10.  Exit                             |");
        Console.WriteLine("-----------------------------------------");
        Console.Write("Pilih menu : ");
    }

    public static void Main()
    {

        int choice;
        do {
            Menu();
            choice = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("-----------------------------------------");

            switch (choice) {
                case 1:
                    menuView.Insert();
                    int tabel = Convert.ToInt32(Console.ReadLine());
                    InsertTables(tabel);
                    break;

                case 2:
                    Console.WriteLine("1. University");
                    Console.WriteLine("2. Education");
                    Console.Write("Pilih tabel yang akan di tampilkan : ");
                    int tabel2 = Convert.ToInt32(Console.ReadLine());
                    if (tabel2 == 1) {
                        universityController.GetAll();
                    }

                    if (tabel2 == 2) {
                        Console.WriteLine("\nSELECT ALL FROM EDUCATION");
                        Console.WriteLine("-----------------------------------------");
                        var results = Education.GetEducation();
                        foreach (var result in results) {
                            Console.WriteLine("Id: " + result.Id);
                            Console.WriteLine("Major: " + result.Major);
                            Console.WriteLine("Degree: " + result.Degree);
                            Console.WriteLine("GPA: " + result.GPA);
                            Console.WriteLine("Universty Id : " + result.UniversityId);
                            Console.WriteLine("-----------------------------------------");
                        }
                    }

                    //Console.ReadKey();
                    //Console.Clear();
                    break;

                case 3:
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1. University");
                    Console.WriteLine("2. Education");
                    Console.Write("Pilih tabel yang akan di Update : ");
                    int tabel3 = Convert.ToInt32(Console.ReadLine());
                    if (tabel3 == 1) {
                        Console.WriteLine("-----------------------------------------");
                        var university1 = new University();
                        Console.Write("\nMasukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        university1.Id = id;

                        Console.Write("Masukkan Nama : ");
                        var name3 = Console.ReadLine();
                        university1.Name = name3;

                        var result = University.UpdateUniversity(university1);
                        if (result > 0) {
                            Console.WriteLine("Update success");
                        }
                        else {
                            Console.WriteLine("Update Failed");
                        }
                    }

                    if (tabel3 == 2) {
                        Console.WriteLine("-----------------------------------------");
                        var education1 = new Education();
                        Console.Write("\nMasukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Major: ");
                        string major = Console.ReadLine();
                        Console.Write("Degree: ");
                        string degree = Console.ReadLine();
                        Console.Write("GPA: ");
                        string gpa = Console.ReadLine();
                        Console.Write("Universty Id : ");
                        int univ_id = Convert.ToInt32(Console.ReadLine());

                        education1.Id = id;
                        education1.Major = major;
                        education1.Degree = degree;
                        education1.GPA = gpa;
                        education1.UniversityId = univ_id;

                        var results = Education.UpdateEducation(education1);
                        if (results > 0) {
                            Console.WriteLine("Update success");
                        }
                        else {
                            Console.WriteLine("Update Failed");
                        }
                    }

                    break;

                case 4:
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1. University");
                    Console.WriteLine("2. Education");
                    Console.Write("Pilih tabel yang akan di hapus : ");
                    int tabel4 = Convert.ToInt32(Console.ReadLine());
                    if (tabel4 == 1) {
                        Console.WriteLine("-----------------------------------------");
                        var university2 = new University();
                        Console.Write("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        university2.Id = id;

                        var result = University.DeleteUniversity(university2);
                        if (result > 0) {
                            Console.WriteLine("Delete success");
                        }
                        else {
                            Console.WriteLine("Delete Failed");
                        }
                    }

                    else if (tabel4 == 2) {
                        Console.WriteLine("-----------------------------------------");
                        var education2 = new Education();
                        Console.Write("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        education2.Id = id;

                        var result = Education.DeleteEducation(education2);
                        if (result > 0) {
                            Console.WriteLine("Delete success");
                        }
                        else {
                            Console.WriteLine("Delete Failed");
                        }
                    }

                    break;

                case 5:
                    Employee.PrintOutEmployee();
                    Console.WriteLine("\n-----------------------------------------");
                    break;

                case 6:
                    Console.WriteLine("\nSELECT ALL FROM EMP");
                    Console.WriteLine("------------------------------------------------------------");
                    var results1 = Employee.GetEmployee();
                    foreach (var results2 in results1) {
                        Console.WriteLine("Id            : " + results2.Id);
                        Console.WriteLine("NIK           : " + results2.Nik);
                        Console.WriteLine("First Name    : " + results2.FirstName);
                        Console.WriteLine("Last Name     : " + results2.LastName);
                        Console.WriteLine("Birthdate     : " + results2.Birthdate);
                        Console.WriteLine("Gender        : " + results2.Gender);
                        Console.WriteLine("Hiring Date   : " + results2.HiringDate);
                        Console.WriteLine("Email         : " + results2.Email);
                        Console.WriteLine("Phone Number  : " + results2.PhoneNumber);
                        Console.WriteLine("Department ID : " + results2.DepartmentId);
                        Console.WriteLine("-------------------------------------------------------");
                    }

                    break;

                case 7:
                    Console.WriteLine("\nSELECT ALL FROM PROFILING");
                    Console.WriteLine("------------------------------------------------------------");
                    var results3 = Profiling.GetProfiling();
                    foreach (var results4 in results3) {
                        Console.WriteLine("Employee ID        : " + results4.EmployeeId);
                        Console.WriteLine("Education ID       : " + results4.EducationId);
                        Console.WriteLine("-------------------------------------------------------");
                    }

                    break;

                case 8:
                    var educations = Education.GetEducation();
                    var getGpa = educations.Where(u => u.GPA == "4");

                    foreach (var gpa in getGpa) {
                        gpa.Output();
                    }

                    break;

                case 9:
                    var educationGet = Education.GetEducation();
                    var employeeGet = Employee.GetEmployee();
                    var profilingGet = Profiling.GetProfiling();
                    var universityGet = University.GetUniversities();

                    var getAll = from emp in employeeGet
                                 join pro in profilingGet on emp.Id equals pro.EmployeeId
                                 join edu in educationGet on pro.EducationId equals edu.Id
                                 join uni in universityGet on edu.UniversityId equals uni.Id
                                 select new {
                                     NIK = emp.Nik,
                                     Fullname = emp.FirstName + " " + emp.LastName,
                                     Birthdate = emp.Birthdate,
                                     Gender = emp.Gender,
                                     HiringDate = emp.HiringDate,
                                     Email = emp.Email,
                                     PhoneNumber = emp.PhoneNumber,
                                     Major = edu.Major,
                                     Degree = edu.Degree,
                                     GPA = edu.GPA,
                                     Univesity = uni.Name
                                 };

                    foreach (var get in getAll) {
                        Console.WriteLine($"NIK         = {get.NIK}");
                        Console.WriteLine($"Fullname    = {get.Fullname}");
                        Console.WriteLine($"Birthdate   = {get.Birthdate}");
                        Console.WriteLine($"Gender      = {get.Gender}");
                        Console.WriteLine($"HiringDate  = {get.HiringDate}");
                        Console.WriteLine($"Email       = {get.Email}");
                        Console.WriteLine($"PhoneNumber = {get.PhoneNumber}");
                        Console.WriteLine($"Major       = {get.Major}");
                        Console.WriteLine($"Degree      = {get.Degree}");
                        Console.WriteLine($"GPA         = {get.GPA}");
                        Console.WriteLine($"Univesity   = {get.Univesity}");
                        Console.WriteLine("-------------------------------------------------------");
                    }


                    break;

                default:
                    Console.WriteLine("Input Invalid");
                    break;
            }
        } while (choice != 10);
    }

    public static void InsertTables(int tabel)
    {
        switch (tabel) {
            case 1:
                Console.WriteLine("-----------------------------------------");
                var university = new University();
                Console.Write("Masukkan nama : ");
                string nama = Console.ReadLine();
                university.Name = nama;

                universityController.Insert(university);
                break;
            case 2:
                Console.WriteLine("-----------------------------------------");
                var education = new Education();
                Console.Write("Masukkan Major : ");
                var major = Console.ReadLine();
                education.Major = major;

                Console.Write("Masukkan Degree : ");
                var degree = Console.ReadLine();
                education.Degree = degree;

                Console.Write("Masukkan GPA : ");
                var gpa = Console.ReadLine();
                education.GPA = gpa;

                Console.Write("University ID : ");
                var university_id = Convert.ToInt32(Console.ReadLine());
                education.UniversityId = university_id;

                /*var result = Education.InsertEducation(education);
                if (result > 0) {
                    Console.WriteLine("Insert success.");
                }
                else {
                    Console.WriteLine("Insert failed.");
                }*/
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    }
}