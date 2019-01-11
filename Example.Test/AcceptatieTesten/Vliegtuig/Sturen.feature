Feature: Sturen vliegtuig
	Als bestuurder 
	Wil ik kunnen sturen
	Zodat ik de bestemming kan berijken

Scenario: Naar het noorden sturen
	Given het vliegtuig vliegt
	When er naar het noorden wordt gestuurd
	Then vliegt het vliegtuig in noordelijke richting

Scenario: Naar het oosten sturen
	Given het vliegtuig vliegt
	When er naar het oosten wordt gestuurd
	Then vliegt het vliegtuig in oostelijke richting

Scenario: Naar het zuiden sturen
	Given het vliegtuig vliegt
	When er naar het zuiden wordt gestuurd
	Then vliegt het vliegtuig in zuidelijke richting

Scenario: Naar het westen sturen
	Given het vliegtuig vliegt
	When er naar het westen wordt gestuurd
	Then vliegt het vliegtuig in westelijke richting
