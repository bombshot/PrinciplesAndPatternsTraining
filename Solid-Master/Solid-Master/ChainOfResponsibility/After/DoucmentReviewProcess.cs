namespace Solid_Master.ChainOfResponsibility.After
{
    class DoucmentReviewProcess
    {
        public ReviewResult Review(Document document)
        {
            Reviewer reviewer = new Reviewer("Editor", new Reviewer("Group Editor", null));
            return reviewer.Review(document);
        }
    }
}
