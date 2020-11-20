using Classes;
using static System.Console;
namespace ITBank_2._0
{
    class Program
    {
        static int ChooseCard(ref int cond1)
        {

            WriteLine("Choose card \n1)Debit.\n2)Kredit.");
            while (!int.TryParse(ReadLine(), out cond1))
            {
                WriteLine("Write correctly,it's not number.");
            }
            return cond1;
        }
        static int ChooseNum(ref int cond2)
        {
            WriteLine("Choose number of card");
            while (!int.TryParse(ReadLine(), out cond2))
            {
                WriteLine("Write correctly,it's not number.");
            }
            return cond2;
        }
        static int ChooreSur(ref int condEnd)
        {
            WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
            while (!int.TryParse(ReadLine(), out condEnd))
            {
                WriteLine("Write correctly,it's not number.");
            }
            return condEnd;
        }
        static void Main(string[] args)
        {
            double add;
            double get;
            double trans;
            string name;
            string surname;
            string lastname;
            string scoreNum;
            int[] arrScoreNum;
            int accForTrans = 0;

            //условные переменные
            int cond;
            int cond1 = 0;
            int cond2 = 0;
            int condEnd = 0;

            Card card = new Card();

            WriteLine("Wellcom to the ITBank.");
            do
            {
                WriteLine("Choose numbers of acounts, what you want to create. ");
                while (!int.TryParse(ReadLine(), out cond))
                {
                    WriteLine("Write correctly,it's not number");
                }
                card.CreatAccuonts(cond);

                Clear();

                WriteLine("Choose how mach you want have debit card. ");
                while (!int.TryParse(ReadLine(), out cond))
                {
                    WriteLine("Write correctly,it's not number");
                }
                card.LinkCardD(cond);

                Clear();

                WriteLine("Choose how mach you want have credit card. ");
                while (!int.TryParse(ReadLine(), out cond))
                {
                    WriteLine("Write correctly,it's not number");
                }

                card.LinkCardK(cond);

                Clear();

                if (card.Link == true)
                {
                    WriteLine("We have problem with registration,try again.");
                }
            } while (card.Link);
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
                        ChooseCard(ref cond1);
                        Clear();

                        ChooseNum (ref cond2);
                        Clear();

                        WriteLine("How match do you want add money?");
                        while (!double.TryParse(ReadLine(), out add))
                        {
                            WriteLine("Write correctly,it's not number.");
                        }

                        Clear();

                        if (cond1 == 1)
                        {
                            card.AddMoney(add, cond2, cond1);
                        }
                        else
                        {
                            card.AddMoney(add, cond2, cond1);

                        }
                        ChooreSur(ref condEnd);
                        Clear();
                        WriteLine("Goodbuy my friend");
                        break;
                    case 2:
                        ChooseCard(ref cond1);
                        Clear();

                        ChooseNum(ref cond2);
                        Clear();

                        WriteLine("How match do you want get money?");
                        while (!double.TryParse(ReadLine(), out get))
                        {
                            WriteLine("Write correctly,it's not number");
                        }
                        Clear();

                        if (cond1 == 1)
                        {
                            card.GetMoney(get, cond2, cond1);
                        }
                        else
                        {
                            card.GetMoney(get, cond2, cond1);
                        }

                        ChooreSur(ref condEnd);
                        Clear();
                        WriteLine("Goodbuy my friend");
                        break;
                    case 3:
                        ChooseCard(ref cond1);
                        Clear();

                        ChooseNum(ref cond2);
                        Clear();

                        if (cond1 == 1)
                        {
                            card.ShowMoney(cond2, cond1);
                        }
                        else
                        {
                            card.ShowMoney(cond2, cond1);
                        }

                        ChooreSur(ref condEnd);
                        Clear();
                        WriteLine("Goodbuy my friend");
                        break;

                    case 4:
                        ChooseCard(ref cond1);
                        Clear();

                        ChooseNum(ref cond2);
                        Clear();

                        WriteLine("How match do you want transit money?");
                        while (!double.TryParse(ReadLine(), out trans))
                        {
                            WriteLine("Write correctly,it's not number.");
                        }

                        Clear();

                        WriteLine("Where are you want transit your money\n1)Your accounts.\n2)Other accounts.");
                        while (!int.TryParse(ReadLine(), out cond))
                        {
                            WriteLine("Write correctly,it's not number.");
                        }

                        Clear();

                        if (cond == 1)
                        {
                            WriteLine("Choose Acounts.");

                            while (!int.TryParse(ReadLine(), out accForTrans))
                            {
                                WriteLine("Write correctly,it's not number.");
                            }
                            if (cond1 == 1)
                            {
                                card.TransitMoney(trans, cond2, accForTrans, cond1);
                            }
                            else
                            {
                                card.TransitMoney(trans, cond2, accForTrans, cond1);
                            }
                            ChooreSur(ref condEnd);
                            Clear();
                            WriteLine("Goodbuy my friend");
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
                                scoreNum = ReadLine();
                                char[] arrScoreNumChar = scoreNum.ToCharArray();
                                arrScoreNum = new int[arrScoreNumChar.Length];
                                for (int i = 0; i < arrScoreNum.Length; i++)
                                {
                                    arrScoreNum[i] = int.Parse(arrScoreNumChar[i].ToString());
                                }
                                if (arrScoreNum.Length < 20 || arrScoreNum.Length > 20)
                                {
                                    WriteLine("You have mistake, try again.");
                                }
                            } while (arrScoreNum.Length < 20 || arrScoreNum.Length > 20);

                            Clear();

                            if (cond1 == 1)
                            {
                                card.TransitMoney(trans, cond2, cond1);
                            }
                            else
                            {
                                card.TransitMoney(trans, cond2, cond1);
                            }

                            ChooreSur(ref condEnd);
                            Clear();
                            WriteLine("Goodbuy my friend");
                        }
                        break;
                    default:
                        WriteLine("We dont have this peratioin,try again.");

                        ChooreSur(ref condEnd);
                        Clear();
                        WriteLine("Goodbuy my friend");
                        break;
                }
            } while (condEnd == 1);
        }
    }
}


