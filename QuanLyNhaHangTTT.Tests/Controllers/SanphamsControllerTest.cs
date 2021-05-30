using Moq;
using System;
using System.Web;
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
        [TestMethod]
        public void TestCreateG()
        {
            var controller = new SanphamsController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreateP()
        {
            var rand = new Random();
            var product = new Sanpham
            {
                Tên_món_ăn = rand.NextDouble().ToString(),
                Số_lượng = -rand.Next(),
                Giá_tiền = -rand.Next()
            };
            var controller = new SanphamsController();

            var result0 = controller.Create( product, null) as ViewResult;
            Assert.IsNotNull(result0);
            Assert.AreEqual("Giá tiền phải lớn hơn 0", controller.ModelState["Giá_tiền"].Errors[0].ErrorMessage);
            //product.Giá_tiền = -product.Giá_tiền;
            //controller.ModelState.Clear();

            Assert.AreEqual("Số lượng phải lớn hơn 0", controller.ModelState["Số_lượng"].Errors[0].ErrorMessage);
            //product.Số_lượng = -product.Số_lượng;
            //controller.ModelState.Clear();

            //result0 = controller.Create(product, null) as ViewResult;
            //Assert.IsNotNull(result0);
            //Assert.AreEqual("hình ảnh không được tìm thấy!", controller.ModelState[""].Errors[0].ErrorMessage);
            
            //var picture = new Mock<HttpPostedFileBase>();
            //var result1 = controller.Create(product, picture.Object);
        }
    }
}