namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public class AsyncBuffer
    {
        #region Constructors

        public AsyncBuffer(byte[] buffer, int offset, int count)
        {
            Buffer = buffer;
            Offset = offset;
            Count = count;
        }

        public AsyncBuffer(byte[] buffer)
        {
            Buffer = buffer;
            Offset = 0;
            Count = buffer.Length;
        }

        #endregion Constructors

        #region Properties

        public byte[] Buffer { get; set; }
        public int Count { get; set; }
        public int Offset { get; set; }

        #endregion Properties
    }
}