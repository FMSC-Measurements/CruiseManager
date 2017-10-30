using CruiseDAL.DataObjects;
using Dapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvol.Data;
using Xunit;

namespace CruiseManager.Test.Tvol
{
    public class CreateTvolPresenterTest : IDisposable
    {
        private string _pathToTvol;

        public CreateTvolPresenterTest()
        {
            _pathToTvol = System.IO.Path.GetFullPath("CreateTvolFileTest.tvol");
        }

        [Fact]
        public void CreateFileTest()
        {
            if(System.IO.File.Exists(_pathToTvol))
            {
                System.IO.File.Delete(_pathToTvol);
            }

            using (var cruiseDB = new CruiseDAL.DAL("TestFiles\\MultiTest.2014.10.31.cruise"))
            {
                Core.Tvol.CreateTvolPresenter.CreateFile(cruiseDB, _pathToTvol);
            }

            System.IO.File.Exists(_pathToTvol).Should().BeTrue();

            var tvolDB = new TvolDatabase(_pathToTvol);
            using(var conn = tvolDB.OpenConnection())
            {
                var sale = conn.Query<Sale>("SELECT * FROM Sale LIMIT 1;").FirstOrDefault();
                sale.Should().NotBeNull();
                sale.SaleNumber.ShouldBeEquivalentTo(12345);

                var treeProfiles = conn.Query<TreeProfile>("SELECT * FROM TreeProfile;").ToList();
                treeProfiles.Should().NotBeEmpty();
                treeProfiles.Should().OnlyContain(
                    x => !string.IsNullOrWhiteSpace(x.LiveDead)
                    && x.Product > 0
                    && !string.IsNullOrWhiteSpace(x.Species));
            }
        }

        [Fact]
        public void PropertyChangedTest()
        {
            var presenter = new Core.Tvol.CreateTvolPresenter(null);
            presenter.MonitorEvents();
            presenter.FilePath = "something";
            presenter.ShouldRaisePropertyChangeFor(x => x.FilePath);
        }

        public void Dispose()
        {
            //System.IO.File.Delete(_pathToTvol);
        }
    }
}
