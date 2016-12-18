using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


public static class Extensions
{
    

    public static SelectList MakeSelection(this SelectList list, object selection)
    {
        return new SelectList(list.Items, list.DataValueField, list.DataTextField, selection);
    }

    public static IEnumerable<SelectListItem> MakeSelection(this IEnumerable<SelectListItem> list, object selection)
    {
        if (selection == null) { selection = "-1"; };

        var items = list.ToList();
        foreach (var i in items)
        {
            if (i.Value == selection.ToString())
            {
                i.Selected = true;
            }
            else
            {
                i.Selected = false;
            }
        }
        return items.AsEnumerable();
    }

    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength) + " ...";
    }

}
