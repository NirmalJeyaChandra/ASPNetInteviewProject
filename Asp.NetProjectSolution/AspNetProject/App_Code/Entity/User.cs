using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
	public User()
	{}

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; }

    public bool MaritalStatus { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }
}