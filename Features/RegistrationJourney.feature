Feature: Registration Journey


@mytag
Scenario: About Us
Given User is on Liaisongroup page
And I Click on ABOUT US Button
Then I Navigate to Search Result for About Us Page
And User Enter INSIGHTS in the Search Tab
And Click on Submit Button
Then Search Results Page is Displayed

Scenario: Register Event
Given User is on Liaisongroup page
And I Click on Register Button
Then I Navigate to Liaison Group and HFMA Electric Car Track Day Page
When I should Click on MORE DETAILS Button
Then I Naviagate to Liaison Group and HFMA Electric Car Track Day and Register your interest Page
And User Register interest to attend this event with Data and Submit
Then Thank you for your submission.is Displayed

Scenario: Dropdown
Given User is on Liaisongroup page
And I Click On integrated care systems Dropdown
And I Click on ICS Regions
Then I ensure ICS Regions Page is Displayed
