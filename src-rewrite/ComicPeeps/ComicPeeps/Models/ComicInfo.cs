using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ComicPeeps.Models
{
	[XmlRoot(ElementName = "ComicInfo")]
	public class ComicInfo
	{
		[XmlElement(ElementName = "Title")]
		public string Title { get; set; } = "";

		[XmlElement(ElementName = "Series")]
		public string Series { get; set; } = "";

		[XmlElement(ElementName = "Number")]
		public string Number { get; set; } = "";

		[XmlElement(ElementName = "Web")]
		public string Web { get; set; } = "";

		[XmlElement(ElementName = "Volume")]
		public string Volume { get; set; } = "";

		[XmlElement(ElementName = "Summary")]
		public string Summary { get; set; } = "";

		[XmlElement(ElementName = "Notes")]
		public string Notes { get; set; } = "";

		[XmlElement(ElementName = "Publisher")]
		public string Publisher { get; set; } = "";

		[XmlElement(ElementName = "Genre")]
		public string Genre { get; set; } = "";

		[XmlElement(ElementName = "PageCount")]
		public string PageCount { get; set; } = "";

		[XmlElement(ElementName = "LanguageISO")]
		public string LanguageISO { get; set; } = "";

		[XmlElement(ElementName = "ScanInformation")]
		public string ScanInformation { get; set; } = "";

		//[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
		//public string Xsd { get; set; } = "";
		
		//[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		//public string Xsi { get; set; } = "";
	}
}
