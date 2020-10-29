﻿using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using Xunit.Sdk;

[UsesVerify]
public class Tests
{
    [Theory]
    [InlineData("Value1")]
    public async Task MissingParameter(string arg)
    {
        var exception = await Assert.ThrowsAsync<XunitException>(() => Verifier.Verify("Foo"));
        Assert.Contains("requires parameters", exception.Message);
    }

    [Fact]
    public Task VerifyFileContent()
    {
        return Verifier.VerifyFileContent("Foo", "ext");
    }

    [Fact]
    public Task VerifyJson()
    {
        return Verifier.VerifyJson("{x:y}");
    }
}