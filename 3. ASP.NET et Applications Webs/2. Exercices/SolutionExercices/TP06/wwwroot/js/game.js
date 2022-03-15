"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/game-Hub").build();

//Disable send button until connection is established
document.getElementById("strBtn").disabled = true;
document.getElementById("dexBtn").disabled = true;
document.getElementById("conBtn").disabled = true;
document.getElementById("intBtn").disabled = true;
document.getElementById("wisBtn").disabled = true;
document.getElementById("chaBtn").disabled = true;
document.getElementById("dice4Btn").disabled = true;
document.getElementById("dice6Btn").disabled = true;
document.getElementById("dice8Btn").disabled = true;
document.getElementById("dice10Btn").disabled = true;
document.getElementById("dice12Btn").disabled = true;
document.getElementById("dice20Btn").disabled = true;
document.getElementById("dice100Btn").disabled = true;
document.getElementById("attackTargetBtn").disabled = true;

connection.on("NewCharacteristicsRoll", function (characterName, charType, rollResult) {
    var li = document.createElement("li");
    document.getElementById("rollsList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.innerHTML = `<b>${characterName}</b> a effectué un jet de [<b>${charType}</b>] ! Résultat : <b>${rollResult}</b>`;
});

connection.on("NewNormalRoll", function (characterName, diceType, rollResult) {
    var li = document.createElement("li");
    document.getElementById("rollsList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.innerHTML = `<b>${characterName}</b> a effectué un lancé de dé [<b>D${diceType}</b>] ! Résultat : <b>${rollResult}</b>`;
});

connection.on("NewAttackRoll", function (characterName, target, hasTouched) {
    var li = document.createElement("li");
    document.getElementById("rollsList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.innerHTML = `<b>${characterName}</b> a effectué une attaque sur <b>${document.getElementById("targetSelect")[target].innerText.substring(0, document.getElementById("targetSelect")[target].innerText.length - 7)}</b> ! Résultat : <b>${(hasTouched ? "Touché" : "Echec")}</b>`;
});

connection.start().then(function () {
    document.getElementById("strBtn").disabled = false;
    document.getElementById("dexBtn").disabled = false;
    document.getElementById("conBtn").disabled = false;
    document.getElementById("intBtn").disabled = false;
    document.getElementById("wisBtn").disabled = false;
    document.getElementById("chaBtn").disabled = false;
    document.getElementById("dice4Btn").disabled = false;
    document.getElementById("dice6Btn").disabled = false;
    document.getElementById("dice8Btn").disabled = false;
    document.getElementById("dice10Btn").disabled = false;
    document.getElementById("dice12Btn").disabled = false;
    document.getElementById("dice20Btn").disabled = false;
    document.getElementById("dice100Btn").disabled = false;
    document.getElementById("attackTargetBtn").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("strBtn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var charType = "Force";
    var charValue = 10;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewCharacteristicRoll", characterName, charType, charValue, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dexBtn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var charType = "Dextérité";
    var charValue = 10;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewCharacteristicRoll", characterName, charType, charValue, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("conBtn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var charType = "Constitution";
    var charValue = 10;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewCharacteristicRoll", characterName, charType, charValue, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("intBtn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var charType = "Intelligence";
    var charValue = 10;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewCharacteristicRoll", characterName, charType, charValue, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("wisBtn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var charType = "Sagesse";
    var charValue = 10;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewCharacteristicRoll", characterName, charType, charValue, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("chaBtn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var charType = "Charisme";
    var charValue = 10;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewCharacteristicRoll", characterName, charType, charValue, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dice4Btn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 4;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewNormalRoll", characterName, diceType, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dice6Btn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 6;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewNormalRoll", characterName, diceType, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dice8Btn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 8;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewNormalRoll", characterName, diceType, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dice10Btn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 10;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewNormalRoll", characterName, diceType, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dice12Btn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 12;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewNormalRoll", characterName, diceType, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dice20Btn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 20;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewNormalRoll", characterName, diceType, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("dice100Btn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 100;
    var modifier = document.getElementById("modifier").value;
    connection.invoke("MakeNewNormalRoll", characterName, diceType, modifier).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("attackTargetBtn").addEventListener("click", function (event) {
    var characterName = document.getElementById("characterName").value;
    var diceType = 20;
    var modifier = document.getElementById("modifier").value;
    var target = document.getElementById("targetSelect").value;
    connection.invoke("MakeNewAttackRoll", characterName, diceType, modifier, target).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});