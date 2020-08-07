namespace Solid_Master.ChainOfResponsibility.After
{
    class Reviewer
    {
        public Reviewer Supervisor { get; }

        public string Name { get; }

        public Reviewer(string name, Reviewer supervisor)
        {
            Supervisor = supervisor;
            Name = name;
        }

        public virtual ReviewResult Review(Document document)
        {
            var isApproved = true;
            if (document.WordCount <= 300) return new ReviewResult(false, document, Name);
            if (document.WordCount > 500 && Supervisor != null)
                isApproved = Supervisor.Review(document).IsApproved;
            return new ReviewResult(isApproved, document, Name);
        }
    }
}
