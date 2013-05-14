using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace ControlCharAdornmentSample
{
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("any")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    [TagType(typeof(IntraTextAdornmentTag))]
    internal sealed class CharDisplayTaggerSourceFactory : IViewTaggerProvider
    {
        #region IViewTaggerProvider

        ITagger<T> IViewTaggerProvider.CreateTagger<T>(ITextView textView, ITextBuffer textBuffer)
        {
            if (textView.TextBuffer == textBuffer)
            {
                return new CharDisplayTaggerSource(textView) as ITagger<T>;
            }

            return null;
        }

        #endregion
    }
}
