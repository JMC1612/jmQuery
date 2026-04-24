using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace JmcAs400Query
{

    public class SqlTextBox : RichTextBox
    {
        private readonly Timer _highlightTimer;
        private readonly SuggestionPopupForm _popup;
        private readonly ListBox _suggestionList;
        private readonly Font _regularFont;
        private readonly Font _boldFont;

        private Regex _keywordRegex;
        private Form? _ownerForm;
        private bool _isHighlighting;

        public List<string> SchemaObjects { get; } = new();

        private static readonly string[] Db2Keywords =
        {
            "SELECT", "FROM", "WHERE", "GROUP", "BY", "ORDER", "HAVING",
            "INSERT", "INTO", "VALUES", "UPDATE", "SET", "DELETE",
            "JOIN", "INNER", "LEFT", "RIGHT", "FULL", "OUTER", "ON",
            "AND", "OR", "NOT", "NULL", "IS", "IN", "EXISTS", "BETWEEN", "LIKE",
            "CREATE", "ALTER", "DROP", "TABLE", "VIEW", "INDEX", "TRIGGER",
            "CASE", "WHEN", "THEN", "ELSE", "END", "AS", "DISTINCT",
            "UNION", "ALL", "FETCH", "FIRST", "ROWS", "ONLY",
            "WITH", "CURRENT", "DATE", "TIME", "TIMESTAMP"
        };

        private static readonly Regex StringRegex =
            new Regex(@"'(''|[^'])*'", RegexOptions.Compiled);

        private static readonly Regex LineCommentRegex =
            new Regex(@"--.*$", RegexOptions.Compiled | RegexOptions.Multiline);

        private static readonly Regex BlockCommentRegex =
            new Regex(@"/\*.*?\*/", RegexOptions.Compiled | RegexOptions.Singleline);

        private static readonly Regex NumberRegex =
            new Regex(@"\b\d+(\.\d+)?\b", RegexOptions.Compiled);

        public SqlTextBox()
        {
            _regularFont = new Font("Consolas", 10f, FontStyle.Regular);
            _boldFont = new Font("Consolas", 10f, FontStyle.Bold);

            Font = _regularFont;
            AcceptsTab = true;
            WordWrap = false;
            Multiline = true;
            HideSelection = false;

            _keywordRegex = BuildKeywordRegex();

            _highlightTimer = new Timer { Interval = 150 };
            _highlightTimer.Tick += (_, __) =>
            {
                _highlightTimer.Stop();
                HighlightSyntax();
            };

            _suggestionList = new ListBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                IntegralHeight = false,
                Font = _regularFont,
                Dock = DockStyle.Fill
            };

            _suggestionList.MouseDown += (_, e) =>
            {
                int index = _suggestionList.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    _suggestionList.SelectedIndex = index;
                    CommitSuggestion();
                }
            };

            _popup = new SuggestionPopupForm
            {
                Size = new Size(260, 180)
            };
            _popup.Controls.Add(_suggestionList);

            TextChanged += (_, __) =>
            {
                if (_isHighlighting)
                    return;

                _highlightTimer.Stop();
                _highlightTimer.Start();

                BeginInvoke((Action)(() => ShowSuggestions(false)));
            };

            KeyDown += SqlTextBox_KeyDown;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            HookOwnerForm();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            HookOwnerForm();
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);

            if (_isHighlighting)
                return;

            if (_popup.Visible)
                RepositionPopup();
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            BeginInvoke((Action)(() => ShowSuggestions(false)));
        }

        private void HookOwnerForm()
        {
            if (_ownerForm != null)
                _ownerForm.Deactivate -= OwnerForm_Deactivate;

            _ownerForm = FindForm();

            if (_ownerForm != null)
                _ownerForm.Deactivate += OwnerForm_Deactivate;
        }

        private void OwnerForm_Deactivate(object? sender, EventArgs e)
        {
            HideSuggestions();
        }

        public void RebuildKeywordList(IEnumerable<string> keywords)
        {
            var merged = keywords
                .Concat(Db2Keywords)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            _keywordRegex = new Regex(
                $@"\b({string.Join("|", merged.Select(Regex.Escape))})\b",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        private Regex BuildKeywordRegex()
        {
            return new Regex(
                $@"\b({string.Join("|", Db2Keywords.Select(Regex.Escape))})\b",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        private void SqlTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                ShowSuggestions(true);
                e.SuppressKeyPress = true;
                return;
            }

            if (!_popup.Visible)
                return;

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (_suggestionList.Items.Count > 0)
                    {
                        int next = _suggestionList.SelectedIndex + 1;
                        if (next >= _suggestionList.Items.Count)
                            next = _suggestionList.Items.Count - 1;
                        if (next < 0)
                            next = 0;

                        _suggestionList.SelectedIndex = next;
                    }
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Up:
                    if (_suggestionList.Items.Count > 0)
                    {
                        int prev = _suggestionList.SelectedIndex - 1;
                        if (prev < 0)
                            prev = 0;

                        _suggestionList.SelectedIndex = prev;
                    }
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Enter:
                case Keys.Tab:
                    CommitSuggestion();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Escape:
                    HideSuggestions();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Left:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                    BeginInvoke((Action)(() => ShowSuggestions(false)));
                    break;
            }
        }

        private void ShowSuggestions(bool force)
        {
            if (SelectionLength > 0)
            {
                HideSuggestions();
                return;
            }

            string prefix = GetCurrentWord();

            if (!force && string.IsNullOrWhiteSpace(prefix))
            {
                HideSuggestions();
                return;
            }

            var suggestions = GetSuggestions(prefix, force).ToList();
            if (suggestions.Count == 0)
            {
                HideSuggestions();
                return;
            }

            _suggestionList.BeginUpdate();
            _suggestionList.Items.Clear();

            foreach (var item in suggestions)
                _suggestionList.Items.Add(item);

            _suggestionList.SelectedIndex = 0;
            _suggestionList.EndUpdate();

            RepositionPopup();

            if (!_popup.Visible)
            {
                _popup.Show(_ownerForm ?? FindForm());
            }
        }

        private void RepositionPopup()
        {
            Point caret = GetPositionFromCharIndex(SelectionStart);
            caret.Y += (int)Math.Ceiling(Font.GetHeight()) + 4;

            Point screenPoint = PointToScreen(caret);

            _popup.Location = screenPoint;
            _popup.Size = new Size(260, Math.Min(180, Math.Max(40, _suggestionList.Items.Count * 18 + 6)));
        }

        private void HideSuggestions()
        {
            if (_popup.Visible)
                _popup.Hide();
        }

        private IEnumerable<string> GetSuggestions(string prefix, bool force)
        {
            var all = Db2Keywords
                .Concat(SchemaObjects)
                .Distinct(StringComparer.OrdinalIgnoreCase);

            if (force && string.IsNullOrWhiteSpace(prefix))
                return all.OrderBy(x => x).Take(100);

            return all
                .Where(x => x.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                .OrderBy(x => x)
                .Take(100);
        }

        private void CommitSuggestion()
        {
            if (!_popup.Visible || _suggestionList.SelectedItem == null)
                return;

            string suggestion = _suggestionList.SelectedItem.ToString()!;
            ReplaceCurrentWord(suggestion);
            HideSuggestions();
            Focus();
        }

        private string GetCurrentWord()
        {
            if (TextLength == 0)
                return string.Empty;

            int caret = SelectionStart;
            if (caret == 0)
                return string.Empty;

            int i = caret - 1;
            while (i >= 0 && IsIdentifierChar(Text[i]))
                i--;

            int start = i + 1;
            int len = caret - start;

            return len > 0 ? Text.Substring(start, len) : string.Empty;
        }

        private void ReplaceCurrentWord(string replacement)
        {
            int caret = SelectionStart;

            int start = caret;
            while (start > 0 && IsIdentifierChar(Text[start - 1]))
                start--;

            int end = caret;
            while (end < TextLength && IsIdentifierChar(Text[end]))
                end++;

            Select(start, end - start);
            SelectedText = replacement;
            SelectionStart = start + replacement.Length;
            SelectionLength = 0;
        }

        private static bool IsIdentifierChar(char c)
        {
            return char.IsLetterOrDigit(c) || c == '_';
        }

        private void HighlightSyntax()
        {
            if (_isHighlighting)
                return;

            _isHighlighting = true;

            int selStart = SelectionStart;
            int selLength = SelectionLength;
            Color oldColor = SelectionColor;
            Font? oldFont = SelectionFont;

            var scrollPos = new Point();
            SendMessage(Handle, EM_GETSCROLLPOS, IntPtr.Zero, ref scrollPos);

            SuspendPainting();

            try
            {
                SelectAll();
                SelectionColor = ForeColor;
                SelectionFont = _regularFont;

                var protectedRanges = new List<(int Start, int End)>();

                foreach (Match m in StringRegex.Matches(Text))
                {
                    SetStyle(m.Index, m.Length, Color.Brown, _regularFont);
                    protectedRanges.Add((m.Index, m.Index + m.Length));
                }

                foreach (Match m in LineCommentRegex.Matches(Text))
                {
                    SetStyle(m.Index, m.Length, Color.Green, _regularFont);
                    protectedRanges.Add((m.Index, m.Index + m.Length));
                }

                foreach (Match m in BlockCommentRegex.Matches(Text))
                {
                    SetStyle(m.Index, m.Length, Color.LimeGreen, _regularFont);
                    protectedRanges.Add((m.Index, m.Index + m.Length));
                }

                foreach (Match m in NumberRegex.Matches(Text))
                {
                    if (!IsInsideProtected(m.Index, m.Length, protectedRanges))
                    {
                        SetStyle(m.Index, m.Length, Color.DarkCyan, _regularFont);
                    }
                }

                foreach (Match m in _keywordRegex.Matches(Text))
                {
                    if (!IsInsideProtected(m.Index, m.Length, protectedRanges))
                    {
                        SetStyle(m.Index, m.Length, Color.CornflowerBlue, _boldFont);
                    }
                }

                Select(selStart, selLength);
                SelectionColor = oldColor;
                if (oldFont != null)
                    SelectionFont = oldFont;

                SendMessage(Handle, EM_SETSCROLLPOS, IntPtr.Zero, ref scrollPos);
            }
            finally
            {
                ResumePainting();
                _isHighlighting = false;
            }
        }

        private void SetStyle(int start, int length, Color color, Font font)
        {
            Select(start, length);
            SelectionColor = color;
            SelectionFont = font;
        }

        private static bool IsInsideProtected(int start, int length, List<(int Start, int End)> ranges)
        {
            int end = start + length;

            foreach (var r in ranges)
            {
                if (start < r.End && end > r.Start)
                    return true;
            }

            return false;
        }

        private const int WM_SETREDRAW = 0x000B;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int EM_GETSCROLLPOS = 0x04DD;
        private const int EM_SETSCROLLPOS = 0x04DE;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)
                Invalidate();
        }

        private const uint RDW_INVALIDATE = 0x0001; 
        private const uint RDW_ERASE = 0x0004; 
        private const uint RDW_FRAME = 0x0400;
        private const uint RDW_ALLCHILDREN = 0x0080; 
        private const uint RDW_UPDATENOW = 0x0100;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref Point lParam);

        [DllImport("user32.dll")]
        private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

        private void SuspendPainting()
        {
            if (IsHandleCreated)
                SendMessage(Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
        }

        private void ResumePainting()
        {
            if (!IsHandleCreated)
                return;

            SendMessage(Handle, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);

            RedrawWindow(
                Handle,
                IntPtr.Zero,
                IntPtr.Zero,
                RDW_INVALIDATE | RDW_ERASE | RDW_FRAME | RDW_ALLCHILDREN | RDW_UPDATENOW);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_ownerForm != null)
                    _ownerForm.Deactivate -= OwnerForm_Deactivate;

                _popup.Dispose();
                _regularFont.Dispose();
                _boldFont.Dispose();
            }

            base.Dispose(disposing);
        }
    }


}