using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;

namespace Library.Web.Code
{
    public class AngularTemplateBundle : Bundle
    {
        public AngularTemplateBundle(string virtualPath)
            : this(virtualPath, (string)null)
        {
        }
        
        public AngularTemplateBundle(string virtualPath, string moduleName)
            : this(virtualPath, (string)null, moduleName)
        {
        }

        public AngularTemplateBundle(string virtualPath, string cdnPath, string moduleName)
            : base(virtualPath, cdnPath, new AngularTemplateBundleTransform(moduleName))
        {
        }
    }
    
    public class AngularTemplateBundleTransform : IBundleTransform
    {
        private readonly string _moduleName;

        public AngularTemplateBundleTransform(string moduleName)
        {
            _moduleName = moduleName;
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("(function(){{angular.module('{0}')", _moduleName);
            builder.AppendLine(".run(['$templateCache', function($templateCache) {");

            foreach (var file in response.Files.Select(bundleFile => bundleFile.VirtualFile).Where(file => !file.IsDirectory))
            {
                using (var reader = new StreamReader(file.Open()))
                {
                    var ngTemplate = string.Format("$templateCache.put('{0}', '{1}');", file.VirtualPath, reader.ReadToEnd().Trim().Replace("'", "\\'").Replace("\r\n", " ").Replace("\n", " "));
                    builder.AppendLine(ngTemplate);
                }
            }

            builder.AppendLine("}]);})();");

            response.Files = new BundleFile[0];
            response.Content = builder.ToString();
            response.ContentType = "text/javascript";
        }
    }
}