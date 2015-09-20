using AngularSPAwithOffline.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace AngularSPAwithOffline.Controllers
{
    public class AppCacheController : Controller
    {
        // GET: AppCache
        public ActionResult AppManifest()
        {
            // Build the model
            var model = new AppCacheModel();

            model.AssemblyVersion = GetType().Assembly.GetName().Version.ToString();
            model.CacheCollection = new List<string>();
            model.CacheCollection.Add(WriteBundle("~/Content/css"));
            model.CacheCollection.Add(WriteBundle("~/bundles/modernizr"));
            model.CacheCollection.Add(WriteBundle("~/bundles/bootstrap"));
            model.CacheCollection.Add(WriteBundle("~/bundles/AwesomeAngularMVCApp"));
            //model.CacheCollection.Add(GetPhysicalFilesToCache("~/images", "*.jpg", string.Empty));
            //model.CacheCollection.Add(GetPhysicalFilesToCache("~/images", "*.png", string.Empty));
            //model.CacheCollection.Add(GetPhysicalFilesToCache("~/Content", "style*.css", string.Empty));

            return View(model);
        }

        private string WriteBundle(string virtualPath)
        {
            var bundleString = new StringBuilder();
            bundleString.AppendLine(Scripts.Url(virtualPath).ToString());
            return bundleString.ToString();
        }

        private string GetPhysicalFilesToCache(string relativeFolderToAssets, string fileTypes, string cdnBucket)
        {
            var outputString = new StringBuilder();
            var folder = new DirectoryInfo(Server.MapPath(relativeFolderToAssets));
            foreach (FileInfo file in folder.GetFiles(fileTypes))
            {
                string location = !String.IsNullOrEmpty(cdnBucket) ? cdnBucket : relativeFolderToAssets;
                string outputFileName = (location + "/" + file).Replace("~", string.Empty);
                outputString.AppendLine(outputFileName);
            }
            return outputString.ToString();
        }
    }
}