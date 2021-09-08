using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Pk2.Media
{
    public struct TextUISystemStruct
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
        public TextUISystemStruct(string[] array)
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
            Thailand = array[10];
            Russian = array[11];
            Turkish = array[12];
            Spanish = array[13];
            Arabic = array[14];
            Deutch = array[15];
        }
    }
}
