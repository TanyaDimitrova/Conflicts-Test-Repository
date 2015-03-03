using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Documents.Model.Revisions;
using Telerik.Windows.Documents.Selection;

namespace TelerikWpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var p1 = new Paragraph();
            p1.Inlines.Add(new Span("On the Insert tab, the galleries include items that are designed to coordinate with the overall look of your document. You can use these galleries to insert tables, headers, footers, lists, cover pages, and other document building blocks. When you create pictures, charts, or diagrams, they also coordinate with your current document look."));

            var p2 = new Paragraph();
            p2.Inlines.Add(new Span("On the Insert tab, the galleries include items that are designed to coordinate with the overall look of your document. You can use these galleries to insert tables, headers, footers, lists, cover pages, and other document building blocks. When you create pictures, charts, or diagrams, they also coordinate with your current document look."));


            var section = new Section();
            section.Blocks.Add(p1);
            section.Blocks.Add(p2);
            var doc = new RadDocument();
            doc.Sections.Add(section);
            var fragment = new DocumentFragment(doc);

            this.radRichTextBox.InsertFragment(fragment);
            this.radRichTextBox.IsTrackChangesEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var annotations = this.radRichTextBox.Document.EnumerateChildrenOfType<AnnotationRangeStart>().First();

            this.radRichTextBox.Document.Selection.SelectAnnotationRange(annotations);
            this.radRichTextBox.Document.Selection.Ranges.First.StartPosition.MoveToNext();
            this.radRichTextBox.Document.Selection.Ranges.First.EndPosition.MoveToPrevious();

            this.radRichTextBox.Insert("a");


            //foreach (var annotation in annotations)
            //{
            //    var spans = annotation.EnumerateChildrenOfType<Span>().ToList();
            //    if (spans.Count != 0)
            //    {
            //        MessageBox.Show(spans[0].Text);
            //    }
            //}

            //// Find revisions in text
            //DocumentPosition start = new DocumentPosition(this.radRichTextBox.Document);
            //start.MoveToPosition(this.radRichTextBox.Document.CaretPosition);
            //start.MoveToCurrentLineStart();
            //this.radRichTextBox.Document.Selection.SetSelectionStart(start);

            //DocumentPosition end = new DocumentPosition(this.radRichTextBox.Document);
            //end.MoveToPosition(this.radRichTextBox.Document.CaretPosition);
            //end.MoveToCurrentLineEnd();
            //this.radRichTextBox.Document.Selection.AddSelectionEnd(end);

            //IEnumerable<RevisionRangeEnd> revisions = this.radRichTextBox.Document.Selection.GetAnnotationMarkersOfType<RevisionRangeEnd>();

        }
    }
}
