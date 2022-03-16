namespace LeGrandRestaurantTest
{
    public interface ITable
    {
        public bool estLibre { get; set; }
        public void installerClient();
        public void liberer();
    }
}