namespace AllanLimaClass
{
    public class MySqlCommand
    {
        public string CommandText { get; internal set; }
        internal MySqlConnection Connection { get; set; }
    }
}