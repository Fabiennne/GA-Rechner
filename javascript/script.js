var personenContainer = document.getElementById("personen");
var pendelnContainer = document.getElementById("pendeln");
var reisenContainer = document.getElementById("reisen");

// "static" keyword in java?
var personCount = 0;
var pendelnCount = 0;
var reisenCount = 0;

// "final" keyword in java?
var gaErwachsenKl1 = 6520; //zwischen 26 und 64
var gaErwachsenKl2 = 3995;
var gaKindKl1 = 2850; //zwischen 6 und 16
var gaKindKl2 = 1720;
var gaJugendKl1 = 4450; //zwischen 16 und 25
var gaJugendKl2 = 2780;
var ga25Kl1 = 5670; //genau 25-jährig
var ga25Kl2 = 3495;
var gaSeniorKl1 = 4950; //eigentlich für Frauen ab 64 und Männer ab 65 aber hier wird mit "ab 65 gerechnet"
var gaSeniorKl2 = 3040;
var gaBehinderungKl1 = 4120;
var gaBehinderungKl2 = 2600;
var gaDuoKl1 = 4450;
var gaDuoKl2 = 2860;

function addPersonInputs() {
    personCount++;

    const personClass = "person" + personCount;
    const nameName = personClass + "-name";
    const geburiName = personClass + "-geburtstag";
    const strasseName = personClass + "-strasse";
    const ortName = personClass + "-ort";

    const container = document.createElement("div");
    const nameLabel = document.createElement("label");
    const nameText = document.createTextNode("Name: ");
    const nameInput = document.createElement("input");
    const geburiLabel = document.createElement("label");
    const geburiText = document.createTextNode("Geburtstag: ");
    const geburiInput = document.createElement("input");
    const strasseLabel = document.createElement("label");
    const strasseText = document.createTextNode("Strasse: ");
    const strasseInput = document.createElement("input");
    const ortLabel = document.createElement("label");
    const ortText = document.createTextNode("PLZ Ort: ");
    const ortInput = document.createElement("input");

    nameLabel.appendChild(nameText);
    geburiLabel.appendChild(geburiText);
    strasseLabel.appendChild(strasseText);
    ortLabel.appendChild(ortText);

    container.classList.add("person");
    container.classList.add(personClass);

    nameLabel.setAttribute("for", nameName);
    nameInput.setAttribute("type", "text");
    nameInput.setAttribute("name", nameName);
    nameInput.setAttribute("id", nameName);
    geburiLabel.setAttribute("for", geburiName);
    geburiInput.setAttribute("type", "date");
    geburiInput.setAttribute("name", geburiName);
    geburiInput.setAttribute("id", geburiName);
    strasseLabel.setAttribute("for", strasseName);
    strasseInput.setAttribute("type", "text");
    strasseInput.setAttribute("name", strasseName);
    strasseInput.setAttribute("id", strasseName);
    ortLabel.setAttribute("for", ortName);
    ortInput.setAttribute("type", "text");
    ortInput.setAttribute("name", ortName);
    ortInput.setAttribute("id", ortName);

    personenContainer.appendChild(container);
    container.appendChild(nameLabel);
    container.appendChild(nameInput);
    container.appendChild(geburiLabel);
    container.appendChild(geburiInput);
    container.appendChild(strasseLabel);
    container.appendChild(strasseInput);
    container.appendChild(ortLabel);
    container.appendChild(ortInput);
}

