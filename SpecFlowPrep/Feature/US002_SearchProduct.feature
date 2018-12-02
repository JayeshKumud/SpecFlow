Feature: US_003 Search Product
	In order to go through Products details
	As registered User
	I want to be able to search product

Background: 
	Given User logged in with below credential:
		| username               | password   |
		| jayesh.kumud@gmail.com | 9320419345 |
	Then User 'jayesh.kumud@gmail.com' displayes on home page


Scenario Outline: Product search pages displays for valid and invalid product
	Given User enter '<product>' on home page
	When I select 'Search' button on home page
	Then Product search page displays for '<product>'
	And  '<product>' displays on product search page
Examples: 
	| product | message |
	|         |         |

