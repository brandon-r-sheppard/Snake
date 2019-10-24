$(document).ready(function () {
    var SIZE = 800; // Size of the play-field in pixels

    var GRID_SIZE = SIZE / 25; // Size of the tiles the snake or food can populate

    var c = document.getElementById('snakeGame'); //Snake Canvas
    c.height = c.width = SIZE * 2; // 2x our resolution so retina screens look good
    c.style.width = c.style.height = SIZE + 'px'; //Setting the width and height of the canvas render area
    var context = c.getContext('2d'); //Getting the 2d context of our canvas
    context.scale(2, 2); // Scale our canvas for retina screens
    var localPlr; // Variable to hold our local snake object
    var otherPlrs; // Variable to hold the other connected players

    //Snake Object
    function Snake(startX, startY, startDirection) {
        var x = startX;
        var y = startY;
        var direction = newDirection = startDirection;
        var tail = [];
        var length = 3;
        var isAlive = true;

        function init() {
        }
        function move() {
        }
    }
    function restart() {
        //TODO: Start
    }

    //Returns a random value from 0 to the size of the grid (800)
    function randomOffset() {
        return Math.floor(Math.random() * SIZE / GRID_SIZE) * GRID_SIZE;
    }

    //Returns the x and y of the object in readable form
    function stringifyCoord(obj) {
        return [obj.x, obj.y].join(',');
    }

    //Main game functions in here
    function render() {
        context.fillStyle = "#23374d";
        context.fillRect(0, 0, SIZE, SIZE);
    }
        
    //Create signalR connection to /play mapped in the Startup.cs file
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/play")
        .withAutomaticReconnect()
        .build();

    //Start connection
    connection.start().then(function () {
        console.log("Connected");
    });

    connection.on("gameInfo", (message) => {
        alert(message);
    });

    connection.on("playerJoin", (message) => {
        $(".gameInfo").append(`<p>${message}</p>`);
    });

    connection.on("joined", (message) => {
        if (message == "true") {
            //Joined group
            $(".gameInfo").html("");
            $(".gameInfo").html("<h1> Lobby </h1><br/>");
        } else {
            //Could not join group
            alert("hey, couldn't join my guy, try again");
        }
    });
    //Button click to generate new game
    $("#generateGame").click(function () {
        connection.invoke("createGame").catch(error => console.log(error.toString()));
        $(".gameInfo").html("");
        $(".gameInfo").html("<h1> Lobby </h1><br/>");
    });
    $("#joinGame").click(function () {
        connection.invoke("joinGame", $("#gameIdInput").val());
    });
    //Start rendering
    window.onload = function () {
        setInterval(render, 50); // Start game loop
        // When arrow button is clicked
        window.onkeydown = function (e) {
            localPlr.newDirection = { 37: -1, 38: -2, 39: 1, 40: 2 }[e.keyCode] || newDirection;
        };
    };
});