function addPendelnInputs() {
    pendelnCount++;

    const pendelnClass = "pendeln" + pendelnCount;
    const startName = pendelnClass + "-start";
    const zielName = pendelnClass + "-ziel";
    const preisProFahrtName = pendelnClass + "-preisProFahrt";
    const tageProWocheName = pendelnClass + "-tageProWoche";
    const fahrtenProTagName = pendelnClass + "-fahrtenProTag";
    const klasseName = pendelnClass + "-klasse";
    const klasse1Name = pendelnClass + "-klasse1";
    const klasse2Name = pendelnClass + "-klasse2";

    const container = document.createElement("div");
    const startLabel = document.createElement("label");
    const startText = document.createTextNode("Start: ");
    const startInput = document.createElement("input");
    const zielLabel = document.createElement("label");
    const zielText = document.createTextNode("Ziel: ");
    const zielInput = document.createElement("input");
    const preisProFahrtLabel = document.createElement("label");
    const preisProFahrtText = document.createTextNode("Preis pro Fahrt: ");
    const preisProFahrtInput = document.createElement("input");
    const tageProWocheLabel = document.createElement("label");
    const tageProWocheText = document.createTextNode("Tage pro Woche: ");
    const tageProWocheInput = document.createElement("input");
    const fahrtenProTagLabel = document.createElement("label");
    const fahrtenProTagText = document.createTextNode("Fahrten pro Tag: ");
    const fahrtenProTagInput = document.createElement("input");
    const klasse1Input = document.createElement("input");
    const klasse1Label = document.createElement("label");
    const klasse1Text = document.createTextNode("1.Klasse");
    const klasse2Input = document.createElement("input");
    const klasse2Label = document.createElement("label");
    const klasse2Text = document.createTextNode("2.Klasse");

    startLabel.appendChild(startText);
    zielLabel.appendChild(zielText);
    preisProFahrtLabel.appendChild(preisProFahrtText);
    tageProWocheLabel.appendChild(tageProWocheText);
    fahrtenProTagLabel.appendChild(fahrtenProTagText);
    klasse1Label.appendChild(klasse1Text);
    klasse2Label.appendChild(klasse2Text);

    container.classList.add("pendel");
    container.classList.add(pendelnClass);

    startLabel.setAttribute("for", startName);
    startInput.setAttribute("type", "text");
    startInput.setAttribute("name", startName);
    startInput.setAttribute("id", startName);
    zielLabel.setAttribute("for", zielName);
    zielInput.setAttribute("type", "text");
    zielInput.setAttribute("name", zielName);
    zielInput.setAttribute("id", zielName);
    preisProFahrtLabel.setAttribute("for", preisProFahrtName);
    preisProFahrtInput.setAttribute("type", "number");
    preisProFahrtInput.setAttribute("name", preisProFahrtName);
    preisProFahrtInput.setAttribute("id", preisProFahrtName);
    tageProWocheLabel.setAttribute("for", tageProWocheName);
    tageProWocheInput.setAttribute("type", "number");
    tageProWocheInput.setAttribute("name", tageProWocheName);
    tageProWocheInput.setAttribute("id", tageProWocheName);
    fahrtenProTagLabel.setAttribute("for", fahrtenProTagName);
    fahrtenProTagInput.setAttribute("type", "number");
    fahrtenProTagInput.setAttribute("name", fahrtenProTagName);
    fahrtenProTagInput.setAttribute("id", fahrtenProTagName);
    klasse1Label.setAttribute("for", klasse1Name);
    klasse1Input.setAttribute("type", "radio");
    klasse1Input.setAttribute("name", klasseName);
    klasse1Input.setAttribute("id", klasse1Name);
    klasse1Input.setAttribute("value", klasse1Name);
    klasse1Input.checked = false;
    klasse2Label.setAttribute("for", klasse2Name);
    klasse2Input.setAttribute("type", "radio");
    klasse2Input.setAttribute("name", klasseName);
    klasse2Input.setAttribute("id", klasse2Name);
    klasse2Input.setAttribute("value", klasse2Name);
    klasse2Input.checked = true;

    pendelnContainer.appendChild(container);
    container.appendChild(startLabel);
    container.appendChild(startInput);
    container.appendChild(zielLabel);
    container.appendChild(zielInput);
    container.appendChild(preisProFahrtLabel);
    container.appendChild(preisProFahrtInput);
    container.appendChild(tageProWocheLabel);
    container.appendChild(tageProWocheInput);
    container.appendChild(fahrtenProTagLabel);
    container.appendChild(fahrtenProTagInput);
    container.appendChild(klasse1Input);
    container.appendChild(klasse1Label);
    container.appendChild(klasse2Input);
    container.appendChild(klasse2Label);
}

