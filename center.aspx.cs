using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdsRushX
{
    public partial class center : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool query;

                query = init_query(sender, e);

                if (query == false)
                {
                    init_categories();
                    init_category();
                    init_related();
                }


            }
        }


        public bool init_query(object sender, EventArgs e)
        {

            bool query_exist = false;

            if (Request.QueryString["createad"] != null)
            {
            
                init_categories();
                init_category();
                init_related();
                create_ad_click(sender, e);
                query_exist = true;

            }

            if (Request.QueryString["affiliates"] != null)
            {
                init_categories();
                init_category();
                init_related();
                aff_click(sender, e);
                query_exist = true;
            }

            if (Request.QueryString["publishers"] != null)
            {
                
                init_categories();
                init_category();
                init_related();
                monetize_click(sender, e);
                
                query_exist = true;
            }

            if (Request.QueryString["bloggers"] != null)
            {
                
                init_categories();
                init_category();
                init_related();
                monetize2_click(sender, e);                
                query_exist = true;
            }

            if (Request.QueryString["cat"] != null)
            {
                /*
                string city = Request.QueryString["city"];
                string cityval = city2val(city);
                string countryval = find_country_by_city_val(cityval);

                init_countries();
                change_country(countryval);
                change_city(cityval);

                DropDownCities.Focus();

                //change_selected_city(cityval);                


                //city_change(sender, e);*/
                query_exist = true;
            }


            return query_exist;
        }

        protected void create_ad_click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;            
            advertisers2.Focus();
        }

        public void init_categories()
        {
            if (DropDownCategories.Items.Count == 1)
            {

                DropDownCategories.Items.Clear();
                ListItem item3 = new ListItem("Select Category");
                DropDownCategories.Items.Add(item3);

                AdsRushX.CategoriesDataContext db4 = new AdsRushX.CategoriesDataContext();


                var categories = (from t in db4.Table_AdsRushX_Categories
                                  orderby t.title
                                  select t.title);

                foreach (var cat in categories)
                {
                    ListItem item2 = new ListItem(cat);
                    DropDownCategories.Items.Add(item2);
                }
            }
        }

        public void init_category()
        {
            wrong19.Visible = false;

            AdsRushX.CategoriesDataContext db = new AdsRushX.CategoriesDataContext();            

            if (DropDownCategories.Items.Count == 0)
            {
                ListItem item = new ListItem("Select Category", "0");
                DropDownCategories.Items.Add(item);


                var the_ver = (from t in db.Table_AdsRushX_Categories
                               orderby t.title ascending
                               select t);

                if (the_ver == null)
                {
                    wrong19.Visible = true;
                    return;
                }

                foreach (var cat in the_ver)
                {
                    ListItem item2 = new ListItem(cat.title, cat.id.ToString());
                    DropDownCategories.Items.Add(item2);

                }

            }

            init_cat();

        }

        public void init_cat()
        {
            AdsRushX.CategoriesDataContext db = new AdsRushX.CategoriesDataContext();            

            string category = DropDownCategories.SelectedItem.Text;            

            if (category.Equals("Select Category"))
            {
                Label411.Text = "Welcome to Ads Rush X, the new and growing advertising network! We currently support over 35 categories, the most popular are: Dating, Travel and Fashion, but we have many more! And most importantly, we will optimize your ads to show on your chosen category!";

                category_image.ImageUrl = "https://www.couponnection.com/graylogo2.png";
                //init_related();
                return;
            }

            var the_category = (from t in db.Table_AdsRushX_Categories
                               where (t.title.Equals(category))
                               select t).FirstOrDefault();

            if (the_category == null)
            {
                wrong19.Visible = true;
                return;
            }


            string cat = category.ToLower();
            string cat2 = category;

            Label411.Text = "Welcome to Ads Rush X CYT! The new and growing advertising network! We currently support over 35 categories, including: CIT! And most importantly, we will optimize your ads to show on your chosen category - CIT and more, and here you can buy and sell quality CIT traffic!";            
            Label411.Text = Label411.Text.Replace("CIT", cat);
            Label411.Text = Label411.Text.Replace("CYT", cat2);

            Label413.Text = "Create ad and promote your cat website!";
            Label414.Text = "Monetize your cat traffic from your website or your blog!";
            Label416.Text = "Become our affiliate and earn great commissions by inviting cat publishers!";
            Label417.Text = "Create ad - promote your cat website!";

            Label421.Text = "Create ad and promote your cat website! We will optimize your ad to show on cat websites and blogs - so you can expect great cat traffic!";
            Label423.Text = "Monetize your cat traffic from your website or blog and be rewarded. We will show relevant cat ads - so you can monetize your cat traffic from your website!";
            Label425.Text = "Monetize your cat traffic from your blog and be rewarded. We will show relevant cat ads so you can monetize your cat traffic from your blog!";
            Label427.Text = "Become our affiliate and earn great commissions by inviting cat publishers and bloggers, we will pay weekly!";

            Label422.Text = "Monetize your cat traffic from your website!";
            Label424.Text = "Monetize your cat traffic from your blog!";

            Label413.Text = Label413.Text.Replace("cat", cat);
            Label414.Text = Label414.Text.Replace("cat", cat);
            Label416.Text = Label416.Text.Replace("cat", cat);
            Label417.Text = Label417.Text.Replace("cat", cat);
            Label421.Text = Label421.Text.Replace("cat", cat);
            Label423.Text = Label423.Text.Replace("cat", cat);
            Label425.Text = Label425.Text.Replace("cat", cat);

            Label422.Text = Label422.Text.Replace("cat", cat);
            Label424.Text = Label424.Text.Replace("cat", cat);
            Label427.Text = Label427.Text.Replace("cat", cat);            

            string gray_circle6 = the_category.graylogo;

            category_image.ImageUrl = gray_circle6;
            //DropDownVertical.Focus();

            //init_related();

        }



    

        protected void monetize_click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            publishers3.Focus();
        }

        protected void monetize2_click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            blogers3.Focus();
        }

        protected void aff_click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            affiliates4.Focus();
        }

        public string find_cat(string val)
        {
            AdsRushX.CategoriesDataContext db = new AdsRushX.CategoriesDataContext();            

            var cat = (from t in db.Table_AdsRushX_Categories
                        where t.id.ToString().Equals(val)
                        select t).FirstOrDefault();

            if (cat == null)
                return "";

            return cat.title;


        }

        public void change_cat(string val)
        {
            string cat = find_cat(val);

            AdsRushX.CategoriesDataContext db = new AdsRushX.CategoriesDataContext();

            if (DropDownCategories.Items.Count == 1)
            {
                init_categories();
            }

            foreach (ListItem li in DropDownCategories.Items)
            {
                    if (li.Text.Equals(cat))
                    {
                        DropDownCategories.SelectedValue = li.Value;
                    }                
            }

            text_change_cat_click(this, null);                

        }


        protected void RDest1_Click(object sender, ImageClickEventArgs e)
        {
            string val = HiddenCat1.Value;

            change_cat(val);
        }

        protected void RDest2_Click(object sender, ImageClickEventArgs e)
        {
            string val = HiddenCat2.Value;

            change_cat(val);
        }

        protected void RDest3_Click(object sender, ImageClickEventArgs e)
        {
            string val = HiddenCat3.Value;

            change_cat(val);
        }

        protected void RDest4_Click(object sender, ImageClickEventArgs e)
        {
            string val = HiddenCat4.Value;

            change_cat(val);
        }

        protected void RDest5_Click(object sender, ImageClickEventArgs e)
        {
            string val = HiddenCat5.Value;

            change_cat(val);
        }

        public void my_focus()        {

//            DropDownCountries.Focus();
            

            if (MultiView1.ActiveViewIndex == 0)
            {
                createad.Focus();
            }
            else if (MultiView1.ActiveViewIndex == 1)
            {
                advertisers2.Focus();
            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                publishers3.Focus();
            }

            else if (MultiView1.ActiveViewIndex == 3)
            {
                blogers3.Focus();
            }

            else if (MultiView1.ActiveViewIndex == 4)
            {
                affiliates4.Focus();
            }

        }

        public void reset_related()
        {

            RelCat1.ImageUrl = "";
            catlink1.Text = "";
            HiddenCat1.Value = "0";
            RelCat1.BorderWidth = 0;
            RelCat1.Visible = false;


            RelCat2.ImageUrl = "";
            catlink2.Text = "";
            HiddenCat2.Value = "0";
            RelCat2.BorderWidth = 0;
            RelCat2.Visible = false;

            RelCat3.ImageUrl = "";
            catlink3.Text = "";
            HiddenCat3.Value = "0";
            RelCat3.BorderWidth = 0;
            RelCat3.Visible = false;

            RelCat4.ImageUrl = "";
            catlink4.Text = "";
            HiddenCat4.Value = "0";
            RelCat4.BorderWidth = 0;
            RelCat4.Visible = false;

            RelCat5.ImageUrl = "";
            catlink5.Text = "";
            HiddenCat5.Value = "0";
            RelCat5.BorderWidth = 0;
            RelCat5.Visible = false;


        }

        public void init_related()
        {

            AdsRushX.CategoriesDataContext db = new AdsRushX.CategoriesDataContext();

            string vert = DropDownCategories.SelectedItem.Text;

            bool def = false;

            if (vert.Equals("Select Category"))
            {
                def = true;
            }

            var group = (from t in db.Table_AdsRushX_Categories
                         where t.title.Equals(vert)
                         select t).FirstOrDefault();

            string mygroup = "";

            if ((group == null) && (def == false))
            {
                return;
            }

            else if (group != null)
            {
                mygroup = group.related_group.ToString();
            }


            var the_vert = (from t in db.Table_AdsRushX_Categories
                            where ((t.related_group.ToString().Equals(mygroup)) || (vert.Equals("Select Category")))
                            orderby t.rank descending
                            select t).Take(5);


            int counter = 1;

            reset_related();



            /*
    

            string category = DropDownCategories.SelectedItem.Text;

            if (category.Equals("Select Category"))
            {
                //dest = "United States";                
            }

            var the_categories = (from t in db.Table_AdsRushX_Categories
                              where ((t.title.Equals(category)) || (category.Equals("Select Category")))
                              orderby t.rank descending
                              select t).Take(5);


            /*var the_cities = (from t in db.Table_MyTouristbook_Cities
                              where t.country.Equals(dest)
                              orderby t.rank descending
                              select t).Take(5);
                              

            int counter = 1;

            reset_related();  */

            foreach (var cat in the_vert)
            {
                //affsbook.Table_Affsbook_Affiliate aff = get_affiliate((int)tab2.authoraid);

                if (counter == 1)
                {
                    RelCat3.ImageUrl = cat.icon;
                    RelCat3.Width = 175;
                    RelCat3.Height = 150;
                    RelCat3.BorderWidth = 2;
                    catlink3.Text = cat.title;
                    HiddenCat3.Value = cat.id.ToString();
                    RelCat3.Visible = true;
                }

                if (counter == 2)
                {
                    RelCat2.ImageUrl = cat.icon;
                    RelCat2.Width = 175;
                    RelCat2.Height = 150;
                    RelCat2.BorderWidth = 2;
                    catlink2.Text = cat.title;
                    HiddenCat2.Value = cat.id.ToString();
                    RelCat2.Visible = true;
                }

                if (counter == 3)
                {
                    RelCat4.ImageUrl = cat.icon;
                    RelCat4.Width = 175;
                    RelCat4.Height = 150;
                    RelCat4.BorderWidth = 2;
                    catlink4.Text = cat.title;
                    HiddenCat4.Value = cat.id.ToString();
                    RelCat4.Visible = true;
                }

                if (counter == 4)
                {
                    RelCat1.ImageUrl = cat.icon;
                    RelCat1.Width = 175;
                    RelCat1.Height = 150;
                    RelCat1.BorderWidth = 2;
                    catlink1.Text = cat.title;
                    HiddenCat1.Value = cat.id.ToString();
                    RelCat1.Visible = true;
                }

                if (counter == 5)
                {
                    RelCat5.ImageUrl = cat.icon;
                    RelCat5.Width = 175;
                    RelCat5.Height = 150;
                    RelCat5.BorderWidth = 2;
                    catlink5.Text = cat.title;
                    HiddenCat5.Value = cat.id.ToString();
                    RelCat5.Visible = true;
                }

                counter++;
            }


        }


        protected void text_change_cat_click(object sender, EventArgs e)
        {

            string cat = DropDownCategories.SelectedItem.Text;
            //init_categories();
            init_category();

            if (!cat.Equals("Select Category"))
            {
                //mycat.Text = "Ads Rush X - " + cat;
            }
            init_related();
            my_focus();

        }
    }
}