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
        Color defaultBackgroundColor = SystemColors.Window;
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
            if (theRTB.TextLength == 0)
            {
                statusStrip.Text = emptyRTBStatus;
                showMsg("empty");
            }
            else
            {
                clearAllTxtBgColor(theRTB);
            }
        }

        private void addColBtn_Click_1(object sender, EventArgs e)
        {
            /*var startIndex = 0; //from beginning of RTB
            var endIndex = theRTB.TextLength; //'til the end*/

            //int startIndex;
            //int endIndex; //'til the end

            //statusStrip.Text = "Add a color...";

            if (theRTB.TextLength == 0)
            {
                statusStrip.Text = emptyRTBStatus;
                showMsg("empty");
            }
            else
            {
                //show the color picker dialog
                DialogResult colorDialogResult = colorDialog1.ShowDialog(this);

                isTextSelected(theRTB);

                //finally, manage the backselectioncolor, based on the selectedtext
                //--manage the color picker dialog--
                if (colorDialogResult == DialogResult.OK)
                {
                    //set background color
                    theRTB.SelectionBackColor = colorDialog1.Color;

                    if (lastColor == Color.Empty) //only for the first time color is changed, next and successive changes dont apply for this if clause
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
                        if (lastColor != theRTB.SelectionBackColor) //if the color has changed, dont directly change "lastColor"
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
                    //remove selection highlight
                    theRTB.DeselectAll();

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
                theRTB.SelectionBackColor = defaultBackgroundColor;
            }
        }

        private void clearTxtBtn_Click(object sender, EventArgs e)
        {
            if (theRTB.TextLength == 0)
            {
                statusStrip.Text = emptyRTBStatus;
                showMsg("empty");
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
            //var startIndex = 0; //from beginning of RTB
            //var endIndex = theRTB.TextLength; //'til the end
            var currentLastColor = Color.Empty;
            
            if(theRTB.TextLength == 0)
            {
                showMsg("empty");
            }
            else
            {
                if(lastColor.IsEmpty || tempLastColor.IsEmpty)
                {
                    MessageBox.Show(this, "Please select a different color from the first color!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    isTextSelected(theRTB);
                    //--manage selected text in the RTB--

                    //set background color
                    theRTB.SelectionBackColor = currentLastColor;

                    //remove selection highlight
                    theRTB.DeselectAll();

                    statusStrip.Text = "Last color changed successfully!";
                }
            }

            //lastly, set focus to RTB
            theRTB.Select();
        }

        //flagger; checks whether user has text selected or not
        private bool isTextSelected(RichTextBox localRTB)
        {
            int startIndex;
            int endIndex;

            if (localRTB.SelectionLength.Equals(0)) //if user don't select any text
            {
                //MessageBox.Show(this, "Enters A!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                startIndex = 0; //from beginning of RTB
                endIndex = localRTB.TextLength; //'til the end of RTB

                //--manage selected text in the RTB--
                localRTB.SelectionStart = startIndex;
                localRTB.SelectionLength = endIndex;

                localRTB.Select(localRTB.SelectionStart, localRTB.SelectionLength);
                //--manage selected text in the RTB--

                return false;
            }
            else if (!(localRTB.SelectionLength.Equals(0))) //if user has text selected
            {
                //MessageBox.Show(this, "Enters B!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                startIndex = localRTB.SelectionStart; //from beginning of RTB
                endIndex = localRTB.SelectionLength; //'til the end of RTB

                if (localRTB.SelectedText.Contains(" ")) //skips whitespaces if selected together with text
                {
                    endIndex -= 1;
                }

                localRTB.Select(startIndex, endIndex);
                //--manage selected text in the RTB--

                return true;
            }

            //by default
            return false;
        }

        //flagger; check if background color was changed/ not default value
        /*private void isBgColorChanged(RichTextBox localRTB)
        {
            *//*int endOfDocIndex = localRTB.TextLength; //end of document
            List<Color> colorList = new List<Color>();
            bool defTxtColChanged = false; //by default
            int startIndex = 0;

            //---if all the text are in default bg color---
            int endIndex = theRTB.TextLength;
            theRTB.Select(startIndex, endIndex);
            if (theRTB.SelectionBackColor != defaultBackgroundColor)
            {
                defTxtColChanged = true;
            }
            //---if all the text are in default bg color---

            //---if the text contains some other colors than the default-- -
            //--manage text selection--
            localRTB.SelectionStart = startIndex;
            int startingSelection = localRTB.SelectionStart;
            int endingSelection = startingSelection + 1;
            //--manage text selection--

            if (defTxtColChanged == true)
            {
                while (startingSelection < endOfDocIndex) //keep going through all the text until end of document
                {
                    localRTB.Select(startingSelection, endingSelection);

                    if (!(colorList.Contains(localRTB.SelectionBackColor))) //if the list doesnt have the color yet, then append it into the list
                    {
                        colorList.Add(localRTB.SelectionBackColor); //get the selectionbackcolor
                    }

                    startingSelection++;
                    endingSelection++;
                }
            }
            //---if the text contains some other colors than the default---

            //after the whole document is analyzed, show color result
            if (defTxtColChanged == false)
            {
                if (localRTB.BackColor == defaultBackgroundColor || localRTB.BackColor == SystemColors.Window)
                {
                    MessageBox.Show(this, "Text background color is in default.\n" + "Color name: " + defaultBackgroundColor, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else //if the txt bg color was changed, and other colors present
            {
                //MessageBox.Show(this, "Text background color(s) was changed.\n" + "Color name(s): " + theColors[i].ToString() + "\n", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(this, "Text background color(s) was changed.\n" + "Color name(s): " + colorList + "\n", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (var theColors in colorList)
                {
                    Console.WriteLine(theColors);
                }
                Console.WriteLine("\n");
                for (int i = 0; i < colorList.Count; i++)
                {
                    Console.WriteLine(colorList[i]);
                }
                Console.WriteLine("\n");
            }

            //clear all the colors in the list for next use
    
                colorList.Clear();

                //by default
                //return false;*//*
        }*/

        private void detectColorChanges(RichTextBox localRTB)
        {
            List<Color> colorList = new List<Color>();

            /*//----case detecting default color----
            //case is special for checking default text color
            //instead of going one by one, just go through all instead, to detect multiple color at once
            localRTB.SelectionStart = 0; //from beginning
            localRTB.SelectionLength = localRTB.TextLength; //'til the end
            localRTB.Select(localRTB.SelectionStart, localRTB.SelectionLength);

            bool localBgColIsDefault = textBgColIsDefault(localRTB);
            //----case detecting default color----*/

            //----case detecting mltiple color----
            //go through text one by one, skipping white lines
            int startIndex = 0;
            int endIndex = localRTB.TextLength;
            localRTB.SelectionStart = startIndex;
            localRTB.SelectionLength = 1; //always 1 'cuz we want to assess each text one by one

            while (localRTB.SelectionStart < endIndex)
            {
                localRTB.Select(localRTB.SelectionStart, localRTB.SelectionLength); //select the text first before processing

                if (localRTB.SelectedText.Contains(" ")) //skip white spaces
                {
                    //so that able to go to next text
                    localRTB.SelectionStart += 1;
                }
                else if (localRTB.SelectedText.Contains("\n")) //skip new line
                {
                    //so that able to go to next text
                    localRTB.SelectionStart += 1;
                }
                else
                {
                    //--testing purposes--
                    //MessageBox.Show(this, "currentSelection: " + localRTB.SelectedText, "Information", MessageBoxButtons.OK);
                    //--testing purposes--

                    //textBgColIsDefault(theRTB);

                    //if the color is not in list, add it
                    if ((!colorList.Contains(localRTB.SelectionBackColor)))
                    {
                        colorList.Add(localRTB.SelectionBackColor);
                    }

                    //so that able to go to next text
                    localRTB.SelectionStart += 1;
                }
            }
            //----case detecting mltiple color----

            //show the contents
            /*for (int i = 0; i < colorList.Count; i++)
            {
                Console.WriteLine(colorList[i]);
            }
            Console.WriteLine("\n");*/
            MessageBox.Show(this, string.Join(Environment.NewLine, colorList), "Color(s) available:", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //clear the list to update latest color
            colorList.Clear();
        }

        private void clearAllTxtBgColor(RichTextBox localRTB)
        {
            //go through text one by one, skipping white lines
            int startIndex = 0;
            int endIndex = localRTB.TextLength;
            localRTB.SelectionStart = startIndex;
            localRTB.SelectionLength = 1; //always 1 'cuz we want to assess each text one by one

            while (localRTB.SelectionStart < endIndex)
            {
                localRTB.Select(localRTB.SelectionStart, localRTB.SelectionLength); //select the text first before processing

                /*if (localRTB.SelectedText.Contains(" ")) //skip white spaces
                {
                    //so that able to go to next text
                    localRTB.SelectionStart += 1;
                }
                else if (localRTB.SelectedText.Contains("\n")) //skip new line
                {
                    //so that able to go to next text
                    localRTB.SelectionStart += 1;
                }
                else
                {
                    //--manage bg color of selected text in RTB--
                    theRTB.SelectionBackColor = defaultBackgroundColor;
                    //--manage bg color of selected text in RTB--

                    //so that able to go to next text
                    localRTB.SelectionStart += 1;
                }*/

                //--manage bg color of selected text in RTB--
                theRTB.SelectionBackColor = defaultBackgroundColor;
                //--manage bg color of selected text in RTB--

                //so that able to go to next text
                localRTB.SelectionStart += 1;
            }

            //finally...
            theRTB.DeselectAll(); //unselect text in RTB
            theRTB.Select(); //set focus back to the RTB

            //show completion status
            statusStrip.Text = "All text background color cleared successfully!";
        }

        private void colorDetectBtn_Click(object sender, EventArgs e)
        {
            if(theRTB.TextLength == 0)
            {
                showMsg("empty");
            }
            else
            {
                detectColorChanges(theRTB);
            }
        }

        //handle common messageboxes
        private void showMsg(string msgStr)
        {
            if(msgStr == "empty")
            {
                MessageBox.Show(this, "Rich Text Box is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //check if if all text color are still default
        private bool textBgColIsDefault22(RichTextBox localRTB)
        {
            if(localRTB.SelectionBackColor == defaultBackgroundColor)
            {
                return true;
            }
            else if(localRTB.SelectionBackColor == Color.White)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure to exit?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
