using System;
using System.Drawing;
using System.Windows.Forms;

namespace RINPOSYS.CustomClasses.Utils
{
    /// <summary>
    /// Used as an extension of the AppendText method of a generic RichTextBox
    /// </summary>
    public static class CustomRichTextBox
    {
        /// <summary>
        /// Extension method
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <remarks>
        /// Formats text with a 'timestamp - text' and text's color
        /// </remarks>
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionColor = color;
            box.AppendText(String.Format("{0} - {1}\n", DateTime.Now, text));   
        }
    }
}
