using System.Collections.Generic;

namespace BinaryFiles.PackFile.Data
{
    public class JMXifoFile
    {
        string JMXOBJI1000;
        public int ObjectCount;
        public Dictionary<int, JMXOBJI> Objects;
        public JMXifoFile(string fileText)
        {
            var singleRows = fileText.Split('\n');
            JMXOBJI1000 = singleRows[0];

            if (int.TryParse(singleRows[1], out ObjectCount))
            {
                Objects = new Dictionary<int, JMXOBJI>(ObjectCount);
                for (int i = 2; i < ObjectCount + 2; i++)
                {
                    Objects.Add(i - 2, new JMXOBJI() { JMXOBJIRow = singleRows[i].Split(' ') });
                }
            }
        }
    }

    public struct JMXOBJI
    {
        public string[] JMXOBJIRow { get; set; }
    }
}

