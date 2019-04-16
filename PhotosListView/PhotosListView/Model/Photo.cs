using System;
using System.Collections.Generic;
using System.Text;

namespace PhotosListView.Model
{
    class Photo
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        public Photo() { }

        public Photo(string c, string d, string t)
        {
            Caption = c;
            Description = d;
            Tags = t;
        }

               
    }


}
