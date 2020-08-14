using System;

namespace PictureProduction
{
    public interface IPicture
    {
        string LeftFrame { get;}
        string RightFrame { get;}
        string Color { get;}
        string Text { get;}
        
        void Print();
    }

    public class EmptyPicture : IPicture
    {
        string leftFrame;
        string rightFrame;
        string color;
        string text;

        public EmptyPicture()
        {
            leftFrame = "";
            rightFrame = "";
            color = "";
            text = "";
        }

        public string LeftFrame
        {
            get { return leftFrame; }   

        }

        public string RightFrame
        {
            get { return rightFrame; }   

        }

        public string Color
        {
            get { return color; }   

        }

        public string Text
        {
            get { return text; }  

        }

        public void Print()
        {
            Console.WriteLine($"{LeftFrame}{Color}{RightFrame} {Text} {LeftFrame}{Color}{RightFrame}");
        }
    }

    public class PaintPictureDecorator : IPicture
    {
        string leftFrame;
        string rightFrame;
        string color;
        string text;

        public PaintPictureDecorator()
        {
            leftFrame = "";
            rightFrame = "";
            color = "";
            text = "";
        }

        public PaintPictureDecorator(IPicture picture, string color)
        {
            leftFrame = picture.LeftFrame;
            rightFrame = picture.RightFrame;
            this.color = color;
            text = picture.Text;
        }



        public string LeftFrame
        {
            get { return leftFrame; }  
           
        }

        public string RightFrame
        {
            get { return rightFrame; }   
            
        }

        public string Color
        {
            get { return color; }   
            
        }

        public string Text
        {
            get { return text; }   
            
        }

        public void Print()
        {
            Console.WriteLine($"{LeftFrame}{Color}{RightFrame} {Text} {LeftFrame}{Color}{RightFrame}");
        }
    }

    public class WriteOnPictureDecorator : IPicture
    {
        string leftFrame;
        string rightFrame;
        string color;
        string text;

        public WriteOnPictureDecorator()
        {
            leftFrame = "";
            rightFrame = "";
            color = "";
            text = "";
        }

        public WriteOnPictureDecorator(IPicture picture, string text)
        {
            leftFrame = picture.LeftFrame;
            rightFrame = picture.RightFrame;
            color = picture.Color;
            this.text = text;
        }


        public string LeftFrame
        {
            get { return leftFrame; }   

        }

        public string RightFrame
        {
            get { return rightFrame; }   

        }

        public string Color
        {
            get { return color; }   

        }

        public string Text
        {
            get { return text; }   

        }

        public void Print()
        {
            Console.WriteLine($"{LeftFrame}{Color}{RightFrame} {Text} {LeftFrame}{Color}{RightFrame}");
        }
    }

    public class FramePictureDecorator : IPicture
    {
        string leftFrame;
        string rightFrame;
        string color;
        string text;

        public FramePictureDecorator()
        {
            leftFrame = "";
            rightFrame = "";
            color = "";
            text = "";
        }

        public FramePictureDecorator(IPicture picture, string leftframe, string rightframe)
        {
            this.leftFrame = leftframe;
            this.rightFrame = rightframe;
            color = picture.Color;
            this.text = picture.Text;
        }


        public string LeftFrame
        {
            get { return leftFrame; }   

        }

        public string RightFrame
        {
            get { return rightFrame; }  

        }

        public string Color
        {
            get { return color; }   

        }

        public string Text
        {
            get { return text; }   

        }

        public void Print()
        {
            Console.WriteLine($"{LeftFrame}{Color}{RightFrame} {Text} {LeftFrame}{Color}{RightFrame}");
        }
    }
}
