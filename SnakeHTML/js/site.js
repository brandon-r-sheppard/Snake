//Main Snake Functions
function moveSnake(snake){
    //Todo: Move Snake Logic

    return snake;
}

$(document).ready(function(){
    //Player variable for use later
    let localplr;

    //renders the login page in the body
    function loginPage(){
        $("#ApplicationContainer").html($("#loginPage").clone());
    }

    //renders the register page in the body
    function registerPage(){
        $("#ApplicationContainer").html($("#registerPage").clone());
    }

    //renders the reset password page in the body
    function resetPasswordPage(){
        $("#ApplicationContainer").html($("#resetPasswordPage").clone());
    }
    //renders the home page in the body
    function homePage(){
        $("#ApplicationContainer").html($("#homePage").clone());
        //Todo: Populate player information div with player from server
    }

    //Calling for the login page to be rendered
    loginPage();
    function logon(){
        let username = $("#loginUsername").val();
        let password = $("#loginPassword").val();
        console.log("Username: " + username + " Password: " + password);
        if(username != "" && password != ""){
            //Statically typed player for testing
            localplr = new Player(1, username, "Boa", 0, 0);

            /*Todo: Connect to server, make sure username/password exists
                    Create player with information from server */
            homePage();
        }
    }

    //Onclick events for the document
    $(document).on("click", "#loginButton", logon);
    $(document).on("click", "#loginRegButton", registerPage);
    $(document).on("click", "#forgotPassword", resetPasswordPage);
    $(document).on("click", "#returnLogin", loginPage);
});