Feature: Startonderbreking vliegtuig
	Als maatschappij
	Willen we dat een vliegtuig alleen start als er een piloot en een copiloot in zit
	Zodat de kans op ongelukken kleiner wordt

Scenario: Vliegtuig zonder piloot start niet
	Given het vliegtuig staat stil
	When het vliegtuig wordt gestart
	Then lukt het niet om het vliegtuig te starten

Scenario: Vliegtuig zonder copiloot start niet
	Given het vliegtuig staat stil
	And de piloot is ingestapt
	When het vliegtuig wordt gestart
	Then lukt het niet om het vliegtuig te starten

Scenario: Vliegtuig met piloot en copiloot start
	Given het vliegtuig staat stil
	And de piloot is ingestapt
	And de copiloot is ingestapt
	When het vliegtuig wordt gestart
	Then gaat het vliegtuig aan
