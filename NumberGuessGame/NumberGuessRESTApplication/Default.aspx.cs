using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections.Specialized;


namespace NumberGuessRESTApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int lowerLimit = 0;
        int upperLimit = 0;
        int input = 0;
        Uri baseUri;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
            input = 0;
            int secretNumber = 0;
            if (LowerTextBox.Text.Equals("") || UpperTextBox.Text.Equals(""))
                ErrorLabel.Text = "Error: Neither Lower Limit nor Upper Limit can be empty.";
            else
            {
                try
                {
                    lowerLimit = int.Parse(LowerTextBox.Text);
                    upperLimit = int.Parse(UpperTextBox.Text);

                    string url1 = @"http://localhost:57910/Service1.svc/generateSecretNumber/" + lowerLimit + "/" + upperLimit;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url1);
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader sreader = new StreamReader(dataStream);
                    secretNumber = int.Parse(sreader.ReadToEnd());
                    response.Close();

                    ErrorLabel.Text = "Note: Secret Number is generated successfully.";
                    NumberLabel.Text = "The number is: Not Enter Yet";
                    AttemptLabel.Text = "Attempts: 0";
                    GuessTextBox.Text = "";

                    Session["secretNum"] = secretNumber;
                    Session["attempt"] = 0;
                }
                catch (Exception exception)
                {
                    ErrorLabel.Text = "Error: Both Lower Limit and Upper Limit must be numbers.";
                    NumberLabel.Text = "The number is: Not Enter Yet";
                    AttemptLabel.Text = "Attempts: 0";
                    GuessTextBox.Text = "";
                    Session["secretNum"] = -1;
                    Session["attempt"] = 0;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GuessTextBox.Text.Equals(""))
                ErrorLabel.Text = "Error: Guess cannot be empty.";
            else if (Int32.Parse(Session["secretNum"] + "") == -1)
            {
                ErrorLabel.Text = "Error: First generate the secret number before start guessing.";
                GuessTextBox.Text = "";
            }
            else
            {
                try
                {
                    input = int.Parse(GuessTextBox.Text);

                    string url1 = @"http://localhost:57910/Service1.svc/checkSecretNumber/" + input + "/" + Session["secretNum"];
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url1);
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader sreader = new StreamReader(dataStream);
                    NumberLabel.Text = "The number is: " + sreader.ReadToEnd();
                    response.Close();


                    int numberOfAttempts = Int32.Parse(Session["attempt"] + "");
                    numberOfAttempts++;
                    Session["attempt"] = numberOfAttempts;

                    AttemptLabel.Text = "Attempts: " + numberOfAttempts;
                    if (input == Int32.Parse(Session["secretNum"] + ""))
                        ErrorLabel.Text = "Note: You have guessed secret number successfully";
                    else
                        ErrorLabel.Text = "";

                }
                catch (Exception exception)
                {
                    ErrorLabel.Text = "Error: Guess must be a number.";
                }
            }
        }
    }
}