function addReiseInputs() {
    reisenCount++;

    const reiseClass = "reise" + reisenCount;
    const startName = reiseClass + "-start";
    const zielName = reiseClass + "-ziel";
    const preisProFahrtName = reiseClass + "-preisProFahrt";
    const ticketArtName = reiseClass + "-ticketArt";
    const ticketArtEinfachName = reiseClass + "-ticketArt-einfach";
    const ticketArtRetourName = reiseClass + "-ticketArt-retour";
    const klasseName = reiseClass + "-klasse";
    const klasse1Name = reiseClass + "-klasse1";
    const klasse2Name = reiseClass + "-klasse2";

    const container = document.createElement("div");
    const startLabel = document.createElement("label");
    const startText = document.createTextNode("Start: ");
    const startInput = document.createElement("input");
    const zielLabel = document.createElement("label");
    const zielText = document.createTextNode("Ziel: ");
    const zielInput = document.createElement("input");
    const preisProFahrtLabel = document.createElement("label");
    const preisProFahrtText = document.createTextNode("Preis pro Fahrt: ");
    const preisProFahrtInput = document.createElement("input");
    const ticketArtEinfachInput = document.createElement("input");
    const ticketArtEinfachLabel = document.createElement("label");
    const ticketArtEinfachText = document.createTextNode("Einfach");
    const ticketArtRetourInput = document.createElement("input");
    const ticketArtRetourLabel = document.createElement("label");
    const ticketArtRetourText = document.createTextNode("Retour");
    const klasse1Input = document.createElement("input");
    const klasse1Label = document.createElement("label");
    const klasse1Text = document.createTextNode("1.Klasse");
    const klasse2Input = document.createElement("input");
    const klasse2Label = document.createElement("label");
    const klasse2Text = document.createTextNode("2.Klasse");

    startLabel.appendChild(startText);
    zielLabel.appendChild(zielText);
    preisProFahrtLabel.appendChild(preisProFahrtText);
    ticketArtEinfachLabel.appendChild(ticketArtEinfachText);
    ticketArtRetourLabel.appendChild(ticketArtRetourText);
    klasse1Label.appendChild(klasse1Text);
    klasse2Label.appendChild(klasse2Text);

    container.classList.add("reise");
    container.classList.add(reiseClass);

    startLabel.setAttribute("for", startName);
    startInput.setAttribute("type", "text");
    startInput.setAttribute("name", startName);
    startInput.setAttribute("id", startName);
    zielLabel.setAttribute("for", zielName);
    zielInput.setAttribute("type", "text");
    zielInput.setAttribute("name", zielName);
    zielInput.setAttribute("id", zielName);
    preisProFahrtLabel.setAttribute("for", preisProFahrtName);
    preisProFahrtInput.setAttribute("type", "number");
    preisProFahrtInput.setAttribute("name", preisProFahrtName);
    preisProFahrtInput.setAttribute("id", preisProFahrtName);
    ticketArtEinfachLabel.setAttribute("for", ticketArtEinfachName);
    ticketArtEinfachInput.setAttribute("type", "radio");
    ticketArtEinfachInput.setAttribute("name", ticketArtName);
    ticketArtEinfachInput.setAttribute("id", ticketArtEinfachName);
    ticketArtEinfachInput.setAttribute("value", ticketArtEinfachName);
    ticketArtEinfachInput.checked = true;
    ticketArtRetourLabel.setAttribute("for", ticketArtRetourName);
    ticketArtRetourInput.setAttribute("type", "radio");
    ticketArtRetourInput.setAttribute("name", ticketArtName);
    ticketArtRetourInput.setAttribute("id", ticketArtRetourName);
    ticketArtRetourInput.setAttribute("value", ticketArtRetourName);
    ticketArtRetourInput.checked = false;
    klasse1Label.setAttribute("for", klasse1Name);
    klasse1Input.setAttribute("type", "radio");
    klasse1Input.setAttribute("name", klasseName);
    klasse1Input.setAttribute("id", klasse1Name);
    klasse1Input.setAttribute("value", klasse1Name);
    klasse1Input.checked = false;
    klasse2Label.setAttribute("for", klasse2Name);
    klasse2Input.setAttribute("type", "radio");
    klasse2Input.setAttribute("name", klasseName);
    klasse2Input.setAttribute("id", klasse2Name);
    klasse2Input.setAttribute("value", klasse2Name);
    klasse2Input.checked = true;

    reisenContainer.appendChild(container);
    container.appendChild(startLabel);
    container.appendChild(startInput);
    container.appendChild(zielLabel);
    container.appendChild(zielInput);
    container.appendChild(preisProFahrtLabel);
    container.appendChild(preisProFahrtInput);
    container.appendChild(ticketArtEinfachInput);
    container.appendChild(ticketArtEinfachLabel);
    container.appendChild(ticketArtRetourInput);
    container.appendChild(ticketArtRetourLabel);
    container.appendChild(klasse1Input);
    container.appendChild(klasse1Label);
    container.appendChild(klasse2Input);
    container.appendChild(klasse2Label);
}

function calculateCosts() {
    alert("calculating...");
    //https://stackoverflow.com/questions/3547035/getting-html-form-values
    //https://codepen.io/kevinfarrugia/pen/Wommgd?editors=1011
}
