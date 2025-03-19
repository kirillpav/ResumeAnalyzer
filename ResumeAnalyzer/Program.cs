// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using Microsoft.ML;
using Microsoft.ML.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Resume analyzer");

        string pdfPath = "../../../cv/testcv.pdf";
        using var reader = new PdfReader(pdfPath);
        using var pdfDoc = new PdfDocument(reader);
        
        string pdfText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(1));
        Console.WriteLine("Extracted Text:");
        Console.WriteLine(pdfText);
    }
}