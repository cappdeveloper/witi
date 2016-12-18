using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


public static class EnumHelper
{
    public static SelectList ToSelectList<TEnum>(this TEnum enumObj, int selected, bool sortByText = true)
    {
        List<SelectListItem> items = new List<SelectListItem>();

        foreach (var i in Enum.GetValues(typeof(TEnum)))
        {

            items.Add(new SelectListItem
            {
                Text = GetDescriptionInternal(((int)i), enumObj),
                Value = ((int)i).ToString(),
                Selected = (((int)i) == selected ? true : false)
            });
        }

        if (sortByText)
            items = items.OrderBy(x => x.Text).ToList();

        return new SelectList(items, "Value", "Text", selected);
    }

    public static string GetDescriptionInternal<TEnum>(int id, TEnum enumObj)
    {
        FieldInfo field = enumObj.GetType().GetField(enumObj.GetType().GetEnumName(id));

        if (field != null)
        {
            DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attr != null)
            {
                return attr.Description;
            }
            else
            {
                return field.Name;
            }
        }
        return null;
    }

    public static string GetName(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
}
