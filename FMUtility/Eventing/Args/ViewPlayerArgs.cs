namespace FMUtility.Eventing.Args
{
    public class ViewPlayerArgs
    {
        public int Id { get; private set; }

        public ViewPlayerArgs(int id)
        {
            Id = id;
        }
    }
}
