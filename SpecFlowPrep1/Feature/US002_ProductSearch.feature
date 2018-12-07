Feature: US002_ProductSearch
	In order to explore product
	As registered user
	I want to be able to search product


Background: 
	Given User logged in with credential on login page:
		| username               | password   |
		| jayesh.kumud@gmail.com | 9320419345 |
	And User 'jayesh.kumud@gmail.com' display on user home page

Scenario Outline: US002_AC01_AC02 : Search product for valid and invalid entry
	Given User entered '<product>' as product on home page
	When User selects 'Search' button on home page
	Then Product search '<product>' page displays
	And Product '<message> display on product search page
Examples: 
	| product    | message            |
	| mobile     | mobile             |
	| aaaaaaaaaa | No results display |
