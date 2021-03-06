﻿// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ExpressionPowerTools.Core.Contract;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ExpressionPowerTools.Serialization.EFCore.Http.Queryable
{
    /// <summary>
    /// Provides a starting point for building remote queries.
    /// </summary>
    /// <typeparam name="TContext">The <see cref="DbContext"/> the query is based on.</typeparam>
    public static class DbClientContext<TContext>
        where TContext : DbContext
    {
        /// <summary>
        /// Creates a trackable query based on the <see cref="DbContext"/> reference.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the query.</typeparam>
        /// <param name="template">A template to access the property.</param>
        /// <returns>A new <see cref="IQueryable"/> to usee.</returns>
        /// <exception cref="ArgumentNullException">Thrown when template is null.</exception>
        /// <exception cref="ArgumentException">Thrown when template does not refer to the right context.</exception>
        public static IQueryable<T> Query<T>(
            Expression<Func<TContext, DbSet<T>>> template)
            where T : class
        {
            VerifyTemplate(template);
            var memberExpression = template.AsEnumerable().OfType<MemberExpression>().First();
            return IQueryableExtensions.CreateQueryTemplate<T>()
                .AsRemoteQueryable(new RemoteContext(
                    typeof(TContext),
                    memberExpression.Member as PropertyInfo));
        }

        /// <summary>
        /// Verify that the template references a collection.
        /// </summary>
        /// <typeparam name="TType">The type of the query.</typeparam>
        /// <param name="template">The template to access the additional property.</param>
        /// <returns>The <see cref="PropertyInfo"/> of the property found.</returns>
        private static PropertyInfo VerifyTemplate<TType>(Expression<Func<TContext, DbSet<TType>>> template)
            where TType : class
        {
            Ensure.NotNull(() => template);
            var memberExpression = template.AsEnumerable().OfType<MemberExpression>().First();
            if (memberExpression.Member.DeclaringType != typeof(TContext))
            {
                throw new ArgumentException($"{typeof(DbContext)} <> {template}", nameof(template));
            }

            if (memberExpression.Member is PropertyInfo property)
            {
                if (!typeof(DbSet<TType>).IsAssignableFrom(property.PropertyType))
                {
                    throw new ArgumentException(
                        $"{typeof(TType)} <> {typeof(DbSet<TType>)}",
                        nameof(template));
                }
            }

            return memberExpression.Member as PropertyInfo;
        }
    }
}
