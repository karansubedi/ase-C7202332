using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace FormTest
{
    /// <summary>
    /// Class Drawing to use many aspects to draw something on panel basically for creating different shapes and modifying them
    /// </summary>
   public class Drawing
    {//declaring Graphics which helps us to create shapes on bitmap
        Graphics g;

        /// <summary>
        /// Making a default pen with color black and width 2
        /// </summary>
        Pen p = new Pen(Color.Black, 2);

        /// <summary>
        /// A solid brush to fill shapes
        /// </summary>
        SolidBrush brush ;

        /// <summary>
        /// To check whether the user wants to fill color or not
        /// </summary>
        bool fil = false;

        /// <summary>
        /// Declaring xpositon and y position for pen positioning in the bitmap 
        /// </summary>
        public int xposition;
        public int yposition;


       
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="g">Graphics to draw shapes on bitmap</param>
        public Drawing(Graphics g)
        {
           
            this.g = g;

            //initializing positions to zero to have something to start with
            this.xposition = 0;
            this.yposition = 0;
        }

        /// <summary>
        /// Fill shape method used to fill colors in shape if called
        /// </summary>
        /// <param name="color">Input colors { Red, Green, Blue}</param>
        public void fillShape(string color)
        {
            //turning fil to true whenever inside this method
            fil = true;

            //checking if color provided as parameter is red , green or blue
            if (color == "red")
            {
                brush = new SolidBrush(Color.Red);
                
            }
            else if(color == "blue")
            {
                brush = new SolidBrush(Color.Blue);
                
            }
           else if(color == "green")
            {
                brush = new SolidBrush(Color.Green);
                
            }
            
        }

        /// <summary>
        /// Pen method created to decide whether to have a coloured pen or not
        /// </summary>
        /// <param name="fill">Fill is variable used to decide which color user wants to use</param>
        public void pen(String fill)
        {
            //Changing the input fill to lower case
            fill = fill.ToLower();

            //If statements to decide whether to create a pen of red , blue or green
            if(fill == "red")
            {
                p = new Pen(Color.Red, 2);
            }
            else if(fill == "blue")
            {
                p = new Pen(Color.Blue, 2);
            }
            else if(fill == "green")
            {
                p = new Pen(Color.Green, 2);
            }
            
        }

        /// <summary>
        /// Move to method is used to initialize the position of x and y positions
        /// </summary>
        /// <param name="xposition">X-axis value</param>
        /// <param name="yposition">Y-axis value</param>
        public void moveto(int xposition, int yposition)
        {
            this.xposition = xposition;
            this.yposition = yposition;

        }

        /// <summary>
        /// Draw to method is used to create a line from point x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawTo(int x, int y)
        {
                g.DrawLine(p, xposition, yposition, x, y);

                this.xposition = x;
                this.yposition = y;
        }

        /// <summary>
        /// Draw Rectangle is method used to create rectangle
        /// </summary>
        /// <param name="height">Height of rectangle</param>
        /// <param name="width">Width of recatangle</param>
        public void DrawRectangle(int height , int width )
        {
            
            g.DrawRectangle(p, xposition, yposition, width, height);

            //if condition to know whether to fill shape or not
            if(fil)
            {
                g.FillRectangle(brush, xposition, yposition, width, height);
            }
            
        }
        /// <summary>
        /// Draw circle is method used to create an ellipse
        /// </summary>
        /// <param name="diameter">Diameter of ellipse</param>
        /// <param name="width">Width of ellipse</param>
        public void DrawCircle(int diameter,int width)
        {
            g.DrawEllipse(p, xposition, yposition, diameter,width);

            //If conditon to know whether to fill shape or not
            if (fil)
            {
                g.FillEllipse(brush,xposition,yposition,diameter,width);
            }
        }
    
    }
    }




