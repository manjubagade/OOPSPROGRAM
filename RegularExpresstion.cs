
namespace OopsPgm
{

    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Regular expresstion using replace the string word
    /// </summary>
  public class RegularExpresstion
    {
        /// <summary>
        /// the regular express
        /// </summary>
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
            message = RegularExpresstion.ShowMatch(message, fname, patternForName);
            ////Pattern for changing full name from the sentence       
            string patternForfame = "<<full name>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpresstion.ShowMatch(message, fname + " " + lname, patternForfame);
            ////Pattern for changing mobile number from the sentence   
            string contactNumber = "<<91-xxxxxxxxx>>";
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpresstion.ShowMatch(message, "91" + " " + mno, contactNumber);
            ////Pattern for changing Currrent date from the sentence   
            string Currentdate = "<<dd/mm/yyyy>>";
            DateTime today = DateTime.Today;
            ////using showmatch static method of regularexexpression class to replace the pattern with valid data
            message = RegularExpresstion.ShowMatch(message, today.ToString(), Currentdate);
            Console.WriteLine(message);
        }
       
        public static string ShowMatch(string text, string expression, string pattern)
        {
            ////creating regex class object for passing pattern
            Regex rgx = new Regex(pattern);
            string newString = rgx.Replace(text, expression);
            return newString;
        }
        public void ReadData()
        {
            ////take the input from usr
            Console.WriteLine("ENTER THE FIRST NAME");
            string fname = Console.ReadLine();
            ////Take the input from usr
            Console.WriteLine("ENTER THE LAST NAME");
            string lname = Console.ReadLine();
            ////Take the input from usr
            Console.WriteLine("ENTER THE VALID MOBILE NUMBER");
            string mobilenum = Console.ReadLine();
            ////create one datetime obj
            DateTime thisDay = DateTime.Today;
            ////storing current date in date variable
           //// string date = thisDay.ToString("d");
           string date = thisDay.ToString("D");
            date = thisDay.ToString("g");
            if (Regex.IsMatch(mobilenum, @"[0-9]{10}") && Regex.IsMatch(fname, @"[a-zA-z]") && Regex.IsMatch(lname, @"[a-zA-z]"))
            {
                RetrieveInfo(fname, lname, mobilenum, date);
            }
            else
            {
                Console.WriteLine("DATA IS NOT PROPER TRY AGAIN");
            }
        }
    }
}