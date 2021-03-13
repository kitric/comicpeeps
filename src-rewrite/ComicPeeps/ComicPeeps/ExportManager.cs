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
            try
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

                MainScreen.Logger.Log($"Data exported as CSV: {exportLocation}");
                GlobalFunctions.SaveLogsAndClear();

                MessageBox.Show($"CSV exported to: {exportLocation}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"There was an error exporting... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainScreen.Logger.Log(e.Message);
                GlobalFunctions.SaveLogsAndClear();
            }
        }

        public static void ExportJson(string exportLocation)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(exportLocation))
                {
                    using (JsonWriter jwriter = new JsonTextWriter(writer))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jwriter, MainScreen.UserData.ComicSeries);
                    }
                }

                MainScreen.Logger.Log($"Data exported as CSV: {exportLocation}");
                GlobalFunctions.SaveLogsAndClear();

                MessageBox.Show($"JSON exported to: {exportLocation}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"There was an error exporting... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainScreen.Logger.Log(e.Message);
                GlobalFunctions.SaveLogsAndClear();
            }
        }

        public static void ExportXml(string exportLocation)
        {
            try
            {
                using (Stream stream = new FileStream(exportLocation, FileMode.OpenOrCreate))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<ComicSeries>));
                    xml.Serialize(stream, MainScreen.UserData.ComicSeries);
                }

                MainScreen.Logger.Log($"Data exported as CSV: {exportLocation}");
                GlobalFunctions.SaveLogsAndClear();

                MessageBox.Show($"XML exported to: {exportLocation}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"There was an error exporting... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainScreen.Logger.Log(e.Message);
                GlobalFunctions.SaveLogsAndClear();
            }
        }
    }
}
