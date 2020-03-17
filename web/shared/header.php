<?php

$date = new DateTime("now", new DateTimeZone('Europe/Amsterdam') );
$shDate = $date->format('Y-m-d');
$shStart = $date->format('H:i:s');


$closestShift = new Shift("", "", "", "", "");

 // Prepare a select statement
 $sql = "SELECT ID, ShiftDate, StartTime, EndTime, ShiftType
  FROM Shifts WHERE ShiftDate <= ? && StartTime <= ? ORDER BY ShiftDate DESC, StartTime DESC limit 1;";
   

   if($stmt = mysqli_prepare($link, $sql)){
    
    mysqli_stmt_bind_param($stmt, "ss", $shDate, $shStart);
    // Attempt to execute the prepared statement
    if(mysqli_stmt_execute($stmt)){
        
    
        // Store result
        mysqli_stmt_store_result($stmt);
    
               
                mysqli_stmt_bind_result($stmt, $ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);
                $closestShift = new Shift($ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);
    

    }else{
        echo "Oops! Something went wrong. Please try again later.";
    }
    
        // Close statement
        mysqli_stmt_close($stmt);
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
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css">
    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

    <!-- JQuery 3.4.1 CDN -->
    <script src="https://code.jquery.com/jquery-3.4.1.js"  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
  

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
    
    
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js"></script>
    
  

    
    <link rel="stylesheet" href="./css/header-page.css">
    <link rel="stylesheet" href="./css/welcome-page.css">
    
    <title>Header</title>
</head>
<body>

<header>

<nav class="navbar navbar-expand-lg navbar-light bg-light justify-content-between">
  
  <div class="collapse navbar-collapse">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="welcome.php"><i class="fas fa-home"></i> Home</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="details.php"><i class="fas fa-info-circle"></i> Details</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#"> <i class="far fa-money-bill-alt"></i> Payments</a>
      </li>
    </ul>
  </div>
  <a class="nav-link disable closest-link"> Closest:
     <?php if($closestShift !== NULL){
        echo "<b>" . $closestShift->get_ShiftDate()."</b>". ' ' . $closestShift->get_ShiftType(); 
      }?>
    </a>
  <a class="nav-link disable"> Welcome <b><?php echo $_SESSION["fullname"] ?></b></a>
  <a  href="./includes/logout.php" class="btn btn-sm btn-outline-secondary">Sign out <i class="fas fa-sign-out-alt"></i> </a>
</nav>

</header>