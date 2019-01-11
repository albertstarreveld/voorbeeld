Feature: Besturen
	Als passagier
	Wil ik dat de bestuurder de richting kan bepalen
	Zodat hij ons naar de bestemming kan brengen
	
Scenario: Bestemming in het noord-westen
	Given de bestemming is in het noord-westen
	And de bestuurder is in het zuid-oosten
	When de bestuurder stuurt
	Then stuurt hij naar het noorden

Scenario: Bestemming in het zuid-oosten
	Given de bestemming is in het zuid-oosten
	And de bestuurder is in het noord-westen
	When de bestuurder stuurt
	Then stuurt hij naar het zuiden

Scenario: Bestemming in het noorden
	Given de bestemming is in het noorden
	And de bestuurder is in het zuiden
	When de bestuurder stuurt
	Then stuurt hij naar het noorden 

Scenario: Bestemming in het zuiden
	Given de bestemming is in het zuiden
	And de bestuurder is in het noorden
	When de bestuurder stuurt
	Then stuurt hij naar het zuiden 
	
Scenario: Bestemming in het oosten
	Given de bestemming is in het oosten
	And de bestuurder is in het westen
	When de bestuurder stuurt
	Then stuurt hij naar het oosten
	
Scenario: Bestemming in het westen
	Given de bestemming is in het westen
	And de bestuurder is in het oosten
	When de bestuurder stuurt
	Then stuurt hij naar het westen
	