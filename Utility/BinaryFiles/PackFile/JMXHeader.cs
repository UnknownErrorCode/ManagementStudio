namespace BinaryFiles.PackFile
{
    public struct JMXHeader : IPaddedString
    {
        public JMXHeader(char[] value, JmxFileFormat file)
        {
            Value = new string(value);
            File = file;
        }

        public int Length => 12;

        public string Value { get; set; }

        public JmxFileFormat File { get; }

    }

    public enum JmxFileFormat : byte
    {
        _m,
        _o,
        _o2,
        _t,
        _ifo,
        _2dt,
        _bsr,
        _bmt,
        _bms,
        _bsk,
        _ban,
        _efp,
        _ddj,
        _nav,
        _navDat,
        _dof,
        _wav,
        _snd,
    }

    public interface IPaddedString
    {
        int Length { get; }
        string Value { get; set; }
    }
}
