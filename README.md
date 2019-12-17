# OnBoard
###
Groep J7 - De Bleecker Bram, De Bruycker Johanna, De Smet Jonah
###

Als je wilt aanmelden als een passagier gebruik je het SeatNr, voor een crewmember is het CrewmemberNr

Passagiers
De Bruycker Johanna - SeatNr: 2 - Group: 2
De Smet Jonah - SeatNr: 1 - Group: 2
De bleecker Bram - SeatNr: 3 - Group: 2
De Bakker Helena - SeatNr: 4 - Group: 1
De Bakker Kurt - SeatNr: 5 - Group: 1
De Bakker Astrid - SeatNr: 6 - Group: 1

Crewmembers
Garcia Maria - CrewmemberNr: 1234
De Visser Bart - CrewmemberNr: 1111


Sommige gebruikers hebben orders (in dataInit).

Een Flight is opgebouwd uit Seats, waarop Passengers zitten. We hebben ervoor gekozen om een crewmember
geen Seat te geven, aangezien deze, bij ons weten, niet bij de gewone passagiers zitten bij echte vluchten.

Verder is de UWP app opgebouwd met sommige viewmodels die geset worden als een singleton, zo is het mogelijk
om voor verschillende views hetzelfde viewmodel te gebruiken. Dit bracht met zich mee dat afmelden vanzelfsprekend lukte,
aangezien de instance van een singleton niet kan hermaakt worden. We hebben hiervoor een logout() methode in App.cs
voorzien die de properties van de singleton's reset.

De app maakt gebruik van 3 externe API's. Deezer voor het ophalen van muziek, Omdbapi voor het ophalen van filminformatie en
tenslotte AccuWeather voor het ophalen van het weer. Voor geen van de API's is een bepaalde beweegreden, deze leken ons
het makkelijkste te implementeren en waren ook gratis. Let wel dat de weer API maar 30 calls per dag kan realiseren.

Het maken van de app werd mogelijk gemaakt door alle 3 de groepsleden, waarbij er geen moeilijkheden ondervonden werden.
