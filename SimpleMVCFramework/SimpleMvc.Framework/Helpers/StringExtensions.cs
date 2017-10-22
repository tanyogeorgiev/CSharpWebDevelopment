namespace SimpleMvc.Framework.Helpers
{
    public static class StringExtensions
    {
        public static  string Capitalize (this string input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }
            var firstLetter = input[0].ToString().ToUpper();
            var rest = input.Substring(1);
            return $"{firstLetter}{rest}";
        }
    }
}
