using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPlatform.Interfaces
{
    public interface ITextBox
    {
        string Content { set; }
        void DrawContent();
    }

    public class iOSTextBox : ITextBox
    {
        string content;

        public iOSTextBox()
        {
            content = string.Empty;
            Console.WriteLine($"iOSTextBox created");
        }

        public string Content { set { content = value; } }
        public void DrawContent() { Console.WriteLine(content); }


    }

    public class WindowsTextBox : ITextBox
    {
        string content;

        public WindowsTextBox()
        {
            content = string.Empty;
            Console.WriteLine($"WindowsTextBox created");
        }

        public string Content
        {
            set
            {
                int start;
                double length = value.Length / 2;
                if (value.Length != 0)
                {
                    start = (int)Math.Ceiling(length);
                    content = value.Substring(start);
                }
                   
                
                content += " by .Net Core";
            }
        }
        public void DrawContent() { Console.WriteLine(content); }


    }

    public class AndroidTextBox : ITextBox
    {
        string content;

        public AndroidTextBox()
        {
            content = string.Empty;
            Console.WriteLine($"AndroidTextBox created");
        }

        public string Content
        {
            set
            {
                for (int i = value.Length - 1; i >= 0; i--)
                    content += value[i];
            }
        }
        public void DrawContent() { Console.WriteLine(content); }


    }
}
