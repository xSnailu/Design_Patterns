﻿namespace PictureProduction
{
    public class Order
    {
        public string Shape { get; private set; }
        public string Color { get; private set; }
        public string Text { get; private set; }
        public string Operation { get; private set; }


        public Order(string shape, string color, string text, string operation)
        {
            Shape = shape;
            Color = color;
            Text = text;
            Operation = operation;
        }
    }
}
