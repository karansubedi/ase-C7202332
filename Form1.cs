using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormTest
{
    public partial class Form1 : Form
    {
        //Creating an object of drawing d
        Drawing d;
        //Bitmap used to have shapes on it
        Bitmap bmap = new Bitmap(400, 500);

        /// <summary>
        /// Default constructor for form
        /// </summary>
        public Form1()
        {
            
            InitializeComponent();
            //initializing drawing object to help to form image on bitmap
            d = new Drawing(Graphics.FromImage(bmap));
            
            //A new variable assigned to create a graphics on bitmap
            var graphics = Graphics.FromImage(bmap);
            
            //populating the font style fornt family and width to variable font
            var font = new Font("TimesNewRoman", 10, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Output box to get the result on the panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputbox_Paint(object sender, PaintEventArgs e)
        {
            //Output image in bitmap
            outputbox.Image = bmap;
        }

        /// <summary>
        /// Event handler when button is clicked
        /// </summary>
        /// <param name="sender">Sender as user</param>
        /// <param name="e">Event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //using variable graphics to form image on bitmap
            var graphics = Graphics.FromImage(bmap);
            var font = new Font("TimesNewRoman", 20, FontStyle.Regular, GraphicsUnit.Pixel);

            //reading input from rich text box
            var commnd = multi.Text;
            
            //reading input from single line command input 
            var command = textBox1.Text;

            //Checking condition whether to parse from single command line or not
            if (textBox1.Text != "run" && string.IsNullOrEmpty(commnd) ) 
            {
                //Declaring a String array parameter
                String[] parameters;
                
                //creating an array to split the taken command from basically adding characters to split line 
                char[] trim = { '(', ')' };
                
                //Declaring line and initializing it with trimmed and tidy lin 
                string line = command.Trim(trim).ToLower();
                
                //Further splitting the syntax from parameters
                string[] split = line.Split('(');

                //Syntax is stored in command
                command = split[0];

                //Using try 
                try
                {
                    //Checking if input is fill or pen to do the specific taks from 
                    if (command.Equals("fill"))
                {
                        //calling fillshape from drawing class using its object
                    d.fillShape(split[1]);
                }
                
               
                    else if (command.Equals("pen"))
                    {
                          //calling pen from drawing class using its object
                        d.pen(split[1]);
                    }
                
                    //Splitting up parameters sperated by a comma
                parameters = split[1].Split(',');


                
                    //for loop
                    for (int i = 0; i < parameters.Length - 1; i++)
                    {
                        //populating strings with parameters
                        String point1 = parameters[0];
                        String point2 = parameters[1];

                        //Storing parsed values from strings
                        int p1 = int.Parse(point1);
                        int p2 = int.Parse(point2);

                        //checking the sytax whether as they should have entered
                        if (command.Equals("moveto") && parameters.Length == 2)
                        {

                            
                            d.moveto(p1, p2);
                        }
                        else if (command.Equals("drawto") && parameters.Length == 2)
                        {

                            d.DrawTo(p1, p2);
                        }
                        else if (command.Equals("drawcircle") && parameters.Length == 2)
                        {

                            d.DrawCircle(p1, p2);
                        }

                        else if (command.Equals("drawrectangle") && parameters.Length == 2)
                        {

                            d.DrawRectangle(p1, p2);
                        }

                        else
                        {
                            //For Syntax error reporting 
                            graphics.DrawString("Syntax Error " +split[0] , font, Brushes.Black, new Point(0, 0));

                        }


                    }
                }

                catch(Exception)
                {
                    
                        //For invalid parameters checking 
                        graphics.DrawString("Wrong Parameters ", font, Brushes.Black, new Point(0, 0));

                    
                }
                

            }

            //else if to check whether user have entered something in richtext box
          else if (textBox1.Text == "run"  || string.IsNullOrEmpty(command) || false)
            {
                //Creating an array and populating it with every new line
                string[] multiLine = commnd.Split('\n');
                String[] parameters;
                char[] trim = { '(', ')' };
                
                //for taking out every line  
                for (int j = 0; j < multiLine.Length; j++)
                {
                    //String line and populating with a single and tidy them up 
                    string line = multiLine[j].Trim(trim).ToLower();
                    
                    //split array to store the splitted line 
                    string[] split = line.Split('(');
                       
                    //Populating with the first part of the command
                    commnd = split[0];

                    //Using try and catch for exception handling 
                    try { 
                        //checking whether the entered commands are entered as they were supposed to
                    if (commnd.Equals("fill"))
                    {
                            //calling fill shape by using the drawing objects
                        d.fillShape(split[1]);
                    }


                    else if (commnd.Equals("pen"))
                    {
                        d.pen(split[1]);
                    }

                    //Splitting up parameter by using comma
                    parameters = split[1].Split(',');

                    //for loop to take out parameters
                        for (int i = 0; i < parameters.Length - 1; i++)
                        {
                            //Points stores the parameters first and second
                            String point1 = parameters[0];
                            String point2 = parameters[1];

                            //parsing the values of string
                            int p1 = int.Parse(point1);
                            int p2 = int.Parse(point2);

                            //Checking various possible inputs possible and calling methods by using drawing object
                            if (commnd.Equals("moveto") && parameters.Length == 2)
                            {


                                d.moveto(p1, p2);
                            }
                            else if (commnd.Equals("drawto") && parameters.Length == 2)
                            {

                                d.DrawTo(p1, p2);
                            }
                            else if (commnd.Equals("drawcircle") && parameters.Length == 2)
                            {

                                d.DrawCircle(p1, p2);
                            }

                            else if (commnd.Equals("drawrectangle") && parameters.Length == 2)
                            {

                                d.DrawRectangle(p1, p2);
                            }

                            

                            else
                            {
                                //Error reporting on bitmap
                                graphics.DrawString("Syntax Error", font, Brushes.Black, new Point(0, 0));
                            }



                        }
                    }
                    catch (Exception)
                    {

                        //Error reporting for parameters on bitmap 
                        graphics.DrawString("Wrong Parameters ", font, Brushes.Black, new Point(3,2 ));


                    }

                }


            }
            //Checking whether user have entered something or not 
            else if(string.IsNullOrEmpty(commnd) && string.IsNullOrEmpty(command))
            {
               

                    graphics.DrawString("Please Enter Something", font, Brushes.Black, new Point(0, 0));

               
            }



        }

        //Reset button click 
        private void button3_Click(object sender, EventArgs e)
        {
            d.xposition = 0;
            d.yposition = 0;
        }


        /// <summary>
        /// Load file in the rich text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.Filter = "Text File (.txt)|*.txt";
            loadFileDialog.Title = "Open File...";

            if (loadFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader streamReader = new System.IO.StreamReader(loadFileDialog.FileName);
                multi.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        /// <summary>
        /// Save file from rich text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (.txt)| *.txt";
            saveFileDialog.Title = "Save File...";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter fWriter = new StreamWriter(saveFileDialog.FileName);
                fWriter.Write(multi.Text);
                fWriter.Close();
            }
            multi.Text += "Command Save";
        }
    }
}

    


