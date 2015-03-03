using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Documents.FormatProviders;
using Telerik.Windows.Documents.Model;

namespace TelerikWpfApp2
{
    public class DataProvider
    {
        private const string SampleDocumentPath = @"SampleData\document.xaml";


        public static RadDocument LoadDocument()
        {
            RadDocument document;
            using (Stream stream = Application.GetResourceStream(GetResourceUri(SampleDocumentPath)).Stream)
            {
                IDocumentFormatProvider xamlProvider = DocumentFormatProvidersManager.GetProviderByExtension(".xaml");
               document = xamlProvider.Import(stream);
            }

            return document;
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(DataProvider).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }

    }
}
