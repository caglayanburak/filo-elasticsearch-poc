using System;
using System.Linq;
using System.Reflection;
using Nest;

namespace FiloElasticSearchPoc.Repository
{
    public static class ExtensionHelper
    {
        /// <summary>
        /// Firsts the letter lower.Ex: CustomerName => customerName
        /// </summary>
        /// <returns>The letter lower.</returns>
        /// <param name="word">Word.</param>
        public static string FirstLetterLower(this string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }
            return Char.ToLowerInvariant(word[0]) + word.Substring(1);
        }


        public static FieldNameQueryBase Boost(this FieldNameQueryBase query,PropertyInfo pInfo)
        {
           
            return query;
        }
    }
}
