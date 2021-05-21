using System.Drawing;
using System.Windows.Forms;

namespace FileTransfer.Interface.Settings
{
    internal static class FormStyles
    {
        private static T InitializeControl<T>(string text, string name, Point location, Size size,
            Font font, Color forceColor, Color backColor, DockStyle style) where T : Control, new()
        {
            T control = new T
            {
                Text = text,
                Name = name,
                Location = location,
                Size = size,
                Font = font,
                ForeColor = forceColor,
                BackColor = backColor,
                Dock = style
            };

            return control;
        }

        public static Label InitializeLabel(string text, string name, Point location, ContentAlignment? alignment= null, bool autoSize = true, Size? size = null,
            Font font = null, Color? forceColor = null, Color? backColor = null, DockStyle style = DockStyle.None)
        {
            Label label = InitializeControl<Label>(text, name, location, size ?? new Size(0, 0), font ?? SetFont(),
                forceColor ?? Color.White, backColor ?? Color.Transparent, style);
            label.AutoSize = autoSize;
            label.TextAlign = alignment ?? ContentAlignment.MiddleCenter;
            return label;
        }

        public static TextBox InitializeTextBox(string text, string name, Point location, Size size, Font font = null, bool readOnly = false,
            HorizontalAlignment? alignment = null, int maxLength = 32767, Color? forceColor = null, Color? backColor = null, DockStyle style = DockStyle.None)
        {
            TextBox textBox = InitializeControl<TextBox>(text, name, location, size, font ?? SetFont(), forceColor ?? Color.Black, backColor ?? Color.White, style);
            textBox.ReadOnly = readOnly;
            textBox.TextAlign = alignment ?? HorizontalAlignment.Left;
            textBox.MaxLength = maxLength;
            return textBox;
        }

        public static Button InitializeButton(string text, string name, Point location, Size size, Color? mouseOverBackColor = null,
            Font font = null, Color? forceColor = null, Color? backColor = null, DockStyle style = DockStyle.None)
        {
            Button button = InitializeControl<Button>(text, name, location, size, font ?? SetFont(), forceColor ?? Color.White,
                backColor ?? Color.FromArgb(13, 17, 23), style);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = true;
            button.FlatAppearance.MouseOverBackColor = mouseOverBackColor ?? Color.FromArgb(41, 50, 64);
            return button;
        }

        public static Font SetFont(float size = 10, FontStyle style = FontStyle.Regular) => new Font("Calibri", size, style, GraphicsUnit.Point, ((byte)(0)));
    }
}
