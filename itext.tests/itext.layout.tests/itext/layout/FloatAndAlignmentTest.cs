/*
This file is part of the iText (R) project.
Copyright (c) 1998-2018 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Test;

namespace iText.Layout {
    public class FloatAndAlignmentTest : ExtendedITextTest {
        public static readonly String sourceFolder = iText.Test.TestUtil.GetParentProjectDirectory(NUnit.Framework.TestContext
            .CurrentContext.TestDirectory) + "/resources/itext/layout/FloatAndAlignmentTest/";

        public static readonly String destinationFolder = NUnit.Framework.TestContext.CurrentContext.TestDirectory
             + "/test/itext/layout/FloatAndAlignmentTest/";

        [NUnit.Framework.OneTimeSetUp]
        public static void BeforeClass() {
            CreateOrClearDestinationFolder(destinationFolder);
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlocksInsideDiv() {
            /* this test shows different combinations of 3 float values blocks  within divParent containers
            */
            String testName = "blocksInsideDiv";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            Div div1 = CreateDiv(ColorConstants.RED, HorizontalAlignment.CENTER, ClearPropertyValue.BOTH, FloatPropertyValue
                .NONE);
            Div div2 = CreateDiv(ColorConstants.BLUE, HorizontalAlignment.LEFT, ClearPropertyValue.BOTH, FloatPropertyValue
                .NONE);
            Div div3 = CreateDiv(ColorConstants.GREEN, HorizontalAlignment.RIGHT, ClearPropertyValue.BOTH, FloatPropertyValue
                .NONE);
            Div divParent1 = CreateParentDiv(HorizontalAlignment.CENTER, ClearPropertyValue.BOTH, 500);
            divParent1.Add(div3);
            divParent1.Add(div2);
            divParent1.Add(div1);
            document.Add(divParent1);
            Div divParent2 = CreateParentDiv(HorizontalAlignment.LEFT, ClearPropertyValue.BOTH, 500);
            divParent2.Add(div2);
            divParent2.Add(div1);
            divParent2.Add(div3);
            document.Add(divParent2);
            Div divParent3 = CreateParentDiv(HorizontalAlignment.RIGHT, ClearPropertyValue.BOTH, 500);
            divParent3.Add(div1);
            divParent3.Add(div2);
            divParent3.Add(div3);
            document.Add(divParent3);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff01_"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlocksInsideDivFloat() {
            /* this test shows different combinations of 3 float values blocks  within divParent containers
            */
            String testName = "blocksInsideDivFloat";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            Div div1 = CreateDiv(ColorConstants.RED, HorizontalAlignment.CENTER, ClearPropertyValue.BOTH, FloatPropertyValue
                .NONE);
            Div div2 = CreateDiv(ColorConstants.BLUE, HorizontalAlignment.LEFT, ClearPropertyValue.BOTH, FloatPropertyValue
                .RIGHT);
            Div div3 = CreateDiv(ColorConstants.GREEN, HorizontalAlignment.RIGHT, ClearPropertyValue.BOTH, FloatPropertyValue
                .LEFT);
            Div divParent1 = CreateParentDiv(HorizontalAlignment.CENTER, ClearPropertyValue.BOTH, 400);
            divParent1.Add(div3);
            divParent1.Add(div2);
            divParent1.Add(div1);
            document.Add(divParent1);
            Div divParent2 = CreateParentDiv(HorizontalAlignment.LEFT, ClearPropertyValue.BOTH, 400);
            divParent2.Add(div2);
            divParent2.Add(div1);
            divParent2.Add(div3);
            document.Add(divParent2);
            Div divParent3 = CreateParentDiv(HorizontalAlignment.RIGHT, ClearPropertyValue.BOTH, 400);
            divParent3.Add(div1);
            divParent3.Add(div2);
            divParent3.Add(div3);
            document.Add(divParent3);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff01_"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlocksInsideEachOther() {
            /* this test shows different combinations of float blocks  inside each other
            * NOTE: second page - incorrect shift of block
            * NOTE: incorrectly placed out of containing divs
            */
            String testName = "blocksInsideEachOther";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            Div div1 = CreateDiv(ColorConstants.RED, HorizontalAlignment.CENTER, ClearPropertyValue.BOTH, FloatPropertyValue
                .NONE);
            Div div2 = CreateDiv(ColorConstants.BLUE, HorizontalAlignment.LEFT, ClearPropertyValue.BOTH, FloatPropertyValue
                .RIGHT);
            Div div3 = CreateDiv(ColorConstants.GREEN, HorizontalAlignment.RIGHT, ClearPropertyValue.BOTH, FloatPropertyValue
                .LEFT);
            Div div4 = CreateDiv(ColorConstants.YELLOW, HorizontalAlignment.RIGHT, ClearPropertyValue.NONE, FloatPropertyValue
                .RIGHT);
            Div div5 = CreateDiv(ColorConstants.ORANGE, HorizontalAlignment.LEFT, ClearPropertyValue.NONE, FloatPropertyValue
                .LEFT);
            Div divParent1 = CreateParentDiv(HorizontalAlignment.CENTER, ClearPropertyValue.BOTH, 500);
            divParent1.Add(div1);
            div1.Add(div2);
            div2.Add(div3);
            document.Add(divParent1);
            Div divParent2 = CreateParentDiv(HorizontalAlignment.LEFT, ClearPropertyValue.BOTH, 500);
            divParent2.Add(div4);
            div4.Add(div1);
            document.Add(divParent2);
            Div divParent3 = CreateParentDiv(HorizontalAlignment.RIGHT, ClearPropertyValue.BOTH, 500);
            divParent3.Add(div5);
            div5.Add(div4);
            document.Add(divParent3);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff02_"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlocksNotInDivCenter() {
            /* this test shows different combinations of 3 float values blocks
            * NOTE, that div1 text is partly overlapped
            */
            String testName = "blocksNotInDivCenter";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            CreateDocumentWithBlocks(outFileName, HorizontalAlignment.CENTER);
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff03_"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlocksNotInDivLeft() {
            /* this test shows different combinations of 3 float values blocks
            * NOTE, that div1 text is partly overlapped
            */
            String testName = "blocksNotInDivLeft";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            CreateDocumentWithBlocks(outFileName, HorizontalAlignment.LEFT);
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff04_"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        public virtual void BlocksNotInDivRight() {
            /* this test shows different combinations of 3 float values blocks
            * NOTE, that div1 text is partly overlapped
            */
            String testName = "blocksNotInDivRight";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            /*
            * Please, NOTE: in current example HorizontalAlignment values are ignored, if FloatPropertyValue !=NONE
            * So, only FloatPropertyValue defines the position of element in such cases
            */
            CreateDocumentWithBlocks(outFileName, HorizontalAlignment.RIGHT);
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diff05_"));
        }

        /// <exception cref="System.IO.FileNotFoundException"/>
        private void CreateDocumentWithBlocks(String outFileName, HorizontalAlignment? horizontalAlignment) {
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            Div div1 = CreateDiv(ColorConstants.RED, horizontalAlignment, ClearPropertyValue.NONE, FloatPropertyValue.
                NONE);
            Div div2 = CreateDiv(ColorConstants.BLUE, HorizontalAlignment.LEFT, ClearPropertyValue.NONE, FloatPropertyValue
                .RIGHT);
            Div div3 = CreateDiv(ColorConstants.GREEN, HorizontalAlignment.RIGHT, ClearPropertyValue.NONE, FloatPropertyValue
                .LEFT);
            Div div4 = CreateDiv(ColorConstants.YELLOW, HorizontalAlignment.RIGHT, ClearPropertyValue.NONE, FloatPropertyValue
                .RIGHT);
            Div div5 = CreateDiv(ColorConstants.ORANGE, HorizontalAlignment.LEFT, ClearPropertyValue.NONE, FloatPropertyValue
                .LEFT);
            document.Add(div5);
            document.Add(div4);
            document.Add(div3);
            document.Add(div2);
            document.Add(div1);
            document.Add(div5);
            document.Add(div4);
            document.Add(div3);
            document.Add(div2);
            document.Add(div1);
            document.Add(div1);
            document.Add(div1);
            document.Close();
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("DEVSIX-1732: Float is moved outside the page boundaries.")]
        public virtual void InlineBlocksAndFloatsWithTextAlignmentTest01() {
            String testName = "inlineBlocksAndFloatsWithTextAlignmentTest01";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            Paragraph parentPara = new Paragraph().SetTextAlignment(TextAlignment.RIGHT);
            Div floatingDiv = new Div();
            floatingDiv.SetProperty(Property.FLOAT, FloatPropertyValue.RIGHT);
            parentPara.Add("Text begin").Add(new Div().Add(new Paragraph("div text").SetBorder(new SolidBorder(2)))).Add
                ("More text").Add(floatingDiv.Add(new Paragraph("floating div text")).SetBorder(new SolidBorder(ColorConstants
                .GREEN, 2)));
            document.Add(parentPara);
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diffTextAlign01_"));
        }

        /// <exception cref="System.IO.IOException"/>
        /// <exception cref="System.Exception"/>
        [NUnit.Framework.Test]
        [NUnit.Framework.Ignore("DEVSIX-1732: floating element is misplaced when justification is applied.")]
        public virtual void InlineBlocksAndFloatsWithTextAlignmentTest02() {
            String testName = "inlineBlocksAndFloatsWithTextAlignmentTest02";
            String outFileName = destinationFolder + testName + ".pdf";
            String cmpFileName = sourceFolder + "cmp_" + testName + ".pdf";
            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(outFileName));
            pdfDocument.SetTagged();
            Document document = new Document(pdfDocument);
            Paragraph parentPara = new Paragraph().SetTextAlignment(TextAlignment.JUSTIFIED);
            Div floatingDiv = new Div();
            floatingDiv.SetProperty(Property.FLOAT, FloatPropertyValue.RIGHT);
            parentPara.Add("Text begin").Add(new Div().Add(new Paragraph("div text").SetBorder(new SolidBorder(2)))).Add
                (floatingDiv.Add(new Paragraph("floating div text")).SetBorder(new SolidBorder(ColorConstants.GREEN, 2
                ))).Add("MoretextMoretextMoretext. MoretextMoretextMoretext. MoretextMoretextMoretext. MoretextMoretextMoretext. MoretextMoretextMoretext. "
                );
            document.Add(parentPara.SetBorder(new DashedBorder(2)));
            document.Close();
            NUnit.Framework.Assert.IsNull(new CompareTool().CompareByContent(outFileName, cmpFileName, destinationFolder
                , "diffTextAlign01_"));
        }

        private Div CreateParentDiv(HorizontalAlignment? horizontalAlignment, ClearPropertyValue? clearPropertyValue
            , float width) {
            Div divParent1 = new Div().SetBorder(new SolidBorder(5)).SetWidth(width);
            divParent1.SetHorizontalAlignment(horizontalAlignment);
            divParent1.SetProperty(Property.CLEAR, clearPropertyValue);
            divParent1.Add(new Paragraph("Div with HorizontalAlignment." + horizontalAlignment + ", ClearPropertyValue."
                 + clearPropertyValue));
            return divParent1;
        }

        private static Div CreateDiv(Color color, HorizontalAlignment? horizontalAlignment, ClearPropertyValue? clearPropertyValue
            , FloatPropertyValue? floatPropertyValue) {
            Div div = new Div().SetBorder(new SolidBorder(color, 1)).SetBackgroundColor(color, 0.3f).SetMargins(10, 10
                , 10, 10).SetWidth(300);
            div.SetHorizontalAlignment(horizontalAlignment);
            div.SetProperty(Property.CLEAR, clearPropertyValue);
            div.SetProperty(Property.FLOAT, floatPropertyValue);
            div.Add(new Paragraph("Div with HorizontalAlignment." + horizontalAlignment + ", ClearPropertyValue." + clearPropertyValue
                 + ", FloatPropertyValue." + floatPropertyValue));
            return div;
        }
    }
}
