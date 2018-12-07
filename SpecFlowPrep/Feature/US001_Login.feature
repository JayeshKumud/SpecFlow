Feature: US001 Login
	In order to explore products
	As registered user
	I want to be able to login

@somke
Scenario: US001_AC01 : Login with valid credential
	Given User enter below credential on login page:
		| username               | password   |
		| jayesh.kumud@gmail.com | 9320419345 |
	When User select 'Login' button on login page
	Then User 'jayesh.kumud@gmail.com' displayes on home page
