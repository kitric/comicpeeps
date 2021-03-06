using ComicPeeps.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ComicPeeps
{
    public static class ExportManager
    {
        public static void ExportCsv(string exportLocation)
        {
            using (StreamWriter writer = new StreamWriter(exportLocation))
            {
                writer.WriteLine("Comic Name, Comic Id, Issue Id, Issue Number, Current Page, Pages, Read");
                for (int i = 0; i < MainScreen.UserData.ComicSeries.Count; i++)
                {
                    for (int j = 0; j < MainScreen.UserData.ComicSeries[i].Issues.Count; j++)
                    {
                        writer.WriteLine($"{MainScreen.UserData.ComicSeries[i].Issues[j].ComicName}, {MainScreen.UserData.ComicSeries[i].Issues[j].SeriesId}, {MainScreen.UserData.ComicSeries[i].Issues[j].IssueId}, {MainScreen.UserData.ComicSeries[i].Issues[j].IssueNumber}, {MainScreen.UserData.ComicSeries[i].Issues[j].CurrentPage}, {MainScreen.UserData.ComicSeries[i].Issues[j].Pages}, {MainScreen.UserData.ComicSeries[i].Issues[j].Completed.ToString()}");
                    }
                }
            }

            MessageBox.Show($"CSV exported to: {exportLocation}");
        }

        public static void ExportJson(string exportLocation)
        {
            using (StreamWriter writer = new StreamWriter(exportLocation))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jwriter, MainScreen.UserData.ComicSeries);
                }
            }

            MessageBox.Show($"JSON exported to: {exportLocation}");
        }

        public static void ExportXml(string exportLocation)
        {
            using (Stream stream = new FileStream(exportLocation, FileMode.OpenOrCreate)) 
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<ComicSeries>));
                xml.Serialize(stream, MainScreen.UserData.ComicSeries);
            }

            MessageBox.Show($"XML exported to: {exportLocation}");
        }
    }
}
