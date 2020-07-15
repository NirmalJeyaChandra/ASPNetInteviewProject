using AspNetProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class CandidateListView : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["MVCProjectConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    { }

    protected void ListViewCandidates_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        //On Edit Mode
        if ((ListViewCandidates.EditIndex >= 0) && (((ListViewDataItem)e.Item)).DisplayIndex == ListViewCandidates.EditIndex)
        {
            string countryId = (e.Item.FindControl("CountryIdLabel") as Label).Text;
            BindStates(e, countryId); 

            RadioButtonList rbListGender = (RadioButtonList)e.Item.FindControl("radioButtonListGender");
            string gender = (e.Item.FindControl("GenderLabel") as Label).Text;
            rbListGender.SelectedValue = gender;
        }
            //On non-edit Mode
        else if ((e.Item.ItemType == ListViewItemType.DataItem))
        {
            DropDownList ddListCountry = (DropDownList)e.Item.FindControl("dropDownListCountry");
            ddListCountry.DataSource = GetCountries();
            ddListCountry.DataTextField = "Name";
            ddListCountry.DataValueField = "CountryId";
            ddListCountry.DataBind();
            //ddListCountry.Items.Insert(0, new ListItem("Please select"));
            string countryId = (e.Item.FindControl("CountryIdLabel") as Label).Text;
            ddListCountry.SelectedValue = countryId;
            BindStates(e, countryId);          
        }
    }

    private void BindStates(ListViewItemEventArgs e, string countryId)
    {
        DropDownList ddListState = (DropDownList)e.Item.FindControl("dropDownListState");
        ddListState.AppendDataBoundItems = true;
        ddListState.DataSource = GetStatesByCountryId(Convert.ToInt32(countryId));
        ddListState.DataTextField = "Name";
        ddListState.DataValueField = "StateId";
        ddListState.DataBind();
        string stateId = (e.Item.FindControl("StateIdLabel") as Label).Text;
        ddListState.SelectedValue = stateId;
    }

    protected void dropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddListCountry = (DropDownList)sender;
        if (ListViewCandidates.EditIndex == -1)
        {
            ListViewItem item = ddListCountry.Parent as ListViewItem;
            DropDownList ddlState = (DropDownList)item.FindControl("dropDownListState");
            ddlState.Items.Clear();
            ddlState.AppendDataBoundItems = true;
            ddlState.DataSource = GetStatesByCountryId(Convert.ToInt32(ddListCountry.SelectedValue));
            ddlState.DataValueField = "StateId";
            ddlState.DataTextField = "Name";
            ddlState.DataBind();
        }
        else if (ListViewCandidates.EditIndex >= 0)
        {
            ListViewDataItem item = (ListViewDataItem)ddListCountry.NamingContainer;
            if (item.DisplayIndex == ListViewCandidates.EditIndex)
            {
                int countryId = Convert.ToInt32(ddListCountry.SelectedValue);               
                DropDownList ddlState = (DropDownList)item.FindControl("dropDownListState");
                ddlState.Items.Clear();
                ddlState.AppendDataBoundItems = true;
                ddlState.DataSource = GetStatesByCountryId(Convert.ToInt32(ddListCountry.SelectedValue));                
                ddlState.DataTextField = "Name";
                ddlState.DataValueField = "StateId";              
                ddlState.DataBind();            
            }            
        }        
    }

    public List<State> GetStatesByCountryId(int countryId)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select * from States where CountryId=" + countryId;
        cmd.Connection = con;
        SqlDataReader dr = cmd.ExecuteReader();
        List<State> states = new List<State>();
        while (dr.Read())
        {
            states.Add(new State { StateId = Convert.ToInt32(dr["StateId"].ToString()), Name = dr["Name"].ToString() });
        }
        con.Close();
        return states;
    }

    public List<Country> GetCountries()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select * from Countries";
        cmd.Connection = con;
        SqlDataReader dr = cmd.ExecuteReader();
        List<Country> countries = new List<Country>();
        while (dr.Read())
        {
            countries.Add(new Country { CountryId = Convert.ToInt32(dr["CountryId"].ToString()), Name = dr["Name"].ToString() });
        }
        con.Close();
        return countries;
    }

    protected void ListViewCandidates_ItemCreated(object sender, ListViewItemEventArgs e)
    {
        if ((e.Item != null) && (e.Item.ItemType == ListViewItemType.InsertItem))
        {
            //DropDownList ddlCountry = (DropDownList)e.Item.FindControl("dropDownListCountry");
            //if (ddlCountry != null)
            //{
            //    ddlCountry.DataSource = GetCountries();
            //    ddlCountry.DataValueField = "CountryId";
            //    ddlCountry.DataTextField = "Name";
            //    ddlCountry.DataBind();
            //}

            //DropDownList ddListState = (DropDownList)e.Item.FindControl("dropDownListState");
            ////bind dropdownlist

            //ddListState.DataSource = new List<State> { new State { StateId = 0, Name = "Select" } };
            //ddListState.DataTextField = "Name";
            //ddListState.DataValueField = "StateId";
            //ddListState.DataBind();
        }
    }

    protected void ListViewCandidates_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
    {

        var i = 0;
        //if ((e.Item != null) && (e.Item.ItemType == ListViewItemType.DataItem))
        //{ 
        //e.NewValues["Name"]
        //    e.NewValues["Address"]
        //        e.NewValues["CountryId"]
        //            e.NewValues["StateId"]
        //                e.NewValues["PhoneNumber"]
        //                    e.NewValues["Email"]
        //                        e.NewValues["DateOfBirth"]
        //                            e.NewValues["MaritalStatus"]
        //                                e.NewValues["Gender"]
        //}
    }

    protected void ListViewCandidates_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        bool isEdit=(String.Compare(e.CommandName, "Edit") == 0);
        if (isEdit)
        {
            var editIndex = e.Item.DataItemIndex;
            var candidateId = (sender as ListView).DataKeys[editIndex].Value;
            Response.Redirect("EditUpdateCandidate.aspx?Type=Edit&Id=" + candidateId);
        }

    }
}