using ResumeAnalyzer.Models;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace ResumeAnalyzer.Services
{
    public class ResumeAnalyzerService
    {
        private readonly MLContext _mlContext;
        
        public ResumeAnalyzerService()
        {
            _mlContext = new MLContext();
        }

        public void AnalyzeText(string inputText)
        {
            var data = new List<TextData>() { new TextData() { Text = inputText } };
            var dataView = _mlContext.Data.LoadFromEnumerable(data);

            var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features: ", nameof(TextData.Text));
            var model = pipeline.Fit(dataView);
            
            var transformedData = model.Transform(dataView);
            var preview = transformedData.Preview();
            
            Console.WriteLine("Preview Features:");
            foreach (var row in preview.RowView)
            {
                foreach (var kv in row.Values)
                {
                    Console.WriteLine($"{kv.Key}: {kv.Value}");
                }
            }
        }
        
    }
}
