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
using Sitecore.Configuration;

namespace ParTech.Field.LimitedTextField
{
    /// <summary>
    /// Provides static methods that support the LimitedField control classes
    /// </summary>
    public static class LimitedFieldHelper
    {
        /// <summary>
        /// JavaScript keycodes of the keys that are allowed to be used when the maximum number of characters in the LimitedField's value has been reached.
        /// </summary>
        private static readonly int[] AllowedKeyCodes = { 8, 46, 37, 38, 39, 40 };

        /// <summary>
        /// Handles the OnLoad event for LimitedField controls
        /// </summary>
        /// <param name="e"></param>
        public static void OnLoad(ILimitedField field)
        {
            // Don't limit field length when MaxLength was not specified
            if (field.MaxLength > 0)
            {
                field.Attributes["onkeyup"] = GetOnKeyUpScript(field);
                field.Attributes["onchange"] = GetOnKeyUpScript(field);
                field.Attributes["onkeydown"] = GetOnKeyDownScript(field);
            }
        }

        /// <summary>
        /// Must be called from the DoRender() eventhandler
        /// </summary>
        /// <param name="output">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the server control content.</param>
        /// <param name="maxLength">Maximum length of the LimitedField value</param>
        public static void DoRender(Action baseRender, HtmlTextWriter output, ILimitedField field)
        {
            output.Write(@"<div style=""position:relative"">");

            // Render a notification with explanation about how to use this component if there is no MaxLength specified.
            // TODO: Localize the notification string to support multi-language editor environments
            if (field.MaxLength == 0)
            {
                output.Write(@"<span>There was no maximum length specified for this field. Specify ""MaxLength=<em>n</em>"" (where <em>n</em> is any fixed number) in the Source property of this field to set the maximum length.</span>");
            }

            baseRender.Invoke();

            output.Write(@"</div>");
        }

        /// <summary>
        /// Get the JavaScript code for the onkeyup event of the LimitedField control.
        /// </summary>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string GetOnKeyUpScript(ILimitedField field)
        {
            var script = new StringBuilder();

            script.Append("(function($, el) {");

            // Strip all characters after max length characters
            script.AppendFormat("$(el).val($(el).val().substring(0, {0}));", field.MaxLength);

            // Get the field label element and text
            script.Append("var label = $(el).parents('td').first('.scEditorFieldMarkerInputCell').find('div.scEditorFieldLabel');");
            script.Append("var labelText = label.text().split(':')[0];");

            // Determine how many characters are left
            script.AppendFormat("var charsLeft = {0} - $(el).val().length;", field.MaxLength);
            script.AppendFormat("var charsLeftText = ': (' + charsLeft + ' of {0} characters left)';", field.MaxLength);

            // Display the amount of characters left after the field label text
            script.Append("label.text(labelText + charsLeftText);");

            script.Append("}(jQuery, this))");

            return script.ToString();
        }

        /// <summary>
        /// Get the JavaScript code for the onkeydown event of the LimitedField control.
        /// </summary>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string GetOnKeyDownScript(ILimitedField field)
        {
            var script = new StringBuilder();
            
            script.Append("(function($, el, evt) {");

            // Allow a certain list of keycodes to be used even when the maximum number of characters has been used
            string allowedKeyCodes = Settings.GetSetting("ParTech.LimitedTextField.AllowedKeyCodes", "8,9,16,17,18,46,37,38,39,40");
            script.AppendFormat("var allowedKeyCodes = [ {0} ];", allowedKeyCodes);

            script.Append("for (var i = 0, imax = allowedKeyCodes.length; i < imax; i++)");
            script.Append("  if (evt.keyCode == allowedKeyCodes[i])");
            script.Append("    return true;");

            // Prevent keydown event when length surpassed max length
            script.AppendFormat("if ($(el).val().length >= {0}) {{", field.MaxLength);
            script.Append("evt.preventDefault();");
            script.Append("}");

            script.Append("}(jQuery, this, event))");

            return script.ToString();
        }

        /// <summary>
        /// Parse the Source property to extract the MaxLength value
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int GetMaxLength(ILimitedField field)
        {
            int maxLength = 0;

            var dataSource = WebUtil.ParseQueryString(field.Source ?? string.Empty);
            int.TryParse(dataSource["MaxLength"], out maxLength);

            return maxLength;
        }
    }
}