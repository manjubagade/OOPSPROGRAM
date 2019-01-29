namespace OopsPgm
{
    using System;

    /// <summary>
    /// ADESSS
    /// </summary>
    class AddressBook
    {
        public void AddressBookDetails()
        {
            try
            {
                int caseCondition;
                string doCondition = null;
                do
                {
                    Console.WriteLine("PRESS 1 FOR ADDING THE DETAILS");
                    Console.WriteLine("PRESS 2 FOR UPDATE THE DETAILS ");
                    Console.WriteLine("PRESS 3 FOR LIST OF DETAILS");
                    Console.WriteLine("PRESS 4 FOR DELETE THE DETAILS");
                    Console.WriteLine("PRESS 5 FOR ORDERBYLAST NAME");
                    Console.WriteLine("PRESS 6 FOR ORDERBYZIPCODE");

                    caseCondition = Convert.ToInt32(Console.ReadLine());
                    switch (caseCondition)
                    {
                        case 1:
                            AddressBookUtil addutil = new AddressBookUtil();
                            addutil.AddPerson();
                            break;
                        case 2:
                            AddressBookUtil addutil1 = new AddressBookUtil();
                            addutil1.Update();
                            break;
                        case 3:
                            AddressBookUtil addlist = new AddressBookUtil();
                            addlist.AllList();
                            break;
                        case 4:
                            AddressBookUtil listdel = new AddressBookUtil();
                            listdel.Delete();
                            break;
                        case 5:
                            AddressBookUtil sortlast = new AddressBookUtil();
                            sortlast.SortByLastName();
                            break;
                        case 6:
                            AddressBookUtil sortZip = new AddressBookUtil();
                            sortZip.SortByZipCode();
                            break;




                    }
                    Console.WriteLine("ENTER THE Y FOR CONTINUE N FOR STOP");
                    doCondition = Console.ReadLine();
                }
                while (doCondition.Equals("y"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
    