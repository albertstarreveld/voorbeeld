Feature: Startonderbreking auto
	Als maatschappij
	Willen we dat een auto alleen start als er een bestuurder in zit
	Zodat de kans op ongelukken kleiner wordt

Scenario: Auto zonder bestuurder start niet
	Given de auto staat stil
	When de auto wordt gestart
	Then lukt het niet om de auto te starten

Scenario: Auto met bestuurder start
	Given de auto staat stil
	And de bestuurder is ingestapt
	When de auto wordt gestart
	Then gaat de auto aan
