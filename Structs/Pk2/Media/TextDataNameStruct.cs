using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Pk2.Media
{
    public struct TextDataNameStruct
    {
        public byte Service;
        public string Code;
        public string Korean;
        public string Unknow1;
        public string Unknow2;
        public string Chinese;
        public string Taiwan;
        public string Japan;
        public string English;
        public string Viethnam;
        public string Thailand;
        public string Russian;
        public string Turkish;
        public string Spanish;
        public string Arabic;
        public string Deutch;


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
