using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch2_Claim
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            Menu();
        }

        public void Menu()
        {
            bool keepRunnng = true;
            while (keepRunnng)
            {
                Console.WriteLine("Choose a menu item\n" +
                    "1: See all claims\n" +
                    "2: Take care of next claim\n" +
                    "3: Enter a new claim\n" +
                    "4: Exit");

                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        keepRunnng = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claim> claimList = _claimRepo.GetClaimQueue();

            foreach (Claim claim in claimList)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date of Incident: {claim.DateOfIncident}\n" +
                    $"Date of Claim: {claim.DateofClaim}\n" +
                    $"Is Valid: {claim.IsValid}");
            }
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();

            Console.WriteLine("Here are the details for the next claim to be handled:");

            _claimRepo.SeeNextClaimInQueue();

            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string response = Console.ReadLine();
            bool validResponse = false;
            while (validResponse == false)
            {
                if (response == "y")
                {
                    _claimRepo.DequeueNextClaim();
                }
                else if (response == "n")
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }
            }
        }

        private void EnterNewClaim()
        {
            Claim claim = new Claim();
            Console.Clear();

            Console.WriteLine("Enter the claim ID.");
            claim.ClaimID = Console.ReadLine();

            Console.WriteLine("Enter the type of claim.");
            claim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter the description of the claim.");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Enter the amount of the claim.");
            string amountAsString = Console.ReadLine();
            claim.ClaimAmount = double.Parse(amountAsString);

            Console.WriteLine("Enter the date of the incident.");
            claim.DateOfIncident = Console.ReadLine();

            Console.WriteLine("Enter the date of the claim.");
            claim.DateofClaim = Console.ReadLine();

            bool validResponse = false;
            while (validResponse == false)
            {
                Console.WriteLine("Is the claim valid? Enter yes or no");
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    claim.IsValid = true;
                    validResponse = true;
                }
                else if (response == "no")
                {
                    claim.IsValid = false;
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine("Please enter yes or no.");
                }
            }

            _claimRepo.EnterNewClaim(claim);
        }
    }
}
