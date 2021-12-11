using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace News.DAL.Classes.NewsClasses
{
	public class New
	{
		[XmlRoot(ElementName = "a")]
		public class A
		{

			[XmlAttribute(AttributeName = "href")]
			public string Href { get; set; }

			[XmlAttribute(AttributeName = "target")]
			public string Target { get; set; }

			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "p")]
		public class P
		{

			[XmlElement(ElementName = "a")]
			public List<A> A { get; set; }

			[XmlElement(ElementName = "img")]
			public Img Img { get; set; }

			[XmlElement(ElementName = "strong")]
			public string Strong { get; set; }

			[XmlElement(ElementName = "br")]
			public object Br { get; set; }
		}

		[XmlRoot(ElementName = "img")]
		public class Img
		{

			[XmlAttribute(AttributeName = "alt")]
			public object Alt { get; set; }

			[XmlAttribute(AttributeName = "src")]
			public string Src { get; set; }

			[XmlAttribute(AttributeName = "style")]
			public string Style { get; set; }
		}

        [XmlRoot(ElementName = "haber_metni")]
        public class HaberMetni
        {

            [XmlElement(ElementName = "p")]
            public string P { get; set; }
        }

        [XmlRoot(ElementName = "haber")]
		public class Haber
		{

			[XmlElement(ElementName = "haber_manset")]
			public string HaberManset { get; set; }

			[XmlElement(ElementName = "haber_resim")]
			public string HaberResim { get; set; }

			[XmlElement(ElementName = "haber_link")]
			public string HaberLink { get; set; }

			[XmlElement(ElementName = "haber_id")]
			public int id { get; set; }

			[XmlElement(ElementName = "haber_video")]
			public object HaberVideo { get; set; }

			[XmlElement(ElementName = "haber_aciklama")]
			public string HaberAciklama { get; set; }

			[XmlElement(ElementName = "haber_metni")]
			public string HaberMetni { get; set; }

			[XmlElement(ElementName = "haber_kategorisi")]
			public string HaberKategorisi { get; set; }

			[XmlElement(ElementName = "haber_tarihi")]
			public string HaberTarihi { get; set; }

			[XmlElement(ElementName = "manset_resim")]
			public string MansetResim { get; set; }

			[XmlElement(ElementName = "izles_id")]
			public object IzlesId { get; set; }

			[XmlElement(ElementName = "okunmaadedi")]
			public int Okunmaadedi { get; set; }

			[XmlElement(ElementName = "yorumSay")]
			public int YorumSay { get; set; }
		}

		[XmlRoot(ElementName = "strong")]
		public class Strong
		{

			[XmlElement(ElementName = "a")]
			public A A { get; set; }
		}

		[XmlRoot(ElementName = "haberler")]
		public class Haberler
		{

			[XmlElement(ElementName = "haber")]
			public List<Haber> Haber { get; set; }
		}

	}
}
