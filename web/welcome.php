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
require "./models/Shift.php";

$shiftArray = array();

 // Prepare a select statement
 $sql = "SELECT ID, ShiftDate, StartTime, EndTime, ShiftType FROM Shifts Where AssignedEmployeeID = ?";
    if($stmt = mysqli_prepare($link, $sql)){
    
        mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
        
        // Attempt to execute the prepared statement
        if(mysqli_stmt_execute($stmt)){
            // Store result
            mysqli_stmt_store_result($stmt);
            
            $rows = mysqli_stmt_num_rows($stmt);

            for ($i=0; $i < $rows; $i++) { 
                   
                    mysqli_stmt_bind_result($stmt, $ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);
                    
                    if(mysqli_stmt_fetch($stmt)){
                            $shift = new Shift($ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);
                            array_push($shiftArray, $shift);
                    }
                }

        }else{
            echo "Oops! Something went wrong. Please try again later.";
        }
        
    }

// closestShift
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
    
                
                mysqli_stmt_bind_result($stmt, $Id, $shDate, $shStartTime, $shEndTime, $shType);
               
                if(mysqli_stmt_fetch($stmt)){ 
                   $closestShift = new Shift($Id, $shDate, $shStartTime, $shEndTime, $shType);
                }
    

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
  
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js"></script>
    
  

    
    <link rel="stylesheet" href="./css/header-page.css">
    <link rel="stylesheet" href="./css/welcome-page.css">
    
    <title>Welcome</title>
</head>
<body>
<!-- Navbar -->
<?php require('./shared/header.php') ?>

<div class="container next-shift">
    
  <?php if(isset($closestShift)){?>

  <p ><i class="fas fa-forward"></i> Next shift:
     <?php 
        echo "<b>" . $closestShift->get_ShiftType() ."  ". $closestShift->get_ShiftDate()."</b>"; 
      ?>
 </p>

  <?php } ?>

</div>

<div class="container welcome-container">
    <table id="example" class="table table-hover table-dark">
    <thead>
        <tr>
        <th scope="col"></th>
        <th scope="col">Type</th>
        <th scope="col"> Date</th>
        <th scope="col">Start Time</th>
        <th scope="col">End Time</th>
        </tr>
    </thead>

    <tbody>
    <?php for ($i=0; $i < count($shiftArray); $i++) { ?>
        <tr>
        
        <th scope="row"> <?php echo $i+1 ?> </th>
        <td> <?php echo $shiftArray[$i]->get_ShiftType();?></td>
        <td> <?php echo $shiftArray[$i]->get_ShiftDate();?></td>
        <td> <?php echo $shiftArray[$i]->get_StartTime();?></td>
        <td> <?php echo $shiftArray[$i]->get_EndTime();?></td>
        </tr>    

    <?php  }?>
    </tbody>
    
    </table>
</div>
    
<script>
$(document).ready(function() {
    $('#example').DataTable();
} );
</script>

<!-- Footer -->
<?php require('./shared/footer.php') ?>