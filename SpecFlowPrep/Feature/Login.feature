Feature: Login
	In explore products
	As registered user
	I want to be able to login

@somke
Scenario: Login with valid credential
	Given User enter below credential on login page:
		| username               | password   |
		| jayesh.kumud@gmail.com | 9320419345 |
	When User selects 'Login' button on login page
	Then User 'username' displayes on home page
