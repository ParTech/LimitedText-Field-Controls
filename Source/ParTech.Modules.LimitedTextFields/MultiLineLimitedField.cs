namespace ParTech.Modules.LimitedTextFields
{
    using System;
    using System.Web.UI;
    using Sitecore.Shell.Applications.ContentEditor;

    /// <summary>
    /// Represents a multi-line text field with a configurable maximum length.
    /// </summary>
    public class MultiLineLimitedField : Memo, ILimitedField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiLineLimitedField" /> class.
        /// </summary>
        public MultiLineLimitedField()
            : base()
        {
        }

        /// <summary>
        /// Gets or sets the field's Source property
        /// </summary>
        public string Source
        {
            get { return this.GetViewStateString("Source"); }

            set { this.SetViewStateString("Source", value); }
        }

        /// <summary>
        /// Gets the maximum allowed length for the field's value
        /// </summary>
        public int MaxLength
        {
            get { return LimitedFieldHelper.GetMaxLength(this); }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load"></see> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LimitedFieldHelper.OnLoad(this);
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="output">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void DoRender(HtmlTextWriter output)
        {
            LimitedFieldHelper.DoRender(new Action(() => base.DoRender(output)), output, this);
        }
    }
}