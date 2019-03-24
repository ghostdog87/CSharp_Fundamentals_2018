using Solid.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Layouts
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            string layoutTypeToLower = layoutType.ToLower();

            switch (layoutTypeToLower)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
