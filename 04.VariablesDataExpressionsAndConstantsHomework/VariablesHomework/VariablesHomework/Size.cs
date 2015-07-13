namespace VariablesHomework
{
    using System;

    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get;
            set;
        }

        public double Height
        {
            get;
            set;
        }

        public static Size GetRotatedSize(
            Size size, double rotationAngle)
        {
            return new Size(
                (Math.Abs(Math.Cos(rotationAngle)) * size.Width) + (Math.Abs(Math.Sin(rotationAngle)) * size.Height),
                (Math.Abs(Math.Sin(rotationAngle)) * size.Width) + (Math.Abs(Math.Cos(rotationAngle)) * size.Height));
        }
    }
}
