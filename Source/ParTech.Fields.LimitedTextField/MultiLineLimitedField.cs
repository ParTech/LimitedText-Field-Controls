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
    public class MultiLineLimitedField : Memo, ILimitedField
    {
        #region ILimitedField implementation
        /// <summary>
        /// Gets or sets the field's Source property
        /// </summary>
        public string Source
        {
            get
            {
                return GetViewStateString("Source");
            }

            set
            {
                SetViewStateString("Source", value);
            }
        }

        /// <summary>
        /// The maximum allowed length for the field's value
        /// </summary>
        public int MaxLength
        {
            get
            {
                return LimitedFieldHelper.GetMaxLength(this);
            }
        }
        #endregion

        public MultiLineLimitedField()
            : base()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            LimitedFieldHelper.OnLoad(this);
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"/> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="output">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the server control content.</param>
        protected override void DoRender(HtmlTextWriter output)
        {
            LimitedFieldHelper.DoRender(new Action(() => base.DoRender(output)), output, this);
        }
    }
}