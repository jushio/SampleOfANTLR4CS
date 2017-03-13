using System.Collections.Generic;


namespace SampleOfANTLR4CS
{
    public class MySpeakVisitor : SpeakBaseVisitor<object>
    {
        public List<SpeakLine> Lines = new List<SpeakLine>();

        public override object VisitLine(SpeakParser.LineContext context)
        {
            SpeakParser.NameContext name = context.name();
            SpeakParser.WordContext word = context.word();

            SpeakLine line = new SpeakLine() { Person = name.GetText(), Text = word.GetText() };
            Lines.Add(line);

            return line;
        }
    }
}
