LimitedText Field Controls
==========================

Description
-----------
This module adds two new field types to the Sitecore Content Editor, *Single-Line Text Limited* and *Multi-Line Text Limited*.
Both controls inherit all functionality from the existing text field controls and add the posibility to configure a maximum allowed value for the field.
The fields inform the user of the number of remaining characters while they are editing.

This comes in extremely handy for field containing a Browser Title or Meta Description, because their length should be kept within the limits of what Google displays in their search results.


References
------------
Blog: http://www.partechit.nl/nl/blog/2013/03/text-fields-with-limited-length-and-feedback-during-editing 
GitHub: https://github.com/ParTech/LimitedText-Field-Controls


Installation
------------
The Sitecore package *\Release\ParTech.Fields.LimitedTextField-1.0.0.zip* contains:
- Binary (release build).
- Configuration include file.
- Core items that install two new field types.

Use the Sitecore Installation Wizard to install the package.
After installation, the new field types will be immediately ready for use


Release notes
-------------
*1.0.0*
- Initial release.

*1.0.1*
- Added configuration setting that defines the JavaScript keycodes of keys that are allowed to be used when the maximum number of characters has been reached.
- Added tab, shift, control and alt keys to default list of allowed keycodes.
- Fixed a bug that allowed pasting content using the mouse even when the maximum number of characters was reached.

Author
------
This solution was brought to you and supported by Ruud van Falier, ParTech IT

Twitter: @BrruuD / @ParTechIT   
E-mail: ruud@partechit.nl   
Web: http://www.partechit.nl