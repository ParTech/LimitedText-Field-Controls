namespace ParTech.Modules.LimitedTextFields
{
    using System.Web.UI;

    /// <summary>
    /// Interface for LimitedField controls
    /// </summary>
    public interface ILimitedField
    {
        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        string Source { get; set; }

        /// <summary>
        /// Gets the maximum length.
        /// </summary>
        int MaxLength { get; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        AttributeCollection Attributes { get; }
    }
}