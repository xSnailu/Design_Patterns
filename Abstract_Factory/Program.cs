using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;

namespace MultiPlatform
{
	class Program
	{
		private static void BuildUI (IFactory factory) //... type of platform
		{

			/*
				Call your method for platform here
			*/
			

			var grid = factory.CreateGrid();
			var button1 = factory.CreateButton();
			var button2 = factory.CreateButton();
			var button3 = factory.CreateButton();

			button1.Content = "BigPurpleButton";
			button2.Content = "SmallButton";
			button3.Content = "Baton";

			grid.AddButton(button1);
			grid.AddButton(button2);
			grid.AddButton(button3);

			var textbox1 = factory.CreateTextBox();
			var textbox2 = factory.CreateTextBox();
			var textbox3 = factory.CreateTextBox();

			textbox1.Content = "";
			textbox2.Content = "EmptyTextBox";
			textbox3.Content = "xoBtxeT";

			grid.AddTextBox(textbox1);
			grid.AddTextBox(textbox2);
			grid.AddTextBox(textbox3);

			var buttons = grid.GetButtons();
			foreach (var button in buttons)
			{
				button.ButtonPressed();
				button.DrawContent();
			}
				

			var textboxes = grid.GetTextBoxes();
			foreach (var textbox in textboxes)
				textbox.DrawContent();



		}

		static void Main(string[] args)
		{

			Console.WriteLine("<---------------------iOS--------------------->");
			BuildUI(new iOSFactory());


			Console.WriteLine("<---------------------Windows--------------------->");
			BuildUI(new WindowsFactory());


			Console.WriteLine("<---------------------Android--------------------->");
			BuildUI(new AndroidFactory());

		}
	}
}
