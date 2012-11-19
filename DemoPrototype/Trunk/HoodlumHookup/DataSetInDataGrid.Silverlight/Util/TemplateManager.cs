using System;
using System.Net;
using System.Windows.Resources;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace DataSetInDataGrid.Silverlight
{
	public class TemplateManager
	{
		public static Dictionary<string, string> DataTemplates;	

        // BLEND NOTE: The following WILL try to run in BLEND DESIGN MODE,
        // AND, the App.Current.Host.Source will be NULL in DESIGN MODE,
        // THEREFORE, the hardcoded Uri will be used.
        // A BETTER way to handle this would be to specify a DESIGN MODE mechanism,
        // WHEREBY the template can load a local resource instead of using a WEB CLIENT.
        // -- Rand.
		public static void LoadTemplate(string path)
		{
			WebClient wc = new WebClient();
			wc.OpenReadCompleted+=new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            Uri pathUri = null;
            Uri baseUri = App.Current.Host.Source;
            if (baseUri == null)
                pathUri = new Uri("http://localhost:3937/Template/" + path);
            if (baseUri != null)
                pathUri = new Uri(App.Current.Host.Source, "../Template/" + path);
			wc.OpenReadAsync(pathUri); //DataGrid/Content.zip			
		}

		static void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				StreamResourceInfo zipInfo = new StreamResourceInfo(e.Result, null);
				// Read manifest from zip file  StreamResourceInfo manifestInfo = Application.GetResourceStream(_zipInfo, new Uri("content.xml", UriKind.Relative)); StreamReader reader = new StreamReader(manifestInfo.Stream); XDocument document = XDocument.Load(reader); var mediaFiles = from m in document.Descendants("mediafile") select new MediaInfo  { Type = (MediaType) Enum.Parse(typeof(MediaType), m.Attribute("type").Value, true), Name = m.Attribute("name").Value }; _mediaInfos = new List<MediaInfo>(); _mediaInfos.AddRange(mediaFiles); ProgressTextBlock.Visibility = Visibility.Collapsed; PrevButton.IsEnabled = true; NextButton.IsEnabled = true; DisplayMedia(_mediaInfos[0]);
				StreamResourceInfo manifestInfo = Application.GetResourceStream(zipInfo, new Uri("content.xml", UriKind.Relative));
				StreamReader reader = new StreamReader(manifestInfo.Stream);
				XDocument xd = XDocument.Load(reader);
				reader.Close();
				var files = from m in xd.Descendants("templatefile")
							select m.Attribute("name").Value;

				if (DataTemplates == null)
					DataTemplates = new Dictionary<string, string>();
				
				foreach (var f in files)
				{
					string filename = f + ".xaml";
					StreamResourceInfo streamInfo = Application.GetResourceStream(zipInfo, new Uri(filename, UriKind.Relative));
					using (StreamReader r = new StreamReader(streamInfo.Stream))
					{
						string s = r.ReadToEnd();
						if (!DataTemplates.ContainsKey(f))
							DataTemplates.Add(f, s);
					}
				}
			}
		}
	}
}
