# GA-Rechner

*[English Version down below](#ga-calculator)*

Dieses Tool berechnet, ob sich für bestimmte Pendlerstrecken und Reisen, die während eines Jahres in der Schweiz zurückgelegt werden, der Kauf eines Generalabonnements (GA), eines Halbtax-Abos oder eines Halbtax PLUS lohnt, oder ob der Kauf von Einzeltickets günstiger ist. Andere Angebote wie zum Beispiel Streckenabos werden hier nicht berücksichtigt.  
Es wurde ursprünglich für meinen persönlichen Gebrauch entwickelt, kann aber auch von anderen genutzt oder angepasst werden.

## Voraussetzungen
- Git installiert
- IDE installiert (Ich nutze Visual Studio 2022)
- .NET installiert

## Nutzung
1. Repository klonen oder herunterladen
2. Eigene Beispielrechnungen im Code anpassen (z. B. Anzahl Fahrten, Ticketpreis)
3. Code laufen lassen - die Resultate werden in der Konsole ausgegeben

Es werden keine Daten gespeichert oder an Dritte übertragen. Alle Berechnungen laufen lokal.  
Bei Fragen bitte bei [FAQ](/documentation/faq.md) und [help](/documentation/help.md) nachsehen.

## Preisangaben
- Die Preise für GA, Halbtax und Halbtax PLUS wurden **manuell** von der offiziellen Webseite der SBB übernommen (Stand: 11. August 2025).  
- Der Ticketpreis für einzelne Fahrten und Pendelstrecken wird **vom Benutzer selbst eingegeben**. Dieser ist verantwortlich für die Richtigkeit der eigenen Eingaben

**Wichtig:** Tarife und Konditionen können sich jederzeit ändern. Bitte überprüfe die aktuellen Preise immer direkt beim offiziellen Anbieter (z. B. [sbb.ch](https://www.sbb.ch)).

## Haftungsausschluss
Die Ergebnisse dieses Rechners dienen **nur als Orientierung**.  
Es wird keine Garantie für Vollständigkeit, Richtigkeit oder Aktualität der Berechnungen übernommen.  

Die Nutzung erfolgt **auf eigenes Risiko**.  
Dieses Projekt steht in **keiner Verbindung** zu den SBB oder anderen Transportunternehmen. Alle genannten Markennamen gehören den jeweiligen Rechteinhabern.

## Lizenz
Dieses Projekt steht unter der [MIT-Lizenz](./LICENSE).  
Das bedeutet: du darfst den Code frei verwenden, kopieren, verändern und weitergeben – allerdings **ohne jegliche Gewährleistung**.


# GA-Calculator

*[Zurück zur Deutschen Version](#ga-rechner)*

This tool helps to calculate whether, for a given travel pattern, it is more cost-effective to purchase a Swiss Travelcard such as a Generalabonnement (GA), a Half Fare Card (Halbtax) or a Halbtax PLUS or if simply buying the tickets would be cheaper. Other offers, such as a subscription for a specific route, won't be considered here.  
It was originally created for personal use but can also be used or adapted by others.

## Prerequisites
- Git installed
- IDE installed (I am using Visual Studio 2022)
- .NET installed

## Usage
1. Clone or download the repository
2. Adjust the example calculations in the code (e.g., number of trips, ticket price)
3. Run the code – the results will be displayed in the console

No data is stored or transmitted. All calculations run locally.  
If you have questions, please consult [FAQ](/documentation/faq.md) and [help](/documentation/help.md).

## Price Information
- Prices for GA, Halbtax, and Halbtax PLUS were entered **manually** based on the official SBB website (as of: 11. August 2025).  
- Ticket prices for individual journeys must be **entered manually by the user**. Users are responsible for entering their correct prices.

**Important:** Fares and conditions may change at any time. Please always check the official source (e.g., [sbb.ch](https://www.sbb.ch)) for the most up-to-date prices.

## Disclaimer
The results of this calculator are intended for **informational purposes only**.  
No guarantee is given for the completeness, accuracy, or timeliness of the calculations.  

Use at your own risk.  
This project is **not affiliated with** SBB or any other transport providers. All mentioned trademarks are the property of their respective owners.

## License
This project is licensed under the [MIT License](./LICENSE).  
This means you are free to use, copy, modify, and distribute the code – but **without any warranty**.


-------------------------------------------

TODO:
- methoden dokumentieren (mit '///', https://dev.to/ravivis13370227/comprehensive-guide-to-documentation-comments-in-c-379d)
- README.md ausformulieren (wie installieren, wie richtig verwenden)
- Testing
