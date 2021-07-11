using System;
using System.Diagnostics;
namespace Passwordman
{
    class Program
    {
        
        static int tableWidth = 73;

        static void PrintLine()
{
    Console.WriteLine(new string('-', tableWidth));
}

static void PrintRow(params string[] columns)
{
    int width = (tableWidth - columns.Length) / columns.Length;
    string row = "|";

    foreach (string column in columns)
    {
        row += AlignCentre(column, width) + "|";
    }

    Console.WriteLine(row);
}

static string AlignCentre(string text, int width)
{
    text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

    if (string.IsNullOrEmpty(text))
    {
        return new string(' ', width);
    }
    else
    {
        return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
    }
}
        public void exit_code()
        {  
           System.Environment.Exit(0); 
        }  

        
        
        public void get_secure_pass(){
            string first="",middle="",second="",last="";
            Random random = new Random();
            for(int i=0;i<7;i++)
            {
                int a = random.Next(0, 26);
                char ch = (char)('a' + a);
                first = first + ch;
            }
            for(int i=0;i<1;i++)
            {
                int a = random.Next(0,6);
                char ch = (char)('!' + a);
                middle = middle + ch;
            }
            for(int i=0;i<3;i++)
            {
                int a = random.Next(0, 26);
                char ch = (char)('a' + a);
                second = second + ch;
            }
            for(int i=0;i<1;i++)
            {
                int a = random.Next(0,6);
                char ch = (char)('#' + a);
                last = last + ch;
            }
            heading();
            Console.ForegroundColor = ConsoleColor.Green;
           
            Console.Write("\n[+] your super strong password is => ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(first+middle+second+last);
            Console.ResetColor();
            Console.WriteLine("\n--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n[*] Press any Key To go Back");
            Console.ResetColor();
            last = Console.ReadLine();
            Console.Clear();
        }

        public void heading(){
            Console.Clear();
            string banner = run_cmd("banner.py");
            Console.WriteLine(banner); 
        }

         
        public string run_cmd(string filename)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"/usr/bin/python3";
            var script = @"/home/ranger/c_sharp/"+filename;
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            //var errors = "";
            var results = "";
            using(var process = Process.Start(psi)){
                //errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }
            return results;
        }

        public string run_cmds(string filename,string name , string password)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"/usr/bin/python3";
            var script = @"/home/ranger/c_sharp/"+filename;
            psi.Arguments = $"\"{script}\" \"{name}\" \"{password}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            //var errors = "";
            var results = "";
            using(var process = Process.Start(psi)){
                //errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }
            return results;
        }

        public string run_cmdss(string filename,string name)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"/usr/bin/python3";
            var script = @"/home/ranger/c_sharp/"+filename;
            psi.Arguments = $"\"{script}\" \"{name}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            //var errors = "";
            var results = "";
            using(var process = Process.Start(psi)){
               // errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }
            return results;
        }

        public void show_password(){
            Console.Clear();
            heading();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Showing Decrypted Password"));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.ResetColor();
            string k = run_cmd("showdb.py");
            Console.WriteLine(k);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("[*] Press any Key To go Back");
            Console.ResetColor();
            k = Console.ReadLine();
            Console.Clear();
        }

        public void insert_password(){
            heading();
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Enter The Name and Password which need to Be saved"));
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.Write("Enter the name : ");
            var name = Console.ReadLine();
            Console.Write("\nEnter password : ");
            var password = Console.ReadLine();
            string k = run_cmds("addusr.py",name,password);
            Console.WriteLine(k);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("[*] Press any Key To go Back");
            Console.ResetColor();
            k = Console.ReadLine();
            Console.Clear();
        }

        public void delete_password(){
            heading();
            Console.ForegroundColor=ConsoleColor.DarkYellow;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "enter the ID which need to be deleted"));
            Console.ResetColor();
            string k = run_cmd("showdb.py");
            Console.WriteLine(k);
            Console.ForegroundColor=ConsoleColor.DarkMagenta;
            Console.Write("enter the ID : ");
            var num = Console.ReadLine();
            Console.ResetColor();
            k = run_cmdss("deldb.py",num);
            Console.WriteLine(k);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("[*] Press any Key To go Back");
            Console.ResetColor();
            k = Console.ReadLine();
            Console.Clear();


        }

        static void Main(string[] args)
        {
            string pass,username;
            bool log = false;
            Program prog = new Program();
            prog.heading();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Enter the usename and password "));
            
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.Write("Enter username\t:\t");
            username = Console.ReadLine();
            Console.Write("Enter user password\t:\t");
            pass = Console.ReadLine();
            if(username=="root" && pass=="toor")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" \n[+]\tSucessfully loggedin!!!");
                Console.ResetColor();
                log = true;
                Console.Clear();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[-] false login!!!");
                Console.ResetColor();
                log = false;
            }
            while(log){
                string cases;
                prog.heading();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Select The Option Below"));
            
                Console.ResetColor();
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("1. show passwords ");
                Console.WriteLine("2. Add password ");
                Console.WriteLine("3. Delete Password");
                Console.WriteLine("4. Get strong password suggestion");
                Console.WriteLine("5. Exit");
                Console.WriteLine("------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("Enter your Option : ");
                cases = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
                
                switch(cases){
                    case "1":
                        prog.show_password();
                        break;
                    case "2":
                        prog.insert_password();
                        break ; 
                    case "3":
                        prog.delete_password(); 
                        break;
                    case "4":
                        prog.get_secure_pass(); 
                        break;
                    case "5":
                        prog.exit_code(); 
                        break; 
                }
            }

        }
    }
}