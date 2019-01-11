Feature: Sturen auto
	Als bestuurder 
	Wil ik kunnen sturen
	Zodat ik de bestemming kan berijken

Scenario: Naar het noorden sturen
	Given de auto rijdt
	When er naar het noorden wordt gestuurd
	Then rijdt de auto in noordelijke richting

Scenario: Naar het oosten sturen
	Given de auto rijdt
	When er naar het oosten wordt gestuurd
	Then rijdt de auto in oostelijke richting

Scenario: Naar het zuiden sturen
	Given de auto rijdt
	When er naar het zuiden wordt gestuurd
	Then rijdt de auto in zuidelijke richting

Scenario: Naar het westen sturen
	Given de auto rijdt
	When er naar het westen wordt gestuurd
	Then rijdt de auto in westelijke richting
