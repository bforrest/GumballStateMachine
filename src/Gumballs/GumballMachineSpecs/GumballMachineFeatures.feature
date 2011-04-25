Feature: Sell Gumballs
	In order to make a million dollars selling gumballs
	As a machine owner
	I want to collect a coin per gumball

@mytag
Scenario: Accept token
	Given I have a gumball machine
	And it has an empty coin slot
	When I insert a coin
	Then the machine should transition to "waiting for crank turn"
