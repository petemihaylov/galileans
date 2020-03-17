<?php
// Initialize the session
session_start();

 
// Check if the user is already logged in, if yes then redirect him to welcome page
if(isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === true){
    header("location: welcome.php");
    exit;
}
 
// Include config file
require_once "./includes/config.php";
 
// Define variables and initialize with empty values
$email = $password = "";
$email_err = $password_err = "";
$focus = "";
$fullname = "";

 
// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){
 
    // Check if email is empty
    if(empty(trim($_POST["email"]))){
        $email_err = "* Please enter email.";
        $focus = "focus";
    } else{
        $email = trim($_POST["email"]);
    }
    
    // Check if password is empty
    if(empty(trim($_POST["password"]))){
        $password_err = "* Please enter your password.";
        $focus = "focus";
    } else{
        $password = trim($_POST["password"]);
    }
    
    // Validate credentials
    if(empty($email_err) && empty($password_err)){
        // Prepare a select statement
        $sql = "SELECT ID, FullName, Email, Password, Role FROM Users WHERE Email = ?";
        
        if($stmt = mysqli_prepare($link, $sql)){
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "s", $param_email);
            
            // Set parameters
            $param_email = $email;
            
            // Attempt to execute the prepared statement
            if(mysqli_stmt_execute($stmt)){
                // Store result
                mysqli_stmt_store_result($stmt);
                
                // Check if email exists, if yes then verify password
                if(mysqli_stmt_num_rows($stmt) == 1){                    
                    // Bind result variables
                    mysqli_stmt_bind_result($stmt, $id, $fullname, $email, $hashed_password, $role);
                    if(mysqli_stmt_fetch($stmt)){
                        if(strtoupper($role) !== "ADMINISTRATOR"){
                            
                        if(password_verify($password, $hashed_password)){
                            // Password is correct, so start a new session
                            session_start();
                            
                            // Store data in session variables
                            $_SESSION["loggedin"] = true;
                            $_SESSION["id"] = $id;
                            $_SESSION["email"] = $email;      
                            $_SESSION["fullname"] = $fullname;                     
                            
                            // Redirect user to welcome page
                            header("location: welcome.php");
                        } else{
                            // Display an error message if password is not valid
                            $password_err = "* The password you entered was not valid.";
                            $focus = "focus";
                        }
                    }else{
                        $email_err = "* Sorry! You are not authorized!";
                        $focus = "focus";
                    }

                    }
                } else{
                    // Display an error message if email doesn't exist
                    $email_err = "* No account found with that email.";
                    $focus = "focus";
                }
            } else{
                echo "Oops! Something went wrong. Please try again later.";
            }

            // Close statement
            mysqli_stmt_close($stmt);
        }
    }
    
    // Close connection
    mysqli_close($link);
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">

    <!-- Bootstrap 4.0 CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

    <!-- JQuery 3.4.1 CDN -->
    <script src="https://code.jquery.com/jquery-3.4.1.js"  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>


    <link rel="stylesheet" href="./css/index-page.css">
    <title>Login</title>
</head>
<body>
    <main class="main">
        <div class="banner">
          <video autoplay muted loop>
              <source src="./css/backgroundVideo.mp4" type="video/mp4">
          </video>
        </div>
        <div class="overlay"></div>

        <div class="login-container">

            <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post" class="login-form">
              <h1>Login</h1>
              
              <div class="txtb">
                <input type="text" name="email" class="<?php echo $focus;?>"  value="<?php echo $email; ?>">
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
                Don't have account? <a href="#"><i class="fas fa-user-plus"></i></a>
              </div>
  
            </form>
        </div>
    </main>
    <script type="text/javascript">
        $('.txtb input').on("focus", function(){
          $(this).addClass("focus");
        });

        $('.txtb input').on("blur", function(){
          if($(this).val() == "")
          $(this).removeClass("focus");
        });
      </script>
</body>
</html>