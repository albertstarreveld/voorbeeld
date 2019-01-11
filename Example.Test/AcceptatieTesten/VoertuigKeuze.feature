Feature: VoertuigFactory
	Als reiziger
	Wil ik dat het juiste voertuig voor mij gekozen wordt
	Zodat ik niet onnodig lang over de reis doe

Scenario: Voertuigkeuze bij korte reis
	Given een afstand van maximaal 500km
	When de voertuigkeuze gemaakt wordt
	Then wordt er voor de auto gekozen

Scenario: Voertuigkeuze bij lange reis
	Given een afstand van minimaal 501km
	When de voertuigkeuze gemaakt wordt
	Then wordt er voor het vliegtuig gekozen
