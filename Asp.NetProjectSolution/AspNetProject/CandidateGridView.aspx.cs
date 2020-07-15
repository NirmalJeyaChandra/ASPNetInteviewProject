using AspNetProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

public partial class CandidateGridView : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["MVCProjectConnectionString"].ConnectionString;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            candidateGridView.DataSource = GetCandidates();
            candidateGridView.DataBind();         
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {         
        if(!Page.IsPostBack)
         ViewState["sortDirection"] = "Ascending";
        candidateGridView.ShowFooter = false;
    }

    protected void candidateGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        candidateGridView.EditIndex = e.NewEditIndex;
        candidateGridView.DataSource =  GetCandidates();
        candidateGridView.DataBind();
    }

    protected void candidateGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        candidateGridView.EditIndex = -1;
        candidateGridView.DataSource = GetCandidates();
        candidateGridView.DataBind();
    }

    protected void candidateGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        candidateGridView.PageIndex = e.NewPageIndex;
        candidateGridView.DataSource = GetCandidates();
        candidateGridView.DataBind();
    }  

    protected void candidateGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userid = Convert.ToInt32(candidateGridView.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)candidateGridView.Rows[e.RowIndex];
        TextBox textBoxName = (TextBox)row.FindControl("textBoxName");
        string name = textBoxName.Text;        
    }

    protected void candidateGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int candidateId = Convert.ToInt32(candidateGridView.DataKeys[e.RowIndex].Value.ToString());
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

    private List<Candidate> GetCandidates()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select * from Candidates";
        cmd.Connection = con;
        SqlDataReader dr = cmd.ExecuteReader();
        List<Candidate> candidates = new List<Candidate>();
        while (dr.Read())
        {
            candidates.Add(new Candidate
            {
                CandidateId = Convert.ToInt32(dr["CandidateId"].ToString()),
                Address = dr["Address"].ToString(),
                CountryId = Convert.ToInt32(dr["CountryId"].ToString()),
                DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"].ToString()),
                Email = dr["Email"].ToString(),
                Gender = dr["Gender"].ToString(),
                Name = dr["Name"].ToString(),
                PhoneNumber = Convert.ToInt64(dr["PhoneNumber"].ToString()),
                StateId = Convert.ToInt32(dr["StateId"].ToString()),
                MaritalStatus = Convert.ToBoolean(dr["MaritalStatus"].ToString())
            });
        }
        con.Close();
        return candidates;

    }

    protected void candidateGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //On Row Editing
        if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState & DataControlRowState.Edit) > 0))
        {
            DropDownList ddListCountry = (DropDownList)e.Row.FindControl("dropDownListCountry");
            //bind dropdownlist

            ddListCountry.DataSource = GetCountries();
            ddListCountry.DataTextField = "Name";
            ddListCountry.DataValueField = "CountryId";
            ddListCountry.DataBind();

            string countryId = (e.Row.FindControl("labelCountryId") as Label).Text;
            ddListCountry.SelectedValue = countryId;


            DropDownList ddListState = (DropDownList)e.Row.FindControl("dropDownListState");
            //bind dropdownlist

            ddListState.DataSource = GetStatesByCountryId(Convert.ToInt32(countryId));
            ddListState.DataTextField = "Name";
            ddListState.DataValueField = "StateId";
            ddListState.DataBind();

            string stateId = (e.Row.FindControl("labelStateId") as Label).Text;
            ddListState.SelectedValue = stateId;

            RadioButtonList rbListGender = (RadioButtonList)e.Row.FindControl("radioButtonListGender");
            string gender = (e.Row.FindControl("labelGender") as Label).Text;
            rbListGender.SelectedValue = gender;

        }   
            //On Non-Edit Mode 
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddListCountry = (DropDownList)e.Row.FindControl("dropDownListCountry");
            //bind dropdownlist

            ddListCountry.DataSource = GetCountries();
            ddListCountry.DataTextField = "Name";
            ddListCountry.DataValueField = "CountryId";
            ddListCountry.DataBind();
            ddListCountry.Items.Insert(0, new ListItem("Please select"));

            string countryId = (e.Row.FindControl("labelCountryId") as Label).Text;
            ddListCountry.SelectedValue = countryId;
            //ddListCountry.Items.FindByValue(countryId).Selected = true;

            DropDownList ddListState = (DropDownList)e.Row.FindControl("dropDownListState");
            //bind dropdownlist

            ddListState.DataSource = GetStatesByCountryId(Convert.ToInt32(countryId));
            ddListState.DataTextField = "Name";
            ddListState.DataValueField = "StateId";
            ddListState.DataBind();

            string stateId = (e.Row.FindControl("labelStateId") as Label).Text;
            ddListState.SelectedValue = stateId;

            RadioButtonList rbListGender = (RadioButtonList)e.Row.FindControl("radioButtonListGender");
            string gender = (e.Row.FindControl("labelGender") as Label).Text;
            rbListGender.SelectedValue = gender;
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

    protected void dropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddListCountry = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddListCountry.NamingContainer;
        if (row != null)
        {
            //On Row Edit Mode or On New Row Mode
            if (((row.RowState & DataControlRowState.Edit) > 0) || (row.RowType.ToString()=="Footer"))
            {
                DropDownList ddlState = (DropDownList)row.FindControl("dropDownListState");
                ddlState.DataSource = GetStatesByCountryId(Convert.ToInt32(ddListCountry.SelectedValue));
                ddlState.DataValueField = "StateId";
                ddlState.DataTextField = "Name";
                ddlState.DataBind();
            }
        }
    }

    protected void candidateGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {  
        //On Clicking the cancel button on the New Row Mode.
        if ((e.CommandName.ToString() == "Cancel") && (e.CommandArgument.ToString() == "Insert"))
        {
            candidateGridView.ShowFooter = false;
        }
            //On New Row Mode
        else if (e.CommandName.ToString() == "New")
        {
            DropDownList ddListCountry = candidateGridView.FooterRow.FindControl("dropDownListCountry") as DropDownList;
            //bind dropdownlist

            ddListCountry.DataSource = GetCountries();
            ddListCountry.DataTextField = "Name";
            ddListCountry.DataValueField = "CountryId";
            ddListCountry.DataBind();
            ddListCountry.Items.Insert(0, new ListItem("Please select"));
            candidateGridView.FooterRow.Visible = true;
        }

        if ((e.CommandName.ToString() == "Insert") && (e.CommandArgument.ToString() == "Insert"))
        {            
            //GetCandidateData(out textBoxName, out textBoxAddress, out ddListCountry, out dropDownListState, out textBoxEmail, out textBoxDateOfBirth, out checkBoxMaritalStatus, out radioButtonListGender);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
          
            TextBox textBoxName = candidateGridView.FooterRow.FindControl("textBoxName") as TextBox;
            TextBox textBoxAddress = candidateGridView.FooterRow.FindControl("textBoxAddress") as TextBox;
            DropDownList ddListCountry = candidateGridView.FooterRow.FindControl("dropDownListCountry") as DropDownList;
            DropDownList dropDownListState = candidateGridView.FooterRow.FindControl("dropDownListState") as DropDownList;
            TextBox textBoxEmail = candidateGridView.FooterRow.FindControl("textBoxEmail") as TextBox;
            TextBox textBoxDateOfBirth = candidateGridView.FooterRow.FindControl("textBoxDateOfBirth") as TextBox;
            CheckBox checkBoxMaritalStatus = candidateGridView.FooterRow.FindControl("checkBoxMaritalStatus") as CheckBox;
            RadioButtonList radioButtonListGender = candidateGridView.FooterRow.FindControl("radioButtonListGender") as RadioButtonList;
            cmd.CommandText = "Insert into Candidates (Name, Address, CountryId, StateId, Email, DateOfBirth, MaritalStatus, Gender) values ('" + textBoxName.Text + "','" + textBoxAddress.Text + "'," + Convert.ToInt32(ddListCountry.SelectedValue) + "," + Convert.ToInt32(dropDownListState.SelectedValue) + ",'" + textBoxEmail.Text + "','" + Convert.ToDateTime(textBoxDateOfBirth.Text) + "'," + ((checkBoxMaritalStatus.Checked)?1:0) + ",'" + radioButtonListGender.SelectedItem.Text + "')";           
            cmd.ExecuteNonQuery();
            con.Close();            
        }
                if (e.CommandName.ToString() == "Update")
        {
            GridViewRow row = (GridViewRow)candidateGridView.Rows[Convert.ToInt32(e.CommandArgument)];
            
            TextBox textBoxName = row.FindControl("textBoxName") as TextBox;
            TextBox textBoxAddress = row.FindControl("textBoxAddress") as TextBox;
            DropDownList ddListCountry = row.FindControl("dropDownListCountry") as DropDownList;
            DropDownList dropDownListState = row.FindControl("dropDownListState") as DropDownList;
            TextBox textBoxEmail = row.FindControl("textBoxEmail") as TextBox;
            TextBox textBoxDateOfBirth = row.FindControl("textBoxDateOfBirth") as TextBox;
            CheckBox checkBoxMaritalStatus = row.FindControl("checkBoxMaritalStatus") as CheckBox;
            RadioButtonList radioButtonListGender = row.FindControl("radioButtonListGender") as RadioButtonList;
            //GetCandidateData(out textBoxName, out textBoxAddress, out ddListCountry, out dropDownListState, out textBoxEmail, out textBoxDateOfBirth, out checkBoxMaritalStatus, out radioButtonListGender);
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = connectionString;
            //con.Open();            
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "Update Candidates set Name='" + textBoxName.Text + "', Address='" + textBoxAddress.Text + "', CountryId=Convert.ToInt32(ddListCountry.SelectedValue), StateId, Email, DateOfBirth, MaritalStatus, Gender) values ('" + textBoxName.Text + "','" + textBoxAddress.Text + "'," + Convert.ToInt32(ddListCountry.SelectedValue) + "," + Convert.ToInt32(dropDownListState.SelectedValue) + ",'" + textBoxEmail.Text + "','" + Convert.ToDateTime(textBoxDateOfBirth.Text) + "'," + ((checkBoxMaritalStatus.Checked) ? 1 : 0) + ",'" + radioButtonListGender.SelectedItem.Text + "')";
           
            //cmd.ExecuteNonQuery();
            //con.Close();  
            var  i=0;
        }
    }           

    protected void candidateGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        var viewStateValue = "";
        List<Candidate> candidates= GetCandidates();
        
            viewStateValue = ViewState["sortDirection"].ToString();
            if (ViewState["sortDirection"] != null)
            {
                if (ViewState["sortDirection"].ToString() == "Ascending")
                {
                    ViewState["sortDirection"] = "Descending";
                    candidates = candidates.OrderByDescending(o => e.SortExpression == "Name" ? o.Name : o.Address).ToList();
                }
                else
                {
                    ViewState["sortDirection"] = "Ascending";
                    candidates = candidates.OrderBy(o => e.SortExpression == "Name" ? o.Name : o.Address).ToList();
                }
            }
       
        candidateGridView.DataSource = candidates;
        candidateGridView.DataBind();
    }
}