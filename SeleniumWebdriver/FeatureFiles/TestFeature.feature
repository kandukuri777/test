Feature: Navigate through the Labcorp website and apply for a QA position

Background: Pre-Condition
	# Given Stpe
	Given User is at Home Page

Scenario: Search for QA position and Apply
	When I find carrers and click on the link
	Then User should be at careers page
	When I provide the job name  and click on Login button
	Then User Should be at job details page
	When I click on Apply Now button
	Then User Should be at job requriements page
	And click on Submit button
	When I click on Return to job Search button
	Then User should be at careers page