using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationCore.Forms.Utilities
{
    public static class Sanitizer
    {
        /// <summary>
        ///     Please do not use this function to fix the quotes against SQL injection attack.
        ///     This is not a replacement of parameterized statements.
        /// </summary>
        /// <param name="identifier">Column name or table name which needs to be sanitized</param>
        /// <returns>
        ///     Only alphabets and underscore are allowed characters in identifier name.
        ///     Anything else than that will be removed.
        /// </returns>
        public static string SanitizeIdentifierName(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
            {
                return null;
            }

            if (identifier.Contains("--"))
            {
                return string.Empty;
            }

            //Only alphabets [a-zA-Z], numbers, underscore, and a period is allowed.
            return identifier.Contains("/*") ? string.Empty : Regex.Replace(identifier, @"[^a-zA-Z0-9_.]", "");
        }
    }
}
