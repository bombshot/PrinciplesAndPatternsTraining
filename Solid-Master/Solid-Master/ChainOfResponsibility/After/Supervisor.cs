namespace Solid_Master.ChainOfResponsibility.After
{
    class Supervisor : Reviewer
    {
        public Supervisor(string name, Reviewer supervisor) : base(name, supervisor)
        {
        }

        public override ReviewResult Review(Document document)
        {
            //Logic based on Supervisor's mood 
            return new ReviewResult(true, document, Name);
        }
    }
}
