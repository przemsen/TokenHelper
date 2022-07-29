using System;
using System.Text.RegularExpressions;

namespace TokenHelper
{
    public sealed class ExtractJwtBearerTokenService
    {
        public string Input { get; set; }
        public string Output { get; set; }

        private static readonly Regex tokenRegex = new Regex(@".*Bearer ([a-zA-Z0-9_\.\-_]+)[""']", RegexOptions.Compiled);

        public void Extract()
        {
            var tokenMatch = tokenRegex.Match(Input);
            if (tokenMatch.Success && tokenMatch.Groups.Count > 1)
            {
                Output = tokenMatch.Groups[1].Value;
            }
            else
            {
                throw new TokenExtractionException();
            }
        }
    }

    public class TokenExtractionException : Exception
    {
        public TokenExtractionException(string message) : base(message)
        {
        }

        public TokenExtractionException()
        {
        }
    }
}