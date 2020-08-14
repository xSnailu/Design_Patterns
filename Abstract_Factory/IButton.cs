using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlatform.Interfaces
{
	public interface IButton
	{
		string Content { set; }
		void DrawContent();
		void ButtonPressed();
	}

    public class iOSButton : IButton
    {
        string content;

        public iOSButton()
        {
            content = string.Empty;
            Console.WriteLine($"iOSButton created");
        }

        public string Content { set { content = value; } }
        public void DrawContent() { Console.WriteLine(content); }
        public void ButtonPressed() { Console.WriteLine($"IOS Button pressed, content - {content}", content); }
    }

    public class WindowsButton : IButton
    {
        string content;

        public WindowsButton()
        {
            content = string.Empty;
            Console.WriteLine($"WindowsButton created");
        }

        public string Content
        {
            set {
                    foreach(char letter in value)
                    {
                        content += char.ToUpper(letter);
                    }
                }
        }
        public void DrawContent() { Console.WriteLine(content); }
        public void ButtonPressed() { Console.WriteLine($"Windows button pressed"); }
    }

    public class AndroidButton : IButton
    {
        string content;

        public AndroidButton()
        {
            content = string.Empty;
            Console.WriteLine($"AndroidButton created");
        }

        public string Content
        {
            set
            {
                if (value.Length >= 8)
                    content = value.Substring(0, 7);
                else
                    content = value;
            }
        }
        public void DrawContent() { Console.WriteLine(content); }
        public void ButtonPressed() { Console.WriteLine($"Sweet {content}", content); }
    }
}
