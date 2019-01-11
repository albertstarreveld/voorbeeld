Feature: Accelereren vliegtuig
	Als bestuurder
	Wil ik kunnen accelereren
	Zodat ik vooruit kom

Scenario: Accelereren vanuit stilstand
	Given het vliegtuig staat stil
	When er wordt geaccellereerd
	Then neemt de snelheid toe

Scenario: Rijdend accelereren
	Given het vliegtuig vliegt
	When er wordt geaccellereerd
	Then neemt de snelheid toe

Scenario: Accelereren als de maximumsnelheid reeds berijkt is
	Given het vliegtuig vliegt de maximale snelheid
	When er wordt geaccellereerd
	Then blijft de snelheid gelijk