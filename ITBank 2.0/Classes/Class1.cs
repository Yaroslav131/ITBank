using System.Threading;
using static System.Console;
namespace Classes
{ 
    public class Account
    {
        public double Money { get; set; }
    }
    public class Card : Account
    {
        Account[] accounts;
        public bool Link { get; set; }
        private bool link;
        public int IdCard { get; set; }
        private int idCard;
        public int[] ArrCardD { get; set; }
        private int[] arrCardD;
        public int[] ArrCardK { get; set; }
        private int[] arrCardK;
        public bool Credit { get; set; }
        private bool credit;

        public void CreatAccuonts(int n)
        {
            accounts = new Account[n];
            for (int i = 0; i < n; i++)
            {
                accounts[i] = new Account();
            }
        }
        public void LinkCardD(int n)
        {
            for (int i = 0; i < n; i++)
            {
                arrCardD = new int[n];
                WriteLine("Choose  acount for debit card. ");
                while (!int.TryParse(ReadLine(), out idCard))
                {
                    WriteLine("Write correctly,it's not number.");
                }

                if (idCard > accounts.Length || idCard < 1)
                {
                    WriteLine("We dont  have this account. ");
                    link = true;
                }
                else
                {
                    arrCardD[i] = idCard - 1;
                    accounts[idCard - 1].Money = 0;
                }
            }
        }
        public void LinkCardK(int n)
        {
            for (int i = 0; i < n; i++)
            {
                arrCardK = new int[n];

                WriteLine("Choose  acount for credit card. ");
                while (!int.TryParse(ReadLine(), out idCard))
                {
                    WriteLine("Write correctly,it's not number.");
                }

                if (idCard > accounts.Length || idCard < 1)
                {
                    WriteLine("We dont  have this account.");
                    link = true;
                }
                else
                {
                    arrCardK[i] = idCard - 1;
                    accounts[idCard - 1].Money = 0;
                }
            }
        }
        public void AddMoney(double add, int idCard, int cond)
        {
            if (cond == 1)
            {
                if (idCard > arrCardD.Length || idCard < arrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    accounts[arrCardD[idCard - 1]].Money += add;
                    WriteLine("Loading...");
                    Thread.Sleep(2500);
                    Clear();
                    WriteLine("Operation was a success.");
                }
            }
            else
            {
                if (idCard > arrCardK.Length || idCard < arrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    accounts[arrCardK[idCard - 1]].Money += add;
                    WriteLine("Loading...");
                    Thread.Sleep(2500);
                    Clear();
                    WriteLine("Operation was a success.");
                }
            }
        }
        public void GetMoney(double get, int idCard, int cond)
        {
            credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                credit = accounts[i].Money < 0;
                if (credit == true)
                {
                    break;
                }
            }
            if (cond == 2)
            {
                if (idCard > arrCardK.Length || idCard < arrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (credit)
                    {
                        WriteLine("You  have  unsecured loan on your accounts. ");
                    }
                    else
                    {
                        accounts[arrCardK[idCard - 1]].Money -= get;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
            else if (cond == 1)
            {
                if (idCard > arrCardD.Length || idCard < arrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (accounts[arrCardD[idCard - 1]].Money < get)
                    {
                        WriteLine("You dont have enough money on account.  ");
                    }
                    else
                    {
                        accounts[arrCardD[idCard - 1]].Money -= get;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
        }
        public void ShowMoney(int idCard, int cond)
        {
            WriteLine("Loading...");
            Thread.Sleep(2500);
            Clear();
            WriteLine("Operation was a success.");
            if (cond == 1)
            {
                if (idCard > arrCardD.Length || idCard < arrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    WriteLine($"In Your accont { accounts[arrCardD[idCard - 1]].Money }$.");
                }
            }
            else
            {
                if (idCard > arrCardK.Length || idCard < arrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    WriteLine($"In Your accont { accounts[arrCardK[idCard - 1]].Money }$.");
                }
            }
        }
        public void TransitMoney(double trans, int idCard, int numAcc, int cond)
        {
            bool credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                credit = accounts[i].Money < 0;
            }
            if (cond == 1)
            {
                if (idCard > arrCardD.Length || idCard < arrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (accounts[arrCardD[idCard - 1]].Money < trans)
                    {
                        WriteLine("You dont have enough money on account.  ");
                    }
                    else
                    {
                        accounts[arrCardD[idCard - 1]].Money -= trans;
                        accounts[numAcc - 1].Money += trans;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
            else if (cond == 2)
            {
                if (idCard > arrCardK.Length || idCard < arrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (credit)
                    {
                        WriteLine("You  have  unsecured loan on your accounts. ");
                    }
                    else
                    {
                        for (int i = 0; i < arrCardD.Length; i++)
                        {
                            if (link = numAcc - 1 == arrCardD[i])
                            {
                                Clear();
                                WriteLine("Transition beetwen debit and credit card is prohibited. ");
                                break;
                            }
                        }
                        if (link == false)
                        {
                            Clear();
                            accounts[arrCardK[idCard - 1]].Money -= trans;
                            accounts[numAcc - 1].Money += trans;
                            WriteLine("Loading...");
                            Thread.Sleep(2500);
                            Clear();
                            WriteLine("Operation was a success.");
                        }
                    }
                }
            }
        }
        public void TransitMoney(double trans, int idCard, int cond)
        {
            credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                credit = accounts[i].Money < 0;
            }
            if (cond == 1)
            {
                if (idCard > arrCardD.Length || idCard < arrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (accounts[idCard - 1].Money < trans)
                    {
                        WriteLine("You dont have enough money on account.  ");
                    }
                    else
                    {
                        accounts[arrCardD[idCard - 1]].Money -= trans;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");

                    }
                }
            }
            else if (cond == 2)
            {
                if (idCard > arrCardK.Length || idCard < arrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (credit)
                    {
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("You dont have enough money on account unsecured loan on your accounts. ");
                    }
                    else
                    {
                        accounts[arrCardK[idCard - 1]].Money -= trans;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
        }
    }
}
