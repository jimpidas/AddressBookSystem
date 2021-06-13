using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem_ADO
{
    class AddressBookModel
    {
        public int person_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string book_type { get; set; }
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string city { get; set; }
        public int zip { get; set; }
        public string state { get; set; }
        
    }
}
