﻿Feature: Digest Authentication Form
	As a user,
	I want to be able to authenticate my credentials,
	so that I can access the Digest Authentication page.

@ignore
Scenario: Cancelling the login popup cancels authentication
    Given the user is on the Digest Authentication form with no credentials
	When the user clicks the cancel button on the popup
	Then the page header text should inform the user that their credentials could not be authenticated ""

Scenario: Logging in with valid credentials redirects user to the Digest Authentication page
    Given the user is on the Digest Authentication form with valid credentials
    Then the page header text should inform the user that their credentials have successfully been authenticated "Digest Auth"

Scenario: Successful authenticatation session persists within window browser
    Given the user is on the Digest Authentication form with valid credentials
    When the user opens a new tab and closes their previous tab
    And the user navigates to the Digest Authentication form with no credentials
    Then the page header text should inform the user that their credentials have successfully been authenticated "Digest Auth"
