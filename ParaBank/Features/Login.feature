Feature: ParaBank Login

@smoke @login
Scenario: User logins with valid credentials
	Given the user is on ParaBank homepage
	And user types username <username>
	And user types password <password>
	And user clicks Login
	Then user should see the Log Out link

	Examples: 
		| username        | password  |
		| eldetest        | 1234      |
		| testtest        | 1234qwer  |

@login
Scenario: User logins with invalid credentials
	Given the user is on ParaBank homepage
	And user types username <username>
	And user types password <password>
	And user clicks Login
	Then user should get an error message

	Examples: 
		| username | password  |
		| test1234 | 1235      |