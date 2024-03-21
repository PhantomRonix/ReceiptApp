using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptApp
{
    internal class Product
    {
        //no id should be below 0
        private uint productID;
        //rating has a limit of 0-100, written as 0-10.0
        private uint rating;
        private float volume;
        private VolumeType volumeType;
        private string name, brandName, comment;
        private List<string> tags;
        private List<Location> locations;

        public uint ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public uint Rating
        {
            get { return rating; }
            set { if (value < 100 && value > 0) { rating = value; } }
        }
        public float Volume
        {
            get { return volume; }
            set { if (value > 0) { volume = value; } }
        }
        public VolumeType VolumeType
        {
            get { return volumeType; }
            set { volumeType = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public Product(uint ID, float vol, VolumeType voltype, string name, string brandname)
        {
            productID = ID;
            volume = vol;
            volumeType = voltype;
            this.name = name;
            brandName = brandname;
            comment = "";
            tags = new List<string>();
            locations = new List<Location>();
        }
    }
}
