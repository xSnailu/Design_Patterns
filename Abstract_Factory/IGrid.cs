using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlatform.Interfaces
{
	public interface IGrid
	{
		void AddButton(IButton button);

		void AddTextBox(ITextBox textBox);

		IEnumerable<IButton> GetButtons();

		IEnumerable<ITextBox> GetTextBoxes();
	}

    public class iOSGrid : IGrid
    {
        List<IButton> buttons;
        List<ITextBox> textboxes;

        public iOSGrid()
        {
            buttons = new List<IButton>();
            textboxes = new List<ITextBox>();
            Console.WriteLine($"iOSGrid created");
        }

        public void AddButton(IButton button)
        {
            buttons.Add(button);
        }

        public void AddTextBox(ITextBox textBox)
        {
            textboxes.Add(textBox);
        }

        public IEnumerable<IButton> GetButtons()
        {
            return buttons;
        }


        public IEnumerable<ITextBox> GetTextBoxes()
        {
            return textboxes;
        }


    }

    public class WindowsGrid : IGrid
    {
        List<IButton> buttons;
        List<ITextBox> textboxes;

        public WindowsGrid()
        {
            buttons = new List<IButton>();
            textboxes = new List<ITextBox>();
            Console.WriteLine($"WindowsGrid created");
        }

        public void AddButton(IButton button)
        {
            buttons.Add(button);
        }

        public void AddTextBox(ITextBox textBox)
        {
            textboxes.Add(textBox);
        }

        public IEnumerable<IButton> GetButtons()
        {
            List<IButton> output = new List<IButton>();
            for(int i = buttons.Count - 1; i >= 0; i--)
            {
                output.Add(buttons[i]);
            }
            return output;
        }


        public IEnumerable<ITextBox> GetTextBoxes()
        {
            List<ITextBox> output = new List<ITextBox>();
            output.Add(textboxes.First());
            for (int i = textboxes.Count - 1; i > 0; i--)
            {
                output.Add(textboxes[i]);
            }
            return output;
        }
    }

    public class AndroidGrid : IGrid
    {
        List<IButton> buttons;
        List<ITextBox> textboxes;

        public AndroidGrid()
        {
            buttons = new List<IButton>();
            textboxes = new List<ITextBox>();
            Console.WriteLine($"AndroidGrid created");
        }

        public void AddButton(IButton button)
        {
            buttons.Add(button);
        }

        public void AddTextBox(ITextBox textBox)
        {
            textboxes.Add(textBox);
        }


        public IEnumerable<IButton> GetButtons()
        {
            return buttons;
        }


        public IEnumerable<ITextBox> GetTextBoxes()
        {
            return new List<ITextBox>();
        }
    }
}
