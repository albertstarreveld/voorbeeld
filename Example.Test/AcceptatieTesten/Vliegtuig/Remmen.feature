Feature: Remmen vliegtuig
	Als inzittende
	Wil ik dat het voertuig kan remmen
	Zodat we geen botsing kunnen krijgen

Scenario: Stilstaand remmen
	Given het vliegtuig staat stil
	When er wordt geremd
	Then blijft de snelheid gelijk

Scenario: Rijdend remmen
	Given het vliegtuig vliegt
	When er wordt geremd
	Then neemt de snelheid af
