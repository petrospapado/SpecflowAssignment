Feature: ParaBank registration

@smoke @registration
Scenario: User registers to ParaBank
    Given the user is on ParaBank registration page
    When user successfully registers to ParaBank with <username> and <password> <confirmpassword>
    And user clicks Register
    Then user should see welcome message of <username>

    Examples: 
      | username | password | confirmpassword |
      | test799  | 1234qwer | 1234qwer        |
      
@registration
Scenario: User cannot registers to ParaBank with wrong password
    Given the user is on ParaBank registration page
    When user successfully registers to ParaBank with <username> and <password> <confirmpassword>
    And user clicks Register
    Then user should get registration error message

    Examples: 
      | username | password | confirmpassword |
      | test     | 1234     | 12345           |