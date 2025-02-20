using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFExtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            StringBuilder sb= new StringBuilder();
            string file = @"C:\Users\l e n o v o\Downloads\Command_Line_Operations.pdf";

            using (PdfReader reader= new PdfReader(file))
            {
                for(int pageNo=1; pageNo<=reader.NumberOfPages; pageNo++ )
                {
                    ITextExtractionStrategy stategy = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, stategy);
                    text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                    sb.Append(text);
                }
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}
