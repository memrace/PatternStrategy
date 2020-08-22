using System;

namespace PatternStrategy
{
	class Program
	{
		static void Main(string[] Args)
		{
			CreateNewUser();
		}


		private static void CreateNewUser()
		{
			Console.WriteLine("Write name of new user");
			var Name = Console.ReadLine();
			if (Name != null && Name != "")
			{
				Console.WriteLine("Do u want to give him admin role? \n y/n");
				var answer = Console.ReadLine();
				if (answer == "y")
				{
					BaseUser TestUser = new BaseUser(Name, new Admin(Name));
					TestUser.GetMyRole();
					Console.WriteLine("Would you like to create one more? \n y/n");
					var repeatAnswer = Console.ReadLine();
					switch (repeatAnswer)
					{
						case "y": CreateNewUser();
							break;
						case "n": Environment.Exit(0);
							break;
					}
				}
				else if (answer == "n")
				{
					BaseUser TestUser = new BaseUser(Name, new User(Name));
					TestUser.GetMyRole();
					Console.WriteLine("Would you like to create one more? \n y/n");
					var repeatAnswer = Console.ReadLine();
					switch (repeatAnswer)
					{
						case "y":
							CreateNewUser();
							break;
						case "n":
							Environment.Exit(0);
							break;
					}
				}
				else
				{
					Console.WriteLine("Wrong answer");
					CreateNewUser();
				}
			}
		}
	}


	public interface IChooseRole
	{
		void GetMyRole();
	}

	class BaseUser
	{
		private String Name;
		public IChooseRole UserRole { private get; set; }

		public BaseUser(String Name, IChooseRole MyRole)
		{
			this.Name = Name;
			UserRole = MyRole;
		}

		public void GetMyRole()
		{
			UserRole.GetMyRole();
		}
		
	}

	class User : IChooseRole
	{
		private String Name;
		public User(String name)
		{
			this.Name = name;
		}
		public void GetMyRole() => Console.WriteLine($"New common User {Name} was created");
	}

	class Admin : IChooseRole
	{
		private String Name;
		public Admin (String name)
		{
			this.Name = name;
		}
		public void GetMyRole() => Console.WriteLine($"New Admin ({Name}) Created!");
	}

}
