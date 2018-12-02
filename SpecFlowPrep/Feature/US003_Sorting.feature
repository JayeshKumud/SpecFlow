Feature: US_002 Sorting
	In order to search better
	As registered user
	I want to be able to sort product list 

Background: 
	Given User logged in with below credential:
		| username               | password   |
		| jayesh.kumud@gmail.com | 9320419345 |
	Then User 'jayesh.kumud@gmail.com' displayes on home page

Scenario Outline: US003_AC01 : Sort the available products via price
	Given User search for '<product>' on home page
	And '<product>' displayes on product search page
	When I press add
	Then the result should be 120 on the screen
Examples: 
	| product |
	| mobile  |
