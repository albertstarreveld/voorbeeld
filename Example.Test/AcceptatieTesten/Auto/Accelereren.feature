Feature: Accelereren auto
	Als bestuurder
	Wil ik kunnen accelereren
	Zodat ik vooruit kom

Scenario: Accelereren vanuit stilstand
	Given de auto staat stil
	When er wordt geaccellereerd
	Then neemt de snelheid toe

Scenario: Rijdend accelereren
	Given de auto rijdt
	When er wordt geaccellereerd
	Then neemt de snelheid toe

Scenario: Accelereren als de maximumsnelheid reeds berijkt is
	Given de auto rijdt de maximale snelheid
	When er wordt geaccellereerd
	Then blijft de snelheid gelijk