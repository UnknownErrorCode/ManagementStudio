namespace ServerFrameworkRes.Handler
{
    public static class Caller
    {
        #region Methods

        public static string GetFilePath([System.Runtime.CompilerServices.CallerFilePath] string filePath = null)
        {
            return filePath;
        }

        public static int GetLineNumber([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }

        public static string GetMemberName([System.Runtime.CompilerServices.CallerMemberName] string memberName = null)
        {
            return memberName;
        }

        #endregion Methods
    }
}