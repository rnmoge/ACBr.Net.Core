// ***********************************************************************
// Assembly         : ACBr.Net.Core
// Author           : RFTD
// Created          : 03-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 07-27-2014
// ***********************************************************************
// <copyright file="XmlDocumentExtensions.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// The Core namespace.
/// </summary>
namespace ACBr.Net.Core
{
	/// <summary>
	/// Class XmlDocumentExtensions.
	/// </summary>
    public static class XmlDocumentExtensions
    {
		/// <summary>
		/// Retorna o XML como uma string.
		/// </summary>
		/// <param name="xmlDoc">The XML document.</param>
		/// <returns>System.String.</returns>
        public static string AsString(this XmlDocument xmlDoc)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    xmlDoc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString();
                }
            }
        }

		/// <summary>
		/// Adiciona uma tag ao documento ignorando os elementos nulos.
		/// </summary>
		/// <param name="xmlDoc">The XML document.</param>
		/// <param name="tag">The tag.</param>
		public static void AddTag(this XmlDocument xmlDoc, XmlElement tag)
		{
			if (tag == null)
				return;
			else
				xmlDoc.AppendChild(tag);
		}

		/// <summary>
		/// Adiciona uma tag ao documento ignorando os elementos nulos.
		/// </summary>
		/// <param name="xmlDoc">The XML document.</param>
		/// <param name="tag">The tag.</param>
		public static void AddTag(this XmlElement xmlDoc, XmlElement tag)
		{
			if (tag == null)
				return;
			else
				xmlDoc.AppendChild(tag);
		}

		/// <summary>
		/// Adiciona varias tag ao documento ignorando os elementos nulos.
		/// </summary>
		/// <param name="xmlDoc">The XML document.</param>
		/// <param name="tags">The tags.</param>
		public static void AddTag(this XmlElement xmlDoc, XmlElement[] tags)
		{
			if (tags.Length < 1)
				return;

			foreach (var tag in tags)
			{
				if (tag == null) continue;
				xmlDoc.AppendChild(tag);
			}
		}
    }
}
