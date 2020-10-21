using System;
using System.Collections.Generic;
using EmailLinkFinder;

namespace LinkFinderTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string message = System.IO.File.ReadAllText("Subject.html");
            EmailLinkFinder.EmailLinkFinder linkFinder = new EmailLinkFinder.EmailLinkFinder();

            List<Link> list = linkFinder.GetLinks(message);

            Console.WriteLine("Stop");

        }
    }
}
