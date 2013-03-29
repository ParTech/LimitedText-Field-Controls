using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Collections;
using Sitecore;
using System.Web;
using Sitecore.Web;
using Sitecore.Shell.Applications.ContentEditor;

namespace ParTech.Field.LimitedTextField
{
    /// <summary>
    /// Interface for LimitedField controls
    /// </summary>
    public interface ILimitedField
    {
        string Source { get; set; }

        int MaxLength { get; }

        AttributeCollection Attributes { get; }
    }
}