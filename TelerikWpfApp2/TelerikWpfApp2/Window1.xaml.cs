using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RichTextBoxUI.Dialogs;
using Telerik.Windows.Documents.UI.Extensibility;

namespace CustomInsertSymbolDialog
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [CustomInsertSymbolWindow]
    public partial class CustomRadInsertSymbolDialog : RadRichTextBoxWindow, IInsertSymbolWindow
    {
        #region Fields

        private Action<char, FontFamily> insertSymbolCallback;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RadInsertSymbolDialog"/> class.
        /// </summary>
        public CustomRadInsertSymbolDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="insertSymbolCallback">The callback that will be invoked to insert symbols.</param>
        /// <param name="initialFont">The font which symbols will be loaded initially.</param>
        /// <param name="owner">The owner of the dialog.</param>
        public void Show(Action<char, FontFamily> insertSymbolCallback, FontFamily initialFont, RadRichTextBox owner)
        {
            this.insertSymbolCallback = insertSymbolCallback;
            this.SetOwner(owner);

            if (!this.IsOpen)
            {
                this.symbolPicker.SelectedFontFamily = initialFont;
                this.Show();
            }
        }

        #endregion

        #region Events Hanlders

        private void symbolPicker_SymbolSelected(object sender, Telerik.Windows.Controls.RichTextBoxUI.Dialogs.Symbols.SymbolEventArgs e)
        {
            if (this.insertSymbolCallback != null)
            {
                this.insertSymbolCallback(e.Symbol, this.symbolPicker.SelectedFontFamily);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
        }

        protected override void OnClosed(WindowClosedEventArgs args)
        {
            base.OnClosed(args);

            this.insertSymbolCallback = null;
            this.Owner = null;
        }

        #endregion
    }
}

