<?php
// Initialize the session
session_start();

// Check if the user is already logged in, if yes then redirect him to welcome page
if (isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === true) {
    header("location: ./views/welcome.php");
    exit;
}

// Handles the authentication 
require './includes/index.inc.php';

?>

<!DOCTYPE html>
<html lang="en">
<head>

    <!-- Includes -->
    <?php require './views/layouts/links.inc.php'  ?>

    <!-- Custom links -->

    <link rel="stylesheet" href="./resources/css/index-page.css">
    <title>Login</title>

</head>

<body>
    <main class="main">

        <!-- particles.js container -->
        <div id="particles-js"></div>


        <div class="overlay"></div>

        <div class="login-container">

            <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post" class="login-form">
                <h1>Login</h1>

                <div class="txtb">
                    <input type="text" name="email" class="<?php echo $focus; ?>" value="<?php echo $email; ?>">
                    <span data-placeholder="Email"></span>
                </div>

                <span class="help-block"><?php echo $email_err; ?></span>

                <div class="txtb <?php echo (!empty($password_err)) ? 'has-error' : ''; ?>">
                    <input type="password" name="password">
                    <span data-placeholder="Password"></span>
                </div>
                <span class="help-block"><?php echo $password_err; ?></span>

                <div class="logbtn-container">
                    <input type="submit" class="logbtn" value="Login">
                </div>

                <div class="bottom-text">
                    Don't have account? <a href="./views/error.php"><i class="fas fa-user-plus"></i></a>
                </div>

            </form>
        </div>

    </main>

    <!-- Scripts -->
    <script type="text/javascript">
        $('.txtb input').on("focus", function() {
            $(this).addClass("focus");
        });

        $('.txtb input').on("blur", function() {
            if ($(this).val() == "")
                $(this).removeClass("focus");
        });
    </script>


    <!-- particles.js lib -->
    <script src="http://cdn.jsdelivr.net/particles.js/2.0.0/particles.min.js"></script>
    <script src="./resources/js/particles.js"></script>

</body>
</html>