using TelevisionRadioCompany.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelevisionRadioCompany
{
	class Menu
	{

		private Company companyCommand = new Company();
		private Address addressCommand = new Address();

		public void runMenu()
		{
			showMenuOption();
		}


		private void showMenuOption()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				Console.WriteLine("Welcome to the Television Radio Company\n");
				Console.WriteLine("Please select an option:\n");
				Console.WriteLine("1) Work with Company");
				Console.WriteLine("2) Work with Address");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectShowMenuOption(userInput);
			}
		}

		private void selectShowMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					showCompaniesMenu();
					break;
				case '2':
					showAddressesMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void showCompaniesMenu()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				companyCommand.PrintAllCompaniesCommand();
				Console.WriteLine();
				Console.WriteLine("1) Create company");
				Console.WriteLine("2) Edit company");
				Console.WriteLine("3) Delete company");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectCompaniesMenuOption(userInput);
			}
		}

		private void selectCompaniesMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					AddCompanyMenu();
					break;
				case '2':
					ChangeCompanyMenu();
					break;
				case '3':
					DeleteCompanyMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void DeleteCompanyMenu()
		{
			Console.Clear();
			int? companyId = null;
			while (!(companyId is int)) companyId = TrySelectCompanyByIDMenu();

			companyCommand.DeleteCategoryCommand((int)companyId);
		}

		private int? TrySelectCompanyByIDMenu()
		{
			Console.Clear();
			companyCommand.PrintAllCompaniesCommand();

			int companyId;

			Console.Write("\nSelect the company id : ");

			bool success = int.TryParse(Console.ReadLine(), out companyId);
			return success ? (int?)companyId : (int?)null;
		}

		private void ChangeCompanyMenu()
		{
			int? companyId = null;
			while (!(companyId is int)) companyId = TrySelectCompanyByIDMenu();

			Console.Clear();
			Console.WriteLine("Enter a new name of the company : ");
			string companyName = Console.ReadLine();
			Console.WriteLine("Enter a new address id of the company : ");
			int address;
			int.TryParse(Console.ReadLine(), out address);
			Console.WriteLine("Enter a new phone of the company : ");
			string phone = Console.ReadLine();

			companyCommand.EditCategoryCommand((int)companyId, companyName, address, phone);
		}

		private void AddCompanyMenu()
		{
			Console.Clear();
			Console.WriteLine("Enter the name of the company : ");
			string companyName = Console.ReadLine();
			Console.WriteLine("Enter the address id of the company : ");
			int address;
			int.TryParse(Console.ReadLine(), out address);
			Console.WriteLine("Enter the phone of the company : ");
			string phone = Console.ReadLine();

			companyCommand.CreateCompanyCommand(companyName, address, phone);

		}

		private void showAddressesMenu()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				addressCommand.PrintAllAddressesCommand();
				Console.WriteLine();
				Console.WriteLine("1) Create address");
				Console.WriteLine("2) Edit address");
				Console.WriteLine("3) Delete address");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectAddressMenuOption(userInput);
			}
		}

		private void selectAddressMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					CreateAddressMenu();
					break;
				case '2':
					EditAddressMenu();
					break;
				case '3':
					DeleteAddressMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void DeleteAddressMenu()
		{
			Console.Clear();
			int? addressId = null;
			while (!(addressId is int)) addressId = TrySelectAddressByIDMenu();

			addressCommand.DeleteAddressCommand((int)addressId);
		}

		private void CreateAddressMenu()
		{
			Console.Clear();
			Console.WriteLine("Enter the flat number of the address : ");
			int flat;
			int.TryParse(Console.ReadLine(), out flat);
			Console.WriteLine("Enter the house number of the address : ");
			int house;
			int.TryParse(Console.ReadLine(), out house);
			Console.WriteLine("Enter the street id  of the address : ");
			int streetId;
			int.TryParse(Console.ReadLine(), out streetId);
			addressCommand.CreateAddressCommand(flat, house, streetId);
		}

		private void EditAddressMenu()
		{
			int? addressId = null;
			while (!(addressId is int)) addressId = TrySelectAddressByIDMenu();

			Console.Clear();
			Console.WriteLine("Enter the new flat number of the address : ");
			int flat;
			int.TryParse(Console.ReadLine(), out flat);
			Console.WriteLine("Enter the new house number of the address : ");
			int house;
			int.TryParse(Console.ReadLine(), out house);
			Console.WriteLine("Enter the new street id  of the address : ");
			int streetId;
			int.TryParse(Console.ReadLine(), out streetId);

			addressCommand.EditAddressCommand((int)addressId, flat, house, streetId);
		}

		private int? TrySelectAddressByIDMenu()
		{
			Console.Clear();
			addressCommand.PrintAllAddressesCommand();

			int addressId;

			Console.Write("\nSelect the address id : ");

			bool success = int.TryParse(Console.ReadLine(), out addressId);
			return success ? (int?)addressId : (int?)null;
		}

		private void printDefaultSwitchStringMenu()
		{
			Console.WriteLine("\nWrong command selected");
		}
	}
}


