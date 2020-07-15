//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//public partial class AspNetEF : System.Web.UI.Page
//{
//    //Retrieving Multiple Record Sets using EF
//    protected void Page_Load(object sender, EventArgs e)
//    {          
//        var Categories = new List<Category_SprocResult>();
//        var Products =  new List<Product_SprocResult>();        

//        using (var dbContext = new StoreDBEntities2())
//        {         
//            var results = dbContext.GetAllCategorisAndProducts();

//            //Get first result set
//            Categories.AddRange(results);
            
//            //Get second result set
//            var products = results.GetNextResult<Product_SprocResult>();
//            Products.AddRange(products);     
//        }

//        GridViewCategory.DataSource = Categories;
//        GridViewCategory.DataBind();

//        GridViewProduct.DataSource = Products;
//        GridViewProduct.DataBind();
//    }
//}