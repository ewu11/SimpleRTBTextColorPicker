using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectColorProject
{
    public partial class MainForm : Form
    {
        //global variable(s)
        const string emptyRTBStatus = "Enter something in the text box...";
        const string filledRTBStatus = "...";
        Color tempLastColor = Color.Empty; //tempLastColor; to store latest color before replacing lastColor
        Color lastColor = Color.Empty;
        bool colorChanged = false; //flag for changed color; false by default
        Bitmap colorSquare = null; //to store "lastColor" graphical color bitmap

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //to show at first time load
            if (theRTB.Text.Length == 0)
            {
                statusStrip.Text = emptyRTBStatus;
            }

            //to create the bitmap for storing "lastColor" color square
            colorSquare = new Bitmap(30, 15);
        }

        private void theRTB_KeyUp(object sender, KeyEventArgs e)
        {
            //to set RTB status when key is pressed
            if (theRTB.Text.Length > 0)
            {
                statusStrip.Text = filledRTBStatus;
            }
            else
            {
                statusStrip.Text = emptyRTBStatus;
            }
        }

        private void clearColBtn_Click_1(object sender, EventArgs e)
        {
            var startIndex = 0; //from beginning of RTB
            var endIndex = theRTB.TextLength; //'til the end

            if (theRTB.TextLength == 0)
            {
                statusStrip.Text = emptyRTBStatus;
                MessageBox.Show(this, "Rich Text Box is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                theRTB.Select();
            }
            else
            {
                statusStrip.Text = "Remove a color...";

                //--manage selected text in the RTB--
                theRTB.SelectionStart = startIndex;
                theRTB.SelectionLength = endIndex;

                theRTB.Select(theRTB.SelectionStart, theRTB.SelectionLength);
                //--manage selected text in the RTB--

                //--manage bg color of selected text in RTB--
                theRTB.SelectionBackColor = SystemColors.Window;
                //--manage bg color of selected text in RTB--

                //finally...
                theRTB.DeselectAll(); //unselect text in RTB
                theRTB.Select(); //set focus back to the RTB

                statusStrip.Text = "All text background color cleared successfully!";
            }
        }

        private void addColBtn_Click_1(object sender, EventArgs e)
        {
            var startIndex = 0; //from beginning of RTB
            var endIndex = theRTB.TextLength; //'til the end

            statusStrip.Text = "Add a color...";

            if (theRTB.TextLength == 0)
            {
                statusStrip.Text = emptyRTBStatus;
                MessageBox.Show(this, "Rich Text Box is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //show the color picker dialog
                DialogResult colorDialogResult = colorDialog1.ShowDialog(this);

                //--manage the color picker dialog--
                if (colorDialogResult == DialogResult.OK)
                {
                    //--manage selected text in the RTB--
                    theRTB.SelectionStart = startIndex;
                    theRTB.SelectionLength = endIndex;

                    theRTB.Select(theRTB.SelectionStart, theRTB.SelectionLength);
                    //--manage selected text in the RTB--

                    //set background color
                    theRTB.SelectionBackColor = colorDialog1.Color;
                    
                    if(lastColor == Color.Empty) //only for the first time color is changed, next and successive changes dont apply for this if clause
                    {
                        lastColor = theRTB.SelectionBackColor;

                        //at first time color choose, set the color of the "lastColor" bitmap
                        using (Graphics theColSquare = Graphics.FromImage(colorSquare))
                        {
                            theColSquare.FillRectangle(new SolidBrush(lastColor), 1, 1, 30, 15);
                        }
                    }
                    else //next and succesive color changes
                    {
                        if(lastColor != theRTB.SelectionBackColor) //if the color has changed, dont directly change "lastColor"
                        {
                            colorChanged = true;

                            tempLastColor = lastColor; //set the old color to tempLastColor, before replacing with new color

                            lastColor = theRTB.SelectionBackColor; //set the new color to the last color
                        }

                        //finally, set the color of the "lastColor" bitmap
                        using (Graphics theColSquare = Graphics.FromImage(colorSquare))
                        {
                            theColSquare.FillRectangle(new SolidBrush(tempLastColor), 1, 1, 30, 15);
                        }
                    }

                    lastColorBtn.ImageAlign = ContentAlignment.MiddleRight;
                    lastColorBtn.Image = colorSquare;

                    //remove selection highlight
                    theRTB.DeselectAll();

                    statusStrip.Text = "Color changed successfully!";
                }
                else if (colorDialogResult == DialogResult.Cancel)
                {
                    statusStrip.Text = "Color change aborted!";
                }
                else
                {
                    MessageBox.Show(this, "\"DialogResult\" selection error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //finally, set focus back to the RTB
                theRTB.Select();
                //--manage the color picker dialog--
            }
        }

        private void colorDialog1_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Please choose a color to change the text background color in the Rich Text Box.", "Color Selection Help", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void theRTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(theRTB.SelectionBackColor != theRTB.BackColor)
            {
                theRTB.SelectionBackColor = theRTB.BackColor;
            }
        }

        private void clearTxtBtn_Click(object sender, EventArgs e)
        {
            if (theRTB.TextLength == 0)
            {
                statusStrip.Text = emptyRTBStatus;
                MessageBox.Show(this, "Rich Text Box is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                theRTB.Select();
            }
            else
            {
                theRTB.Clear();
                theRTB.Select();

                statusStrip.Text = "All text cleared successfully!";
            }
        }

        private void lastColorBtn_Click(object sender, EventArgs e)
        {
            var startIndex = 0; //from beginning of RTB
            var endIndex = theRTB.TextLength; //'til the end
            var currentLastColor = Color.Empty;
            
            if(theRTB.TextLength == 0)
            {
                MessageBox.Show(this, "Rich Text Box is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (colorChanged == false) //set lastColor to colorSquare bitmap
                {
                    currentLastColor = lastColor;
                    lastColorBtn.Image = colorSquare;
                }
                else if (tempLastColor != Color.Empty) //if secondary color not yet chosen
                {
                    //MessageBox.Show(this, "Second last color not yet added, choose different color from the first one!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentLastColor = tempLastColor;
                    lastColorBtn.Image = colorSquare;
                }

                //--manage selected text in the RTB--
                theRTB.SelectionStart = startIndex;
                theRTB.SelectionLength = endIndex;

                theRTB.Select(theRTB.SelectionStart, theRTB.SelectionLength);
                //--manage selected text in the RTB--

                //set background color
                theRTB.SelectionBackColor = currentLastColor;

                //remove selection highlight
                theRTB.DeselectAll();

                statusStrip.Text = "Last color changed successfully!";
            }

            //lastly, set focus to RTB
            theRTB.Select();
        }
    }
}
