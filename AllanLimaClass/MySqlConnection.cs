using System;

namespace AllanLimaClass
{
    internal class MySqlConnection
    {
        private string strcon;

        public MySqlConnection(string strcon)
        {
            this.strcon = strcon;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}