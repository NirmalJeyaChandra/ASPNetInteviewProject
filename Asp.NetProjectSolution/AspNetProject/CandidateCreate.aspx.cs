using AspNetProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CandidateCreate : System.Web.UI.Page
{
    //Retrieving connection string from the web.config file
    string connectionString = ConfigurationManager.ConnectionStrings["MVCProjectConnectionString"].ConnectionString;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCountries();
            BindTechnologies();
        }
    }

    private void BindCountries()
    {
        dropDownListCountry.DataSource = GetCountries();
        dropDownListCountry.DataTextField = "Name";
        dropDownListCountry.DataValueField = "CountryId";
        dropDownListCountry.DataBind();
    }

    private void BindTechnologies()
    {
        listBoxTechs.DataSource = GetTechnologies();
        listBoxTechs.DataTextField = "Name";
        listBoxTechs.DataValueField = "TechnologyId";
        listBoxTechs.DataBind();
    }

    private List<Technology> GetTechnologies()
    {
        var con = new SqlConnection();
        con.ConnectionString = connectionString;
        con.Open();
        var cmd = new SqlCommand();
        cmd.CommandText = "Select * from Technologies";
        cmd.Connection = con;
        var dr = cmd.ExecuteReader();
        var technologies = new List<Technology>();
        while (dr.Read())
        {
            technologies.Add(new Technology { TechnologyId = Convert.ToInt32(dr["TechnologyId"].ToString()), Name = dr["Name"].ToString() });
        }
        return technologies;
    }

    protected void Page_Load(object sender, EventArgs e)
    { }

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
        return countries;
    }

    public List<State> GetStatesByCountryId()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select * from States where CountryId=" + dropDownListCountry.SelectedValue;
        cmd.Connection = con;
        SqlDataReader dr = cmd.ExecuteReader();
        List<State> states = new List<State>();
        while (dr.Read())
        {
            states.Add(new State { StateId = Convert.ToInt32(dr["StateId"].ToString()), Name = dr["Name"].ToString() });
        }
        return states;
    }

    protected void dropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindStates();
    }

    private void BindStates()
    {
        List<State> states = GetStatesByCountryId();
        dropDownListState.DataSource = states;
        dropDownListState.DataTextField = "Name";
        dropDownListState.DataValueField = "StateId";
        dropDownListState.DataBind();
    }

    protected void buttonSave_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();        
        cmd.CommandText = "";
        cmd.Connection = con;
        Candidate candidate = new Candidate
        {
            Name = textBoxName.Text,
            Address = textBoxAddress.Text,
            CountryId = Convert.ToInt32(dropDownListCountry.SelectedValue),
            StateId = Convert.ToInt32(dropDownListState.SelectedValue),
            PhoneNumber = Convert.ToInt64(textBoxPhone.Text),
            Email = textBoxEmail.Text,
            DateOfBirth = Convert.ToDateTime(textBoxDate.Text),
            MaritalStatus = checkBoxMarried.Checked,
            Gender = radioButtonListGender.SelectedValue//or selectedItem.Value
        };
        List<int> selectedTechIds=new List<int>();
        foreach (ListItem li in listBoxTechs.Items)
        {
            if (li.Selected == true)
            {
                // you are always using lstCatID.SelectedItem.Value.
                selectedTechIds.Add(Convert.ToInt32(li.Value));
            }
        }      
        //cmd.ExecuteNonQuery();
        
    }
}