namespace Euler.Data
{
    public class CsvUnitOfWork : IUnitOfWork
    {
        public CsvUnitOfWork()
        {
            var problems = CSVHelper.LoadProblems();
            Problems = new ProblemRepository(problems);
        }

        public IProblemRepository Problems { get; set; }

        public void Save()
        {
            CSVHelper.SaveProblems(Problems.GetAll());
        }

        public void Dispose()
        {
            Problems = null;
        }
    }
}
