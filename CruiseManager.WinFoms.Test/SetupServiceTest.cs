﻿using CruiseManager.WinForms.App;
using FluentAssertions;
using Xunit;

namespace CruiseManager.WinForms.Test
{
    public class SetupServiceTest
    {
        [Fact]
        public void GetCruiseMethodsTest()
        {
            var setupServ = new SetupService();
            var cruiseMethods = setupServ.GetCruiseMethods();

            cruiseMethods.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetLogFieldSetupsTest()
        {
            var setupServ = new SetupService();

            var logFields = setupServ.GetLogFieldSetups();
            logFields.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetLoggingMethodsTest()
        {
            var setupServ = new SetupService();

            var logMeths = setupServ.GetLoggingMethods();
            logMeths.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetProductCodesTest()
        {
            var setupServ = new SetupService();

            var prodCodes = setupServ.GetProductCodes();
            prodCodes.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetRegionsTest()
        {
            var setupServ = new SetupService();

            var regions = setupServ.GetRegions();
            regions.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetTreeFieldSetupsTest()
        {
            var setupServ = new SetupService();

            var treeFields = setupServ.GetTreeFieldSetups();
            treeFields.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GetUOMCodesTest()
        {
            var setupServ = new SetupService();

            var uomCodes = setupServ.GetUOMCodes();
            uomCodes.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void SaveCruiseMethodsTest()
        {
            var setupServ = new SetupService();

            var cruiseMethods = setupServ.GetCruiseMethods();
            cruiseMethods.RemoveAt(0);
            setupServ.SaveCruiseMethods(cruiseMethods);

            setupServ.GetCruiseMethods().Should().HaveSameCount(cruiseMethods);
        }

        [Fact]
        public void SaveLoggingMethodsTest()
        {
            var setupServ = new SetupService();
            var logMethods = setupServ.GetLoggingMethods();

            logMethods.RemoveAt(0);
            setupServ.SaveLoggingMethods(logMethods);

            setupServ.GetLoggingMethods().Should().HaveSameCount(logMethods);
        }

        [Fact]
        public void SaveProductCodesTest()
        {
            var setupServ = new SetupService();
            var prodCodes = setupServ.GetProductCodes();

            prodCodes.RemoveAt(0);
            setupServ.SaveProductCodes(prodCodes);
            setupServ.GetProductCodes().Should().HaveSameCount(prodCodes);
        }

        [Fact]
        public void SaveRegionsTest()
        {
            var setupServ = new SetupService();
            var list = setupServ.GetRegions();
            list.RemoveAt(0);
            setupServ.SaveRegions(list);
            setupServ.GetRegions().Should().HaveSameCount(list);
        }

        [Fact]
        public void SaveUOMCodesTest()
        {
            var setupServ = new SetupService();

            var list = setupServ.GetUOMCodes();
            list.RemoveAt(0);
            setupServ.SaveUOMCodes(list);
            setupServ.GetUOMCodes().Should().HaveSameCount(list);
        }
    }
}