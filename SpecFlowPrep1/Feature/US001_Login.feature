Feature: US001_Login
	In order to access product details
	As registered user
	I want to be able to login

Scenario: US001_AC01 : Login with valid credential
	Given User landed on 'Login' page
	And User enter below credential on login page:
		| username               | password   |
		| jayesh.kumud@gmail.com | 93204193452 |
	When User selects 'Login' button on login page
	Then User 'jayesh.kumud@gmail.com' displays on user home page
