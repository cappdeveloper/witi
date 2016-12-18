﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Helpers
{

    static string[] sizeSuffixes = {
        "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

    public static string ByteSize(long size)
    {
        
        const string formatTemplate = "{0}{1:0.#} {2}";

        if (size == 0)
        {
            return string.Format(formatTemplate, null, 0, sizeSuffixes[0]);
        }

        var absSize = Math.Abs((double)size);
        var fpPower = Math.Log(absSize, 1000);
        var intPower = (int)fpPower;
        var iUnit = intPower >= sizeSuffixes.Length
            ? sizeSuffixes.Length - 1
            : intPower;
        var normSize = absSize / Math.Pow(1000, iUnit);

        return string.Format(
            formatTemplate,
            size < 0 ? "-" : null, normSize, sizeSuffixes[iUnit]);
    }

    public static bool IsItemExistList(List<string> list, string text)
    {
        bool isExist = false;
        foreach (var item in list)
        {
            if (item.Equals(text))
            {
                isExist = true;
            }

        }
        return isExist;
    }
}
