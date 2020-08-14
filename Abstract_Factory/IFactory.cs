using System;
using System.Collections.Generic;
using System.Text;

namespace MultiPlatform.Interfaces
{
    public interface IFactory
    {
        IGrid CreateGrid();
        IButton CreateButton();
        ITextBox CreateTextBox();
    }



    public class iOSFactory : IFactory
    {
        public iOSFactory() { }
        public IButton CreateButton()
        {
            return new iOSButton();
        }

        public IGrid CreateGrid()
        {
            return new iOSGrid();
        }

        public ITextBox CreateTextBox()
        {
            return new iOSTextBox();
        }
    }

    public class WindowsFactory : IFactory
    {
        public WindowsFactory() { }
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public IGrid CreateGrid()
        {
            return new WindowsGrid();
        }

        public ITextBox CreateTextBox()
        {
            return new WindowsTextBox();
        }
    }

    public class AndroidFactory : IFactory
    {
        public AndroidFactory() { }
        public IButton CreateButton()
        {
            return new AndroidButton();
        }

        public IGrid CreateGrid()
        {
            return new AndroidGrid();
        }

        public ITextBox CreateTextBox()
        {
            return new AndroidTextBox();
        }
    }


}
