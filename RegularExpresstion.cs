

namespace OopsPgm
{

    using System;
    using System.Text.RegularExpressions;

    class RegularExpresstion
    {
        public void Operation()
        {
           this.ReadData();
        }

        public void RetrieveInfo(string fname, string lname, string mno, string date)
        {
            ////this is sentance for given requirements
            string message = "Hello <<name>>, We have your full name as <<full name>> in our system your contact number is <<91-xxxxxxxxx>>, Please,let us know in case of any clarification Thank you BridgeLabz <<dd/mm/yyyy>>.";
            //// give string to change the position of names
            string patternForName = "<<name>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpresstion.showMatch(message, fname, patternForName);
            ////Pattern for changing full name from the sentence       
            string patternForfame = "<<full name>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpresstion.showMatch(message, fname + " " + lname, patternForfame);
            ////Pattern for changing mobile number from the sentence   
            string contactNumber = "<<91-xxxxxxxxx>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpresstion.showMatch(message, "91" + " " + mno, contactNumber);
            ////Pattern for changing Currrent date from the sentence   
            string Currentdate = "<<dd/mm/yyyy>>";
            DateTime today = DateTime.Today;
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpresstion.showMatch(message, today.ToString(), Currentdate);

            Console.WriteLine(message);

        }
       
        public static string showMatch(string text, string expression, string pattern)
        {
            ////creating regex class object for passing pattern
            Regex rgx = new Regex(pattern);
            string newString = rgx.Replace(text, expression);
            return newString;
        }
        public void ReadData()
        {
            ////Taking user input for first name
            Console.WriteLine("Enter your First name");
            string fname = Console.ReadLine();
            ////Taking user input for last name
            Console.WriteLine("Enter your Last name");
            string lname = Console.ReadLine();
            ////Taking user input for mobile
            Console.WriteLine("Enter your mobile number");
            string mobilenum = Console.ReadLine();
            ////creating object of dateTime class to calculate current date
            DateTime thisDay = DateTime.Today;
            ////storing current date in date variable
            string date = thisDay.ToString("d");
            if (Regex.IsMatch(mobilenum, @"[0-9]{10}") && Regex.IsMatch(fname, @"[a-zA-z]") && Regex.IsMatch(lname, @"[a-zA-z]"))
            {
                RetrieveInfo(fname, lname, mobilenum, date);
            }
            else
            {
                Console.WriteLine("Data is invalid,Try again");
            }
        }
    }
}