﻿using PublicApiGeneratorTests.Examples;
using Xunit;

namespace PublicApiGeneratorTests
{
    public class Interface_method_return_value_attributes : ApiGeneratorTestsBase
    {
        [Fact]
        public void Should_add_attribute_with_no_parameters()
        {
            AssertPublicApi<IMethodReturnValueWithSimpleAttribute>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValueWithSimpleAttribute
    {
        [return: PublicApiGeneratorTests.Examples.SimpleAttribute()]
        void Method();
    }
}");
        }

        [Fact]
        public void Should_add_attribute_with_positional_parameters()
        {
            AssertPublicApi<IMethodReturnValuesWithAttributeWithPositionalParameters>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValuesWithAttributeWithPositionalParameters
    {
        [return: PublicApiGeneratorTests.Examples.AttributeWithPositionalParameters1Attribute(""Hello"")]
        void Method1();
        [return: PublicApiGeneratorTests.Examples.AttributeWithPositionalParameters2Attribute(42)]
        void Method2();
        [return: PublicApiGeneratorTests.Examples.AttributeWithMultiplePositionalParametersAttribute(42, ""Hello world"")]
        void Method3();
    }
}");
        }

        [Fact]
        public void Should_add_attribute_with_named_parameters()
        {
            AssertPublicApi<IMethodReturnValuesWithAttributeWithNamedParameters>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValuesWithAttributeWithNamedParameters
    {
        [return: PublicApiGeneratorTests.Examples.AttributeWithNamedParameterAttribute(StringValue=""Hello"")]
        void Method1();
        [return: PublicApiGeneratorTests.Examples.AttributeWithNamedParameterAttribute(IntValue=42)]
        void Method2();
    }
}");
        }

        [Fact]
        public void Should_add_multiple_named_parameters_in_alphabetical_order()
        {
            AssertPublicApi<IMethodReturnValueWithAttributeWithMultipleNamedParameters>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValueWithAttributeWithMultipleNamedParameters
    {
        [return: PublicApiGeneratorTests.Examples.AttributeWithNamedParameterAttribute(IntValue=42, StringValue=""Hello world"")]
        void Method();
    }
}");
        }

        [Fact]
        public void Should_add_attribute_with_both_named_and_positional_parameters()
        {
            AssertPublicApi<IMethodReturnValueWithAttributeWithBothNamedAndPositionalParameters>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValueWithAttributeWithBothNamedAndPositionalParameters
    {
        [return: PublicApiGeneratorTests.Examples.AttributeWithNamedAndPositionalParameterAttribute(42, ""Hello world"", IntValue=13, StringValue=""Thingy"")]
        void Method();
    }
}");
        }

        [Fact]
        public void Should_expand_enum_flags()
        {
            AssertPublicApi<IMethodReturnValueWithAttributeWithEnumFlags>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValueWithAttributeWithEnumFlags
    {
        [return: PublicApiGeneratorTests.Examples.AttributeWithEnumFlagsAttribute(PublicApiGeneratorTests.Examples.EnumWithFlags.One | PublicApiGeneratorTests.Examples.EnumWithFlags.Two | PublicApiGeneratorTests.Examples.EnumWithFlags.Three)]
        void Method();
    }
}");
        }

        [Fact]
        public void Should_add_multiple_attributes_in_alphabetical_order()
        {
            AssertPublicApi<IMethodReturnValueWithMultipleAttributes>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValueWithMultipleAttributes
    {
        [return: PublicApiGeneratorTests.Examples.Attribute_AA()]
        [return: PublicApiGeneratorTests.Examples.Attribute_MM()]
        [return: PublicApiGeneratorTests.Examples.Attribute_ZZ()]
        void Method();
    }
}");
        }

        [Fact]
        public void Should_order_return_and_method_attributes_correctly()
        {
            AssertPublicApi<IMethodWithAttributesOnMethodAndReturnValue>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodWithAttributesOnMethodAndReturnValue
    {
        [PublicApiGeneratorTests.Examples.SimpleAttribute()]
        [return: PublicApiGeneratorTests.Examples.SimpleAttribute()]
        void Method();
    }
}");
        }

        [Fact]
        public void Should_skip_excluded_attribute()
        {
            AssertPublicApi<IMethodReturnValueWithAttributeWithMultipleNamedParameters>(
                @"namespace PublicApiGeneratorTests.Examples
{
    public interface IMethodReturnValueWithAttributeWithMultipleNamedParameters
    {
        void Method();
    }
}", excludeAttributes: new[] { "PublicApiGeneratorTests.Examples.AttributeWithNamedParameterAttribute" });
        }
    }

    // ReSharper disable UnusedMember.Global
    // ReSharper disable ClassNeverInstantiated.Global
    namespace Examples
    {
        public interface IMethodReturnValueWithSimpleAttribute
        {
            [return: SimpleAttribute]
            void Method();
        }

        public interface IMethodReturnValuesWithAttributeWithPositionalParameters
        {
            [return: AttributeWithPositionalParameters1("Hello")]
            void Method1();

            [return: AttributeWithPositionalParameters2(42)]
            void Method2();

            [return: AttributeWithMultiplePositionalParameters(42, "Hello world")]
            void Method3();
        }

        public interface IMethodReturnValuesWithAttributeWithNamedParameters
        {
            [return: AttributeWithNamedParameter(StringValue = "Hello")]
            void Method1();

            [return: AttributeWithNamedParameter(IntValue = 42)]
            void Method2();
        }

        public interface IMethodReturnValueWithAttributeWithMultipleNamedParameters
        {
            [return: AttributeWithNamedParameter(StringValue = "Hello world", IntValue = 42)]
            void Method();
        }

        public interface IMethodReturnValueWithAttributeWithBothNamedAndPositionalParameters
        {
            [return: AttributeWithNamedAndPositionalParameter(42, "Hello world", StringValue = "Thingy", IntValue = 13)]
            void Method();
        }

        public interface IMethodReturnValueWithAttributeWithEnumFlags
        {
            [return: AttributeWithEnumFlags(EnumWithFlags.One | EnumWithFlags.Two | EnumWithFlags.Three)]
            void Method();
        }

        public interface IMethodReturnValueWithMultipleAttributes
        {
            [return: Attribute_ZZ]
            [return: Attribute_MM]
            [return: Attribute_AA]
            void Method();
        }

        public interface IMethodWithAttributesOnMethodAndReturnValue
        {
            [SimpleAttribute]
            [return: SimpleAttribute]
            void Method();
        }
    }
    // ReSharper restore ClassNeverInstantiated.Global
    // ReSharper restore UnusedMember.Global
}