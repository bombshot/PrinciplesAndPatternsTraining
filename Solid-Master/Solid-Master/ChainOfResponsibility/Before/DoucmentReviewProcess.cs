namespace Solid_Master.ChainOfResponsibility.Before
{
    class DoucmentReviewProcess
    {
        public ReviewResult Review(Document document, string reviewer, string manager)
        {
            bool isApproved = false;
            if(document.WordCount > 300)
                isApproved = document.WordCount > 500 || GetChiefEditorApproval(document, manager);

            return new ReviewResult(isApproved, document, reviewer);
        }

        private bool GetChiefEditorApproval(Document document, string manager)
        {
            //Some logic
            return true;
        }
    }
}
