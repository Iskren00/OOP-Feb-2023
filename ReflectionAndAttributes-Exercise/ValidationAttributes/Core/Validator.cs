﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Core;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        Type objType = obj.GetType();

        PropertyInfo[] propertyInfos = objType
            .GetProperties()
            .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.AttributeType)))
            .ToArray();

        foreach (PropertyInfo propertyInfo in propertyInfos)
        {
            IEnumerable<MyValidationAttribute> attributes = propertyInfo
                .GetCustomAttributes()
                .Where(ca => typeof(MyValidationAttribute)
                .IsAssignableFrom(ca.GetType()))
                .Cast<MyValidationAttribute>();

            foreach (var attribut in attributes)
            {
                if (!attribut.IsValid(propertyInfo.GetValue(obj)))
                {
                    return false;
                }
            }

        }

        return true;
    }
}
