namespace FMUtility.Data.Queries
{
    public interface IQuery<in T>
    {
        bool IsMatch(T model);
    }

    public class GetAllQuery<T> : IQuery<T>
    {
        public bool IsMatch(T model)
        {
            return true;
        }
    }
}