//$("button").on("click", function (evt) {
//    console.log(evt);
//    console.log(this);
    
//    vediEdizioniCorso(this.getAttribute("data-corso-id"));
//})


//document.querySelectorAll("button").forEach(function (element, indice) {
//    console.log(element);
//    console.log(indice);
//    element.addEventListener("click", function (evt) {
//        vediEdizioniCorso(this.getAttribute("data-corso-id"));
//    });

//});

//let buttons = document.querySelectorAll("button");

//for (let button of buttons) {
//    //console.log(button);
//    button.addEventListener("click", function (evt) {
//        vediEdizioniCorso(this.getAttribute("data-corso-id"));
//    });
//}

$("#tabCorsi").on("click", "button", function (evt) {
    vediEdizioniCorso(this.getAttribute("data-corso-id"));
}); // Funziona anche se all'inizio i bottoni non c'erano e verranno generati dinamicamente
// Basta che esista già la tabella, e ci registriamo sulla tabella
// Poi gli diciamo come secondo argomento la tag "button" in modo che l'evento scatti solo se il click è avvenuto su un <button>

//Senza jQuery non abbiamo l'overload comodo di cui sopra

//document.querySelector("#tabCorsi").addEventListener("click", function (evt) {
//    console.log(evt);
//    console.log(evt.target.tagName);
//    if (evt.target.tagName.toUpperCase() === "BUTTON") {
//        vediEdizioniCorso(evt.target.getAttribute("data-corso-id"));
//    }
//});

function togliGrassetti() {
    let daSgrassettare = document.getElementsByClassName("righeCorsi");
    for (let i = 0; i < daSgrassettare.length; i++) {
        daSgrassettare[i].removeAttribute("style");
    }
}

function mettiGrassetto(idCorso) { // si può anche usare parent due volte invece di riandare a beccare l'id
    let daGrassettare = document.getElementById("rigaCorso_" + idCorso);
    daGrassettare.setAttribute("style", "font-weight: bold;");
}

function vediEdizioniCorso(idCorso) {
    //alert(`vediEdizioniCorso(${idCorso});`);
    document.getElementById("details").removeAttribute("hidden");

    document.getElementById("idCorsoTitoloDetail").textContent = idCorso;

    togliGrassetti();
    mettiGrassetto(idCorso);

    let tagDaRiempire = document.getElementById("tabEdizioniCorso");
    let intestazioni = document.getElementById("intestazioniTabEdizioniCorso");
    $.ajax({
        type: 'GET',
        url: '/API/APIEdizioniCorsi/' + idCorso,
        dataType: 'json',
        success: function (datiJson) {
            console.log("success(datiJson);");

            tagDaRiempire.innerHTML = "";
            tagDaRiempire.appendChild(intestazioni);
            intestazioni.removeAttribute("hidden");

            if (datiJson.length > 0) {
                //alert(datiJson[0].dataInizio);
                console.log("datiJson.length > 0");



                for (let data of datiJson) {
                    console.log("LOOP: " + data.idEdizioneCorso);
                    let riga = document.createElement("tr");

                    let casellaIdEdizioneCorso = document.createElement("td");
                    riga.appendChild(casellaIdEdizioneCorso);
                    casellaIdEdizioneCorso.textContent = data.idEdizioneCorso;

                    let casellaDataInizio = document.createElement("td");
                    riga.appendChild(casellaDataInizio);
                    casellaDataInizio.textContent = data.dataInizio;

                    tagDaRiempire.appendChild(riga);
                }
            }
            else {
                tagDaRiempire.innerHTML = "";
                tagDaRiempire.appendChild(intestazioni);
                intestazioni.setAttribute("hidden", "hidden");

                let noEdizioni = document.createElement("p");
                noEdizioni.textContent = "Questo corso non ha ancora edizioni";
                noEdizioni.setAttribute("style", "color: red; font-style: italic;");
                // Per cambiare lo stile di un elemento del DOM, invece di dargli l'attributo style, è meglio cambiargli classe (SEMANTICA)
                // e poi gestire lo stile col CSS
                tagDaRiempire.appendChild(noEdizioni);
            }

        },
        error: function (ex) {
            alert(`ERROR CODE: ${ex.status}\nERROR TEXT: ${ex.statusText}`);
        }

    });
}