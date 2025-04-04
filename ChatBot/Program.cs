using System;
using System.Media;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Play a voice greeting at startup
            PlayVoiceGreeting();

            //Display ASCII art logo
            DisplayAsciiArt();

            // Greet the user and personalize interaction
            string userName = GreetUser();

            // Main menu loop
            bool isRunning = true;
            while (isRunning)
            {
                // Enhanced console UI/Menu
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nWhat would you like to ask about?");
                Console.WriteLine("1. How are you?");
                Console.WriteLine("2. What’s your purpose?");
                Console.WriteLine("3. What can I ask you about?");
                Console.WriteLine("4. Learn about Phishing Emails");
                Console.WriteLine("5. Learn about Password Safety");
                Console.WriteLine("6. Learn about Recognizing Suspicious Links");
                Console.WriteLine("7. Exit");
                Console.ResetColor();

                Console.Write("\nEnter your choice (1-7): ");
                string userInput = Console.ReadLine();

                // Handle menu options
                switch (userInput)
                {
                    case "1":
                        Respond($"I’m just a chatbot, {userName}, but I’m functioning perfectly and here to help you!");
                        break;
                    case "2":
                        Respond("My purpose is to educate you on cybersecurity awareness and help you stay safe online.");
                        break;
                    case "3":
                        Respond("You can ask me about phishing emails, creating strong passwords, or recognizing suspicious links.");
                        break;
                    case "4":
                        DisplayPhishingInfo();
                        break;
                    case "5":
                        DisplayPasswordInfo();
                        break;
                    case "6":
                        DisplayLinkInfo();
                        break;
                    case "7":
                        Respond($"Thank you for chatting with me, {userName}. Stay safe online, and have a great day!");
                        isRunning = false;
                        break;
                    default:
                        Respond("I didn’t quite understand that. Could you rephrase?");
                        break;
                }
            }
        }

        //Play a voice greeting at startup
        static void PlayVoiceGreeting()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(@"voice_greeting.wav")) 
                {
                    player.PlaySync();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Voice greeting could not be played. Please check the file path.");
                Console.ResetColor();
            }
        }

        // Displaying ASCII art logo
        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
   _____            _                       _   _             
  / ____|          | |                     | | (_)            
 | |     ___  _ __ | |_ ___  _ __ ___   ___| |_ _  ___  _ __  
 | |    / _ \| '_ \| __/ _ \| '_ ` _ \ / _ \ __| |/ _ \| '_ \ 
 | |___| (_) | | | | || (_) | | | | | |  __/ |_| | (_) | | | |
  \_____\___/|_| |_|\__\___/|_| |_| |_|\___|\__|_|\___/|_| |_|
");
            Console.ResetColor();
        }

        //Greet the user and personalize interaction
        static string GreetUser()
        {
            Console.Write("\nWhat’s your name? ");
            string name = Console.ReadLine();

            // Input validation: Default to "User" if name is empty
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "User";
            }

            // Personalized greeting
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nHello, {name}! Welcome to the Cybersecurity Awareness Bot.");
            Console.WriteLine("I’m here to help you learn about staying safe online.");
            Console.ResetColor();

            return name;
        }

        // Basic response system
        static void Respond(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Typing effect
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Educational modules
        static void DisplayPhishingInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPhishing Emails:");
            Console.WriteLine("Phishing emails try to trick you into sharing sensitive information.");
            Console.WriteLine("Tips:");
            Console.WriteLine("- Verify the sender's email address carefully.");
            Console.WriteLine("- Avoid clicking on links or downloading attachments from unknown sources.");
            Console.WriteLine("- Look out for urgent or suspicious language in emails.");
            Console.ResetColor();
        }

        static void DisplayPasswordInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPassword Safety:");
            Console.WriteLine("Strong passwords help protect your online accounts from being compromised.");
            Console.WriteLine("Tips:");
            Console.WriteLine("- Use a mix of uppercase letters, lowercase letters, numbers, and special characters.");
            Console.WriteLine("- Avoid using common words or personal information like your name or birthdate.");
            Console.WriteLine("- Enable two-factor authentication wherever possible.");
            Console.ResetColor();
        }

        static void DisplayLinkInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nRecognizing Suspicious Links:");
            Console.WriteLine("Cybercriminals use deceptive links to trick you into visiting malicious websites.");
            Console.WriteLine("Tips:");
            Console.WriteLine("- Hover over links to check their actual destination before clicking.");
            Console.WriteLine("- Be cautious of shortened URLs or links with unusual characters.");
            Console.WriteLine("- Do not click on links from untrusted or unsolicited emails.");
            Console.ResetColor();
        }
    }
}
