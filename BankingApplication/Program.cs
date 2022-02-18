using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    public class LimitExceeded : Exception
    {
        public override string Message
        {
            get
            {
                return "amount limit exceeded";
            }
        }

        public class Employee
        {
            public string id { get; set; }
            public string name { get; set; }
            public string age { get; set; }
            public string mobileno { get; set; }
            public string accounttype { get; set; }
            public string accountno { get; set; }
            public int balance { get; set; }
        }

        public class program
        {
            static void Main(string[] args)
            {
                bool ATMReq = false;
                Console.WriteLine("Enter ATM is required or not if yes press 1 otherwise press 0:-");
                ATMReq = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                if (ATMReq)
                {
                    ATM at1 = new ATM();
                    ATM.ATM1 obj = new ATM.ATM1(at1.ATMYesSel);
                    obj();
                }
                else
                {
                }
            }
                 
        }
        public class ATM
        {

            public delegate void ATM1();
            bool deposit = false;
            int nooftransactions = 0;
            string Accounttype;
            int balamount = 10000;
            int depamnt;
            int withdrwamnt;
            int i = 1;
            public List<Employee> lstemployee = new List<Employee>();
            public void ATMYesSel()
            {
                Console.WriteLine("Thanks for choosing ATM");
                while (i <= 10)
                {
                    Employee emp1 = new Employee();
                    Console.WriteLine("Enter the name");
                    string name = Console.ReadLine();
                    emp1.name = name;
                    Console.WriteLine("Enter the age");
                    string _age = Console.ReadLine();
                    emp1.age = _age;
                    Console.WriteLine("Enter the Id");
                    string id = Console.ReadLine();
                    emp1.id = id;
                    Console.WriteLine("Enter the mobileno");
                    string mobileno = Console.ReadLine();
                    emp1.mobileno = mobileno;
                    Console.WriteLine("Enter the accounttype");
                    string accounttype = Console.ReadLine();
                    emp1.accounttype = accounttype;
                    Console.WriteLine("for deposit enter 1 and for withdraw enter 0?");
                    deposit = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                    if (deposit)
                    {
                        Accounttype = accounttype;
                        try
                        {
                            switch (Accounttype)
                            {
                                case "savings":
                                    Console.WriteLine("Account type is savings");
                                    Console.WriteLine("Enter the amount you want to deposit");
                                    depamnt = int.Parse(Console.ReadLine());
                                    if (depamnt > 100000)
                                    {
                                        throw new LimitExceeded();
                                    }
                                    else
                                    {
                                        balamount = balamount + depamnt;
                                        Console.WriteLine("Deposited Amount is:-" + depamnt);
                                        Console.WriteLine("Balance Amount is:-" + balamount);
                                    }
                                    break;
                                case "current":
                                    Console.WriteLine("Account type is current");
                                    Console.WriteLine("Enter the amount you want to deposit");
                                    depamnt = Convert.ToInt32(Console.ReadLine());
                                    if (depamnt > 200000)
                                    {
                                        throw new LimitExceeded();
                                    }
                                    else
                                    {
                                        balamount = balamount + depamnt;
                                        Console.WriteLine("Deposited Amount is:-" + depamnt);
                                        Console.WriteLine("Balance Amount is:-" + balamount);
                                    }
                                    break;
                                case "child":
                                    Console.WriteLine("Account type is child");
                                    Console.WriteLine("Enter the amount you want to deposit");
                                    depamnt = Convert.ToInt32(Console.ReadLine());
                                    if (depamnt > 50000)
                                    {
                                        throw new LimitExceeded();
                                    }
                                    else
                                    {
                                        balamount = balamount + depamnt;
                                        Console.WriteLine("Deposited Amount is:-" + depamnt);
                                        Console.WriteLine("Balance Amount is:-" + balamount);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Please enter valid account type");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        catch (LimitExceeded ex1)
                        {
                            Console.WriteLine("Result:-" + ex1.Message);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        if (nooftransactions < 3)
                        {
                            Console.WriteLine("Enter amount to withdraw:-");
                            withdrwamnt = Convert.ToInt32(Console.ReadLine());
                            if (balamount >= withdrwamnt)
                            {
                                balamount = balamount - withdrwamnt;
                                Console.WriteLine("amount withdrawn successfully.balance is " + balamount);
                                nooftransactions++;
                            }
                            else
                            {
                                Console.WriteLine("insufficient bal");
                            }
                        }
                        else
                        {
                            Console.WriteLine("maximum limit exceeded");
                            balamount = balamount - 500;
                            balamount = balamount - withdrwamnt;
                            Console.WriteLine("Balance is:" + balamount);
                        }
                    }
                    emp1.balance = balamount;
                    lstemployee.Add(emp1);
                    Console.WriteLine("Employee details are:");
                    foreach (Employee e in lstemployee)
                    {
                        Console.WriteLine("{0}||{1}||{2}||{3}||{4}||{5}", e.id, e.name, e.age, e.mobileno, e.accounttype, e.balance);
                    }
                }
                i++;
            }
        }
       










    }
}
