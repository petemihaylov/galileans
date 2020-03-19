<?php
// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: index.php");
    exit;
}

?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Wage Statistics</title>

        <!-- Google Fonts -->
        <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">

        <!-- Bootstrap 4.0 CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

        <!-- Font Awesome Icons -->
        <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

        <!-- JQuery 3.4.1 CDN -->
        <script src="https://code.jquery.com/jquery-3.4.1.js"  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>

        <link rel="stylesheet" href="./css/header-page.css">
        <link rel="stylesheet" href="./css/earnings-page.css">
</head>
<body>
    
<!-- Navbar -->
<?php require('./shared/header.php') ?>

<div class="container earnings-container">
        <div class="total-container">
            <div class="money">
                <h4> € </h4>
                <h2>100</h2>
                <h3>00 </h3>
            </div>
            <div class="money-label">
                Total earnings
            </div>
        </div>
        <div class="attendance-container">
            <div class="attendance">
                    <h2>20</h2>
            </div>
            <div class="attendance-label">
                Attended shifts
            </div>
        </div>
</div>

</body>
</html>