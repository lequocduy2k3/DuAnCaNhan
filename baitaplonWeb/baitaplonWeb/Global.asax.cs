using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace baitaplonWeb
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Application["ProductList"] = new List<product>();
            List<product> products = new List<product>();
            products.Add(new product(1, "hamburger truyền thống", "Bánh mì Hamburger là một loại sandwich nổi tiếng, bao gồm hai lớp bánh mì kẹp thịt xay ở giữa (thường là thịt bò).", 20, "img/AR-72657-best-hamburger-ever-ddmfs-4x3-hero-878e801ab30445988d007461782b3c25.jpg", "img/banh-mi-hamburger-truyen-thong.jpeg", "img/cach-lam-banh-Hamburger-5.jpg"));
            products.Add(new product(2, "hamburger bò", "Bánh mì Hamburger là một loại sandwich nổi tiếng, bao gồm hai lớp bánh mì kẹp thịt xay ở giữa (thường là thịt bò).", 19.55, "img/delicious-appetizing-burgers-wood-used-cutting-beef-wooden-table_481527-1073.jpg", "img/banh-mi-hamburger-truyen-thong.jpeg", "img/cach-lam-banh-Hamburger-5.jpg"));
            products.Add(new product(3, "hamburger gà", "Bánh mì Hamburger là một loại sandwich nổi tiếng, bao gồm hai lớp bánh mì kẹp thịt xay ở giữa (thường là thịt bò).", 25, "img/xchickbg.png.pagespeed.ic.vcPtK7csEr.jpg", "img/banh-mi-hamburger-truyen-thong.jpeg", "img/delicious-appetizing-burgers-wood-used-cutting-beef-wooden-table_481527-1073.jpg"));
            products.Add(new product(4, "piza hải vị", "Hương vị biển bùng nổ: tôm, mực, thanh cua cùng bí ngòi, dứa trên nền xốt Tartar (phục vụ kèm xốt Tartar)", 5, "img/Ocean Breeze_20240521172127J1N.jpeg", "img/piza_ga.jpeg", "img/piza_phomai.jpeg"));
            products.Add(new product(5, "piza gà", "Tuyệt phẩm từ gà Popcorn giòn rụm, hành tây và nấm tươi trên lớp phô mai Cheddar (phục vụ kèm xốt phô mai)", 6, "img/piza_ga.jpeg", "img/Ocean Breeze_20240521172127J1N.jpeg", "img/piza_phomai.jpeg"));
            products.Add(new product(6, "piza nướng phomai", "Thanh đạm nhưng cuốn hút từ sự hòa quyện giữa cà chua Beef, cà Tím, bí Ngòi, xốt cà chua và phô mai béo ngậy", 4, "img/piza_phomai.jpeg", "img/piza_ga.jpeg", "img/Pizza_Thap_Cam_400x275.jpg"));
            products.Add(new product(7, "Cánh gà giòn Karaage", "Cánh gà tẩm bột Karaage chiên giòn", 10.55, "img/Ga_Gion_Karaage_400x275.jpg", "img/Canh_Ga_BBQ_400x275.jpg", "img/Ga_Pho_Mai.jpg"));
            products.Add(new product(8, "Cánh gà BBQ", "Cánh gà nướng BBQ", 10, "img/Canh_Ga_BBQ_400x275.jpg", "img/Ga_Gion_Karaage_400x275.jpg", "img/Ga_Pho_Mai.jpg"));
            products.Add(new product(9, "Gà Phomai", "Gà giòn không xương phủ phô mai", 11, "img/Ga_Pho_Mai.jpg", "img/anh_Ga_BBQ_400x275.jpg", "img/Ga_Gion_Karaage_400x275.jpg"));
            Application["ProductList"] = products;
            Application["ProductHot"] = new List<product>();

            // Initialize user list
            Application["Users"] = new List<User>
            {
                new User("Admin", "admin@gmail.com", "123456", "123456", true), // Admin account
                new User("Nguyenthao", "thao2k2@gmail.com", "12345", "12345", false)  // Normal user account
            };

            // Initialize visitor count
            Application["CurrentVisitors"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Initialize the session variable 'login'
            Session["login"] = 0;

            // Increase the visitor count
            Application.Lock();
            Application["CurrentVisitors"] = (int)Application["CurrentVisitors"] + 1;
            Application.UnLock();

        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Decrease the visitor count
            Application.Lock();
            Application["CurrentVisitors"] = (int)Application["CurrentVisitors"] - 1;
            Application.UnLock();

            System.Diagnostics.Debug.WriteLine("Session Ended. CurrentVisitors: " + Application["CurrentVisitors"]);

        }
    }
}