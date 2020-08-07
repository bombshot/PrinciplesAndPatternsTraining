namespace Solid_Master.ChainOfResponsibility.After
{
    class ReviewResult
    {
        private readonly string _name;

        public ReviewResult(bool isApproved, Document document, string name)
        {
            _name = name;
            IsApproved = isApproved;
            Document = document;
        }

        public bool IsApproved { get; }
        public Document Document { get; }

    }
}
