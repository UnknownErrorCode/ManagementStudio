namespace ManagementServer.Utility
{
    internal partial class SQL
    {
        public struct SaveResult
        {
            public bool Success { get; set; }
            public string Status { get; set; }
            public string Message { get; set; }
        }

    }
}