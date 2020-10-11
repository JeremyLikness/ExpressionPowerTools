// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;

namespace ExpressionPowerTools.Serialization
{
    /// <summary>
    /// Attribute to tag a key that can be compressed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CompressableKeyAttribute : Attribute
    {
    }
}
