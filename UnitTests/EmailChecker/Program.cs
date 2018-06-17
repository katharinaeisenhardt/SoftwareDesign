using System;

namespace EmailChecker
{
    class Program
    {
        public static bool IsEmailAddress(string emailAddress){
            int iAt = emailAddress.IndexOf('@');  //@ suchen, ob drin und position und in iAt abspeichern, index von vorne gezählt
            int iDot = emailAddress.LastIndexOf('.'); // . suchen, index von hinten gezählt
            return (iAt > 0 && iDot > iAt);
        }

        static void TestIsEmailAddress(string emailAddress, bool expected){
            bool result = IsEmailAddress(emailAddress);
            if (result == expected){
                Console.WriteLine("TEST PASSED - " + emailAddress +" is valid? -> " + expected);
            }else{
                Console.WriteLine("TEST FAILED - " + emailAddress + " results in: " + result + "; expected: " + expected);
            }
        }

        static void Main(string[] args)
        {
            /*if (IsEmailAddress("irgendwas@web.de")){
                Console.WriteLine("TEST PASSED - irgendwas@web.de is a valid email address.");
            }else{
                Console.WriteLine("TEST FAILED - irgendwas@web.de is not a valid email address.");
            }               //wurde zu eigener Methode*/

            TestIsEmailAddress("irgwas@web.de", true);

            TestIsEmailAddress("@web.de", false);
            TestIsEmailAddress("test@eins.zwei.de", true);
            TestIsEmailAddress("a.b@eins.zwei.de", true);
            TestIsEmailAddress("a@.", false);

            /*Console.WriteLine(IsEmailAddress("@web.de"));
            Console.WriteLine(IsEmailAddress("@eins.zwei.de"));
            Console.WriteLine(IsEmailAddress(".@eins.zwei.de"));
            Console.WriteLine(IsEmailAddress("irgwaswas@.de"));

            Console.WriteLine(IsEmailAddress("a@."));         //1. Aufrufversuch*/
        }
    }
}
