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
                    Console.WriteLine("enter 1 for add person");
                    Console.WriteLine("enter 2 to update ");
                   
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
                    }
                    Console.WriteLine("enter y to continue");
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
    