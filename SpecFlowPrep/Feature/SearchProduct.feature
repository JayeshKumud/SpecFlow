Feature: Search Product
	In order to go through Products details
	As registered User
	I want to be able to search product

Background: 
	Given User logged in with below credential:
		| username               | password   |
		| jayesh.kumud@gmail.com | 9320419345 |
	Then User 'username' displayes on home page

@Smoke
Scenario: Search valid product
	Given User search for '<product>' on home page
	And List of valid '<product>' displays on home page
	When I see flight records display
	Then all the records display have '<Class>'