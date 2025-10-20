using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmcAs400Query.UI_Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    namespace PopoutDemo
    {
        /// <summary>
        /// A lightweight button that pops out either a ContextMenuStrip or an arbitrary Control as a drop-down.
        /// Optimized for minimal allocations and flicker-free rendering.
        /// </summary>
        [DefaultEvent(nameof(Click))]
        public sealed class PopoutMenuButton : Button
        {
            private ToolStripDropDown? _dropDown;
            private ToolStripControlHost? _host;

            public PopoutMenuButton()
            {
                DoubleBuffered = true;
                FlatStyle = FlatStyle.System; // uses system rendering; change if you prefer owner-draw
                TabStop = true;
                AccessibleRole = AccessibleRole.PushButton;
            }

            /// <summary>
            /// Optional: use a ContextMenuStrip for a classic menu drop-down.
            /// </summary>
            [DefaultValue(null)]
            public ContextMenuStrip? Menu { get; set; }

            /// <summary>
            /// Optional: use any WinForms Control as the drop-down content (e.g., Panel, UserControl).
            /// Size of the control determines pop-out size.
            /// </summary>
            [DefaultValue(null)]
            public Control? DropDownContent { get; set; }

            /// <summary>
            /// Show a small arrow at the right side.
            /// </summary>
            [DefaultValue(true)]
            public bool ShowDropArrow { get; set; } = true;

            /// <summary>
            /// If true, automatically set drop-down width to match the button (for menus).
            /// </summary>
            [DefaultValue(true)]
            public bool MatchButtonWidth { get; set; } = true;

            /// <summary>
            /// Opens the assigned drop-down (Menu or DropDownContent).
            /// </summary>
            public void ShowDropDown()
            {
                if (Menu != null)
                {
                    if (MatchButtonWidth)
                        Menu.Width = Math.Max(Menu.Width, Width);

                    var screen = PointToScreen(new Point(0, Height));
                    Menu.Show(screen, ToolStripDropDownDirection.BelowRight);
                    return;
                }

                if (DropDownContent != null)
                {
                    EnsureHostedDropDown();
                    if (_host is null || _dropDown is null) return;

                    // Keep host sized to content (avoids redundant layouts/GC)
                    _host.Size = DropDownContent.Size;

                    var screen = PointToScreen(new Point(0, Height));
                    _dropDown.Show(screen);
                    return;
                }
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                ShowDropDown();
            }

            protected override bool IsInputKey(Keys keyData)
            {
                // Let Alt+Down be handled here to open the drop-down
                if ((keyData & Keys.KeyCode) == Keys.Down && (keyData & Keys.Alt) == Keys.Alt)
                    return true;
                return base.IsInputKey(keyData);
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.Alt && e.KeyCode == Keys.Down)
                {
                    ShowDropDown();
                    e.Handled = true;
                    return;
                }
                base.OnKeyDown(e);
            }

            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);

                if (!ShowDropArrow) return;

                var g = pevent.Graphics;
                var r = ClientRectangle;

                // Simple down triangle (device-independent; scales OK with system DPI)
                int w = 8;
                int h = 4;
                int paddingRight = 10;
                int cx = r.Right - paddingRight - w / 2;
                int cy = r.Top + r.Height / 2;

                var p1 = new Point(cx - w / 2, cy - h / 2);
                var p2 = new Point(cx + w / 2, cy - h / 2);
                var p3 = new Point(cx, cy + h / 2);

                using var b = new SolidBrush(Enabled ? ForeColor : SystemColors.GrayText);
                g.FillPolygon(b, new[] { p1, p2, p3 });
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (_dropDown != null)
                    {
                        _dropDown.Closed -= DropDown_ClosedFocusBack;
                        _dropDown.Dispose();
                        _dropDown = null;
                    }
                    _host?.Dispose();
                    _host = null;
                }
                base.Dispose(disposing);
            }

            private void EnsureHostedDropDown()
            {
                if (DropDownContent == null)
                    return;

                if (_dropDown != null && _host != null && _host.Control == DropDownContent)
                    return;

                // If reassigning content, tear down previous host/dropdown
                _dropDown?.Dispose();
                _host?.Dispose();
                _dropDown = null;
                _host = null;

                // Host the provided control without extra padding/margins to avoid layout churn
                _host = new ToolStripControlHost(DropDownContent)
                {
                    Margin = Padding.Empty,
                    Padding = Padding.Empty,
                    AutoSize = false
                };

                _dropDown = new ToolStripDropDown
                {
                    AutoClose = true,
                    Padding = Padding.Empty
                };
                _dropDown.Items.Add(_host);
                _dropDown.Closed += DropDown_ClosedFocusBack;
            }

            private void DropDown_ClosedFocusBack(object? sender, ToolStripDropDownClosedEventArgs e)
            {
                // Return focus to the button for better keyboard UX
                if (!IsDisposed && IsHandleCreated)
                    BeginInvoke(new Action(() => { Focus(); }));
            }
        }
    }

}
