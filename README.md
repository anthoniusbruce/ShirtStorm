# ShirtStorm
Shirt storm is a Blazor Server SPA that is intended to be a subscription store for tee-shirts. This app runs on Azure. This document will attempt to keep up with steps taken to support he app on Azure.
## Azure Active Directory B2C Steps
Follow steps at https://blazorhelpwebsite.com/ViewBlogPost/55
## Add key for appsettings encryption/decryption
1. Resource groups, **Create** shirt\_storm
1. Key vaults
	1. **Create key vault**
	1. Resource group shirt\_storm
	1. Key vault name shirt-storm-vault
	1. **Review and create**
1. Key vaults, shirt-storm-vault
	1. Access configuration
	1. Go to Access contrl (IAM)
		1. Add role assignment
			1. Add Key Vault Secrets Officer
	1. Objects, Secrets, **Generate/Import**
		1. Name appsettingscipher
		1. Add value for appsettings cipher
## Appsettings Steps
1. Decrypt appsettings.json
1. Fill in "AzureAdB2C" section from values in Azure at **Azure AD B2C|App registrations**
1. Encrypt appsettings.json
## Program.cs Step
1. Replace value of **kvUri** with Azure Key vaults, shirt-storm-vault, **Vault URI**