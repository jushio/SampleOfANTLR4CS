using System;
using System.Text;
using Antlr4.Runtime;

namespace SampleOfANTLR4CS
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = "";
                StringBuilder text = new StringBuilder();
                Console.WriteLine("Input the chat.");

                // to type the EOF character and end the input: use CTRL+D, then press <enter>
                // e.g. 
                // hoge says fuga[Enter]
                // fuga says hoge[Enter]
                // CTRL+D
                while ((input = Console.ReadLine()) != "\u0004")
                {
                    text.AppendLine(input);
                }

                AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
                SpeakLexer speakLexer = new SpeakLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
                SpeakParser speakParser = new SpeakParser(commonTokenStream);

                SpeakParser.ChatContext chatContext = speakParser.chat();
                MySpeakVisitor visitor = new MySpeakVisitor();
                visitor.Visit(chatContext);

                foreach (var line in visitor.Lines)
                {
                    Console.WriteLine("{0} has said \"{1}\"", line.Person, line.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
