<Query Kind="Statements">
  <Connection>
    <ID>56b0004e-a9da-45f4-9ab6-f8fc47836931</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(local)</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <UseMicrosoftDataSqlClient>true</UseMicrosoftDataSqlClient>
    <EncryptTraffic>true</EncryptTraffic>
    <Database>StartTed-2025-Sept</Database>
    <MapXmlToString>false</MapXmlToString>
    <DriverData>
      <SkipCertificateCheck>true</SkipCertificateCheck>
    </DriverData>
  </Connection>
</Query>

// Question 1
Rentals 
	.Where(x => x.MaxTenants >= 5 &&
			  (x.Address.Community == "Oliver" ||
			   x.Address.Community == "Westmount" ||
			   x.Address.Community == "Forest Heights"))
	.OrderBy(x => x.Address.Community )
	.ThenByDescending(x => x.MonthlyRent)
	.Select(x => new
		{
			RentalID = x.RentalID,
			MonthlyRent = x.MonthlyRent,
			MaxTenants = x.MaxTenants,
			Community = x.Address.Community,
			Description = x.RentalType.Description,
			AvailableDate = x.AvailableDate == null ? "U/K" : x.AvailableDate.Value.ToString()
		})
	.Dump();

// Question 2
ClubMembers
	.Where(x => x.Active == true &&
			x.Role.Description != "Member")
	.OrderBy( x => x.Club.ClubName)
	.ThenBy(x => x.Role.Description)
	.ThenBy(x => x.Student.LastName)
	.Select (x => new
		{
			StudentNumber = x.StudentNumber,
			Role = x.Role.Description,
			FirstName = x.Student.FirstName,
			LastName = x.Student.LastName,
			ClubName = x.Club.ClubName
		})
	.Dump();