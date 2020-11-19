using System.Threading;
using static System.Console;
namespace ITBank_2._0
{

    class Account
    {
        public double Money { get; set; }
    }
    class Card : Account
    {
        private int sumDeb = 0;
        private int sumKred = 0;
        private int numDebCard;
        private int numCredCard;
        public bool link;
        Account[] accounts;
        public void CreatAccuonts(int n)
        {
            accounts = new Account[n];
            for (int i = 0; i < n; i++)
            {
                accounts[i] = new Account();
            }
        }
        public void LinkCardD(int IdCard)
        {
            if (IdCard > accounts.Length || IdCard < 1)
            {
                WriteLine("We dont  have this account. ");
                link = true;
            }
            else
            {
                numDebCard = IdCard;
                accounts[IdCard - 1].Money = sumDeb;
            }
        }
        public void LinkCardK(int IdCard)
        {
            if (IdCard > accounts.Length || IdCard < 1)
            {
                WriteLine("We dont  have this account.");
                link = true;
            }
            else
            {
                numCredCard = IdCard;
                accounts[IdCard - 1].Money = sumKred;
            }
        }
        public void AddMoney(double add, int IdCard)
        {
            accounts[IdCard - 1].Money += add;
            WriteLine("Loading...");
            Thread.Sleep(5000);
            WriteLine("Operation was a success.");
        }
        public void GetMoney(double get, int IdCard, int cardId)
        {
            bool credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                credit = accounts[i].Money < 0;
                if (credit == true)
                {
                    break;
                }
            }
            if (cardId == 2)
            {

                if (credit)
                {
                    WriteLine("You  have  unsecured loan on your accounts. ");
                }
                else
                {
                    accounts[IdCard - 1].Money -= get;
                    WriteLine("Loading...");
                    Thread.Sleep(5000);
                    WriteLine("Operation was a success.");
                }
            }
            else if (cardId == 1)
            {
                if (accounts[IdCard - 1].Money < get)
                {
                    WriteLine("You dont have enough money on account.  ");
                }
                else
                {
                    accounts[IdCard - 1].Money -= get;
                    WriteLine("Loading...");
                    Thread.Sleep(5000);
                    WriteLine("Operation was a success.");
                }
            }
        }
        public void ShowMoney(int IdCard)
        {
            WriteLine("Loading...");
            Thread.Sleep(5000);
            WriteLine("Operation was a success.");
            WriteLine($"In Your accont { accounts[IdCard - 1].Money} $.");
        }
        public void TransitMoney(int IdCard, double trans, int numAcc, int cardId)
        {
            bool credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                credit = accounts[i].Money < 0;
            }
            if (cardId == 1)
            {
                if (accounts[IdCard - 1].Money < trans)
                {
                    WriteLine("You dont have enough money on account.  ");
                }
                else
                {
                    accounts[IdCard - 1].Money -= trans;
                    accounts[numAcc].Money += trans;
                    WriteLine("Loading...");
                    Thread.Sleep(5000);
                    WriteLine("Operation was a success.");
                }
            }
            else if (cardId == 2)
            {
                if (credit)
                {
                    WriteLine("You  have  unsecured loan on your accounts. ");
                }
                else
                {
                    accounts[IdCard - 1].Money -= trans;
                    accounts[numAcc].Money += trans;
                    WriteLine("Loading...");
                    Thread.Sleep(5000);
                    WriteLine("Operation was a success.");
                }
            }
        }
        public void TransitMoney(int IdCard, double trans, int cardId)
        {
            bool credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                credit = accounts[i].Money < 0;
            }
            if (cardId == 1)
            {
                if (accounts[IdCard - 1].Money < trans)
                {
                    WriteLine("You dont have enough money on account.  ");
                }
                else
                {
                    accounts[IdCard - 1].Money -= trans;
                    WriteLine("Loading...");
                    Thread.Sleep(5000);
                    WriteLine("Operation was a success.");
                }
            }
            else if (cardId == 2)
            {
                if (credit)
                {
                    WriteLine("Loading...");
                    Thread.Sleep(5000);
                    WriteLine("You dont have enough money on account unsecured loan on your accounts. ");
                }
                else
                {
                    accounts[IdCard - 1].Money -= trans;
                    WriteLine("Loading...");
                    Thread.Sleep(5000);
                    WriteLine("Operation was a success.");
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                double add;
                double get;
                double trans;
                string name;
                string surname;
                string lastname;
                ulong scoreNum;

                //условные переменные
                int accForTrans = 0;
                int numDebCard;
                int numCredCard;
                int cond;
                int cond2;
                int condEnd = 0;
                int couter = 0;
                int cardIdD = 1;
                int cardIdK = 2;

                Card card = new Card();

                WriteLine("Wellcom to the ITBank.");

                WriteLine("Choose numbers of acounts, what you want to create. ");
                while (!int.TryParse(ReadLine(), out cond))
                {
                    WriteLine("Write correctly,it's not number");
                }
                card.CreatAccuonts(cond);

                Clear();

                do
                {
                    WriteLine("Choose  acount for debit card. ");
                    while (!int.TryParse(ReadLine(), out numDebCard))
                    {
                        WriteLine("Write correctly,it's not number.");
                    }
                    card.LinkCardD(numDebCard);

                    Clear();

                    WriteLine("Choose  acount for  credit card.");
                    while (!int.TryParse(ReadLine(), out numCredCard))
                    {
                        WriteLine("Write correctly,it's not number");
                    }
                    card.LinkCardK(numCredCard);

                    Clear();

                    if (card.link == true)
                    {
                        WriteLine("We have problem with registration,try again.");
                    }
                } while (card.link);
                do
                {
                    Clear();

                    WriteLine($"What you want to do?\n1)Add money to acount.\n2)Get Money from acount.\n3)Look score.\n4)Transition money.");
                    while (!int.TryParse(ReadLine(), out cond))
                    {
                        WriteLine("Write correctly,it's not number");
                    }

                    Clear();

                    switch (cond)
                    {
                        case 1:
                            WriteLine("Choose card \n1)Debit.\n2)Kredit.");
                            while (!int.TryParse(ReadLine(), out cond))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }

                            Clear();

                            WriteLine("How match do you want add money?");
                            while (!double.TryParse(ReadLine(), out add))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }
                            Clear();
                            if (cond == 1)
                            {
                                card.AddMoney(add, numDebCard);
                            }
                            else
                            {
                                card.AddMoney(add, numCredCard);

                            }

                            WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
                            while (!int.TryParse(ReadLine(), out condEnd))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }
                            break;
                        case 2:
                            WriteLine("Choose card \n1)Debit.\n2)Kredit.");
                            while (!int.TryParse(ReadLine(), out cond))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }

                            Clear();

                            WriteLine("How match do you want get money?");
                            while (!double.TryParse(ReadLine(), out get))
                            {
                                WriteLine("Write correctly,it's not number");
                            }
                            Clear();

                            if (cond == 1)
                            {
                                card.GetMoney(get, numDebCard, cardIdD);
                            }
                            else
                            {
                                card.GetMoney(get, numCredCard, cardIdK);
                            }

                            WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
                            while (!int.TryParse(ReadLine(), out condEnd))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }
                            break;
                        case 3:
                            WriteLine("Choose card \n1)Debit.\n2)Kredit.");
                            while (!int.TryParse(ReadLine(), out cond))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }

                            Clear();

                            if (cond == 1)
                            {
                                card.ShowMoney(numDebCard);
                            }
                            else
                            {
                                card.ShowMoney(numCredCard);
                            }

                            WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
                            while (!int.TryParse(ReadLine(), out condEnd))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }
                            break;
                        case 4:
                            WriteLine("Choose card \n1)Debit.\n2)Kredit.");
                            while (!int.TryParse(ReadLine(), out cond))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }

                            Clear();

                            WriteLine("How match do you want transit money?");
                            while (!double.TryParse(ReadLine(), out trans))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }

                            Clear();

                            WriteLine("Where are you want transit your money\n1)Your accounts.\n2)Other accounts.");
                            while (!int.TryParse(ReadLine(), out cond2))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }

                            Clear();

                            if (cond2 == 1)
                            {
                                WriteLine("Choose Acounts.");
                                while (!int.TryParse(ReadLine(), out accForTrans))
                                {
                                    WriteLine("Write correctly,it's not number.");
                                }
                                if (cond == 1)
                                {
                                    card.TransitMoney(numDebCard, trans, accForTrans, cardIdD);
                                }
                                else
                                {
                                    card.TransitMoney(numCredCard, trans, accForTrans, cardIdK);
                                }

                                WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
                                while (!int.TryParse(ReadLine(), out condEnd))
                                {
                                    WriteLine("Write correctly,it's not number.");
                                }
                            }
                            else
                            {
                                WriteLine("Write name of a recipient.");
                                name = ReadLine();


                                WriteLine("Write surname of a recipient.");
                                surname = ReadLine();


                                WriteLine("Write lastname of a recipient.");
                                lastname = ReadLine();


                                WriteLine("Write account number of a recipient (20 numbers). ");
                                do
                                {
                                    while (!ulong.TryParse(ReadLine(), out scoreNum))
                                    {
                                        WriteLine("Write correctly,it's not number.");
                                    }
                                    couter = 0;
                                    do
                                    {
                                        scoreNum /= 10;
                                        couter++;
                                    } while (scoreNum > 0);

                                    if (couter < 20 || couter > 20)
                                    {
                                        WriteLine("You have mistake, try again.");
                                    }
                                } while (couter < 20 || couter > 20);

                                Clear();

                                if (cond == 1)
                                {
                                    card.TransitMoney(numDebCard, trans, cardIdD);
                                }
                                else
                                {
                                    card.TransitMoney(numCredCard, trans, cardIdK);
                                }

                                WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
                                while (!int.TryParse(ReadLine(), out condEnd))
                                {
                                    WriteLine("Write correctly,it's not number.");
                                }
                            }
                            break;
                        default:
                            WriteLine("We dont have this peratioin,try again.");

                            WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
                            while (!int.TryParse(ReadLine(), out condEnd))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }
                            break;
                    }
                } while (condEnd == 1);
            }
        }
    }
}

