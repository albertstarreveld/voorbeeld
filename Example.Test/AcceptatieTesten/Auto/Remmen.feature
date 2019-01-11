Feature: Remmen auto
	Als inzittende
	Wil ik dat het voertuig kan remmen
	Zodat we geen botsing kunnen krijgen

Scenario: Stilstaand remmen
	Given de auto staat stil
	When er wordt geremd
	Then blijft de snelheid gelijk

Scenario: Rijdend remmen
	Given de auto rijdt
	When er wordt geremd
	Then neemt de snelheid af
