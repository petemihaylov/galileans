<?php
// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: ../index.php");
    exit;
}


// Include config file
require_once "../includes/config.inc.php";
 
$fullname = $email = $subject = $message = "";
$fullname_err = $email_err = $subject_err = $message_err = "";
$success_mes = "";

$date = new DateTime("now", new DateTimeZone('Europe/Amsterdam') );
$creationDate = $date->format('Y-m-d');

// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){
     // Check if email is empty
  if(empty(trim($_POST["email"]))){
      $email_err = "* Please enter email.";
  } else{
      $email = trim($_POST["email"]);
  }
  
  // Check if name is empty
  if(empty(trim($_POST["fullname"]))){
      $fullname_err = "* Please enter your name";
      
  } else{
      $fullname = trim($_POST["fullname"]);
  }

  if(empty($name_err) && empty($email_err)){
    
    // Prepare a select statement
    $sql = "INSERT INTO Cancellation(Date, Email, Subject, Message, UserID) values(?,?,?,?,?);";
    
    if($stmt = mysqli_prepare($link, $sql)){
        // Bind variables to the prepared statement as parameters
        mysqli_stmt_bind_param($stmt, "sssss", $creationDate, $_POST['subject'], $_POST["email"] ,$_POST['message'], $_SESSION['id']);
        
        // Attempt to execute the prepared statement
        if(!mysqli_stmt_execute($stmt)){
          echo "Oops! Something went wrong. Please try again later.";
        }else{
            $success_mes = "Successfully submitted!";
        }
      }
            // Close statement
            mysqli_stmt_close($stmt);
    }
    // Close connection
    mysqli_close($link);


}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <!-- Bootstrap 4.0 CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <!-- Custom Stylesheet -->
    <link rel="stylesheet" href="../resources/css/notification-page.css">
    <link rel="stylesheet" href="../resources/css/header-page.css">
    
  
  <title>Notification</title>
</head>
<body>

<!-- Navbar -->
<?php require('header.php') ?>

    <main class="main">
        <div class="notification-container">
            <!-- Header -->
            <h1>Get in touch</h1>
            
            <!-- Notification Form -->
            <form class="form" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post" >
                <!-- Name -->
                <div class="form-group">
                    <input type="name" class="form-control" name="fullname" id="nameInput" value="<?php echo $_SESSION['fullname']?>">
                </div>
                
                <!-- Email address -->
                <div class="form-group">
                    <input type="email" class="form-control" name="email" id="emailInput" aria-describedby="emailHelp" value="<?php echo $_SESSION['email']?>">
                    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                </div>
                
                <!-- Subject -->
                <div class="form-group">
                    <input type="subject" class="form-control" name="subject" id="subjectInput" placeholder="Subject">
                </div>
                <span class="success-message"><?php echo $success_mes; ?></span>
                <!-- Message -->
                <div class="form-group">
                    <textarea class="form-control" placeholder="Message" name="message" id="messageBox" rows="5"></textarea>
                </div>

                <!-- Submit button -->
                <div class="sb-button">

                    <!-- svg image -->
                    <svg xmlns="http://www.w3.org/2000/svg" version="1.1" class="goo">
                      <defs>
                        <filter id="goo">
                          <feGaussianBlur in="SourceGraphic" stdDeviation="10" result="blur" />
                          <feColorMatrix in="blur" mode="matrix" values="1 0 0 0 0  0 1 0 0 0  0 0 1 0 0  0 0 0 19 -9" result="goo" />
                          <feComposite in="SourceGraphic" in2="goo"/>
                        </filter>
                      </defs>
                    </svg>
                    
                    <span class="button--bubble__container">
                      <button type="submit"  class="button button--bubble">
                        Submit message
                      </button>

                      <!-- bubbles-->
                      <span class="button--bubble__effect-container">
                        <span class="circle top-left"></span>
                        <span class="circle top-left"></span>
                        <span class="circle top-left"></span>
                    
                        <span class="button effect-button"></span>
                    
                        <span class="circle bottom-right"></span>
                        <span class="circle bottom-right"></span>
                        <span class="circle bottom-right"></span>
                      </span>

                    </span>
                    </div>
            </form>
        </div>
    </main>

<!-- JQuery 2.1.3 -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/1.17.0/plugins/CSSPlugin.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/1.17.0/easing/EasePack.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/1.17.0/TweenLite.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/latest/TimelineLite.min.js"></script>

<!-- jQuery 3.2.1, then Popper.js, then Bootstrap JS -->
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.11.2/js/all.min.js" integrity="sha256-qM7QTJSlvtPSxVRjVWNM2OfTAz/3k5ovHOKmKXuYMO4=" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

<!-- Optional JavaScript -->
<script src="./resources/js/notification-page.js"></script>
 
</body>
</html>