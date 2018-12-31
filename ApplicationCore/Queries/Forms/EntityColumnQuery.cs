using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Queries.Forms
{
    public class EntityColumnQuery
    {
        public int row_id { set; get; }
        public int id { set; get; }
        public string column_name { set; get; }
        public string nullable { set; get; }
        public string db_data_type { set; get; }
        public string value { set; get; }
        public int? max_length { set; get; }
        public string primary_key { set; get; }
        public string data_type { set; get; }
        public bool is_serial { set; get; }
    }
}
