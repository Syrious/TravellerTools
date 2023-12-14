﻿using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

#nullable disable
#pragma warning disable RCS1139 // Add summary element to documentation comment.

namespace Grauenwolf.TravellerTools.Equipment
{
    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Catalog
    {
        /// <remarks/>
        [XmlElement("Section")]
        public CatalogSection[] Section { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Book", IsNullable = false)]
        public CatalogBook[] Books { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CatalogBook
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Url { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class CatalogSection
    {
        /// <remarks/>
        [XmlElement("Item")]
        public CatalogSectionItem[] Item { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Name { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Species { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Book { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Law { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Category { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Contraband { get; set; }

        [XmlAttribute()]
        public string Page { get; set; }

        [XmlElement("Subsection")]
        public CatalogSection[] Subsection { get; set; }

        [XmlAttribute()]
        public string Skill { get; set; }

        [XmlAttribute()]
        public string TL { get; set; }

        [XmlAttribute()]
        public string Mod { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class CatalogSectionItem
    {
        /// <remarks/>
        [XmlAttribute()]
        public string Name { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string TL { get; set; }

        /// <remarks/>
        [XmlAttribute()] public string Price { get; set; }

        /// <remarks/>
        [XmlAttribute()] public string AmmoPrice { get; set; }

        [XmlAttribute()] public string Mass { get; set; }
        [XmlAttribute()] public string Notes { get; set; }
        [XmlAttribute()] public string Species { get; set; }

        /// <remarks/>
        [XmlAttribute()]
        public string Contraband { get; set; }

        public decimal PriceCredits
        {
            get
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(Price))
                        return 0;
                    if (Price.StartsWith("Cr"))
                        return decimal.Parse(Price.Substring(2), CultureInfo.InvariantCulture);
                    if (Price.StartsWith("KCr"))
                        return decimal.Parse(Price.Substring(3), CultureInfo.InvariantCulture) * 1000M;
                    if (Price.StartsWith("MCr"))
                        return decimal.Parse(Price.Substring(3), CultureInfo.InvariantCulture) * 1000M * 1000M;

                    return decimal.Parse(Price, CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    throw new BookException($"Cannot parse price of '{Price}'", ex);
                }
            }
        }

        public decimal AmmoPriceCredits
        {
            get
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(AmmoPrice))
                        return 0;
                    if (AmmoPrice.StartsWith("Cr"))
                        return decimal.Parse(AmmoPrice.Substring(2), CultureInfo.InvariantCulture);
                    if (AmmoPrice.StartsWith("KCr"))
                        return decimal.Parse(AmmoPrice.Substring(3), CultureInfo.InvariantCulture) * 1000M;
                    if (AmmoPrice.StartsWith("MCr"))
                        return decimal.Parse(AmmoPrice.Substring(3), CultureInfo.InvariantCulture) * 1000M * 1000M;

                    return decimal.Parse(AmmoPrice, CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    throw new BookException($"Cannot parse price of '{AmmoPrice}'", ex);
                }
            }
        }

        /// <remarks/>
        [XmlAttribute()] public string Law { get; set; }

        /// <remarks/>
        [XmlAttribute()] public string Category { get; set; }

        /// <remarks/>
        [XmlAttribute()] public string Mod { get; set; }

        [XmlAttribute()] public string Book { get; set; }

        [XmlAttribute()] public string Page { get; set; }

        [XmlAttribute()] public string Skill { get; set; }

        [XmlAttribute()] public string Computer { get; set; }
        [XmlAttribute()] public string Difficulty { get; set; }
        [XmlAttribute()] public string Bandwidth { get; set; }
    }
}
