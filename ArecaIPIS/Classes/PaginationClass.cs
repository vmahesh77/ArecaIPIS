using ArecaIPIS.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    class PaginationClass
    {

        public void Populate(int recordCount, int currentPage, int pageSize, Panel pnlPagination, Form form, Action<int, int> dataRetrievalAction)
        {
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;
            int pagerSpan = 6;

            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "|<", Value = "1" });
            }

            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
            }

            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = ">|", Value = pageCount.ToString() });
            }

            pnlPagination.Controls.Clear();

            int count = 0;
            int panelWidth = pnlPagination.Width;
            int totalButtonWidth = pages.Count * 38;
            int startingPosition = (panelWidth - totalButtonWidth) / 2;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Size = new System.Drawing.Size(35, 22);
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Font = new Font(btnPage.Font, FontStyle.Bold);
                btnPage.ForeColor = Color.White;
                btnPage.FlatStyle = FlatStyle.Flat;
                btnPage.BackColor = Color.ForestGreen;
                btnPage.Enabled = !page.Selected;
                if (page.Selected)
                {
                    btnPage.ForeColor = Color.White;
                    btnPage.BackColor = Color.LightGray;
                }
                btnPage.Click += (sender, e) => Page_Click(sender, e, dataRetrievalAction, pageSize);

                int xCoordinate = startingPosition + (38 * count);
                btnPage.Location = new System.Drawing.Point(xCoordinate, 10);
                pnlPagination.Controls.Add(btnPage);
                count++;
            }

            int verticalPadding = 5;
            int labelYCoordinate = pnlPagination.Controls.Count > 0 ? pnlPagination.Controls[0].Bottom + verticalPadding : 10;

            int recordStartIndex = (currentPage - 1) * pageSize + 1;
            int recordEndIndex = Math.Min(currentPage * pageSize, recordCount);
            string pageInfoText = $"{recordStartIndex}-{recordEndIndex} out of {recordCount}";

            Label lblPageInfo = new Label();
            lblPageInfo.Text = pageInfoText;
            lblPageInfo.AutoSize = true;
            lblPageInfo.ForeColor = Color.Black;
            lblPageInfo.BackColor = Color.White;
            lblPageInfo.Location = new Point((pnlPagination.Width - lblPageInfo.Width) / 2, labelYCoordinate);
            pnlPagination.Controls.Add(lblPageInfo);
        }


        private void Page_Click(  object sender, EventArgs e, Action<int, int> dataRetrievalAction, int pageSize)
        {
         

            Button btnPager = (sender as Button);
            int pageIndex = int.Parse(btnPager.Name);
            dataRetrievalAction(pageIndex, pageSize);

        }

        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

    }
 }
