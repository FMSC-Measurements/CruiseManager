using CruiseManager.Utility;
using FluentAssertions;
using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace CSMTest
{
    public class COConverterTest
    {
        public readonly string TEST_CRZ_FILE = ".\\TestFiles\\TESTMETH.crz";
        public readonly string OUTPUT_CURSE_FILE = ".\\TestFiles\\TESTMETH_CONVERTED_TEST.cruise";

        [Fact]
        public void COConverterConstructorTest()
        {
            File.Exists(TEST_CRZ_FILE).Should().BeTrue();
            if (File.Exists(OUTPUT_CURSE_FILE))
            {
                File.Delete(OUTPUT_CURSE_FILE);
            }

            COConverter target = new COConverter();

            var result = target.BenginConvert(TEST_CRZ_FILE, OUTPUT_CURSE_FILE, null, null);
            var value = target.EndConvert(result);

            target.ErrorOutput.Should().BeNullOrEmpty();
            value.Should().BeTrue();
        }
    }
}