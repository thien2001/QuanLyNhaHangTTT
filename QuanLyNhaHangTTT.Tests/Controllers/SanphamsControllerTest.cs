using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyNhaHangTTT.Controllers;
using QuanLyNhaHangTTT.Models;

namespace QuanLyNhaHangTTT.Tests.Controllers
{
    [TestClass]
    public class SanPhamControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new SanphamsController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<Sanpham>;
            Assert.IsNotNull(model);

            var db = new CT25Team111Entities();
            Assert.AreEqual(db.Sanphams.Count(), model.Count);
        }

        [TestMethod]
        public void TestIndex2()
        {
            var controller = new SanphamsController();

            var result = controller.Index2() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<Sanpham>;
            Assert.IsNotNull(model);

            var db = new CT25Team111Entities();
            Assert.AreEqual(db.Sanphams.Count(), model.Count);
        }
    }
}