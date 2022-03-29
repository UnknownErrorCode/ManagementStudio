using System.Runtime.InteropServices;
using System.Text;

namespace StudioServer.Config
{
    public class InitializeFile
    {
        #region Public Fields

        public string path;

        #endregion Public Fields

        #region Public Constructors

        public InitializeFile(string INIPath)
        {
            path = INIPath;
        }

        #endregion Public Constructors

        #region Public Methods

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            long i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        #endregion Public Methods

        #region Private Methods

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        #endregion Private Methods
    }
}