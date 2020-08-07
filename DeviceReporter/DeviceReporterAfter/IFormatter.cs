namespace SOLID.Assessment.After
{
    public interface IFormatter
    {
        void AppendHeader(string header);
        string ToReportString();
        void AppendBodyElement(string label, string key, string value);
        void AppendBodyElement(string key, string value);
        void AppendText(string text);
    }
}