Feature: ParaBank Login

Background:
Given the user is on ParaBank homepage

Scenario: User logins with valid credentials
	And user types username <username>
	And user types password <password>
	When user clicks Login
	Then user should see the Log Out link


	Examples: 
		| username        | password  |
		| katy1234        | 1234      |
		| OldManChristmas | Ho!ho!ho! |


Scenario: User logins with invalid credentials
	And user types username <username>
	And user types password <password>
	When user clicks Login
	Then user should get an error message

	Examples: 
		| username | password  |
		| katy1234 | 1235      |
		| katy1235 | 1234      |