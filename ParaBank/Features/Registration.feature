Feature: ParaBank registration

#    Background:
#        Given the user is on ParaBank registration page

    Scenario: User registers to ParaBank
        Given the user is on ParaBank registration page
        When user successfully registers to ParaBank with <username> and <password>
#        Then user should see the Log Out link
        Then user should see welcome message of <username>

    Examples: 
      | username        | password  |
      | test789         | 1234qwer  |