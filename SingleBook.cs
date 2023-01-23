using System.Drawing;

namespace BookStoreApp
{
    public class SingleBook
    {
        public ButtonClass button { get; set; }
        public LabelClass title { get; set; }
        public LabelClass price { get; set; }
        public SingleBook(int pos_x, int pos_y)
        {
            button = new ButtonClass(pos_x, pos_y, 70, 70, "");
            button.GetObject().Visible = false;

            title = new LabelClass(pos_x + 100, pos_y, "", 300, 50);
            title.GetObject().Visible = false;
            title.GetObject().Font = UtilitiesClass.arial12Bold;

            price = new LabelClass(pos_x + 300, pos_y, "", 100, 50);
            price.GetObject().Visible = false;
            price.GetObject().Font = UtilitiesClass.arial12Bold;
        }
        public void setParams(Image img, string tit, string pri)
        {
            button.GetObject().BackgroundImage = img;
            title.GetObject().Text = tit;
            price.GetObject().Text = pri;
        }
    }
}
