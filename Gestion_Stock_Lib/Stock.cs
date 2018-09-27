using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Stock_Lib
{
    public class Stock
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        int id_article;

        public int Id_article
        {
            get { return id_article; }
            set { id_article = value; }
        }

        int id_depot;

        public int Id_depot
        {
            get { return id_depot; }
            set { id_depot = value; }
        }
        DateTime date_stock;

        public DateTime Date_stock
        {
            get { return date_stock; }
            set { date_stock = value; }
        }

    }
}
