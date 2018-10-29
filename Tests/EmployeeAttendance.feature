Feature: Employee Attendance
	In order to track employee attendance
	As HR Manager
	I want to be able to create employee attendance record

@mytag
Scenario: Create Attendance record
	Given I open Orange website
	And I login with credentials
	| Username | Password |
	| Admin    | admin123 |
	And I navigate to Employee Records page via menu
	When I search today attendance for John Smith
	Then I verify number of attendance(s) in table is 0
	When I create new attendance
	Then Attendance data should be present in table
