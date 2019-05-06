using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ArticleSelection.Controllers
{
    public class AlgorithmController : Controller
    {
        private string privateKey { get; set; }
        private string publicKey { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Asymmetric()
        {

            //RSA测试实例
            string oldData = "taiyonghai";
            CreateRSAKey();//创建加密公钥私钥
            string ciphertext = RSAEncrypt(oldData);//加密
            string newData = RSADecrypt(ciphertext);//解密
            string[] Result = { ciphertext, newData };
            //视图显示
            return View(Result);
        }

        #region Rsa加密实现
        /// <summary>
        /// 创建RSA公钥私钥
        /// </summary>
        public void CreateRSAKey()
        {
            //创建RSA对象
            var rsa = RSA.Create();
            //生成RSA[公钥私钥]
            //var rsaParameters = new RSAParameters();
            privateKey = rsa.ToXmlString(true);
            publicKey = rsa.ToXmlString(false);
        }
        /// <summary>
        /// 使用RSA实现加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <returns></returns>
        public string RSAEncrypt(string data)
        {
            //C#默认只能使用[公钥]进行加密(想使用[公钥解密]可使用第三方组件BouncyCastle来实现)
            //创建RSA对象并载入[公钥]
            RSACryptoServiceProvider rsaPublic = new RSACryptoServiceProvider();
            rsaPublic.FromXmlString(publicKey);
            //对数据进行加密
            byte[] publicValue = rsaPublic.Encrypt(Encoding.UTF8.GetBytes(data), false);
            string publicStr = Convert.ToBase64String(publicValue);//使用Base64将byte转换为string
            return publicStr;
        }
        /// <summary>
        /// 使用RSA实现解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <returns></returns>
        public string RSADecrypt(string data)
        {
            //C#默认只能使用[私钥]进行解密(想使用[私钥加密]可使用第三方组件BouncyCastle来实现)
            //创建RSA对象并载入[私钥]
            RSACryptoServiceProvider rsaPrivate = new RSACryptoServiceProvider();
            rsaPrivate.FromXmlString(privateKey);
            //对数据进行解密
            byte[] privateValue = rsaPrivate.Decrypt(Convert.FromBase64String(data), false);//使用Base64将string转换为byte
            string privateStr = Encoding.UTF8.GetString(privateValue);
            return privateStr;
        }
        #endregion
    }
}