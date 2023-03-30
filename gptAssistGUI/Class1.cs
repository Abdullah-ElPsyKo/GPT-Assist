using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace clipClass
{
    public class returnClipboard
    {
        public string clipboardText = Clipboard.GetText();

        public static async Task<string> processText(string text)
        {
            string clipboardText = text;

            if (clipboardText == "")
            {
                await Console.Out.WriteLineAsync("Copy some text");
                return "";
            }
            else
            {
                await Console.Out.WriteLineAsync(clipboardText);
                string apiKey = "YOUR-API-KEY-HERE"; //add your API key here

                return (await AskGpt(apiKey, clipboardText));
            }
        }

        public static async Task<string> AskGpt(string apiKey, string textInput)
        {
            var openAiService = new OpenAIService(new OpenAiOptions(){
                ApiKey = apiKey
            });
            var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest{
                Messages = new List<ChatMessage> {ChatMessage.FromUser(textInput)}, Model = Models.Gpt_4, MaxTokens = 800 //optional
            });
            if (completionResult.Successful)
            {
                string response = completionResult.Choices.First().Message.Content;
                return (response);
            }
            else
            {
                return "Error";
            }
        }
        public static string GetClipboardText()
        {
            string clipboardText = string.Empty;
            Thread staThread = new Thread(
                delegate ()
                {
                    try
                    {
                        clipboardText = Clipboard.GetText();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return clipboardText;
        }
    }
}