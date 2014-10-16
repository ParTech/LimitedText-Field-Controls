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
The Sitecore package *\Release\ParTech.Modules.LimitedTextFields-1.0.2.zip* contains:
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

*1.0.2*
- Fixed a bug that placed the cursor at the end of the field on all key down/up events.
- Fixed a bug that disallowed keys to be pressed when ctrl is pressed (so ctrl+x, etc. does now work when the text field is full).
- Added home, end and escape keys to default allowed keys.
- Renamed the assembly and namespace to match that of other ParTech modules.  *Important:* Make sure to re-install the entire module with the installation package if you are already using an older version!


Author
------
This solution was brought to you and supported by Ruud van Falier, ParTech IT

Twitter: @BrruuD / @ParTechIT   
E-mail: ruud@partechit.nl   
Web: http://www.partechit.nl