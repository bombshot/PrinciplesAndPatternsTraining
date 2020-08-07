using System;
using System.Text;

namespace SOLID.Assessment.After
{
    public class HtmlFormatter : IFormatter
    {
        private const string LineBreak = "<BR/>";
        private string _header;

        private readonly StringBuilder _htmlBodyBuilder;

        private static void Guard(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value), message);
            }
        }

        public HtmlFormatter()
        {
            _htmlBodyBuilder = new StringBuilder();
        }

        public void AppendHeader(string header)
        {
            Guard(header, "Header cannot be null or empty");
            
            _header = $"<H1>{header}</H1>";
        }

        public string ToReportString()
        {
            return _header + _htmlBodyBuilder;
        }

        public void AppendBodyElement(string key, string value)
        {
            Guard(key, "Key cannot be null or empty");
            Guard(value, "Header cannot be null or empty");
            
            _htmlBodyBuilder.Append($"{LineBreak}{key}: {value}");
        }

        public void AppendText(string text)
        {
            Guard(text, "Text cannot be null or empty");

            _htmlBodyBuilder.Append($"{LineBreak}{text}");
        }

        public void AppendBodyElement(string label, string key, string value)
        {
            Guard(key, "Key cannot be null or empty");
            Guard(value, "Header cannot be null or empty");
            Guard(label, "Label cannot be null or empty");

            _htmlBodyBuilder.Append($"{LineBreak}{label}: {key}, {value}");
        }
    }
}