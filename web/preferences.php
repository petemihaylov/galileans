<?php
// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: index.php");
    exit;
}


// Include config file
require_once "./includes/config.php";
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


    <link rel="stylesheet" href="./css/header-page.css">
    <link rel="stylesheet" href="./css/preferences.css">

    <title>Preferences</title>
</head>
<body>
<!-- Navbar -->
<?php require('./shared/header.php') ?>


<div class="container preferences">
  <?php for($i = 0; $i < 7; $i++){?>
  <div class="row">
    <div class="col-md-1"><span class="badge badge-info badge-pill"><?php echo $i + 10 ?></span></div>
    <div class="col-md-1 ">WED</div>
    <div class="col-md-8">AVAILABLE</div>
    <div class="col-md-2">
    <div class="col-md-2">
      <button type="button" class="btn btn-outline-info"><i class="fas fa-plus"></i></button>
    </div>
    </div>
  </div>
<?php }?>
</div>


</body>
</html>