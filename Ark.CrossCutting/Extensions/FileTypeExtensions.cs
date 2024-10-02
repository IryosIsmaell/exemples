﻿using Ark.CrossCutting.Attributes;
using System.ComponentModel;

namespace Ark.CrossCutting.Extensions
{
    internal static class FileTypeExtensions
    {
        public static string ToDescriptionString(this FileType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
