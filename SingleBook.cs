using System.Drawing;

namespace BookStoreApp
{
    public class SingleBook
    {
        public int bookId = 0;
        public ButtonClass button { get; set; }
        public LabelClass title { get; set; }
        public LabelClass price { get; set; }
        public SingleBook(int pos_x, int pos_y)
        {
            button = new ButtonClass(pos_x, pos_y, 70, 70, "");
            button.GetObject().Visible = false;

            title = new LabelClass(pos_x + 200, pos_y + 12, "", 300, 50);
            title.GetObject().Visible = false;
            title.GetObject().Font = UtilitiesClass.arial12Bold;

            price = new LabelClass(pos_x + 600, pos_y + 12, "", 100, 50);
            price.GetObject().Visible = false;
            price.GetObject().Font = UtilitiesClass.arial12Bold;
        }
        public void setParams(int id, Bitmap img, string tit, string pri)
        {
            bookId = id;
            button.GetObject().BackgroundImage = img;
            title.GetObject().Text = tit;
            price.GetObject().Text = pri;
        }
        public void setVisible(bool value)
        {
            button.GetObject().Visible = value;
            title.GetObject().Visible = value;
            price.GetObject().Visible = value;
        }
        public ButtonClass GetButtonObj()
        {
            return button;
        }
        public LabelClass GetTtleObj()
        {
            return title;
        }
        public LabelClass GetPriceObj()
        {
            return price;
        }
    }
}
