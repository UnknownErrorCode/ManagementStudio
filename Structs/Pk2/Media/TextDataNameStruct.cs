using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Pk2.Media
{
    public struct TextDataNameStruct
    {
        public byte Service { get; set; }
        public string Code { get; set; }
        public string Korean { get; set; }
        public string Unknow1 { get; set; }
        public string Unknow2 { get; set; }
        public string Chinese { get; set; }
        public string Taiwan { get; set; }
        public string Japan { get; set; }
        public string English { get; set; }
        public string Viethnam { get; set; }
        public string Thailand { get; set; }
        public string Russian { get; set; }
        public string Turkish { get; set; }
        public string Spanish { get; set; }
        public string Arabic { get; set; }
        public string Deutch { get; set; }


        public TextDataNameStruct(string[] array)
        {
            if (Byte.TryParse(array[0], out byte service))
                Service = service;
            else
                Service = 0;

            Code = array[1];
            Korean = array[2];
            Unknow1 = array[3];
            Unknow2 = array[4];
            Chinese = array[5];
            Taiwan = array[6];
            Japan = array[7];
            English = array[8];
            Viethnam = array[9];
            Thailand = ""; // obsolete array[10] ==null ? "" : array[10];
            Russian = ""; // obsolete array[11] == null ? "" : array[11];
            Turkish = ""; // obsolete array[12] == null ? "" : array[12];
            Spanish = ""; // obsolete array[13] == null ? "" : array[13];
            Arabic = ""; // obsolete array[14] == null ? "" :  array[14];
            Deutch = "";  // obsolete array[15] == null ? "" :  array[15];
        }
    }
}
