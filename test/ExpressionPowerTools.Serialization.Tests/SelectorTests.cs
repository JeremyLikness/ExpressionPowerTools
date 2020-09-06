using System;
using System.Linq;
using System.Reflection;
using ExpressionPowerTools.Serialization.Extensions;
using ExpressionPowerTools.Serialization.Rules;
using Xunit;

namespace ExpressionPowerTools.Serialization.Tests
{
    public class SelectorTests
    {
        public class Nested
        {
            public Nested()
            {
            }

            public Nested(int prop)
            {
                Prop = prop;
            }

            public int Prop { get; set; }
        }

        public int field;
        public int Property { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "xUnit1013:Public method should be marked as test",
            Justification = "Used by tests.")]
        public void SelectorMethod(string parameter) { }

        public FieldInfo fieldInfo = typeof(SelectorTests)
            .GetField(nameof(field));
        public PropertyInfo propertyInfo = typeof(SelectorTests)
            .GetProperty(nameof(Property));
        public MethodInfo methodInfo = typeof(SelectorTests)
            .GetMethod(nameof(SelectorMethod));
        public ConstructorInfo ctorInfo = typeof(Nested)
            .GetConstructors().First(c => c.GetParameters().Length > 0);

        public object memberSelector = null;

        private MemberSelector<T> typedMemberSelector<T>()
            where T : MemberInfo => memberSelector as MemberSelector<T>;

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Usage",
            "xUnit1013:Public method should be marked as test",
            Justification = "Used by tests.")]
        public void SelectMember<T>(Action<MemberSelector<T>> selectMember)
            where T : MemberInfo
        {
            memberSelector = new MemberSelector<T>();
            selectMember((MemberSelector<T>)memberSelector);
        }

        [Fact]
        public void GivenFieldSelectorWhenByFieldInfoThenShouldSetFieldInfo()
        {
            SelectMember<FieldInfo>(selectField => selectField.ByMemberInfo(fieldInfo));
            Assert.Same(fieldInfo, typedMemberSelector<FieldInfo>().Member[0]);
        }

        [Fact]
        public void GivenFieldSelectorWhenByNameForTypeThenShouldSetFieldInfo()
        {
            SelectMember<FieldInfo>(selectField => selectField.ByNameForType(
                GetType(), nameof(field)));
            Assert.Same(fieldInfo, typedMemberSelector<FieldInfo>().Member[0]);
        }

        [Fact]
        public void GivenFieldSelectorWhenByNameForTypeTypedThenShouldSetFieldInfo()
        {
            SelectMember<FieldInfo>(selectField => selectField.ByNameForType<FieldInfo, SelectorTests>
            (nameof(field)));
            Assert.Same(fieldInfo, typedMemberSelector<FieldInfo>().Member[0]);
        }

        [Fact]
        public void GivenFieldSelectorWhenByResolveThenShouldSetFieldInfo()
        {
            SelectMember<FieldInfo>(selectField => selectField.ByResolver<FieldInfo, SelectorTests>
            (st => st.field));
            Assert.Same(fieldInfo, typedMemberSelector<FieldInfo>().Member[0]);
        }

        [Fact]
        public void GivenPropertySelectorWhenByPropertyInfoThenShouldSetPropertyInfo()
        {
            SelectMember<PropertyInfo>(selectProperty => selectProperty.ByMemberInfo(propertyInfo));
            Assert.Same(propertyInfo, typedMemberSelector<PropertyInfo>().Member[0]);
        }

        [Fact]
        public void GivenPropertySelectorWhenByNameForTypeThenShouldSetPropertyInfo()
        {
            SelectMember<PropertyInfo>(selectProperty => selectProperty.ByNameForType(
                GetType(), nameof(Property)));
            Assert.Same(propertyInfo, typedMemberSelector<PropertyInfo>().Member[0]);
        }

        [Fact]
        public void GivenPropertySelectorWhenByNameForTypeTypedThenShouldSetPropertyInfo()
        {
            SelectMember<PropertyInfo>(selectProperty => selectProperty.ByNameForType<PropertyInfo, SelectorTests>
            (nameof(Property)));
            Assert.Same(propertyInfo, typedMemberSelector<PropertyInfo>().Member[0]);
        }

        [Fact]
        public void GivenPropertySelectorWhenByResolveThenShouldSetPropertyInfo()
        {
            SelectMember<PropertyInfo>(selectProperty => selectProperty.ByResolver<PropertyInfo, SelectorTests>
            (st => st.Property));
            Assert.Same(propertyInfo, typedMemberSelector<PropertyInfo>().Member[0]);
        }

        [Fact]
        public void GivenMethodSelectorWhenByMethodInfoThenShouldSetMethodInfo()
        {
            SelectMember<MethodInfo>(selectMethod => selectMethod.ByMemberInfo(methodInfo));
            Assert.Same(methodInfo, typedMemberSelector<MethodInfo>().Member[0]);
        }

        [Fact]
        public void GivenMethodSelectorWhenByNameForTypeThenShouldSetMethodInfo()
        {
            SelectMember<MethodInfo>(selectMethod => selectMethod.ByNameForType(
                GetType(), nameof(SelectorMethod)));
            Assert.Same(methodInfo, typedMemberSelector<MethodInfo>().Member[0]);
        }

        [Fact]
        public void GivenMethodSelectorWhenByNameForTypeTypedThenShouldSetMethodInfo()
        {
            SelectMember<MethodInfo>(selectMethod => selectMethod.ByNameForType<MethodInfo, SelectorTests>
            (nameof(SelectorMethod)));
            Assert.Same(methodInfo, typedMemberSelector<MethodInfo>().Member[0]);
        }

        [Fact]
        public void GivenMethodSelectorWhenByResolveThenShouldSetMethodInfo()
        {
            SelectMember<MethodInfo>(selectMethod => selectMethod.ByResolver<MethodInfo, SelectorTests>
            (st => st.SelectorMethod(string.Empty)));
            Assert.Same(methodInfo, typedMemberSelector<MethodInfo>().Member[0]);
        }

        [Fact]
        public void GivenMethodSelectorWhenByConstructorInfoThenShouldSetConstructorInfo()
        {
            SelectMember<ConstructorInfo>(selectCtor => selectCtor.ByMemberInfo(ctorInfo));
            Assert.Same(ctorInfo, typedMemberSelector<ConstructorInfo>().Member[0]);
        }

        [Fact]
        public void GivenMethodSelectorWhenByNameForTypeThenShouldThrowInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() =>
                SelectMember<ConstructorInfo>(selectCtor => selectCtor.ByNameForType(
                typeof(Nested), "whatever")));
        }

        [Fact]
        public void GivenMethodSelectorWhenByNameForTypeTypedThenShouldThrowInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                SelectMember<ConstructorInfo>(selectCtor => selectCtor.ByNameForType<ConstructorInfo, Nested>
                ("some string"));
            });
        }

        [Fact]
        public void GivenMethodSelectorWhenByResolveThenShouldSetConstructorInfo()
        {
            SelectMember<ConstructorInfo>(selectCtor => selectCtor.ByResolver<ConstructorInfo, Nested>
            (n => new Nested(nameof(Nested).GetHashCode())));
            Assert.Same(ctorInfo, typedMemberSelector<ConstructorInfo>().Member[0]);
        }
    }
}
