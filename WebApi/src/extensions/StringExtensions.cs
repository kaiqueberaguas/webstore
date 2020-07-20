﻿namespace webApi.src.extensions
{
    public static class StringExtensions
    {
        public static string ToCaptalize(this string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
        }
    }
}
