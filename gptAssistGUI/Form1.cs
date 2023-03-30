using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using clipClass;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gptAssistGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AddUserResponse(returnClipboard.GetClipboardText());

            // now generate a response

            string result = await GenerateResponse(3);

            AddBotResponse(result);
        }
        private void AddBotResponse(string response)
        {
            // ChatGPT response
            textBox1.AppendText("AI: " + response + Environment.NewLine);
        }
        private void AddUserResponse(string response)
        {
            // users response
            textBox1.AppendText("You: " + response + Environment.NewLine);
        }

        private async Task<string> GenerateResponse(int task)
        {
            returnClipboard clip = new returnClipboard();
            string response;
            switch (task)
            {
                case 1:
                    response = await returnClipboard.processText($"Please debug the next code:\n\n\n--------------\n\n {returnClipboard.GetClipboardText()}");
                    return response;
                case 2:
                    response = await returnClipboard.processText($"Please improve the following text:\n\n\n--------------\n\n {returnClipboard.GetClipboardText()}");
                    return response;
                case 3:
                    response = await returnClipboard.processText($"Please explain the next code/text:\n\n\n--------------\n\n {returnClipboard.GetClipboardText()}");
                    return response;
                case 4:
                    response = await returnClipboard.processText($"Please do this:\n\n\n--------------\n\n {returnClipboard.GetClipboardText()}");
                    return response;
                default:
                    return "An error has occured";
            }
        }


        private async void BtnDebug_Click(object sender, EventArgs e)
        {

            AddUserResponse(returnClipboard.GetClipboardText());

            // now generate a response

            string result = await GenerateResponse(1);

            AddBotResponse(result);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Set the TextBox's ScrollBars property to Vertical
            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private async void BtnImprove_Click(object sender, EventArgs e)
        {
            AddUserResponse(returnClipboard.GetClipboardText());

            // now generate a response

            string result = await GenerateResponse(2);

            AddBotResponse(result);
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            AddUserResponse(returnClipboard.GetClipboardText());

            // now generate a response

            string result = await GenerateResponse(4);

            AddBotResponse(result);
        }
    }
}