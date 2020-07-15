using AspNetProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

public partial class EditUpdateCandidate : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["MVCProjectConnectionString"].ConnectionString;
    //Filling the Candidate Edit For based on the Candidate Id passed from the ListView Edit Mode.
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var listCountries = GetCountries();
            listCountries.Add(new Country { CountryId = 0, Name = "Select" });
            ddlCountry.DataSource = listCountries;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "CountryId";
            ddlCountry.DataBind();
            ddlCountry.SelectedValue = "0";

            var type = Request.QueryString["Type"];
            var candidateId = Convert.ToInt32(Request.QueryString["Id"]);
            var candidate = GetCandidatesById(candidateId);
            FillCandidateDetails(candidate);
        }
    }

    public void FillCandidateDetails(Candidate candidate)
    {
        txtBoxName.Text = candidate.Name;
        txtBoxAddress.Text = candidate.Address;
        ddlCountry.SelectedItem.Value= candidate.CountryId.ToString();
        ddlState.SelectedValue = candidate.StateId.ToString();
        txtBoxPhone.Text = candidate.PhoneNumber.ToString();
        txtBoxEmail.Text = candidate.Email;
        txtBoxDateOfBirth.Text = candidate.DateOfBirth.ToString();
        chkBoxMarried.Checked = Convert.ToBoolean(candidate.MaritalStatus.ToString());
        rdbtnListGender.SelectedValue = candidate.Gender;

    }

    public Candidate GetCandidatesById(int candidateId)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select * from Candidates where CandidateId=" + candidateId;
        cmd.Connection = con;
        SqlDataReader dr = cmd.ExecuteReader();
        var candidate = new Candidate();
        while (dr.Read())
        {
            candidate.CandidateId = Convert.ToInt32(dr["CandidateId"].ToString());
            candidate.CountryId = Convert.ToInt32(dr["CountryId"].ToString());
            candidate.Address = dr["Address"].ToString();
            candidate.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"].ToString());
            candidate.Email = dr["Email"].ToString();
            candidate.Gender = dr["Gender"].ToString();
            candidate.MaritalStatus = Convert.ToBoolean(dr["MaritalStatus"].ToString());
            candidate.Name = dr["Name"].ToString();
            candidate.PhoneNumber = Convert.ToInt64(dr["PhoneNumber"].ToString());
            candidate.StateId = Convert.ToInt32(dr["StateId"].ToString());
        }
        dr.Close();
        con.Close();
        return candidate;
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

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        var listStates = GetStatesByCountryId(Convert.ToInt32(ddlCountry.SelectedValue));
        listStates.Add(new State { StateId = 0, Name = "Select" });
        ddlState.DataSource = listStates;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "StateId";
        ddlState.DataBind();
        ddlState.SelectedValue = "0";
    }
}